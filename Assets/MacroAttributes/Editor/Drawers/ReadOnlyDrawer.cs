
using MacroAttributes.Interfaces;
using UnityEditor;
using UnityEngine;


namespace MacroAttributes.Drawers
{
    public class ReadOnlyDrawer : IAttributeDrawer
    {
        public void BeforeProperty(Rect position, SerializedProperty property, PropertyAttribute attribute, GUIContent label)
        {
            GUI.enabled = false;
        }

        public void AfterProperty(Rect position, SerializedProperty property, PropertyAttribute attribute, GUIContent label)
        {
            GUI.enabled = true;
        }

        public float GetAdditionalHeight(SerializedProperty property, PropertyAttribute attribute, GUIContent label)
        {
            return 0f;
        }
    }
}

