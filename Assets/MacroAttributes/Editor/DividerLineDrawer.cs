using UnityEditor;
using MacroAttributes;
using UnityEngine;

namespace MacroAttributes.Editor
{
#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(DividerAttribute))]
    public class DividerDrawer : DecoratorDrawer
    {
        public override void OnGUI(Rect position)
        {
            //DividerAttribute dividerAttribute = (DividerAttribute)attribute;

            // Save original color
            Color oldColor = GUI.color;

            // Set color and draw line
        
            EditorGUI.DrawRect(new Rect(position.x, position.y + 10, position.width, 2), Color.grey);

            // Reset color
            GUI.color = oldColor;
        }

        public override float GetHeight()
        {
        
            return EditorGUIUtility.singleLineHeight;
        }
    }
#endif
}

