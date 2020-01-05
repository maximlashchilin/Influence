using System;
using System.Collections.Generic;
using System.IO;

namespace Model
{
  public class Helper
  {
    public event dPaintHandler PaintEvent;

    private const string HELP_FILE = "Help.txt";

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
      _helpText = ReadTextFromFile(HELP_FILE);

      PaintEvent?.Invoke();
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
