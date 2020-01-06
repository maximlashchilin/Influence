using System;

namespace Model
{
  /// <summary>
  /// Кнопка
  /// </summary>
  public class Button
  {
    /// <summary>
    /// Событие нажатия на кнопку
    /// </summary>
    public event EventHandler Click;

    /// <summary>
    /// Событие перерисовки кнопки
    /// </summary>
    public event dPaintHandler PaintEvent;

    /// <summary>
    /// Название кнопки
    /// </summary>
    private string _name;

    /// <summary>
    /// Координата X1
    /// </summary>
    private float _x1;

    /// <summary>
    /// Координата Y1
    /// </summary>
    private float _y1;

    /// <summary>
    /// Координата X2
    /// </summary>
    private float _x2;

    /// <summary>
    /// Координата Y2
    /// </summary>
    private float _y2;

    /// <summary>
    /// Название кнопки
    /// </summary>
    public string Name
    {
      get
      {
        return _name;
      }
      set
      {
        _name = value;
      }
    }

    /// <summary>
    /// Координата X1
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
    /// Координата Y1
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
    /// Координата X2
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
    /// Координата Y2
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
    /// Конструктор
    /// </summary>
    /// <param name="parX1">Координата X1</param>
    /// <param name="parY1">Координата Y1</param>
    /// <param name="parX2">Координата X2</param>
    /// <param name="parY2">Координата Y2</param>
    /// <param name="parName">Название</param>
    public Button(float parX1, float parY1, float parX2, float parY2, string parName)
    {
      _x1 = parX1;
      _y1 = parY1;
      _x2 = parX2;
      _y2 = parY2;
      _name = parName;
    }

    /// <summary>
    /// Вызывает событие нажатия на кнопку
    /// </summary>
    public void CallClick()
    {
      Cursor cursor = Cursor.GetInstance();
      if ((cursor.X <= _x2) && (cursor.Y <= _y2)
          && (cursor.X >= _x1) && (cursor.Y >= _y1))
      {
        Click?.Invoke(this, EventArgs.Empty);
      }
    }

    /// <summary>
    /// Вызывает событие перерисовки
    /// </summary>
    public void CallPaintEvent()
    {
      PaintEvent?.Invoke();
    }
  }
}
