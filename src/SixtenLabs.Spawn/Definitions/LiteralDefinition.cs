using System;

namespace SixtenLabs.Spawn
{
  public class LiteralDefinition : Definition
  {
    public LiteralDefinition(object value, Type literalType)
			: base(value.ToString())
		{
      Value = value;
      LiteralType = literalType;
    }

    public object Value { get; }

    public Type LiteralType { get; }
  }
}
