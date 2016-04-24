using System;

namespace SixtenLabs.Spawn
{
	public static class TypeExtensions
	{
		public static bool IsSimpleOrNullableType(this Type type)
		{
			if (type == null) throw new ArgumentNullException("type");

			if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
			{
				type = Nullable.GetUnderlyingType(type);
			}

			return IsSimpleType(type);
		}

		public static bool IsSimpleType(this Type type)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}

			return type.IsPrimitive || type.IsEnum || type == typeof(string) || type == typeof(decimal) || type == typeof(DateTime) || type == typeof(Guid);
		}
	}
}
