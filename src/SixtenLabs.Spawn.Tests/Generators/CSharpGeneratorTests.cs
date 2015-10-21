using Xunit;
using FluentAssertions;

using Microsoft.CodeAnalysis.CSharp;

using static SixtenLabs.Spawn.Test.OutputStringHelper;

namespace SixtenLabs.Spawn.Test.Generators
{
	public class CSharpGeneratorTests
	{
		#region Generate Enum Tests

		[Fact]
		public void GenerateEnum_CreatesCorrectCode()
		{
			var output = new OutputDefinition("OnMyToast.cs");
			output.AddStandardUsingDirective("System");
			output.AddStandardUsingDirective("System.Linq");
			output.AddNamespace("SixtenLabs.Spawn.GeneratorTest");

			var definition = new EnumDefinition("OnMyToast");
			definition.AddModifier(SyntaxKindX.PublicKeyword);

			definition.AddEnumMember("Error", "0");
			definition.AddEnumMember("Butter", "");
			definition.AddEnumMember("Eggs", "2");
			definition.AddEnumMember("Jam", "4");

			var subject = NewSubject();

			var actual = subject.GenerateEnum(output, definition);

			var expected = $"using System;{NL}using System.Linq;{NL}{NL}namespace SixtenLabs.Spawn.GeneratorTest{NL}{OB}{NL}{I4}public enum OnMyToast : int{NL}{I4}{OB}{NL}{I8}Error = 0,{NL}{I8}Butter,{NL}{I8}Eggs = 2,{NL}{I8}Jam = 4{NL}{I4}{CB}{NL}{CB}";
			actual.Should().Be(expected);
		}

		[Fact]
		public void GenerateEnum_WithoutUsings_CreatesCorrectCode()
		{
			var output = new OutputDefinition("OnMyToast.cs");
			output.AddNamespace("SixtenLabs.Spawn.GeneratorTest");

			var definition = new EnumDefinition("OnMyToast");

			definition.AddModifier(SyntaxKindX.PublicKeyword);

			definition.AddEnumMember("Error", "0");
			definition.AddEnumMember("Butter", "");
			definition.AddEnumMember("Eggs", "2");
			definition.AddEnumMember("Jam", "4");

			var subject = NewSubject();

			var actual = subject.GenerateEnum(output, definition);

			var expected = $"namespace SixtenLabs.Spawn.GeneratorTest{NL}{OB}{NL}{I4}public enum OnMyToast : int{NL}{I4}{OB}{NL}{I8}Error = 0,{NL}{I8}Butter,{NL}{I8}Eggs = 2,{NL}{I8}Jam = 4{NL}{I4}{CB}{NL}{CB}";
			actual.Should().Be(expected);
		}

		[Fact]
		public void GenerateEnum_Flags_CreatesCorrectCode()
		{
			var output = new OutputDefinition("OnMyToast.cs");
			output.AddStandardUsingDirective("System");
			output.AddStandardUsingDirective("System.Linq");
			output.AddNamespace("SixtenLabs.Spawn.GeneratorTest");

			var definition = new EnumDefinition("OnMyToast", hasFlags: true);

			definition.AddModifier(SyntaxKindX.PublicKeyword);

			definition.AddEnumMember("Error", "0");
			definition.AddEnumMember("Butter", "1");
			definition.AddEnumMember("Eggs", "2");
			definition.AddEnumMember("Jam", "4");

			var subject = NewSubject();

			var actual = subject.GenerateEnum(output, definition);

			var expected = $"using System;{NL}using System.Linq;{NL}{NL}namespace SixtenLabs.Spawn.GeneratorTest{NL}{OB}{NL}{I4}[Flags]{NL}{I4}public enum OnMyToast : int{NL}{I4}{OB}{NL}{I8}Error = 0,{NL}{I8}Butter = 1,{NL}{I8}Eggs = 2,{NL}{I8}Jam = 4{NL}{I4}{CB}{NL}{CB}";
			actual.Should().Be(expected);
		}

		#endregion

		#region GenerateClass Tests

		[Fact]
		public void GenerateClass_X_CreatesCorrectCode()
		{
			var output = new OutputDefinition("Delegates.cs");
			output.AddStandardUsingDirective("System");
			output.AddStandardUsingDirective("System.Runtime.InteropServices");
			output.AddNamespace("SixtenLabs.Spawn.GeneratorTest");

			var definition = new ClassDefinition("Delegates");

			definition.AddModifier(SyntaxKindX.InternalKeyword);
			definition.AddModifier(SyntaxKindX.StaticKeyword);
			definition.AddModifier(SyntaxKindX.PartialKeyword);

			var subject = NewSubject();

			var actual = subject.GenerateClass(output, definition);

			var expected = $"using System;{NL}using System.Runtime.InteropServices;{NL}{NL}namespace SixtenLabs.Spawn.GeneratorTest{NL}{OB}{NL}{I4}internal static partial class Delegates{NL}{I4}{OB}{NL}{I4}{CB}{NL}{CB}";
      actual.Should().Be(expected);
		}

    #endregion

    #region Subjects Under Test

    private CSharpGenerator NewSubject()
		{
			return new CSharpGenerator();
		}

		#endregion
	}
}
