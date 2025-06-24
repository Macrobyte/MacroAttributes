using MacroAttributes.Interfaces;
using UnityEditor;
using UnityEngine;

namespace MacroAttributes.Drawers
{
    public class DividerDrawer : IAttributeDrawer
    {
        public void BeforeProperty(Rect position, SerializedProperty property, PropertyAttribute attribute, GUIContent label)
        {
            DividerAttribute divider = (DividerAttribute)attribute;

            if (!ColorUtility.TryParseHtmlString(divider.HexColor, out var color))
            {
                color = Color.gray;
            }

            // Save current color
            Color prevColor = GUI.color;
            GUI.color = color;

            // Draw the divider line
            Rect lineRect = new Rect(position.x, position.y, position.width, divider.Height);
            EditorGUI.DrawRect(lineRect, color);

            // Restore GUI color
            GUI.color = prevColor;
        }

        public void AfterProperty(Rect position, SerializedProperty property, PropertyAttribute attribute, GUIContent label)
        {
            
        }

        public float GetAdditionalHeight(SerializedProperty property, PropertyAttribute attribute, GUIContent label)
        {
            return ((DividerAttribute)attribute).Height + 5;
        }
    }
}

