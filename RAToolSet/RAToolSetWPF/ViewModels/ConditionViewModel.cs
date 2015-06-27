using Caliburn.Micro;
using System;
using System.Collections.ObjectModel;

namespace RAToolSetWPF
{
  /// <summary>
  /// Represents the view model for the leaderboard maker.
  /// </summary>
  class ConditionViewModel : PropertyChangedBase
  {
    private ObservableCollection<Condition> _startConditions;
    private ObservableCollection<Condition> _cancelConditions;
    private ObservableCollection<Condition> _submitConditions;
    private Condition _selectedStartCondition;
    private Condition _selectedCancelCondition;
    private Condition _selectedSubmitCondition;
    private string _startConditionsOutputText;
    private string _cancelConditionsOutputText;
    private string _submitConditionsOutputText;
    private int _selectedTabControlIndex;

    /// <summary>
    /// Gets/sets the start conditions.
    /// </summary>
    public ObservableCollection<Condition> StartConditions
    {
      get { return _startConditions; }
      private set { _startConditions = value; }
    }

    /// <summary>
    /// Gets/sets the cancel conditions.
    /// </summary>
    public ObservableCollection<Condition> CancelConditions
    {
      get { return _cancelConditions; }
      private set { _cancelConditions = value; }
    }

    /// <summary>
    /// Gets/sets the submit conditions.
    /// </summary>
    public ObservableCollection<Condition> SubmitConditions
    {
      get { return _submitConditions; }
      private set { _submitConditions = value; }
    }

    /// <summary>
    /// Gets/sets the selected start condition.
    /// </summary>
    public Condition SelectedStartCondition
    {
      get { return _selectedStartCondition; }
      set
      {
        _selectedStartCondition = value;
        NotifyOfPropertyChange(() => CanRemoveCondition);
      }
    }

    /// <summary>
    /// Gets/sets the selected cancel condition.
    /// </summary>
    public Condition SelectedCancelCondition
    {
      get { return _selectedCancelCondition; }
      set
      {
        _selectedCancelCondition = value;
        NotifyOfPropertyChange(() => CanRemoveCondition);
      }
    }

    /// <summary>
    /// Gets/sets the selected submit condition.
    /// </summary>
    public Condition SelectedSubmitCondition
    {
      get { return _selectedSubmitCondition; }
      set
      {
        _selectedSubmitCondition = value;
        NotifyOfPropertyChange(() => CanRemoveCondition);
      }
    }

    /// <summary>
    /// The output text of the start conditions.
    /// </summary>
    public string StartConditionsOutputText
    {
      get { return _startConditionsOutputText; }
      private set
      {
        _startConditionsOutputText = value;
        NotifyOfPropertyChange(() => StartConditionsOutputText);
      }
    }

    /// <summary>
    /// The output text of the cancel conditions.
    /// </summary>
    public string CancelConditionsOutputText
    {
      get { return _cancelConditionsOutputText; }
      private set
      {
        _cancelConditionsOutputText = value;
        NotifyOfPropertyChange(() => CancelConditionsOutputText);
      }
    }

    /// <summary>
    /// The output text of the submit conditions.
    /// </summary>
    public string SubmitConditionsOutputText
    {
      get { return _submitConditionsOutputText; }
      private set
      {
        _submitConditionsOutputText = value;
        NotifyOfPropertyChange(() => StartConditionsOutputText);
      }
    }

    /// <summary>
    /// Gets/sets the index for the currently selected tabPage.
    /// </summary>
    public int SelectedTabControlIndex
    {
      get { return _selectedTabControlIndex; }
      set
      {
        _selectedTabControlIndex = value;
        NotifyOfPropertyChange(() => CanRemoveCondition);
        NotifyOfPropertyChange(() => SelectedTabControlIndex);
      }
    }

    /// <summary>
    /// Gets if the user can remove a condition from the currently selected tabPage.
    /// </summary>
    public bool CanRemoveCondition
    {
      get
      {
        if (SelectedTabControlIndex == 0 && SelectedStartCondition != null)
          return true;
        else if (SelectedTabControlIndex == 1 && SelectedCancelCondition != null)
          return true;
        else if (SelectedTabControlIndex == 2 && SelectedSubmitCondition != null)
          return true;
        else
          return false;
      }
    }

    /// <summary>
    /// Gets if the user can generate output text for the current conditions.
    /// </summary>
    public bool CanGenerate
    {
      get { return StartConditions.Count + CancelConditions.Count + SubmitConditions.Count >= 1; }
    }

    /// <summary>
    /// Ctor.
    /// </summary>
    public ConditionViewModel()
    {
      _startConditions = new ObservableCollection<Condition>();
      _cancelConditions = new ObservableCollection<Condition>();
      _submitConditions = new ObservableCollection<Condition>();
    }

    /// <summary>
    /// Adds a new condition to the selected tabPage.
    /// </summary>
    public void AddCondition()
    {
      if (SelectedTabControlIndex == 0)
        StartConditions.Add(new Condition());
      else if (SelectedTabControlIndex == 1)
        CancelConditions.Add(new Condition());
      else
        SubmitConditions.Add(new Condition());

      NotifyOfPropertyChange(() => CanRemoveCondition);
      NotifyOfPropertyChange(() => CanGenerate);
    }

    /// <summary>
    /// Removes the currently selected condition on the currently selected tabPage.
    /// </summary>
    public void RemoveCondition()
    {
      if (SelectedTabControlIndex == 0 && SelectedStartCondition != null)
        StartConditions.Remove(SelectedStartCondition);
      else if (SelectedTabControlIndex == 1 && SelectedCancelCondition != null)
        CancelConditions.Remove(SelectedCancelCondition);
      else if (SelectedTabControlIndex == 2 && SelectedSubmitCondition != null)
        SubmitConditions.Remove(SelectedSubmitCondition);

      NotifyOfPropertyChange(() => CanRemoveCondition);
      NotifyOfPropertyChange(() => CanGenerate);
    }

    /// <summary>
    /// Generates the output strings for all condition sets.
    /// </summary>
    public void GenerateOutput()
    {
      StartConditionsOutputText = Generate(StartConditions);
      CancelConditionsOutputText = Generate(CancelConditions);
      SubmitConditionsOutputText = Generate(SubmitConditions);

      SelectedTabControlIndex = 3;
    }

    /// <summary>
    /// Generates the output set for the given <paramref name="conditions"/>.
    /// </summary>
    /// <param name="conditions">Conditions to generate output string from.</param>
    /// <returns>Output string</returns>
    private string Generate(ObservableCollection<Condition> conditions)
    {
      try
      {
        string outString = "";

        for (int i = 0; i < conditions.Count; i++)
        {
          string mem1 = "";

          if (conditions[i].Type1 == MemType.Delta)
          {
            mem1 += "d";
          }

          mem1 += conditions[i].Mem1.Replace("0x", GetStringToReplaceBySize(conditions[i].Size1));
          mem1 += GetStringByComp(conditions[i].Cmp);

          string mem2 = "";

          if (conditions[i].Type2 == MemType.Delta)
          {
            mem2 += "d";
          }

          mem2 += conditions[i].Mem2.Replace("0x", GetStringToReplaceBySize(conditions[i].Size2));

          outString += (mem1 + mem2);

          if (i != conditions.Count - 1)
            outString += "_";
        }

        return outString;
      }
      catch(Exception ex)
      {
        return "ERROR, CHECK YOUR SYNTAX. ERROR MESSAGE: " + ex.Message;
      }
    }

    /// <summary>
    /// Gets the corresponding string for the given <paramref name="size"/>
    /// </summary>
    /// <param name="size">Size to get string for.</param>
    /// <returns>String of the size.</returns>
    private string GetStringToReplaceBySize(Size size)
    {
      if (size == Size.Bit0)
        return "0xM";
      else if (size == Size.Bit1)
        return "0xN";
      else if (size == Size.Bit2)
        return "0xO";
      else if (size == Size.Bit3)
        return "0xP";
      else if (size == Size.Bit4)
        return "0xQ";
      else if (size == Size.Bit5)
        return "0xR";
      else if (size == Size.Bit6)
        return "0xS";
      else if (size == Size.Bit7)
        return "0xT";
      else if (size == Size.Lower4)
        return "0xL";
      else if (size == Size.Upper4)
        return "0xU";
      else if (size == Size.EightBit)
        return "0xH";
      else
        return "0x";
    }

    /// <summary>
    /// Gets the corresponding string for the given <paramref name="cmp"/>
    /// </summary>
    /// <param name="cmp">Comparer to get string for.</param>
    /// <returns>String of the comparer.</returns>
    private string GetStringByComp(Comparer cmp)
    {
      if (cmp == Comparer.Bigger)
        return ">";
      else if (cmp == Comparer.BiggerEqual)
        return ">=";
      else if (cmp == Comparer.Equal)
        return "=";
      else if (cmp == Comparer.NotEqual)
        return "!=";
      else if (cmp == Comparer.Smaller)
        return "<";
      else
        return "<=";
    }
  }
}