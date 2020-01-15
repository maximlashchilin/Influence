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
    private static readonly Font DEFAULT_FONT = new Font(FontFamily.GenericSansSerif, 16, FontStyle.Bold);

    /// <summary>
    /// Шрифт для цифр
    /// </summary>
    private static readonly Font NUMBER_FONT = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold);

    /// <summary>
    /// Объект класса WinFormsDrawer
    /// </summary>
    private WinFormsDrawer _winFormsDrawer;

    /// <summary>
    /// Конструктор
    /// </summary>
    public WinFormsPlatform()
    {
      _winFormsDrawer = new WinFormsDrawer(new AppForm());
      _winFormsDrawer.Initialize();
      WidthPlatform = _winFormsDrawer.AppForm.ClientSize.Width;
      HeightPlatform = _winFormsDrawer.AppForm.ClientSize.Height;
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
        case Keys.Back:
          CallBackspaceDown();
          break;
        case Keys.Escape:
          CallEscDown();
          break;
        case Keys.Tab:
          // CallTabDown();
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
    /// <param name="parDecorativity">Выделение ячейки</param>
    public override void DrawHexagonWithScore(float parX, float parY, int parScore, ItemColors parColor, bool parDecorativity)
    {
      int firstDistance = 10;
      int secondDistance = 5;
      int x = TranslateBaseXToPlatformX(parX);
      int y = TranslateBaseYToPlatformY(parY);
      Point[] points = new Point[6];

      points[0] = new Point(x, y - firstDistance);
      points[1] = new Point(x + firstDistance, y - secondDistance);
      points[2] = new Point(x + firstDistance, y + secondDistance);
      points[3] = new Point(x, y + firstDistance);
      points[4] = new Point(x - firstDistance, y + secondDistance);
      points[5] = new Point(x - firstDistance, y - secondDistance);

      _winFormsDrawer.Graphics.FillPolygon(GetPenWithColor(parColor), points);
      _winFormsDrawer.Graphics.DrawString(Convert.ToString(parScore), NUMBER_FONT, Brushes.White, x - secondDistance, y - secondDistance);

      if (parDecorativity)
      {
        firstDistance = 15;
        secondDistance = 10;
        points[0] = new Point(x, y - firstDistance);
        points[1] = new Point(x + firstDistance, y - secondDistance);
        points[2] = new Point(x + firstDistance, y + secondDistance);
        points[3] = new Point(x, y + firstDistance);
        points[4] = new Point(x - firstDistance, y + secondDistance);
        points[5] = new Point(x - firstDistance, y - secondDistance);
        _winFormsDrawer.Graphics.DrawPolygon(Pens.Blue, points);
      }
    }

    /// <summary>
    /// Получает объект Brush c заданным цветом
    /// </summary>
    /// <param name="parColor">Цвет элемента</param>
    /// <returns>Объект Brush</returns>
    private Brush GetPenWithColor(ItemColors parColor)
    {
      switch (parColor)
      {
        case ItemColors.Red:
          return Brushes.Red;
        case ItemColors.Green:
          return Brushes.Green;
        case ItemColors.Default:
        default:
          return Brushes.Gray;
      }
    }

    /// <summary>
    /// Отрисовывает прямоугольник
    /// </summary>
    /// <param name="parX1">Координата X1</param>
    /// <param name="parY1">Координата Y1</param>
    /// <param name="parX2">Координата X2</param>
    /// <param name="parY2">Координата Y2</param>
    public override void DrawRectangle(float parX1, float parY1, float parX2, float parY2)
    {
      float width = TranslateBaseXToPlatformX(parX2) - TranslateBaseXToPlatformX(parX1);
      float height = TranslateBaseYToPlatformY(parY2) - TranslateBaseYToPlatformY(parY1);
      _winFormsDrawer.Graphics.DrawRectangle(Pens.Black, TranslateBaseXToPlatformX(parX1), TranslateBaseYToPlatformY(parY1), width, height);
    }

    /// <summary>
    /// Уничтожает платформу
    /// </summary>
    public override void Drop()
    {
      Application.Exit();
    }

    /// <summary>
    /// Инициализирует платформу
    /// </summary>
    public override void Initialize()
    {
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
      DrawRectangle(parX1, parY1, parX2, parY2);
      float width = TranslateBaseXToPlatformX(parX2) - TranslateBaseXToPlatformX(parX1);
      float height = TranslateBaseYToPlatformY(parY2) - TranslateBaseYToPlatformY(parY1);
      _winFormsDrawer.Graphics.DrawString(parText, DEFAULT_FONT, Brushes.Blue, TranslateBaseXToPlatformX(parX1) + width / 2 - parText.Length * 16 / 2, TranslateBaseYToPlatformY(parY1) + 10);
      if (parCursorVisible)
      {
        Pen pen = Pens.Black;
        _winFormsDrawer.Graphics.DrawLine(pen, 
          new Point((int)(TranslateBaseXToPlatformX(parX1) + width / 2 - parText.Length * 16 / 2 + parText.Length * 16), 
          TranslateBaseYToPlatformY(parY1)), new Point((int)(TranslateBaseXToPlatformX(parX1) + width / 2 - parText.Length * 16 / 2 + parText.Length * 16), 
          TranslateBaseYToPlatformY(parY2)));
      }
    }

    /// <summary>
    /// Печатает текст
    /// </summary>
    /// <param name="parX">Координата X</param>
    /// <param name="parY">Координата Y</param>
    /// <param name="parText">Текст</param>
    public override void PrintText(float parX, float parY, string parText)
    {
      _winFormsDrawer.Graphics.DrawString(parText, DEFAULT_FONT, Brushes.Blue, (float)TranslateBaseXToPlatformX(parX), (float)TranslateBaseYToPlatformY(parY));
    }

    /// <summary>
    /// Печатает текст в прямоугольнике
    /// </summary>
    /// <param name="parX1">Координата X1</param>
    /// <param name="parY1">Координата Y1</param>
    /// <param name="parX2">Координата X2</param>
    /// <param name="parY2">Координата Y2</param>
    /// <param name="parText">Текст</param>
    /// <param name="parCursorVisible">Видимость курсора</param>
    public override void PrintTextInRectangle(float parX1, float parY1, float parX2, float parY2, string parText, bool parCursorVisible)
    {
      DrawRectangle(parX1, parY1, parX2, parY2);
      float width = TranslateBaseXToPlatformX(parX2) - TranslateBaseXToPlatformX(parX1);
      float height = TranslateBaseYToPlatformY(parY2) - TranslateBaseYToPlatformY(parY1);
      _winFormsDrawer.Graphics.DrawString(parText, DEFAULT_FONT, Brushes.Black, TranslateBaseXToPlatformX(parX1) + width / 2 - parText.Length * 16 / 2, TranslateBaseYToPlatformY(parY1) + 10);
      if (parCursorVisible)
      {
        Pen pen = Pens.Black;
        _winFormsDrawer.Graphics.DrawLine(pen, new Point(TranslateBaseXToPlatformX(parX1) + parText.Length * 16, TranslateBaseYToPlatformY(parY1)), new Point(TranslateBaseXToPlatformX(parX1) + parText.Length * 16, TranslateBaseYToPlatformY(parY2)));
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
