using System;
using System.Collections.Generic;
using System.Reflection;

namespace DotNetMonitor
{
    public class ParameterInfoWithValue
    {
        public object Value { get; }
        public string String;

        // Stupid read-only properties...
        public int Position { get; }
        public ParameterAttributes Attributes { get; }
        public MemberInfo Member { get; }
        public bool IsIn { get; }
        public bool IsRetval { get; }
        public bool IsLcid { get; }
        public object RawDefaultValue { get; }
        public bool IsOptional { get; }
        public bool IsOut { get; }
        public object DefaultValue { get; }
        public IEnumerable<CustomAttributeData> CustomAttributes { get; }
        public string Name { get; }
        public Type ParameterType { get; }
        public int MetadataToken { get; }
        public bool HasDefaultValue { get; }

        public override string ToString() => String;

        public ParameterInfoWithValue(ParameterInfo p, object value)
        {
            Position = p.Position;
            Attributes = p.Attributes;
            Member = p.Member;
            IsIn = p.IsIn;
            IsRetval = p.IsRetval;
            IsLcid = p.IsLcid;
            RawDefaultValue = p.RawDefaultValue;
            IsOptional = p.IsOptional;
            IsOut = p.IsOut;
            DefaultValue = p.DefaultValue;
            CustomAttributes = p.CustomAttributes;
            Name = p.Name;
            ParameterType = p.ParameterType;
            MetadataToken = p.MetadataToken;
            HasDefaultValue = p.HasDefaultValue;

            String = p.ToString();
            Value = value;
        }
    }
}
