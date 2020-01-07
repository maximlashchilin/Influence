using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Threading;

namespace WinFormsView
{
  /// <summary>
  /// Отвечает за перерисовку формы
  /// </summary>
  public class WinFormsDrawer
  {
    /// <summary>
    /// Объект формы
    /// </summary>
    private AppForm _appForm;

    /// <summary>
    /// Поток вызова события перерисовки
    /// </summary>
    private Thread _paintThread;

    /// <summary>
    /// Признак работы потока
    /// </summary>
    private bool _isRun;

    private object _syncObj = new object();

    /// <summary>
    /// Объект буферной графики
    /// </summary>
    private BufferedGraphics _bufferedDrawer;

    /// <summary>
    /// Объект формы
    /// </summary>
    public AppForm AppForm
    {
      get
      {
        return _appForm;
      }
    }

    /// <summary>
    /// Объект Graphics
    /// </summary>
    public Graphics Graphics
    {
      get
      {
        return _bufferedDrawer.Graphics;
      }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parAppForm">Объект формы</param>
    public WinFormsDrawer(AppForm parAppForm)
    {
      _appForm = parAppForm;
    }

    /// <summary>
    /// Инициализирует WinFormsDrawer
    /// </summary>
    public void Initialize()
    {
      _appForm.Text = "Influence";
      _appForm.WindowState = FormWindowState.Maximized;
      Graphics drawer = _appForm.CreateGraphics();
      drawer.SmoothingMode = SmoothingMode.AntiAlias;

      BufferedGraphicsContext context = new BufferedGraphicsContext();
      _bufferedDrawer = context.Allocate(drawer, new Rectangle(0, 0, _appForm.ClientSize.Width, _appForm.ClientSize.Height));

      _paintThread = new Thread(CallPaint);
      _isRun = true;      

      _appForm.Paint += OnPaint;
      _appForm.FormClosing += OnFormClosing;
      _appForm.Shown += OnShown;
    }

    private void OnShown(object sender, System.EventArgs e)
    {
      _paintThread.Start();
    }


    /// <summary>
    /// Обрабатывает событие FormClosing
    /// </summary>
    /// <param name="parSender">Источник события</param>
    /// <param name="parE">Параметры события</param>
    private void OnFormClosing(object parSender, FormClosingEventArgs parE)
    {
      _isRun = false;
    }

    /// <summary>
    /// Вызывает событие перерисовки формы
    /// в потоке
    /// </summary>
    private void CallPaint()
    {
      while (_isRun)
      {
        lock (_syncObj)
        {
          _appForm.Invalidate();
          Thread.Sleep(10);
        }
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
