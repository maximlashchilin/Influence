namespace Model
{
  /// <summary>
  /// Курсор
  /// </summary>
  public class Cursor
  {
    /// <summary>
    /// Объект курсора
    /// </summary>
    private static Cursor _instance;

    /// <summary>
    /// Координата x
    /// </summary>
    private float _x;

    /// <summary>
    /// Координата y
    /// </summary>
    private float _y;

    /// <summary>
    /// Объект синхронизации
    /// </summary>
    private static object _syncObject = new object();

    /// <summary>
    /// Координата x
    /// </summary>
    public float X
    {
      get
      {
        return _x;
      }
    }

    /// <summary>
    /// Координата y
    /// </summary>
    public float Y
    {
      get
      {
        return _y;
      }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parX">Координата X</param>
    /// <param name="parY">Координата Y</param>
    private Cursor(float parX, float parY)
    {
      _x = parX;
      _y = parY;
    }

    /// <summary>
    /// Получает экземпляр курсора
    /// </summary>
    /// <returns>Объект курсора</returns>
    public static Cursor GetInstance()
    {
      if (null == _instance)
      {
        lock (_syncObject)
        {
          if (null == _instance)
          {
            _instance = new Cursor(0.0f, 0.0f);
          }
        }
      }

      return _instance;
    }
    /// <summary>
    /// Изменяет координаты курсора
    /// </summary>
    /// <param name="parX">Координата X</param>
    /// <param name="parY">Координата Y</param>
    public void Move(float parX, float parY)
    {
      _x = parX;
      _y = parY;
    }
  }
}
