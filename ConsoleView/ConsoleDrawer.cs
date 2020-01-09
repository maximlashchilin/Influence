using System;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace ConsoleView
{
  /// <summary>
  /// Отвечает за двойную буферизацию
  /// </summary>
  public class ConsoleDrawer
  {
    /// <summary>
    /// Объект дескриптора файла
    /// </summary>
    private SafeFileHandle _handle;

    /// <summary>
    /// Буфер
    /// </summary>
    private CharInfo[] _buffer;

    /// <summary>
    /// Область перерисовки
    /// </summary>
    private SmallRect _rect;

    /// <summary>
    /// Курсор буфера
    /// </summary>
    private int _bufferCursor;

    /// <summary>
    /// Ширина буфера
    /// </summary>
    private short _width;

    /// <summary>
    /// Высота буфера
    /// </summary>
    private short _height;

    /// <summary>
    /// Устанавливает кодовую страницу вывода
    /// </summary>
    /// <param name="wCodePageID">Идентификатор кодовой страницы</param>
    /// <returns>Код ошибки</returns>
    [DllImport("kernel32.dll")]
    private static extern bool SetConsoleOutputCP(uint wCodePageID);

    /// <summary>
    /// Создает файл
    /// </summary>
    /// <param name="fileName">Имя файла</param>
    /// <param name="fileAccess">Флаг доступа</param>
    /// <param name="fileShare">Совместный доступ</param>
    /// <param name="securityAttributes">Дескриптор защиты</param>
    /// <param name="creationDisposition">Выполняемое действие</param>
    /// <param name="flags">Аттрибуты файла</param>
    /// <param name="template">Дескриптор файла шаблона</param>
    /// <returns></returns>
    [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    static extern SafeFileHandle CreateFile(
        string fileName,
        [MarshalAs(UnmanagedType.U4)] uint fileAccess,
        [MarshalAs(UnmanagedType.U4)] uint fileShare,
        IntPtr securityAttributes,
        [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition,
        [MarshalAs(UnmanagedType.U4)] int flags,
        IntPtr template);

    /// <summary>
    /// Выводит в консоль
    /// </summary>
    /// <param name="hConsoleOutput">Дескриптор файла</param>
    /// <param name="lpBuffer">Буфер</param>
    /// <param name="dwBufferSize">Размер буфера</param>
    /// <param name="dwBufferCoord">Начальные координаты</param>
    /// <param name="lpWriteRegion">Область отрисовки</param>
    /// <returns></returns>
    [DllImport("kernel32.dll", EntryPoint = "WriteConsoleOutput", CharSet = CharSet.Unicode, SetLastError = true)]
    static extern bool WriteConsoleOutput(
      SafeFileHandle hConsoleOutput,
      CharInfo[] lpBuffer,
      Coord dwBufferSize,
      Coord dwBufferCoord,
      ref SmallRect lpWriteRegion);

    /// <summary>
    /// Координаты
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Coord
    {
      /// <summary>
      /// Координата X
      /// </summary>
      public short X;
      /// <summary>
      /// Координата Y
      /// </summary>
      public short Y;

      /// <summary>
      /// Конструктор
      /// </summary>
      /// <param name="X">Координата X</param>
      /// <param name="Y">Координата Y</param>
      public Coord(short X, short Y)
      {
        this.X = X;
        this.Y = Y;
      }
    };

    /// <summary>
    /// Символ
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct CharUnion
    {
      /// <summary>
      /// Символ Unicode
      /// </summary>
      [FieldOffset(0)] public char UnicodeChar;
      /// <summary>
      /// Символ ASCII
      /// </summary>
      [FieldOffset(0)] public byte AsciiChar;
    }

    /// <summary>
    /// Информация о символе
    /// </summary>
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public struct CharInfo
    {
      /// <summary>
      /// Символьный код
      /// </summary>
      [FieldOffset(0)] public CharUnion Char;
      /// <summary>
      /// Аттрибуты
      /// </summary>
      [FieldOffset(2)] public short Attributes;
    }

    /// <summary>
    /// Прямоугольник отрисовки
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SmallRect
    {
      /// <summary>
      /// Левая координата
      /// </summary>
      public short Left;
      /// <summary>
      /// Верхняя координата
      /// </summary>
      public short Top;
      /// <summary>
      /// Правая координата
      /// </summary>
      public short Right;
      /// <summary>
      /// Нижняя координата
      /// </summary>
      public short Bottom;
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parWidth">Ширина буфера</param>
    /// <param name="parHeight">Высота буфера</param>
    public ConsoleDrawer(short parWidth, short parHeight)
    {
      _width = parWidth;
      _height = parHeight;
      _bufferCursor = 0;
      SetConsoleOutputCP((uint)1251);
      _handle = CreateFile("CONOUT$", 0x40000000, 2, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero);
      if (!_handle.IsInvalid)
      {
        _buffer = new CharInfo[_width * _height];
        _rect = new SmallRect() { Left = 0, Top = 0, Right = _width, Bottom = _height };
      }
    }

    /// <summary>
    /// Выводит содержимое буфера на консоль
    /// </summary>
    public void Draw()
    {
      if (!_handle.IsInvalid)
      {
        bool b = WriteConsoleOutput(_handle, _buffer,
              new Coord() { X = _width, Y = _height },
              new Coord() { X = 0, Y = 0 },
              ref _rect);
      }
      Clear();
    }

    /// <summary>
    /// Записывает содержимое в буфер
    /// </summary>
    /// <param name="parText">Текст</param>
    /// <param name="parAttribute">Аттрибуты</param>
    public void WriteInBuffer(string parText, short parAttribute)
    {
      for (int i = 0; i < parText.Length; i++)
      {
        _buffer[_bufferCursor].Attributes = parAttribute;
        _buffer[_bufferCursor].Char.UnicodeChar = parText[i];
        _bufferCursor++;
      }
    }

    /// <summary>
    /// Устанавливает курсор в буфере
    /// </summary>
    /// <param name="parX">Координата X</param>
    /// <param name="parY">Координата Y</param>
    public void SetBufferCursor(short parX, short parY)
    {
      if (parX + parY * _width < _buffer.Length)
      {
        _bufferCursor = parX + parY * _width;
      }
    }

    /// <summary>
    /// Очищает буфер
    /// </summary>
    public void Clear()
    {
      _buffer = new CharInfo[_width * _height];
      _bufferCursor = 0;
    }
  }
}
