using System;
using Model;

namespace View
{
  public abstract class Platform
  {
    private static Platform _instance;

    private static PlatformType _type;

    private static readonly object _lock = new object();
    /// <summary>
    /// 
    /// </summary>
    private int _widthPlatform;

    /// <summary>
    /// 
    /// </summary>
    private int _heightPlatform;

    /// <summary>
    /// 
    /// </summary>
    public event EventHandler ArrowUp;

    /// <summary>
    /// 
    /// </summary>
    public event EventHandler ArrowDown;

    /// <summary>
    /// 
    /// </summary>
    public event EventHandler EnterDown;

    public event dMoveEventHander Move;

    public event EventHandler Click;

    public int WidthPlatform
    {
      get
      {
        return _widthPlatform;
      }
      set
      {
        _widthPlatform = value;
      }
    }

    public int HeightPlatform
    {
      get
      {
        return _heightPlatform;
      }
      set
      {
        _heightPlatform = value;
      }
    }

    public BaseView View
    {
      get; set;
    }

    //private Platform()
    //{
    //}

    //public static Platform GetInstance()
    //{
    //  if (null == _instance)
    //  {
    //    lock (_lock)
    //    {
    //      if (null == _instance)
    //      {
    //        _instance = 
    //      }
    //    }
    //  }

    //  return _instance;
    //}

    //protected abstract Platform CreatePlatform();

    public abstract void Initialize();

    public abstract void Drop();

    protected virtual void CallArrowUpDown()
    {
      ArrowUp?.Invoke(this, EventArgs.Empty);
    }

    protected virtual void CallArrowDown()
    {
      ArrowDown?.Invoke(this, EventArgs.Empty);
    }

    protected virtual void CallEnterDown()
    {
      EnterDown?.Invoke(this, EventArgs.Empty);
    }

    protected virtual void CallMove(object parSender, MoveEventArgs parE)
    {
      Move?.Invoke(parSender, parE);
    }

    protected virtual void CallClick()
    {
      Click?.Invoke(this, EventArgs.Empty);
    }

    public void UnsubscribeAllEvents()
    {
      ArrowUp = null;
      ArrowDown = null;
      EnterDown = null;
      Move = null;
      Click = null;
    }

    public int TranslateBaseXToPlatformX(float parBaseX)
    {
      return (int)(parBaseX / 100.0f * _widthPlatform);
    }

    public int TranslateBaseYToPlatformY(float parBaseY)
    {
      return (int)(parBaseY / 100.0f * _heightPlatform);
    }

    public float TranslatePlatformXToBaseX(int parPlatformX)
    {
      return (float)parPlatformX / _widthPlatform * 100.0f;
    }

    public float TranslatePlatformYToBaseY(int parPlatformY)
    {
      return (float)parPlatformY / _heightPlatform * 100;
    }

    public abstract void Clear();

    public abstract void PrintText(float parX, float parY, string parText);

    public abstract void DrawRectangle(float parX1, float parY1, float parX2, float parY2);

    public abstract void PrintTextInRectangle(float parX1, float parY1, float parX2, float parY2, string parText);

    public abstract void PrintMarkedTextInRectangle(float parX1, float parY1, float parX2, float parY2, string parText);

    public abstract void DrawHexagonWithScore(float parX, float parY, int parScore, ItemColor parColor);
  }
}
