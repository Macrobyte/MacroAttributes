using MacroAttributes;
using UnityEditor;
using UnityEngine;

namespace MacroAttributes.Drawers
{
    using Interfaces;
    
    public class SectionHeaderDrawer : IAttributeDrawer
    {
        public void BeforeProperty(Rect position, SerializedProperty property, PropertyAttribute attribute, GUIContent label)
        {
            SectionHeaderAttribute header = (SectionHeaderAttribute)attribute;

            // Spacing above the property
            position.y += 5f;
            
            // Create a custom label style
            GUIStyle style = new GUIStyle(EditorStyles.boldLabel)
            {
                alignment = header.TextAnchor,
                fontSize = header.FontSize
            };

            Rect headerRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
            EditorGUI.LabelField(headerRect, header.Label, style);
        }

        public void AfterProperty(Rect position, SerializedProperty property, PropertyAttribute attribute, GUIContent label)
        {
            
        }

        public float GetAdditionalHeight(SerializedProperty property, PropertyAttribute attribute, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight + 10;
        }
    }
}

