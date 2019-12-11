using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsView
{
  public partial class AppForm : Form
  {
    private BufferedGraphics _bufferedDrawer;

    private bool _isRun;

    private Thread _repaintThread;

    public BufferedGraphics BufferedDrawer
    {
      get
      {
        return _bufferedDrawer;
      }
    }
    public Graphics Drawer
    {
      get
      {
        return _bufferedDrawer.Graphics;
      }
    }
    public AppForm()
    {
      InitializeComponent();

      WindowState = FormWindowState.Maximized;
      Graphics drawer = CreateGraphics();
      drawer.SmoothingMode = SmoothingMode.AntiAlias;
      
      int BorderWidth = (Width - ClientSize.Width) / 2;
      int TitlebarHeight = Height - ClientSize.Height - 2 * BorderWidth;
      //Width = Screen.PrimaryScreen.Bounds.Width;
      //Height = Screen.PrimaryScreen.Bounds.Height;
      BufferedGraphicsContext context = new BufferedGraphicsContext();
      _bufferedDrawer = context.Allocate(drawer, new Rectangle(0, 0, ClientSize.Width, ClientSize.Height));

      _repaintThread = new Thread(CallPaint);
      _isRun = true;
      _repaintThread.Start();

      FormClosing += OnFormClosing;
    }

    private void OnFormClosing(object parSender, FormClosingEventArgs parE)
    {
      _isRun = false;
    }

    private void CallPaint()
    {
      while (_isRun)
      {
        Invalidate();
      }
    }
  }
}
