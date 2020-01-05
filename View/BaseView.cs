namespace View
{
  /// <summary>
  /// Базовое представление
  /// </summary>
  public abstract class BaseView
  {
    /// <summary>
    /// Объект платформы
    /// </summary>
    private Platform _platform;

    /// <summary>
    /// Объект платформы
    /// </summary>
    public Platform Platform
    {
      get
      {
        return _platform;
      }
    }

    /// <summary>
    /// Конструктор базового представления
    /// </summary>
    /// <param name="parPlatform">Объект платформы</param>
    public BaseView(Platform parPlatform)
    {
      _platform = parPlatform;
    }

    /// <summary>
    /// Отрисовывает представление
    /// </summary>
    public abstract void Draw();
  }
}
