using System;
using System.Collections.Generic;
using UnityEngine;

namespace MacroAttributes.Editor
{
    using Interfaces;
    using Drawers;
    
    public static class AttributeDrawerRegistry
    {
        private static readonly Dictionary<Type, IAttributeDrawer> Drawers = new();
        
        /// <summary>
        /// Register drawers to their respective attributes here.
        /// </summary>
        static AttributeDrawerRegistry()
        {
            RegisterDrawer<SectionHeaderAttribute>(new SectionHeaderDrawer());
            RegisterDrawer<DividerAttribute>(new DividerDrawer());
            RegisterDrawer<ReadOnlyAttribute>(new ReadOnlyDrawer());
            RegisterDrawer<FoldoutAttribute>(new FoldoutDrawer());
            
        }
        
        /// <summary>
        /// Registers a drawer for a specific PropertyAttribute type.
        /// Adds the drawer to the 'drawers' dictionary, keyed by the attribute type.
        /// </summary>
        /// <param name="drawer">The drawer instance that handles rendering for the attribute</param>
        /// <typeparam name="T">The PropertyAttribute type to associate with this drawer</typeparam>
        public static void RegisterDrawer<T>(IAttributeDrawer drawer) where T : PropertyAttribute
        {
            Drawers[typeof(T)] = drawer;
        }

        /// <summary>
        /// Returns the drawer associated with a specific PropertyAttribute type.
        /// </summary>
        /// <param name="attributeType">The PropertyAttribute type to look up</param>
        /// <returns>The registered IAttributeDrawer for the given type, or null if none is registered</returns>
        public static IAttributeDrawer GetDrawer(Type attributeType)
        {
            Drawers.TryGetValue(attributeType, out var drawer);
            return drawer;
        }
    }
}


