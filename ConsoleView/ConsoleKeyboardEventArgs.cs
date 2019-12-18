using System;

namespace ConsoleView
{
  /// <summary>
  /// Параметры события нажатия клавиши в консоле
  /// </summary>
  public class ConsoleKeyboardEventArgs : EventArgs
  {
    /// <summary>
    /// Признак нажатия клавиши
    /// </summary>
    private bool _keyDown;

    /// <summary>
    /// Цифровой код клавиши
    /// </summary>
    private int _virtualKeyCode;

    /// <summary>
    /// Признак нажатия клавиши
    /// </summary>
    public bool KeyDown
    {
      get
      {
        return _keyDown;
      }
    }

    /// <summary>
    /// Цифровой код клавиши
    /// </summary>
    public int VirtualKeyCode
    {
      get
      {
        return _virtualKeyCode;
      }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parKeyDown">Признак нажатия клавиши</param>
    /// <param name="parVirtualKeyCode">Цифровой код клавиши</param>
    public ConsoleKeyboardEventArgs(bool parKeyDown, int parVirtualKeyCode)
    {
      _keyDown = parKeyDown;
      _virtualKeyCode = parVirtualKeyCode;
    }
  }
}
