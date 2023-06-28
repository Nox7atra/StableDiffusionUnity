using System;
using DevGame.Utility;
using UnityEditor;
using UnityEngine;

namespace DevGame.Editor.StableDiffusion
{
    [CustomPropertyDrawer(typeof(StringArray))]
    public class StringInListDrawer : PropertyDrawer {
        public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) {
            var stringInList = attribute as StringArray;
            var list = stringInList.Strings;
            int index = Mathf.Max (0, Array.IndexOf (list, property.stringValue));
            index = EditorGUI.Popup (position, property.displayName, index, list);
            property.stringValue = list [index];
        }
    }
}