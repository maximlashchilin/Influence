using System;

namespace Model
{
  /// <summary>
  /// Текстовое поле
  /// </summary>
  public class TextField
  {
    /// <summary>
    /// Идентификатор
    /// </summary>
    private int _id;

    /// <summary>
    /// Координата X1
    /// </summary>
    private float _x1;

    /// <summary>
    /// 
    /// </summary>
    private float _y1;

    /// <summary>
    /// 
    /// </summary>
    private float _x2;

    /// <summary>
    /// 
    /// </summary>
    private float _y2;

    /// <summary>
    /// 
    /// </summary>
    private string _text;

    /// <summary>
    /// 
    /// </summary>
    private MenuItemStatus _itemStatus;

    /// <summary>
    /// 
    /// </summary>
    public event EventHandler Click;

    /// <summary>
    /// 
    /// </summary>
    public event dPaintHandler PaintEvent;

    /// <summary>
    /// 
    /// </summary>
    public int Id
    {
      get
      {
        return _id;
      }
      set
      {
        _id = value;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    public float X1
    {
      get
      {
        return _x1;
      }
      set
      {
        _x1 = value;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    public float Y1
    {
      get
      {
        return _y1;
      }
      set
      {
        _y1 = value;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    public float X2
    {
      get
      {
        return _x2;
      }
      set
      {
        _x2 = value;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    public float Y2
    {
      get
      {
        return _y2;
      }
      set
      {
        _y2 = value;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    public string Text
    {
      get
      {
        return _text;
      }
      set
      {
        _text = value;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    public MenuItemStatus ItemStatus
    {
      get
      {
        return _itemStatus;
      }
      set
      {
        _itemStatus = value;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="parId"></param>
    /// <param name="parX1"></param>
    /// <param name="parY1"></param>
    /// <param name="parX2"></param>
    /// <param name="parY2"></param>
    public TextField(int parId, float parX1, float parY1, float parX2, float parY2)
    {
      _id = parId;
      _x1 = parX1;
      _y1 = parY1;
      _x2 = parX2;
      _y2 = parY2;
      _text = string.Empty;
      _itemStatus = MenuItemStatus.Unselected;
    }

    /// <summary>
    /// 
    /// </summary>
    public void Initialize()
    {
      PaintEvent?.Invoke();
    }

    /// <summary>
    /// 
    /// </summary>
    public void CallClick()
    {
      Click?.Invoke(this, EventArgs.Empty);
    }

    public void AddChar(char parChar)
    {
      if (_itemStatus == MenuItemStatus.Selected)
      {
        _text += parChar;
      }

      PaintEvent?.Invoke();
    }

    public void DeleteLastChar()
    {
      if (_itemStatus == MenuItemStatus.Selected)
      {
        _text = _text.Substring(0, _text.Length - 1);
      }

      PaintEvent?.Invoke();
    }
  }
}
