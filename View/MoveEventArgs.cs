using System;

namespace View
{
  /// <summary>
  /// Параметры события перемещения курсора мыши
  /// </summary>
  public class MoveEventArgs : EventArgs
  {
    /// <summary>
    /// Координата X
    /// </summary>
    private float _x;

    /// <summary>
    /// Координата Y
    /// </summary>
    private float _y;

    /// <summary>
    /// Координата X
    /// </summary>
    public float X
    {
      get
      {
        return _x;
      }
    }

    /// <summary>
    /// Координата Y
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
    public MoveEventArgs(float parX, float parY)
    {
      _x = parX;
      _y = parY;
    }
  }
}
