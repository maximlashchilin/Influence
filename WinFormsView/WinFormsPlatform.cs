using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Model;
using View;

namespace WinFormsView
{
  public class WinFormsPlatform : Platform
  {
    private static readonly Font DEFAULT_FONT = new Font(FontFamily.GenericSansSerif, 21, FontStyle.Bold);
    private static readonly Font NUMBER_FONT = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold);

    private AppForm _appForm;

    public WinFormsPlatform()
    {
      _appForm = new AppForm();
      _appForm.Click += OnClick;
      _appForm.MouseMove += OnMouseMove;
      _appForm.KeyDown += OnKeyDown;
      _appForm.FormClosing += OnClose;
      _appForm.Paint += OnPaint;
    }

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
    }

    public override void Clear()
    {
      _appForm.Drawer.Clear(Color.White);
    }

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

      _appForm.Drawer.FillPolygon(GetPenWithColor(parColor), points);
      _appForm.Drawer.DrawString(Convert.ToString(parScore), NUMBER_FONT, Brushes.Black, x - 5, y - 5);
    }

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

    public override void Drop()
    {
      Application.Exit();
      Environment.Exit(0);
    }

    public override void Initialize()
    {
      WidthPlatform = _appForm.ClientSize.Width;
      HeightPlatform = _appForm.ClientSize.Height;
      
      Application.Run(_appForm);
    }

    public override void PrintMarkedTextInRectangle(float parX1, float parY1, float parX2, float parY2, string parText)
    {
      _appForm.Drawer.DrawString(parText, DEFAULT_FONT, Brushes.Blue, (float)TranslateBaseXToPlatformX(parX1), (float)TranslateBaseYToPlatformY(parY1));
    }

    public override void PrintText(float parX, float parY, string parText)
    {
      throw new NotImplementedException();
    }

    public override void PrintTextInRectangle(float parX1, float parY1, float parX2, float parY2, string parText)
    {
      _appForm.Drawer.DrawString(parText, DEFAULT_FONT, Brushes.Black, TranslateBaseXToPlatformX(parX1), TranslateBaseYToPlatformY(parY1));
    }

    private void OnClick(object parSender, EventArgs parE)
    {
      CallClick();
    }

    private void OnPaint(object parSender, PaintEventArgs parE)
    {
      _appForm.BufferedDrawer.Render(parE.Graphics);
    }

    private void OnMouseMove(object parSender, MouseEventArgs parE)
    {
      if (parE.Button == MouseButtons.Left)
      {
        CallClick();
      }
      else
      {
        CallMove(this, new MoveEventArgs(TranslatePlatformXToBaseX(parE.X), TranslatePlatformYToBaseY(parE.Y)));
      }
    }

    private void OnClose(object parSender, EventArgs parE)
    {
      Drop();
    }
  }
}
