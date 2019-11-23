namespace View
{
  /// <summary>
  /// Базовое представление
  /// </summary>
  public abstract class BaseView
  {
    /// <summary>
    /// Текущая платформа
    /// </summary>
    private Platform _platform;

    /// <summary>
    /// Конструктор базового представления
    /// </summary>
    /// <param name="parPlatform">Текущая платформа</param>
    public BaseView(Platform parPlatform)
    {
      _platform = parPlatform;
    }

    /// <summary>
    /// Метод рисования
    /// </summary>
    public abstract void Draw();
  }
}
