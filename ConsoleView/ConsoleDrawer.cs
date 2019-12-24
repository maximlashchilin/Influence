using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace ConsoleView
{
  public class ConsoleDrawer
  {
    private SafeFileHandle _handle;

    private CharInfo[] _buffer;

    private int _bufferCursor;

    private SmallRect _rect;

    private short _width;

    private short _height;

    [DllImport("kernel32.dll")]
    private static extern bool SetConsoleOutputCP(uint wCodePageID);

    [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    static extern SafeFileHandle CreateFile(
        string fileName,
        [MarshalAs(UnmanagedType.U4)] uint fileAccess,
        [MarshalAs(UnmanagedType.U4)] uint fileShare,
        IntPtr securityAttributes,
        [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition,
        [MarshalAs(UnmanagedType.U4)] int flags,
        IntPtr template);

    [DllImport("kernel32.dll", EntryPoint = "WriteConsoleOutput", CharSet = CharSet.Unicode, SetLastError = true)]
    static extern bool WriteConsoleOutput(
      SafeFileHandle hConsoleOutput,
      CharInfo[] lpBuffer,
      Coord dwBufferSize,
      Coord dwBufferCoord,
      ref SmallRect lpWriteRegion);

    [StructLayout(LayoutKind.Sequential)]
    public struct Coord
    {
      public short X;
      public short Y;

      public Coord(short X, short Y)
      {
        this.X = X;
        this.Y = Y;
      }
    };

    [StructLayout(LayoutKind.Explicit)]
    public struct CharUnion
    {
      [FieldOffset(0)] public char UnicodeChar;
      [FieldOffset(0)] public byte AsciiChar;
    }

    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public struct CharInfo
    {
      [FieldOffset(0)] public CharUnion Char;
      [FieldOffset(2)] public short Attributes;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SmallRect
    {
      public short Left;
      public short Top;
      public short Right;
      public short Bottom;
    }

    public ConsoleDrawer(short parWidth, short parHeight)
    {
      _width = parWidth;
      _height = parHeight;
      _bufferCursor = 0;
      //SetConsoleOutputCP((uint)1251);
      Console.OutputEncoding = UTF8Encoding.UTF8;
      _handle = CreateFile("CONOUT$", 0x40000000, 2, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero);
      if (!_handle.IsInvalid)
      {
        _buffer = new CharInfo[_width * _height];
        _rect = new SmallRect() { Left = 0, Top = 0, Right = _width, Bottom = _height };
      }
    }

    public void Draw()
    {
      //if (!_handle.IsInvalid)
      //{
        bool b = WriteConsoleOutput(_handle, _buffer,
              new Coord() { X = _width, Y = _height },
              new Coord() { X = 0, Y = 0 },
              ref _rect);
      //}
    }

    public void WriteInBuffer(string parText)
    {
      for (int i = 0; i < parText.Length; i++)
      {
        _buffer[_bufferCursor].Attributes = 15;
        _buffer[_bufferCursor].Char.UnicodeChar = parText[i];
        _bufferCursor++;
      }
    }

    public void SetBufferCursor(short parX, short parY)
    {
      //if (parX * _width + parY < _buffer.Length)
      //{
        _bufferCursor = parX + parY * _width;
      //}
    }
  }
}
