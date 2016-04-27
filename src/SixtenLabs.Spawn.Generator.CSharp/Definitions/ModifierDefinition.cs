using Microsoft.CodeAnalysis.CSharp;

namespace SixtenLabs.Spawn.Generator.CSharp
{
	/// <summary>
	/// Modifiers are used to modify declarations of types and type members
	/// 
	/// Access Modifiers
	///   public
	///   private
	///   internal
	///   protected
	/// 
	/// Other Modifiers
	///   abstract
	///   async
	///   const
	///   event
	///   extern
	///   in
	///   out
	///   new
	///   override
	///   partial
	///   readonly
	///   sealed
	///   static
	///   unsafe
	///   virtual
	///   volatile
	/// 
	/// </summary>
	public class ModifierDefinition : Definition
	{
		/// <summary>
		/// Use this constructor to create a modifier definition
		/// </summary>
		/// <param name="modifier">The SyntaxKind to create a modifier for</param>
		public ModifierDefinition()
    {
		}

		public SyntaxKindDto Modifier { get; set; }
	}
}
