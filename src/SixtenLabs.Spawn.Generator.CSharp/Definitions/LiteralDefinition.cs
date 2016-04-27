using System;

namespace SixtenLabs.Spawn.Generator.CSharp
{
  public class LiteralDefinition : Definition
  {
    public LiteralDefinition()
		{
    }

    public string Value { get; set; }

    public Type LiteralType { get; set; }
  }
}
