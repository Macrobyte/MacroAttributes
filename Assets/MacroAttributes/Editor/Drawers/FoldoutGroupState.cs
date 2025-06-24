using System.Collections.Generic;

namespace MacroAttributes.Editor
{
    /// <summary>
    /// Static class that stores foldout states globally per group name using a static dictionary.
    /// </summary>
    public static class FoldoutGroupState
    {
        private static readonly Dictionary<string, bool> state = new();

        public static bool IsExpanded(string key)
        {
            if (!state.TryGetValue(key, out var expanded))
            {
                state[key] = true; // Default to expand.
            }

            return state[key];
        }

        public static void SetExpanded(string key, bool expanded)
        {
            state[key] = expanded;
        }
    }
}


