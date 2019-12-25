using System;

namespace View
{
  public class KeyDownEventArgs : EventArgs
  {
    private char _inputChar;

    public char InputChar
    {
      get
      {
        return _inputChar;
      }
    }

    public KeyDownEventArgs(char parInputedChar)
    {
      _inputChar = parInputedChar;
    }
  }
}
