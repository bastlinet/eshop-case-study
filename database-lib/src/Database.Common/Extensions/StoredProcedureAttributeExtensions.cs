using System.Reflection;
using System.Runtime.CompilerServices;

namespace Database.Common.Attributes
{
    /// <summary>
    /// Extensions for stored procedure attribute
    /// </summary>
    public static class StoredProcedureAttributeExtensions
    {
        /// <summary>
        /// Return value of [StoredProcedure] attribute which is used in service.
        /// </summary>
        /// <typeparam name="T">type of service</typeparam>
        /// <param name="service">service</param>
        /// <param name="member">name of method</param>
        /// <returns>value in attribute</returns>
        public static string ProcedureName<T>(this T service, [CallerMemberName] string member = null)
        {
            MethodBase method = service.GetType().GetMethod(member) != null ? service.GetType().GetMethod(member) :
                service.GetType().GetMethod(member, BindingFlags.Instance | BindingFlags.NonPublic);
            var attrs = method.GetCustomAttributes(typeof(StoredProcedureAttribute), true);
            StoredProcedureAttribute attr = attrs.Length > 0 ? (StoredProcedureAttribute)attrs[0] : null;
            return attr?.Value;
        }
    }
}
