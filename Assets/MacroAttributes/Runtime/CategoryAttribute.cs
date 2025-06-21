using UnityEngine;

namespace MacroAttributes
{
#if UNITY_EDITOR
    public class CategoryAttribute : PropertyAttribute
    {
        public string label;
        public TextAnchor textAnchor;

        public CategoryAttribute(string categoryLabel, TextAnchor textAnchor)
        {
            this.label = categoryLabel;
            this.textAnchor = textAnchor;

        }
    }
#endif
    
}