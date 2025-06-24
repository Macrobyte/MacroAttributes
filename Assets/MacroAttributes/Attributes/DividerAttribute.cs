using UnityEngine;

namespace MacroAttributes
{
    public class DividerAttribute : PropertyAttribute
    {
        public readonly float Height;
        public readonly string HexColor;
        
        public DividerAttribute(string hexColor = "#808080", float height = 5f)
        {
            Height = height;
            HexColor = hexColor;
        }
    }
}