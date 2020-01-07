using System;
using System.Collections.Generic;
using System.IO;

namespace Model
{
  /// <summary>
  /// Отвечает за запись результата игры в файл
  /// </summary>
  public class RecordsWriter
  {
    /// <summary>
    /// Имя файла
    /// </summary>
    private const string DEFAULT_FILENAME = "Records.txt";

    /// <summary>
    /// Записывает результат игрока
    /// </summary>
    /// <param name="parPlayer">Объект игрока</param>
    public void RecordResult(Player parPlayer)
    {
      using (StreamWriter writer = new StreamWriter(DEFAULT_FILENAME, true))
      {
        string record = parPlayer.Name + " " + parPlayer.Score;
        writer.WriteLine(record);
      }
    }
  }
}
