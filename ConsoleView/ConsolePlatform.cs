using System;
using System.Text;
using View;
using System.Runtime.InteropServices;
using Model;

namespace ConsoleView
{
  /// <summary>
  /// Консольная платформа
  /// </summary>
  public class ConsolePlatform : Platform
  {
    /// <summary>
    /// 
    /// </summary>
    private const int WM_SYSCOMMAND = 0x0112;

    /// <summary>
    /// Код для сообщения максимизации окна
    /// </summary>
    private const int SC_MAXIMIZE = 0xF030;

    /// <summary>
    /// Слушатель событий Windows
    /// </summary>
    private EventListener _eventListener;

    /// <summary>
    /// Получает указатель на окно консоли
    /// </summary>
    /// <returns>Указатель на окно консоли</returns>
    [DllImport("kernel32")]
    static extern IntPtr GetConsoleWindow();

    /// <summary>
    /// Отправляет сообщение окну
    /// </summary>
    /// <param name="hWnd">Указатель окна</param>
    /// <param name="wMsg"></param>
    /// <param name="wParam"></param>
    /// <param name="lParam"></param>
    /// <returns></returns>
    [DllImport("user32.dll")]
    public static extern int SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

    /// <summary>
    /// Конструктор платформы
    /// </summary>
    public ConsolePlatform()
    {
      _eventListener = EventListener.GetIntance();
      _eventListener.ConsoleMouseEvent += ConsoleMouseEventHandler;
      _eventListener.ConsoleKeyboardEvent += ConsoleKeyboardEventHandler;
    }

    /// <summary>
    /// Инициализирует консольную платформу
    /// </summary>
    public override void Initialize()
    {
      SendMessage(GetConsoleWindow(), WM_SYSCOMMAND, SC_MAXIMIZE, 0);
      Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
      Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
      WidthPlatform = Console.WindowWidth;
      HeightPlatform = Console.WindowHeight;
      Console.CursorVisible = false;
      _eventListener.Initialize();
      Console.Title = "Influence";
    }

    /// <summary>
    /// Уничтожает платформу
    /// </summary>
    public override void Drop()
    {
      _eventListener.Stop();
    }

    /// <summary>
    /// Обрабатывает событие работы с мышью в консоли
    /// </summary>
    /// <param name="parSender">Отправитель события</param>
    /// <param name="parE">Параметры события</param>
    public void ConsoleMouseEventHandler(object parSender, ConsoleMouseEventArgs parE)
    {
      if (parE.ButtonState == 1)
      {
        CallClick();
      }
      else
      {
        CallMove(this, new MoveEventArgs(TranslatePlatformXToBaseX((int)parE.X), TranslatePlatformYToBaseY((int)parE.Y)));
      }
    }

    /// <summary>
    /// Обрабатывает событие работы с клавиатурой в консоли
    /// </summary>
    /// <param name="parSender">Отправитель события</param>
    /// <param name="parE">Параметры события</param>
    public void ConsoleKeyboardEventHandler(object parSender, ConsoleKeyboardEventArgs parE)
    {
      const int ENTER_CODE = 13;
      const int ARROW_UP_CODE = 38;
      const int ARROW_DOWN_CODE = 40;
      if (parE.KeyDown)
      {
        switch (parE.VirtualKeyCode)
        {
          case ENTER_CODE:
            CallEnterDown();
            break;
          case ARROW_UP_CODE:
            CallArrowUpDown();
            break;
          case ARROW_DOWN_CODE:
            CallArrowDown();
            break;
        }

        if (parE.VirtualKeyCode >= 65 && parE.VirtualKeyCode <= 90)
        {
          CallKeyDown();
        }
      }
    }

    /// <summary>
    /// Очищает поверхность отображения платформы
    /// </summary>
    public override void Clear()
    {
      Console.Clear();
    }

    /// <summary>
    /// Отображает восьмиугольник в указанных координатах
    /// с количеством очков и соответствующим цветом
    /// </summary>
    /// <param name="parX">Координата X</param>
    /// <param name="parY">Координата Y</param>
    /// <param name="parScore">Количество очков</param>
    /// <param name="parColor">Цвет</param>
    public override void DrawHexagonWithScore(float parX, float parY, int parScore, ItemColor parColor)
    {
      if (parColor != ItemColor.Default)
      {
        if (parColor == ItemColor.Green)
        {
          Console.ForegroundColor = ConsoleColor.Green;
        }
        else if (parColor == ItemColor.Red)
        {
          Console.ForegroundColor = ConsoleColor.Red;
        }
      }
      Console.SetCursorPosition(TranslateBaseXToPlatformX(parX) - 1, TranslateBaseYToPlatformY(parY) - 1);
      Console.WriteLine("/─\\");
      Console.SetCursorPosition(TranslateBaseXToPlatformX(parX) - 1, TranslateBaseYToPlatformY(parY));
      Console.WriteLine("│" + Convert.ToString(parScore) + "│");
      Console.SetCursorPosition(TranslateBaseXToPlatformX(parX) - 1, TranslateBaseYToPlatformY(parY) + 1);
      Console.WriteLine("\\_/");

      Console.ResetColor();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="parX1"></param>
    /// <param name="parY1"></param>
    /// <param name="parX2"></param>
    /// <param name="parY2"></param>
    public override void DrawRectangle(float parX1, float parY1, float parX2, float parY2)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="parX"></param>
    /// <param name="parY"></param>
    /// <param name="parText"></param>
    public override void PrintText(float parX, float parY, string parText)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Печатает текст в прямоугольнике
    /// </summary>
    /// <param name="parX1">Координата X1</param>
    /// <param name="parY1">Координата Y1</param>
    /// <param name="parX2">Координата X2</param>
    /// <param name="parY2">Координата Y2</param>
    /// <param name="parText">Текст</param>
    public override void PrintTextInRectangle(float parX1, float parY1, float parX2, float parY2, string parText)
    {
      StringBuilder s = new StringBuilder("┌");
      for (int i = TranslateBaseXToPlatformX(parX1) + 1; i < TranslateBaseXToPlatformX(parX2); i++)
      {
        s.Append("─");
      }
      s.Append("┐").Append("\n");

      for (int i = 0; i < TranslateBaseXToPlatformX(parX1); i++)
      {
        s.Append(" ");
      }

      s.Append("│");
      int numbersOfLeftSpaces = (int)Math.Floor((TranslateBaseXToPlatformX(parX2) - TranslateBaseXToPlatformX(parX1) - parText.Length - 1) / 2.0f);
      for (int i = 0; i < numbersOfLeftSpaces; i++)
      {
        s.Append(" ");
      }
      s.Append(parText);

      int numbersOfRightSpaces = TranslateBaseXToPlatformX(parX2) - TranslateBaseXToPlatformX(parX1) - parText.Length - 1 - numbersOfLeftSpaces;
      for (int i = 0; i < numbersOfRightSpaces; i++)
      {
        s.Append(" ");
      }
      s.Append("│").Append("\n");

      for (int i = 0; i < TranslateBaseXToPlatformX(parX1); i++)
      {
        s.Append(" ");
      }
      s.Append("└");
      for (int i = TranslateBaseXToPlatformX(parX1) + 1; i < TranslateBaseXToPlatformX(parX2); i++)
      {
        s.Append("─");
      }
      s.Append("┘");

      Console.SetCursorPosition(TranslateBaseXToPlatformX(parX1), TranslateBaseYToPlatformY(parY1));
      Console.WriteLine(s);
    }

    /// <summary>
    /// Выводит текст в выделенном прямоугольнике
    /// </summary>
    /// <param name="parX1">Координата X1</param>
    /// <param name="parY1">Координата Y1</param>
    /// <param name="parX2">Координата X2</param>
    /// <param name="parY2">Координата Y2</param>
    /// <param name="parText">Текст</param>
    public override void PrintMarkedTextInRectangle(float parX1, float parY1, float parX2, float parY2, string parText)
    {
      StringBuilder s = new StringBuilder("┌");
      Console.ForegroundColor = ConsoleColor.Blue;
      for (int i = TranslateBaseXToPlatformX(parX1) + 1; i < TranslateBaseXToPlatformX(parX2); i++)
      {
        s.Append("─");
      }
      s.Append("┐").Append("\n");

      for (int i = 0; i < TranslateBaseXToPlatformX(parX1); i++)
      {
        s.Append(" ");
      }

      s.Append("│");
      int numbersOfLeftSpaces = (int)Math.Floor((TranslateBaseXToPlatformX(parX2) - TranslateBaseXToPlatformX(parX1) - parText.Length - 1) / 2.0f);
      for (int i = 0; i < numbersOfLeftSpaces; i++)
      {
        s.Append(" ");
      }
      s.Append(parText);

      int numbersOfRightSpaces = TranslateBaseXToPlatformX(parX2) - TranslateBaseXToPlatformX(parX1) - parText.Length - 1 - numbersOfLeftSpaces;
      for (int i = 0; i < numbersOfRightSpaces; i++)
      {
        s.Append(" ");
      }
      s.Append("│").Append("\n");

      for (int i = 0; i < TranslateBaseXToPlatformX(parX1); i++)
      {
        s.Append(" ");
      }
      s.Append("└");
      for (int i = TranslateBaseXToPlatformX(parX1) + 1; i < TranslateBaseXToPlatformX(parX2); i++)
      {
        s.Append("─");
      }
      s.Append("┘");

      Console.SetCursorPosition(TranslateBaseXToPlatformX(parX1), TranslateBaseYToPlatformY(parY1));
      Console.WriteLine(s);
      Console.ForegroundColor = ConsoleColor.White;
    }
  }
}
