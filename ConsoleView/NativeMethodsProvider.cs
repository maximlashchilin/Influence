using System;
using Microsoft.Win32.SafeHandles;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ConsoleView
{
  /// <summary>
  /// Провайдер нативных методов
  /// для работы с WinAPI
  /// </summary>
  public class NativeMethodsProvider
  {
    /// <summary>
    /// 
    /// </summary>
    public const Int32 STD_INPUT_HANDLE = -10;

    /// <summary>
    /// 
    /// </summary>
    public const Int32 ENABLE_MOUSE_INPUT = 0x0010;

    /// <summary>
    /// 
    /// </summary>
    public const Int32 ENABLE_QUICK_EDIT_MODE = 0x0040;

    /// <summary>
    /// 
    /// </summary>
    public const Int32 ENABLE_EXTENDED_FLAGS = 0x0080;

    /// <summary>
    /// 
    /// </summary>
    public const Int32 KEY_EVENT = 1;

    /// <summary>
    /// 
    /// </summary>
    public const Int32 MOUSE_EVENT = 2;

    /// <summary>
    /// 
    /// </summary>
    [DebuggerDisplay("EventType: {EventType}")]
    [StructLayout(LayoutKind.Explicit)]
    public struct INPUT_RECORD
    {
      [FieldOffset(0)]
      public Int16 EventType;
      [FieldOffset(4)]
      public KEY_EVENT_RECORD KeyEvent;
      [FieldOffset(4)]
      public MOUSE_EVENT_RECORD MouseEvent;
    }

    /// <summary>
    /// 
    /// </summary>
    [DebuggerDisplay("{dwMousePosition.X}, {dwMousePosition.Y}")]
    public struct MOUSE_EVENT_RECORD
    {
      public COORD dwMousePosition;
      public Int32 dwButtonState;
      public Int32 dwControlKeyState;
      public Int32 dwEventFlags;
    }

    /// <summary>
    /// 
    /// </summary>
    [DebuggerDisplay("{X}, {Y}")]
    public struct COORD
    {
      public UInt16 X;
      public UInt16 Y;
    }

    /// <summary>
    /// 
    /// </summary>
    [DebuggerDisplay("KeyCode: {wVirtualKeyCode}")]
    [StructLayout(LayoutKind.Explicit)]
    public struct KEY_EVENT_RECORD
    {
      [FieldOffset(0)]
      [MarshalAsAttribute(UnmanagedType.Bool)]
      public Boolean bKeyDown;
      [FieldOffset(4)]
      public UInt16 wRepeatCount;
      [FieldOffset(6)]
      public UInt16 wVirtualKeyCode;
      [FieldOffset(8)]
      public UInt16 wVirtualScanCode;
      [FieldOffset(10)]
      public Char UnicodeChar;
      [FieldOffset(10)]
      public Byte AsciiChar;
      [FieldOffset(12)]
      public Int32 dwControlKeyState;
    };

    /// <summary>
    /// 
    /// </summary>
    public class ConsoleHandle : SafeHandleMinusOneIsInvalid
    {
      public ConsoleHandle() : base(false) { }

      protected override bool ReleaseHandle()
      {
        return true;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="hConsoleHandle"></param>
    /// <param name="lpMode"></param>
    /// <returns></returns>
    [DllImportAttribute("kernel32.dll", SetLastError = true)]
    [return: MarshalAsAttribute(UnmanagedType.Bool)]
    public static extern Boolean GetConsoleMode(ConsoleHandle hConsoleHandle, ref Int32 lpMode);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="nStdHandle"></param>
    /// <returns></returns>
    [DllImportAttribute("kernel32.dll", SetLastError = true)]
    public static extern ConsoleHandle GetStdHandle(Int32 nStdHandle);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="hConsoleInput"></param>
    /// <param name="lpBuffer"></param>
    /// <param name="nLength"></param>
    /// <param name="lpNumberOfEventsRead"></param>
    /// <returns></returns>
    [DllImportAttribute("kernel32.dll", SetLastError = true)]
    [return: MarshalAsAttribute(UnmanagedType.Bool)]
    public static extern Boolean ReadConsoleInput(ConsoleHandle hConsoleInput, ref INPUT_RECORD lpBuffer, UInt32 nLength, ref UInt32 lpNumberOfEventsRead);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="hConsoleHandle"></param>
    /// <param name="dwMode"></param>
    /// <returns></returns>
    [DllImportAttribute("kernel32.dll", SetLastError = true)]
    [return: MarshalAsAttribute(UnmanagedType.Bool)]
    public static extern Boolean SetConsoleMode(ConsoleHandle hConsoleHandle, Int32 dwMode);
  }
}
