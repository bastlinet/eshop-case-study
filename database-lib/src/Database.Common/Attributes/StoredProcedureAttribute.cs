using System;

namespace Database.Common.Attributes
{
    /// <summary>
    /// Name of called stored procedures
    /// </summary>
    public class StoredProcedureAttribute : Attribute
    {
        public string Value { get; set; }

        public StoredProcedureAttribute(string value)
        {
            Value = value;
        }
    }
}
