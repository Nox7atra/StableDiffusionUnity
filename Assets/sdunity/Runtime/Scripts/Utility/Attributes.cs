using UnityEngine;

namespace DevGame.Utility
{
    public class StringArray : PropertyAttribute
    {
        public string[] Strings;
        public StringArray(string[] strings)
        {
            Strings = strings;
        }
    }
}
