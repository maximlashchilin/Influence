using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View;
using System.Runtime.InteropServices;
using System.Windows.Forms;


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
      _eventListener.ConsoleKeyboardEvent += ConsoleKeyboardEventHandler;
    }

    public override void Initialize()
    {
      SendMessage(Handle, WM_SYSCOMMAND, SC_MAXIMIZE, 0);
      Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
      Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
      Console.CursorVisible = false;
      _eventListener.Initialize();
      Console.Title = "Influence";
    }

    public override void Drop()
    {
      throw new NotImplementedException();
    }

    public void ConsoleMouseEventHandler(object parSender, ConsoleMouseEventArgs parE)
    {
      
    }

    public void ConsoleKeyboardEventHandler(object parSender, ConsoleKeyboardEventArgs parE)
    {
      if (parE.KeyDown)
      {
        switch (parE.VirtualKeyCode)
        {
          case 13:
            OnEnterDown();
            break;
          case 38:
            OnArrowUpDown();
            break;
          case 40:
            OnArrowDown();
            break;
        }
      }
    }

    public override void DrawHexagonWithScore(float parX, float parY, int parScore)
    {
      Console.SetCursorPosition((int)parX - 1, (int)parY - 1);
      Console.WriteLine("/-\\");
      Console.WriteLine(" " + Convert.ToString(parScore));
      Console.WriteLine("\\_/");
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
      for (int i = (int)parX1 + 1; i < (int)parX2; i++)
      {
        s.Append("─");
      }
      s.Append("┐").Append("\n");

      for (int i = 0; i < (int) parX1; i++)
      {
        s.Append(" ");
      }

      s.Append("│");
      int numbersOfLeftSpaces = (int)Math.Floor(((int)(parX2) - (int)(parX1) - parText.Length - 1) / 2.0f);
      for (int i = 0; i < numbersOfLeftSpaces; i++)
      {
        s.Append(" ");
      }
      s.Append(parText);

      int numbersOfRightSpaces = (int)(parX2) - (int)(parX1) - parText.Length - 1 - numbersOfLeftSpaces;
      for (int i = 0; i < numbersOfRightSpaces; i++)
      {
        s.Append(" ");
      }
      s.Append("│").Append("\n");

      for (int i = 0; i < (int)parX1; i++)
      {
        s.Append(" ");
      }
      s.Append("└");
      for (int i = (int)parX1 + 1; i < (int)parX2; i++)
      {
        s.Append("─");
      }
      s.Append("┘");

      Console.SetCursorPosition((int)parX1, (int)parY1);
      Console.WriteLine(s);
    }

    public override void PrintMarkedTextInRectangle(float parX1, float parY1, float parX2, float parY2, string parText)
    {
      Console.BackgroundColor = ConsoleColor.Blue;
      StringBuilder s = new StringBuilder("┌");
      for (int i = (int)parX1 + 1; i < (int)parX2; i++)
      {
        s.Append("─");
      }
      s.Append("┐").Append("\n");

      for (int i = 0; i < (int)parX1; i++)
      {
        s.Append(" ");
      }

      s.Append("│");
      int numbersOfLeftSpaces = (int)Math.Floor(((int)(parX2) - (int)(parX1) - parText.Length - 1) / 2.0f);
      for (int i = 0; i < numbersOfLeftSpaces; i++)
      {
        s.Append(" ");
      }
      s.Append(parText);

      int numbersOfRightSpaces = (int)(parX2) - (int)(parX1) - parText.Length - 1 - numbersOfLeftSpaces;
      for (int i = 0; i < numbersOfRightSpaces; i++)
      {
        s.Append(" ");
      }
      s.Append("│").Append("\n");

      for (int i = 0; i < (int)parX1; i++)
      {
        s.Append(" ");
      }
      s.Append("└");
      for (int i = (int)parX1 + 1; i < (int)parX2; i++)
      {
        s.Append("─");
      }
      s.Append("┘");

      Console.SetCursorPosition((int)parX1, (int)parY1);
      Console.WriteLine(s);
      Console.BackgroundColor = ConsoleColor.Black;
    }
  }
}
