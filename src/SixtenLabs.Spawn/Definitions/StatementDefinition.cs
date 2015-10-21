using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixtenLabs.Spawn
{
	/// <summary>
	/// Define a statement to generate.
	/// 
	/// A statement can consist of a single line of code that ends in a semicolon, or a series of single-line statements in a block.
	/// A statement block is enclosed in {} brackets and can contain nested blocks.
	/// 
	/// For now it is just a simple string formated by you.
	/// 
	/// TODO: explore a more detailed definition that assists in creating a statement
	///   declaration
	///   expression
	///   selection
	///   iteration
	///   jump
	///   exception handling
	///   checked and unchecked
	///   await
	///   yield
	///   fixed
	///   lock
	///   labeled
	///   empty
	///   embedded
	///   nested
	/// </summary>
	public class StatementDefinition : Definition
	{
		#region Constructors

		public StatementDefinition(string name, string code)
			: base(name)
		{
			Code = code;
		}

		#endregion

		#region Properties

		public string Code { get; }

		#endregion
	}
}
