using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MacroAttributes.Editor
{
    using UnityEditor;
    using UnityEngine;

    public abstract class MacroAttributesEditor<T> : Editor where T : Object
    {
        /// <summary>
        /// Entry point for drawing the custom inspector UI.
        /// Updates the serialized object, retrieves all properties, organizes them into foldout groups and draws each property or group in the original order, applying any foldout logic.
        /// Also applies modified properties.
        /// </summary>
        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            var allProperties = GetAllProperties();
            var foldoutGroups = BuildFoldoutGroups(allProperties);
            var drawnFoldoutGroups = new HashSet<string>();

            foreach (var prop in allProperties)
            {
                if (prop.name == "m_Script")
                {
                    DrawScriptField(prop);
                    continue;
                }

                var field = GetFieldForProperty(prop);
                if (field == null)
                {
                    DrawProperty(prop);
                    continue;
                }

                var foldoutAttr = GetFoldoutAttribute(field);
                if (foldoutAttr != null)
                {
                    DrawFoldoutGroupIfNeeded(foldoutAttr.GroupName, foldoutGroups, drawnFoldoutGroups);
                }
                else
                {
                    DrawProperty(prop);
                }
            }

            serializedObject.ApplyModifiedProperties();
        }
        
        /// <summary>
        /// Scans all properties to find those marked with the custom FoldoutAttribute.
        /// Groups these properties by their foldout group name into a dictionary, enabling grouped drawing under foldout headers.
        /// </summary>
        /// <param name="allProperties"></param>
        /// <returns></returns>
        protected virtual Dictionary<string, List<SerializedProperty>> BuildFoldoutGroups(
            List<SerializedProperty> allProperties)
        {
            var groups = new Dictionary<string, List<SerializedProperty>>();

            foreach (var prop in allProperties)
            {
                var field = GetFieldForProperty(prop);
                if (field == null) continue;

                var foldoutAttr = GetFoldoutAttribute(field);
                if (foldoutAttr != null)
                {
                    if (!groups.ContainsKey(foldoutAttr.GroupName))
                        groups[foldoutAttr.GroupName] = new List<SerializedProperty>();

                    groups[foldoutAttr.GroupName].Add(prop);
                }
            }

            return groups;
        }

        /// <summary>
        /// Uses reflection to find the underlying FieldInfo of a serialized property by matching the property name to the target object's fields (public or private).
        /// </summary>
        /// <param name="prop"></param>
        /// <returns></returns>
        protected virtual FieldInfo GetFieldForProperty(SerializedProperty prop)
        {
            return target.GetType().GetField(prop.name,
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
        }

        /// <summary>
        /// Retrieves the custom FoldoutAttribute from a given field via reflection if it exists. Returns null if the attribute is not present.
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        protected virtual FoldoutAttribute GetFoldoutAttribute(FieldInfo field)
        {
            return field.GetCustomAttribute<FoldoutAttribute>();
        }

        /// <summary>
        /// Draws the default disabled Unity script reference field (m_Script), preventing edits to the script reference in the inspector.
        /// </summary>
        /// <param name="scriptProperty"></param>
        protected virtual void DrawScriptField(SerializedProperty scriptProperty)
        {
            EditorGUI.BeginDisabledGroup(true);
            EditorGUILayout.PropertyField(scriptProperty, true);
            EditorGUI.EndDisabledGroup();
        }

        /// <summary>
        /// Manages drawing a foldout group header and its associated properties.
        /// Ensures each foldout group is only drawn once, maintains foldout expanded state, indents properties inside the group, and skips if the group was already drawn.
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="foldoutGroups"></param>
        /// <param name="drawnFoldoutGroups"></param>
        protected virtual void DrawFoldoutGroupIfNeeded(string groupName,
            Dictionary<string, List<SerializedProperty>> foldoutGroups,
            HashSet<string> drawnFoldoutGroups)
        {
            if (drawnFoldoutGroups.Contains(groupName)) return;

            bool expanded = FoldoutGroupState.IsExpanded(groupName);
            expanded = EditorGUILayout.Foldout(expanded, groupName, true);
            FoldoutGroupState.SetExpanded(groupName, expanded);
            drawnFoldoutGroups.Add(groupName);

            if (expanded)
            {
                EditorGUI.indentLevel++;
                foreach (var prop in foldoutGroups[groupName])
                {
                    DrawProperty(prop);
                }

                EditorGUI.indentLevel--;
            }
        }

        /// <summary>
        /// Handles drawing an individual property in the inspector, including all extra attribute drawers.
        /// </summary>
        /// <param name="property"></param>
        protected virtual void DrawProperty(SerializedProperty property)
        {
            var field = GetFieldForProperty(property);
            if (field == null)
            {
                EditorGUILayout.HelpBox($"No field found for '{property.name}'", MessageType.Warning);
                return;
            }

            var attributes = field.GetCustomAttributes<PropertyAttribute>(true).ToArray();

            float propertyHeight = EditorGUI.GetPropertyHeight(property, true);
            float extraHeight = attributes.Sum(attr =>
            {
                var drawer = AttributeDrawerRegistry.GetDrawer(attr.GetType());
                return drawer?.GetAdditionalHeight(property, attr, new GUIContent(property.displayName)) ?? 0f;
            });

            Rect totalRect = EditorGUILayout.GetControlRect(false, propertyHeight + extraHeight);
            Rect currentRect = new Rect(totalRect.x, totalRect.y, totalRect.width, 0);

            foreach (var attr in attributes)
            {
                var drawer = AttributeDrawerRegistry.GetDrawer(attr.GetType());
                if (drawer == null) continue;

                float h = drawer.GetAdditionalHeight(property, attr, new GUIContent(property.displayName));
                currentRect.height = h;
                drawer.BeforeProperty(currentRect, property, attr, new GUIContent(property.displayName));
                currentRect.y += h;
            }

            currentRect.height = propertyHeight;
            EditorGUI.PropertyField(currentRect, property, new GUIContent(property.displayName), true);
            currentRect.y += propertyHeight;

            foreach (var attr in attributes)
            {
                var drawer = AttributeDrawerRegistry.GetDrawer(attr.GetType());
                if (drawer == null) continue;

                float h = drawer.GetAdditionalHeight(property, attr, new GUIContent(property.displayName));
                currentRect.height = h;
                drawer.AfterProperty(currentRect, property, attr, new GUIContent(property.displayName));
                currentRect.y += h;
            }
        }

        #region Helper Methods

        /// <summary>
        /// Collects and returns a list of all visible serialized properties on the target object in their natural serialized order. Uses Unity’s SerializedProperty iterator to capture every property.
        /// </summary>
        /// <returns></returns>
        private List<SerializedProperty> GetAllProperties()
        {
            var iterator = serializedObject.GetIterator();
            var properties = new List<SerializedProperty>();
            bool enterChildren = true;

            while (iterator.NextVisible(enterChildren))
            {
                enterChildren = false;
                properties.Add(iterator.Copy());
            }

            return properties;
        }

        #endregion
    }
}