using System;

namespace ReflectionDemo
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public class AuditAttribute : Attribute
    {
        public string Message {get;}
        public AuditAttribute(string msg) {Message=msg;}
    }
}
