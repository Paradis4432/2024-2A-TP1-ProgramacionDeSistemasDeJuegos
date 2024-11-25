using System;

namespace Tools.Attributes {
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class IgnoreAttribute : Attribute {
    }
}