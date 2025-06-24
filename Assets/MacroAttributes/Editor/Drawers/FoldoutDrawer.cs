using MacroAttributes.Editor;
using MacroAttributes.Interfaces;
using UnityEditor;
using UnityEngine;

namespace MacroAttributes.Drawers
{
    public class FoldoutDrawer : IAttributeDrawer
    {
        public void BeforeProperty(Rect position, SerializedProperty property, PropertyAttribute attribute, GUIContent label)
        {
            var foldout = (FoldoutAttribute)attribute;

            if (!FoldoutGroupState.IsExpanded(foldout.GroupName))
                return;
        }

        public void AfterProperty(Rect position, SerializedProperty property, PropertyAttribute attribute, GUIContent label)
        {
            
        }

        public float GetAdditionalHeight(SerializedProperty property, PropertyAttribute attribute, GUIContent label)
        {
            var foldout = (FoldoutAttribute)attribute;

            // Only take up space if expanded
            return FoldoutGroupState.IsExpanded(foldout.GroupName) ? 0f : -EditorGUIUtility.singleLineHeight;
        }
    }
}

