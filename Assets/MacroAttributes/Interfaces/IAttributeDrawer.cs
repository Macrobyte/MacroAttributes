using UnityEditor;
using UnityEngine;

namespace MacroAttributes.Interfaces
{
    /// <summary>
    /// Interface for custom attribute drawers.
    /// This allows injecting UI logic before and after a property is drawn, as well as controlling height.
    /// </summary>
    public interface IAttributeDrawer
    {
        /// <summary>
        /// Called before the property field is drawn.
        /// Used to render custom UI elements above or around the property field.
        /// </summary>
        /// <param name="position">The rectangle in which to draw the property</param>
        /// <param name="property">The serialized property being drawn</param>
        /// <param name="attribute">The attribute instance associated with this drawer</param>
        /// <param name="label">The label of the property</param>
        void BeforeProperty(Rect position, SerializedProperty property, PropertyAttribute attribute, GUIContent label);
        
        /// <summary>
        /// Called after the property field is drawn.
        /// Useful for rendering UI elements below or next to the property.
        /// </summary>
        /// <param name="position">The rectangle in which the property was drawn</param>
        /// <param name="property">The serialized property that was drawn</param>
        /// <param name="attribute">The attribute instance associated with this drawer</param>
        /// <param name="label">The label of the property</param>
        void AfterProperty(Rect position, SerializedProperty property, PropertyAttribute attribute, GUIContent label);
        
        /// <summary>
        /// Returns the extra height that should be added to the property's layout to accommodate any custom UI drawn in BeforeProperty or AfterProperty.
        /// </summary>
        /// <param name="property">The serialized property being drawn</param>
        /// <param name="attribute">The attribute instance associated with this drawer</param>
        /// <param name="label">The label of the property</param>
        /// <returns>Height in pixels to add to the property's layout</returns>
        float GetAdditionalHeight(SerializedProperty property, PropertyAttribute attribute, GUIContent label);
    }
}

