using UnityEngine;

namespace MacroAttributes
{
    public class FoldoutAttribute : PropertyAttribute
    {
        public readonly string GroupName;
        public readonly string Label;
        
        public FoldoutAttribute(string groupName, string label = null )
        {
            GroupName = groupName;
            Label = label ?? groupName;
        }
    }
}

