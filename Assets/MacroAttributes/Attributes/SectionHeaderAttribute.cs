using UnityEngine;

namespace MacroAttributes
{
    public class SectionHeaderAttribute : PropertyAttribute
    {
        public readonly string Label;
        public readonly TextAnchor TextAnchor;
        public readonly int FontSize;

        public SectionHeaderAttribute(string categoryLabel, TextAnchor textAnchor = TextAnchor.MiddleLeft, int fontSize = 15)
        {
            this.Label = categoryLabel;
            this.TextAnchor = textAnchor;
            this.FontSize = fontSize;

        }
    }
}