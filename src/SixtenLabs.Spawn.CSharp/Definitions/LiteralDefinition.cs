using System;

namespace SixtenLabs.Spawn.CSharp
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
