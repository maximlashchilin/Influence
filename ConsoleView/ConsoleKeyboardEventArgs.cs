using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleView
{
  /// <summary>
  /// 
  /// </summary>
  public class ConsoleKeyboardEventArgs : EventArgs
  {
    /// <summary>
    /// 
    /// </summary>
    private bool _keyDown;

    /// <summary>
    /// 
    /// </summary>
    private int _virtualKeyCode;

    /// <summary>
    /// 
    /// </summary>
    public bool KeyDown
    {
      get
      {
        return _keyDown;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    public int VirtualKeyCode
    {
      get
      {
        return _virtualKeyCode;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="parKeyDown"></param>
    /// <param name="parVirtualKeyCode"></param>
    public ConsoleKeyboardEventArgs(bool parKeyDown, int parVirtualKeyCode)
    {
      _keyDown = parKeyDown;
      _virtualKeyCode = parVirtualKeyCode;
    }
  }
}
