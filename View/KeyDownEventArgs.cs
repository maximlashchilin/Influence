using System;

namespace View
{
  /// <summary>
  /// Параметры события нажатия клавиши
  /// </summary>
  public class KeyDownEventArgs : EventArgs
  {
    /// <summary>
    /// Введённый символ
    /// </summary>
    private char _inputChar;

    /// <summary>
    /// Введённый символ
    /// </summary>
    public char InputChar
    {
      get
      {
        return _inputChar;
      }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parInputedChar">Введенный символ</param>
    public KeyDownEventArgs(char parInputedChar)
    {
      _inputChar = parInputedChar;
    }
  }
}
