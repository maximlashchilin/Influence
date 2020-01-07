using System;
using System.Drawing;
using System.Windows.Forms;
using Model;
using View;

namespace WinFormsView
{
  /// <summary>
  /// Платформа Windows Forms
  /// </summary>
  public class WinFormsPlatform : Platform
  {
    /// <summary>
    /// Шрифт по умолчанию
    /// </summary>
    private static readonly Font DEFAULT_FONT = new Font(FontFamily.GenericSansSerif, 18, FontStyle.Bold);

    /// <summary>
    /// Шрифт для цифр
    /// </summary>
    private static readonly Font NUMBER_FONT = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold);

    private WinFormsDrawer _winFormsDrawer;

    /// <summary>
    /// Конструктор
    /// </summary>
    public WinFormsPlatform()
    {
      _winFormsDrawer = new WinFormsDrawer(new AppForm());
      _winFormsDrawer.Initialize();
      _winFormsDrawer.AppForm.Click += OnClick;
      _winFormsDrawer.AppForm.MouseMove += OnMouseMove;
      _winFormsDrawer.AppForm.KeyDown += OnKeyDown;
      _winFormsDrawer.AppForm.FormClosing += OnClose;
    }

    /// <summary>
    /// Обрабатывает нажатие клавиши на клавиатуре
    /// </summary>
    /// <param name="parSender">Источник события</param>
    /// <param name="parE">Параметры события</param>
    private void OnKeyDown(object parSender, KeyEventArgs parE)
    {
      switch (parE.KeyCode)
      {
        case Keys.Up:
          CallArrowUpDown();
          break;
        case Keys.Down:
          CallArrowDown();
          break;
        case Keys.Enter:
          CallEnterDown();
          break;
      }

      if (parE.KeyCode >= Keys.A && parE.KeyCode <= Keys.Z)
      {
        CallKeyDown(new KeyDownEventArgs(Convert.ToChar(parE.KeyCode)));
      }
    }

    /// <summary>
    /// Очищает область рисования
    /// </summary>
    public override void Clear()
    {
      _winFormsDrawer.Graphics.Clear(Color.White);
    }

    /// <summary>
    /// Рисует игровую ячейку
    /// </summary>
    /// <param name="parX">Координата X</param>
    /// <param name="parY">Координата Y</param>
    /// <param name="parScore">Счёт</param>
    /// <param name="parColor">Цвет</param>
    public override void DrawHexagonWithScore(float parX, float parY, int parScore, ItemColor parColor)
    {
      int x = TranslateBaseXToPlatformX(parX);
      int y = TranslateBaseYToPlatformY(parY);
      Point[] points = new Point[6];

      points[0] = new Point(x, y - 10);
      points[1] = new Point(x + 10, y - 5);
      points[2] = new Point(x + 10, y + 5);
      points[3] = new Point(x, y + 10);
      points[4] = new Point(x - 10, y + 5);
      points[5] = new Point(x - 10, y - 5);

      _winFormsDrawer.Graphics.FillPolygon(GetPenWithColor(parColor), points);
      _winFormsDrawer.Graphics.DrawString(Convert.ToString(parScore), NUMBER_FONT, Brushes.Black, x - 5, y - 5);
    }

    /// <summary>
    /// Получает объект Brush c заданным цветом
    /// </summary>
    /// <param name="parColor">Цвет элемента</param>
    /// <returns>Объект Brush</returns>
    private Brush GetPenWithColor(ItemColor parColor)
    {
      switch (parColor)
      {
        case ItemColor.Red:
          return Brushes.Red;
        case ItemColor.Green:
          return Brushes.Green;
        case ItemColor.Default:
        default:
          return Brushes.Gray;
      }
    }

    public override void DrawRectangle(float parX1, float parY1, float parX2, float parY2)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Уничтожает платформу
    /// </summary>
    public override void Drop()
    {
      Application.Exit();
      Environment.Exit(0);
    }

    /// <summary>
    /// Инициализирует платформу
    /// </summary>
    public override void Initialize()
    {
      WidthPlatform = _winFormsDrawer.AppForm.ClientSize.Width;
      HeightPlatform = _winFormsDrawer.AppForm.ClientSize.Height;
      Application.Run(_winFormsDrawer.AppForm);
    }

    /// <summary>
    /// Печатает текст в выделенном прямоугольнике
    /// </summary>
    /// <param name="parX1">Координата X1</param>
    /// <param name="parY1">Координата Y1</param>
    /// <param name="parX2">Координата X2</param>
    /// <param name="parY2">Координата Y2</param>
    /// <param name="parText">Текст</param>
    /// <param name="parCursorVisible">Видимость курсора</param>
    public override void PrintMarkedTextInRectangle(float parX1, float parY1, float parX2, float parY2, string parText, bool parCursorVisible)
    {
      _winFormsDrawer.Graphics.DrawString(parText, DEFAULT_FONT, Brushes.Blue, (float)TranslateBaseXToPlatformX(parX1), (float)TranslateBaseYToPlatformY(parY1));
      if (parCursorVisible)
      {
        Pen pen = Pens.Black;
        _winFormsDrawer.Graphics.DrawLine(pen, new Point(TranslateBaseXToPlatformX(parX1) + parText.Length * 20, TranslateBaseYToPlatformY(parY1)), new Point(TranslateBaseXToPlatformX(parX1) + parText.Length * 20, TranslateBaseYToPlatformY(parY2)));
      }
    }

    /// <summary>
    /// Печатает текст
    /// </summary>
    /// <param name="parX"></param>
    /// <param name="parY"></param>
    /// <param name="parText"></param>
    public override void PrintText(float parX, float parY, string parText)
    {
      _winFormsDrawer.Graphics.DrawString(parText, DEFAULT_FONT, Brushes.Blue, (float)TranslateBaseXToPlatformX(parX), (float)TranslateBaseYToPlatformY(parY));
    }

    /// <summary>
    /// Печатает текст в прямоугольнике
    /// </summary>
    /// <param name="parX1"></param>
    /// <param name="parY1"></param>
    /// <param name="parX2"></param>
    /// <param name="parY2"></param>
    /// <param name="parText"></param>
    /// <param name="parCursorVisible"></param>
    public override void PrintTextInRectangle(float parX1, float parY1, float parX2, float parY2, string parText, bool parCursorVisible)
    {
      _winFormsDrawer.Graphics.DrawString(parText, DEFAULT_FONT, Brushes.Black, TranslateBaseXToPlatformX(parX1), TranslateBaseYToPlatformY(parY1));
      if (parCursorVisible)
      {
        Pen pen = Pens.Black;
        _winFormsDrawer.Graphics.DrawLine(pen, new Point(TranslateBaseXToPlatformX(parX1) + parText.Length * 20, TranslateBaseYToPlatformY(parY1)), new Point(TranslateBaseXToPlatformX(parX1) + parText.Length * 20, TranslateBaseYToPlatformY(parY2)));
      }
    }

    /// <summary>
    /// Обрабатывает событие клика на форме
    /// </summary>
    /// <param name="parSender">Источник события</param>
    /// <param name="parE">Параметры события</param>
    private void OnClick(object parSender, EventArgs parE)
    {
      CallClick();
    }

    /// <summary>
    /// Обрабатывает событие работы с мышью на форме
    /// </summary>
    /// <param name="parSender">Источник события</param>
    /// <param name="parE">Параметры собыия</param>
    private void OnMouseMove(object parSender, MouseEventArgs parE)
    {
      CallMove(new MoveEventArgs(TranslatePlatformXToBaseX(parE.X), TranslatePlatformYToBaseY(parE.Y)));
    }

    /// <summary>
    /// Обрабатывает событие закрытия формы
    /// </summary>
    /// <param name="parSender">Источник события</param>
    /// <param name="parE">Параметры события</param>
    private void OnClose(object parSender, EventArgs parE)
    {
      Drop();
    }
  }
}
