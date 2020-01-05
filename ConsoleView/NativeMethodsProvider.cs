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
    /// Код стандартного устройства ввода
    /// </summary>
    public const Int32 STD_INPUT_HANDLE = -10;

    /// <summary>
    /// Код активации мыши как устройства ввода
    /// </summary>
    public const Int32 ENABLE_MOUSE_INPUT = 0x0010;

    /// <summary>
    /// Код, позволяющий использовать мышь для для выбора
    /// и редактирования текста
    /// </summary>
    public const Int32 ENABLE_QUICK_EDIT_MODE = 0x0040;

    /// <summary>
    /// Код, необходимый для включения и отключения
    /// расширенных флагов
    /// </summary>
    public const Int32 ENABLE_EXTENDED_FLAGS = 0x0080;

    /// <summary>
    /// Код событий клавиатуры
    /// </summary>
    public const Int32 KEY_EVENT = 1;

    /// <summary>
    /// Код событий мыши
    /// </summary>
    public const Int32 MOUSE_EVENT = 2;

    /// <summary>
    /// Используется для возвращения информации
    /// о входных сообщениях в консольном входном буфере
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
    /// Используется для сообщения
    /// о событиях ввода информации от мыши
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
    /// Используется для хранения координат
    /// текстового курсора
    /// </summary>
    [DebuggerDisplay("{X}, {Y}")]
    public struct COORD
    {
      public UInt16 X;
      public UInt16 Y;
    }

    /// <summary>
    /// Используется для сообщения
    /// о событиях ввода информации от клавиатуры
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
    /// Дескриптор консоли
    /// </summary>
    public class ConsoleHandle : SafeHandleMinusOneIsInvalid
    {
      /// <summary>
      /// Конструктор
      /// </summary>
      public ConsoleHandle() : base(false) { }

      /// <summary>
      /// Выполняет код, необходимый для освобождения дескриптора
      /// </summary>
      /// <returns></returns>
      protected override bool ReleaseHandle()
      {
        return true;
      }
    }

    /// <summary>
    /// Извлекает текущий режим буфера консоли
    /// или текущий режим вывода
    /// </summary>
    /// <param name="hConsoleHandle">Дескриптор консоли</param>
    /// <param name="lpMode">Указатель на переменную, которая получает режим указанного буфера</param>
    /// <returns>Код ошибки</returns>
    [DllImportAttribute("kernel32.dll", SetLastError = true)]
    [return: MarshalAsAttribute(UnmanagedType.Bool)]
    public static extern Boolean GetConsoleMode(ConsoleHandle hConsoleHandle, ref Int32 lpMode);

    /// <summary>
    /// Извлекает дескриптор указанного стандартного устройства
    /// </summary>
    /// <param name="nStdHandle">Стандартное устройство</param>
    /// <returns>Дескриптор указанного устройства</returns>
    [DllImportAttribute("kernel32.dll", SetLastError = true)]
    public static extern ConsoleHandle GetStdHandle(Int32 nStdHandle);

    /// <summary>
    /// Читает данные из буфера консоли
    /// и удаляет их из буфера
    /// </summary>
    /// <param name="hConsoleInput">Дескриптор консоли</param>
    /// <param name="lpBuffer">Указатель на массив структур INPUT_RECORD</param>
    /// <param name="nLength">Размер массива lpBuffer</param>
    /// <param name="lpNumberOfEventsRead">Указатель на переменную, которая получает количество входных записей</param>
    /// <returns>Код ошибки</returns>
    [DllImportAttribute("kernel32.dll", SetLastError = true)]
    [return: MarshalAsAttribute(UnmanagedType.Bool)]
    public static extern Boolean ReadConsoleInput(ConsoleHandle hConsoleInput, ref INPUT_RECORD lpBuffer, UInt32 nLength, ref UInt32 lpNumberOfEventsRead);

    /// <summary>
    /// Устанавливает режим буфера консоли
    /// или режим вывода
    /// </summary>
    /// <param name="hConsoleHandle">Дескриптор консоли</param>
    /// <param name="dwMode">Устанавливаемый режим</param>
    /// <returns>Код ошибки</returns>
    [DllImportAttribute("kernel32.dll", SetLastError = true)]
    [return: MarshalAsAttribute(UnmanagedType.Bool)]
    public static extern Boolean SetConsoleMode(ConsoleHandle hConsoleHandle, Int32 dwMode);
  }
}
