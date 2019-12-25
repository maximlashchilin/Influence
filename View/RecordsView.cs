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
      float delta = 10.0f;

      Platform.Clear();
      for (int i = 0; i < _records.BestResults.Count; i++)
      {
        Platform.PrintText(40.0f, 5.0f + (i * delta), _records.BestResults[i]);
      }
    }
  }
}
