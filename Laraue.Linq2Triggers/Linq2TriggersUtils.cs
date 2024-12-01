using System;

namespace Laraue.Linq2Triggers
{
    /// <summary>
    /// Helper methods.
    /// </summary>
    public static class Linq2TriggersUtils
    {
        /// <summary>
        /// Get underlying type if it is nullable or return this type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Type GetNotNullableType(Type type)
        {
            var nullableUnderlyingType = Nullable.GetUnderlyingType(type);
        
            return nullableUnderlyingType ?? type;
        }
    }
}