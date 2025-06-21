using UnityEditor;
using MacroAttributes;
using UnityEngine;

namespace MacroAttributes.Editor
{
    [CustomPropertyDrawer(typeof(SectionHeaderAttribute))]
    public class SectionHeaderDrawer : DecoratorDrawer
    {
        public override void OnGUI(Rect position)
        {
            SectionHeaderAttribute sectionHeader = (SectionHeaderAttribute)attribute;

            // Styling
            GUIStyle style = new GUIStyle(GUI.skin.label);
            style.alignment = sectionHeader.TextAnchor;
            style.fontStyle = FontStyle.Bold;
            style.fontSize = sectionHeader.FontSize;

            // Draw the category label
            EditorGUI.LabelField(position, sectionHeader.Label, style);
        }

        public override float GetHeight()
        {
            return EditorGUIUtility.singleLineHeight + 10;
        }
    }
}

