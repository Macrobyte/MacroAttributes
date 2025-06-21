using UnityEngine;

namespace MacroAttributes
{
    public class DividerAttribute : PropertyAttribute
    {
        public readonly float Height;
        public readonly string HexColor;
        
        public DividerAttribute(float height = 5f, string hexColor = "#808080")
        {
            Height = height;
            HexColor = hexColor;
        }
    }
}