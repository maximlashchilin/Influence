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
    /// Текущая платформа
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
    /// <param name="parPlatform">Текущая платформа</param>
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
