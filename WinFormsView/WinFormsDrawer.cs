using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Threading;

namespace WinFormsView
{
  public class WinFormsDrawer
  {
    private AppForm _appForm;

    //private Timer _timer;

    private Thread thread;

    private bool isRun;

    /// <summary>
    /// Объект буферной графики
    /// </summary>
    private BufferedGraphics _bufferedDrawer;

    public AppForm AppForm
    {
      get
      {
        return _appForm;
      }
    }

    public Graphics Graphics
    {
      get
      {
        return _bufferedDrawer.Graphics;
      }
    }

    public WinFormsDrawer(AppForm parAppForm)
    {
      _appForm = parAppForm;
    }

    public void Initialize()
    {
      _appForm.Text = "Influence";
      _appForm.WindowState = FormWindowState.Maximized;
      Graphics drawer = _appForm.CreateGraphics();
      drawer.SmoothingMode = SmoothingMode.AntiAlias;

      BufferedGraphicsContext context = new BufferedGraphicsContext();
      _bufferedDrawer = context.Allocate(drawer, new Rectangle(0, 0, _appForm.ClientSize.Width, _appForm.ClientSize.Height));

      _appForm.Paint += OnPaint;
      _appForm.FormClosing += _appForm_FormClosing;
      thread = new Thread(CallP);
      isRun = true;
      thread.Start();
    //  _timer = new Timer()
    //  {
    //    Interval = 10
    //};
      //_timer.Tick += CallPaint;
      //_timer.Start();
    }

    private void _appForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      isRun = false;
    }

    /// <summary>
    /// Вызывает событие перерисовки
    /// </summary>
    private void CallPaint(object parSender, EventArgs parE)
    {
      lock (this)
      {

      }
          _appForm.Invalidate();
    }

    private void CallP()
    {
      while (isRun)
      {
        _appForm.Invalidate();
      }
    }

    /// <summary>
    /// Обрабатывает событие перерисовки формы
    /// </summary>
    /// <param name="parSender">Источник события</param>
    /// <param name="parE">Параметры события</param>
    private void OnPaint(object parSender, PaintEventArgs parE)
    {
        _bufferedDrawer.Render(parE.Graphics);
    }
  }
}
