

using System.Reflection;

namespace Utility
{
    public class Common
    {
        
        public static PropertyInfo[] GetProperties(object obj)
        {
            return obj.GetType().GetProperties();
        }
    }
}
