using System;
using UnityEditor;

namespace Unity.SelectionGroups
{
    [AttributeUsage(AttributeTargets.Method)]
    public class SelectionGroupToolAttribute : Attribute
    {
        public string icon;
        public string text;
        public string description;
        public readonly string toolId;

        public SelectionGroupToolAttribute(string icon, string text, string description)
        {
            this.icon = icon;
            this.text = text;
            this.description = description;
            this.toolId = $"{icon}.{text}.{description}";
        }
    }
}