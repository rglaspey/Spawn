using System;

namespace SixtenLabs.Spawn
{
  public class LiteralDefinition : Definition
  {
    #region Constructors

    public LiteralDefinition(object value, Type literalType)
			: base(value.ToString())
		{
      Value = value;
      LiteralType = literalType;
    }

    #endregion

    #region Properties

    public object Value { get; }

    public Type LiteralType { get; }

    #endregion
  }
}
