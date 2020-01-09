using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace Model
{
  /// <summary>
  /// Справка
  /// </summary>
  public class Helper
  {
    /// <summary>
    /// Событие перерисовки
    /// </summary>
    public event dPaintHandler PaintEvent;

    /// <summary>
    /// Имя файла
    /// </summary>
    private const string HELP_FILE = "Help.txt";

    /// <summary>
    /// 
    /// </summary>
    private List<string> _helpText;

    public List<string> HelpText
    {
      get
      {
        return _helpText;
      }
    }

    public void Initialize()
    {
      string text = Resource.Help;
      //_helpText = ReadTextFromFile(HELP_FILE);
      _helpText = SplitOnStrings(text);
      PaintEvent?.Invoke();
    }

    private List<string> SplitOnStrings(string parText)
    {
      string[] strings = parText.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
     
      return strings.ToList<string>();
    }

    private List<string> ReadTextFromFile(string parFileName)
    {
      List<string> result = new List<string>();
      using (StreamWriter writer = new StreamWriter(parFileName, true)) { writer.Close(); }
      using (StreamReader reader = new StreamReader(parFileName))
      {
        string currentString = reader.ReadToEnd();
        string[] lines = currentString.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

        foreach (string line in lines)
        {
          result.Add(line);
        }

        reader.Close();
      };

      return result;
    }
  }
}
