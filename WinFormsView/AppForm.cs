using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;

namespace WinFormsView
{
  /// <summary>
  /// Форма приложения
  /// </summary>
  public partial class AppForm : Form
  {
    /// <summary>
    /// Объект буферной графики
    /// </summary>
    private BufferedGraphics _bufferedDrawer;

    /// <summary>
    /// Признак работы потока вызова события перерисовки
    /// </summary>
    private bool _isRun;

    /// <summary>
    /// Поток вызова события перерисовки
    /// </summary>
    private Thread _repaintThread;

    /// <summary>
    /// Объект буферной графики
    /// </summary>
    public BufferedGraphics BufferedDrawer
    {
      get
      {
        return _bufferedDrawer;
      }
    }

    /// <summary>
    /// Объект поверхности рисования
    /// </summary>
    public Graphics Drawer
    {
      get
      {
        return _bufferedDrawer.Graphics;
      }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    public AppForm()
    {
      InitializeComponent();

      WindowState = FormWindowState.Maximized;
      Graphics drawer = CreateGraphics();
      drawer.SmoothingMode = SmoothingMode.AntiAlias;
      
      int BorderWidth = (Width - ClientSize.Width) / 2;
      int TitlebarHeight = Height - ClientSize.Height - 2 * BorderWidth;
      BufferedGraphicsContext context = new BufferedGraphicsContext();
      _bufferedDrawer = context.Allocate(drawer, new Rectangle(0, 0, ClientSize.Width, ClientSize.Height));

      _repaintThread = new Thread(CallPaint);
      _isRun = true;
      _repaintThread.Start();

      FormClosing += OnFormClosing;
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
    /// Вызывает событие перерисовки
    /// </summary>
    private void CallPaint()
    {
      while (_isRun)
      {
        Invalidate();
        Thread.Sleep(10);
      }
    }
  }
}
