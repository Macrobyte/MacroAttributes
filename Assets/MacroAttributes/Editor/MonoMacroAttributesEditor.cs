using UnityEditor;
using UnityEngine;

namespace MacroAttributes.Editor
{
    [CustomEditor(typeof(MonoBehaviour),true)]
    [CanEditMultipleObjects]
    public class MonoMacroAttributesEditor : MacroAttributesEditor<MonoBehaviour> {}
}

