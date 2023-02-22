using System.Reflection;

namespace DotNetMonitor
{
    public class OverridableApi
    {
        public bool Enabled { get; set; }
        public string Name { get; }
        public string FullName { get; }
        public bool IsOverridable { get; }

        public OverridableApi(MethodBase methodBase, bool enabled = true)
        {
            Name = methodBase.DeclaringType.Name + "." + methodBase.Name;
            FullName = methodBase.DeclaringType.FullName + "." + methodBase.Name;
            Enabled = enabled;
        }
    }
}