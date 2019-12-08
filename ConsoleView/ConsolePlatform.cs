using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Model;

namespace ConsoleView
{
  public class ConsolePlatform : Platform
  {
    private const int WM_SYSCOMMAND = 0x0112;
    private const int SC_MAXIMIZE = 0xF030;

    private EventListener _eventListener;

    [DllImport("kernel32")]
    static extern IntPtr GetConsoleWindow();

    [DllImport("user32.dll")]
    public static extern int SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

    public static IntPtr Handle
    {
      get
      {
        return GetConsoleWindow();
      }
    }

    public ConsolePlatform()
    {
      _eventListener = new EventListener();
      _eventListener.ConsoleMouseEvent += ConsoleMouseEventHandler;
      _eventListener.ConsoleKeyboardEvent += ConsoleKeyboardEventHandler;
    }

    public override void Initialize()
    {
      SendMessage(Handle, WM_SYSCOMMAND, SC_MAXIMIZE, 0);
      Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
      Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
      WidthPlatform = Console.WindowWidth;
      HeightPlatform = Console.WindowHeight;
      Console.CursorVisible = false;
      _eventListener.Initialize();
      Console.Title = "Influence";
    }

    public override void Drop()
    {
      _eventListener.Stop();
    }

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

    public void ConsoleKeyboardEventHandler(object parSender, ConsoleKeyboardEventArgs parE)
    {
      if (parE.KeyDown)
      {
        switch (parE.VirtualKeyCode)
        {
          case 13:
            CallEnterDown();
            break;
          case 38:
            CallArrowUpDown();
            break;
          case 40:
            CallArrowDown();
            break;
        }
      }
    }

    public override void Clear()
    {
      Console.Clear();
    }
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

    public override void DrawRectangle(float parX1, float parY1, float parX2, float parY2)
    {
      throw new NotImplementedException();
    }

    public override void PrintText(float parX, float parY, string parText)
    {
      throw new NotImplementedException();
    }

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

    public override void PrintMarkedTextInRectangle(float parX1, float parY1, float parX2, float parY2, string parText)
    {
      Console.BackgroundColor = ConsoleColor.Blue;
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
      Console.BackgroundColor = ConsoleColor.Black;
    }
  }
}
