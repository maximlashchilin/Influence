using System;
using System.Collections.Generic;
using System.IO;

namespace Model
{
  public class Records
  {
    public event dPaintHandler PaintEvent;

    private const int NUM_OF_RECORDS = 5;

    private const string DEFAULT_FILENAME = "Records.txt";

    private List<string> _bestResults;

    public List<string> BestResults
    {
      get
      {
        return _bestResults;
      }
      set
      {
        _bestResults = value;
      }
    }

    public void Initialize()
    {
      _bestResults = ReadTextFromFile(DEFAULT_FILENAME);

      FilterBestResults(_bestResults);

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

    private void FilterBestResults(List<string> parRecords)
    {
      parRecords.Sort();
      parRecords.Reverse();
      while (parRecords.Count > NUM_OF_RECORDS)
      {
        parRecords.RemoveAt(0);
      }
    }
  }
}
