using UnityEditor;
using MacroAttributes;
using UnityEngine;

namespace MacroAttributes.Editor
{
#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(DividerAttribute))]
    public class DividerDrawer : DecoratorDrawer
    {
        private float dividerHeight = 0f;
        
        public override void OnGUI(Rect position)
        {
            DividerAttribute dividerAttribute = (DividerAttribute)attribute;

            dividerHeight = dividerAttribute.Height;
            
            // Parse hex color
            Color lineColor = Color.grey;
            if (ColorUtility.TryParseHtmlString(dividerAttribute.HexColor, out var parsed))
            {
                lineColor = parsed;
            }
            
            // Save original color
            Color oldColor = GUI.color;

            // Set color and draw line
            EditorGUI.DrawRect(new Rect(position.x, position.y + 10, position.width, dividerHeight), lineColor);

            // Reset color
            GUI.color = oldColor;
        }

        public override float GetHeight()
        {
            return EditorGUIUtility.singleLineHeight + dividerHeight;
        }
    }
#endif
}

