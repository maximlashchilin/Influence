using System;
using System.Collections.Generic;
using System.IO;

namespace Model
{
  /// <summary>
  /// Отвечает за просмотр рекордов
  /// </summary>
  public class Records
  {
    /// <summary>
    /// Событие перерисовки
    /// </summary>
    public event dPaintHandler PaintEvent;

    /// <summary>
    /// Число выводимых результатов
    /// </summary>
    private const int NUM_OF_RECORDS = 5;

    /// <summary>
    /// Имя файла
    /// </summary>
    private const string DEFAULT_FILENAME = "Records.txt";

    /// <summary>
    /// Список результатов
    /// </summary>
    private List<string> _bestResults;

    /// <summary>
    /// Список результатов
    /// </summary>
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

    /// <summary>
    /// Инициализирует просмотре рекордов
    /// </summary>
    public void Initialize()
    {
      _bestResults = ReadTextFromFile(DEFAULT_FILENAME);

      FilterBestResults(_bestResults);

      PaintEvent?.Invoke();
    }

    /// <summary>
    /// Читает текст из файла
    /// </summary>
    /// <param name="parFileName">Имя файла</param>
    /// <returns>Список строк</returns>
    private List<string> ReadTextFromFile(string parFileName)
    {
      List<string> result = new List<string>();
      //using (StreamWriter writer = new StreamWriter(parFileName, true)) { writer.Close(); }
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

    /// <summary>
    /// Фильтрует результаты
    /// </summary>
    /// <param name="parRecords">Список результатов</param>
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
