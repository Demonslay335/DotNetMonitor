using System;
using System.Linq;

namespace DotNetMonitor
{
    public class CallStruct
    {
        public long ID { get; set; }
        public object Instance { get; set; }
        public DateTime Time { get; set; }
        public TimeSpan TimeOfDay { get => Time.TimeOfDay; }
        public int Ticks { get; set; }
        public string ModuleName { get => Instance != null ? Instance.GetType().Name : ""; }
        public string ModuleFullName { get => Instance != null ? Instance.GetType().FullName : ""; }
        public int HashCode { get => Instance != null ? Instance.GetHashCode() : -1; }
        public string MethodName { get; set; }
        public ParameterInfoWithValue Return { get => parameters?.FirstOrDefault(p => p.Name == "__result"); }
        public object ReturnValue { get => Return?.Value; }
        public string ReturnPrototype { get => Return?.ToString(); }
        public string MethodPrototype { get => MethodName + "(" + string.Join(", ", parameters.Where(p => !p.Name.StartsWith("__")).Select(p => p.ToString())) + ")"; }

        public ParameterInfoWithValue[] Parameters { get => parameters.Where(p => !p.Name.StartsWith("__") || p.Name == "__result").ToArray(); set => parameters = value; }

        private ParameterInfoWithValue[] parameters;

        public string ToCsv()
        {
            return string.Join(";", new string[]
            {
                HashCode.ToString(),
                ModuleFullName,
                MethodName,
                string.Join(",", parameters?.Select(p => {
                    if (p?.ParameterType == MainForm.Types.ByteArray || p?.ParameterType == MainForm.Types.ByteArrayRef)
                    {
                        return p?.ToString() + " = " + ((byte[])p?.Value)?.ToHexString();
                    }
                    return p?.ToString() + " = " + p?.Value?.ToString();
                })),
                Return?.ParameterType == MainForm.Types.ByteArray || Return?.ParameterType == MainForm.Types.ByteArrayRef ? ((byte[])Return?.Value)?.ToHexString() : Return?.Value?.ToString()
            });
        }
    }
}
