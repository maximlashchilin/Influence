using Model;

namespace View
{
  /// <summary>
  /// Представление рекордов
  /// </summary>
  public class RecordsView : BaseView
  {
    /// <summary>
    /// Объект рекордов
    /// </summary>
    private Records _records;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parPlatform">Объект платформы</param>
    /// <param name="parRecords">Объект рекордов</param>
    public RecordsView(Platform parPlatform, Records parRecords) : base(parPlatform)
    {
      _records = parRecords;

      _records.PaintEvent += Draw;
    }

    /// <summary>
    /// Отрисовывает представление рекордов
    /// </summary>
    public override void Draw()
    {
      const float DELTA = 10.0f;
      const float X = 40.0f;
      const float Y = 15.0f;
      const string HEAD_STRING = "Best game results";
      Platform.Clear();
      Platform.PrintText(X, Y, HEAD_STRING);
      for (int i = 0; i < _records.BestResults.Count; i++)
      {
        Platform.PrintText(X, Y + 20 + (i * DELTA), _records.BestResults[i]);
      }
    }
  }
}
