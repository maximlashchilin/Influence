using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Model
{
  public class Records
  {
    private const int NUM_OF_RECORDS = 5;

    private const string DEFAULT_FILENAME = "Records.txt";

    private List<string> _bestResults;

    public Records()
    {

    }

    private void Initialize()
    {
      _bestResults = new List<string>();
      using (StreamWriter writer = new StreamWriter(DEFAULT_FILENAME, true)) { writer.Close(); }
      using (StreamReader reader = new StreamReader(DEFAULT_FILENAME))
      {
        string result = reader.ReadToEnd();
        string[] lines = result.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

        foreach (string line in lines)
        {
          _bestResults.Add(line);
        }

        reader.Close();
      }

      FilterBestResults(_bestResults);
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
