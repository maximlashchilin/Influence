using System;

namespace ConsoleView
{
  /// <summary>
  /// 
  /// </summary>
  public class ConsoleMouseEventArgs : EventArgs
  {
    /// <summary>
    /// 
    /// </summary>
    private float _x;

    /// <summary>
    /// 
    /// </summary>
    private float _y;

    /// <summary>
    /// 
    /// </summary>
    private int _buttonState;

    /// <summary>
    /// 
    /// </summary>
    public float X
    {
      get
      {
        return _x;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    public float Y
    {
      get
      {
        return _y;
      }
    }

    public int ButtonState
    {
      get
      {
        return _buttonState;
      }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="parX"></param>
    /// <param name="parY"></param>
    public ConsoleMouseEventArgs(float parX, float parY, int parButtonState)
    {
      _x = parX;
      _y = parY;
      _buttonState = parButtonState;
    }
  }
}
