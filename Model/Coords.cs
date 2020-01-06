namespace Model
{
  /// <summary>
  /// Координаты ячейки в массиве
  /// </summary>
  public class Coords
  {
    /// <summary>
    /// Индекс ряда
    /// </summary>
    private int _i;

    /// <summary>
    /// Индекс колонки
    /// </summary>
    private int _j;

    /// <summary>
    /// Индекс ряда
    /// </summary>
    public int I
    {
      get
      {
        return _i;
      }
      set
      {
        _i = value;
      }
    }

    /// <summary>
    /// Индекс колонки
    /// </summary>
    public int J
    {
      get
      {
        return _j;
      }
      set
      {
        _j = value;
      }
    }
  }
}
