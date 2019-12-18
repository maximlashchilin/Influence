using System;

namespace ConsoleView
{
  /// <summary>
  /// Параметры события работы с мышью в консоле
  /// </summary>
  public class ConsoleMouseEventArgs : EventArgs
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
    /// Состояние клавиши мыши
    /// </summary>
    private int _buttonState;

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
    /// Состояние клавиши мыши
    /// </summary>
    public int ButtonState
    {
      get
      {
        return _buttonState;
      }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parX">Координата X</param>
    /// <param name="parY">Координата Y</param>
    /// <param name="parButtonState">Состояние клавиши мыши</param>
    public ConsoleMouseEventArgs(float parX, float parY, int parButtonState)
    {
      _x = parX;
      _y = parY;
      _buttonState = parButtonState;
    }
  }
}
