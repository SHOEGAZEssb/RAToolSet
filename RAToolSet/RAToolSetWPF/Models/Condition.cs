using System.ComponentModel;
namespace RAToolSetWPF
{
  /// <summary>
  /// Type of an operand.
  /// </summary>
  enum MemType
  {
    /// <summary>
    /// Specifies that this operand is a memory address.
    /// </summary>
    Mem,

    /// <summary>
    /// Specifies that this operand is a delta memory address.
    /// </summary>
    Delta,

    /// <summary>
    /// Specifies that this operand is a value.
    /// </summary>
    Value
  }

  /// <summary>
  /// The size of an operand.
  /// </summary>
  enum Size
  {
    EightBit,
    SixteenBit,
    //ThirtyTwoBit,
    Bit0,
    Bit1,
    Bit2,
    Bit3,
    Bit4,
    Bit5,
    Bit6,
    Bit7,
    Lower4,
    Upper4
  }

  /// <summary>
  /// The comparer between the two operands of this condition.
  /// </summary>
  enum Comparer
  {
    Equal,
    Smaller,
    SmallerEqual,
    Bigger,
    BiggerEqual,
    NotEqual
  }

  /// <summary>
  /// Represents a single condition of a leaderboard.
  /// </summary>
  class Condition
  {
    private MemType _operand1Type;
    private Size _operand1Size;
    private string _operand1;

    private Comparer _comparer;

    private MemType _operand2Type;
    private Size _operand2Size;
    private string _operand2;

    /// <summary>
    /// The <see cref="MemType"/> of the first operand.
    /// </summary>
    public MemType Type1
    {
      get { return _operand1Type; }
      set { _operand1Type = value; }
    }

    /// <summary>
    /// The <see cref="Size"/> of the first operand.
    /// </summary>
    public Size Size1
    {
      get { return _operand1Size; }
      set { _operand1Size = value; }
    }

    /// <summary>
    /// The memory string of the first operand.
    /// </summary>
    public string Mem1
    {
      get { return _operand1; }
      set 
      {
        if (Type1 != MemType.Value && !value.StartsWith("0x"))
          _operand1 = "0x" + value;
        else
          _operand1 = value;
      }
    }

    /// <summary>
    /// The comparer
    /// </summary>
    public Comparer Cmp
    {
      get { return _comparer; }
      set { _comparer = value; }
    }

    /// <summary>
    /// The <see cref="MemType"/> of the second operand.
    /// </summary>
    public MemType Type2
    {
      get { return _operand2Type; }
      set { _operand2Type = value; }
    }

    /// <summary>
    /// The <see cref="Size"/> of the second operand.
    /// </summary>
    public Size Size2
    {
      get { return _operand2Size; }
      set { _operand2Size = value; }
    }

    /// <summary>
    /// The memory string of the second operand.
    /// </summary>
    public string Mem2
    {
      get { return _operand2; }
      set 
      {
        if (Type2 != MemType.Value && !value.StartsWith("0x"))
          _operand2 = "0x" + value;
        else
          _operand2 = value; 
      }
    }
  }
}