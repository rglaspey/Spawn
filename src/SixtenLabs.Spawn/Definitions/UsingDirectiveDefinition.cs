using System;

namespace SixtenLabs.Spawn
{
	/// <summary>
	/// Define a Using Directive.
	/// 
	/// There are three types of Using Directives in C#
	/// 
	/// Standard: To allow the use of types in a namespace so that you do not have to qualify the use of a type in that namespace:
	///   using System.Text;
	/// 
	/// Static: To allow you to access static members of a type without having to qualify the access with the type name:
	///   using static System.Math;
	/// 
	/// Alias: To create an alias for a namespace or a type. This is called a using alias directive.
	///   using Project = PC.MyCompany.Project;
	/// 
	/// </summary>
	public class UsingDirectiveDefinition : Definition
	{
		#region Constructors

		/// <summary>
		/// Use this constructor to create a standard or static using directive definition
		/// </summary>
		/// <param name="dllName">The name of the dll to create a using directive for</param>
		/// <param name="isStatic">Should this be a static using directive</param>
		public UsingDirectiveDefinition(string dllName, bool isStatic = false)
      : base(dllName)
    {
			IsStatic = isStatic;
		}

		/// <summary>
		/// Use this constructor to create an aliased using directive.
		/// </summary>
		/// <param name="dllName">The name of the dll to create a using directive for</param>
		/// <param name="alias">The alias to use in the using directive</param>
		public UsingDirectiveDefinition(string dllName, string alias)
			: base(dllName)
		{
			if (string.IsNullOrEmpty(alias))
			{
				throw new ArgumentNullException("You cannot have a null or empty alias. Pass in correct alias value or use the non alias constructor.");
			}
			else
			{
				Alias = alias;
				UseAlias = true;
			}
		}

		#endregion

		#region Properties

		/// <summary>
		/// Is this a static using directive?
		/// </summary>
		public bool IsStatic { get; }

		/// <summary>
		/// Is this an aliased using directive?
		/// </summary>
		public bool UseAlias { get; }

		/// <summary>
		/// The alias to use in the using directive
		/// </summary>
		public string Alias { get; }

		#endregion
	}
}
