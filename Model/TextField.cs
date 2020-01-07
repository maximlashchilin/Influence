using System;

namespace Model
{
  /// <summary>
  /// Текстовое поле
  /// </summary>
  public class TextField
  {
    /// <summary>
    /// Событие перерисовки
    /// </summary>
    public event dPaintHandler PaintEvent;

    /// <summary>
    /// Идентификатор
    /// </summary>
    private int _id;

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
    /// Текст
    /// </summary>
    private string _text;

    /// <summary>
    /// Статус текстового поля
    /// </summary>
    private ItemStatuses _itemStatus;

    /// <summary>
    /// Идентификатор
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
    /// Текст
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
    /// Статус текстового поля
    /// </summary>
    public ItemStatuses ItemStatus
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
    /// Конструктор
    /// </summary>
    /// <param name="parId">Идентификатор</param>
    /// <param name="parX1">Координата X1</param>
    /// <param name="parY1">Координата Y1</param>
    /// <param name="parX2">Координата X2</param>
    /// <param name="parY2">Координата Y2</param>
    public TextField(int parId, float parX1, float parY1, float parX2, float parY2)
    {
      _id = parId;
      _x1 = parX1;
      _y1 = parY1;
      _x2 = parX2;
      _y2 = parY2;
      _text = string.Empty;
      _itemStatus = ItemStatuses.Unselected;
    }

    /// <summary>
    /// Инициализирует текстовое поле
    /// </summary>
    public void Initialize()
    {
      PaintEvent?.Invoke();
    }

    /// <summary>
    /// Добавляет символ в текстовое поле
    /// </summary>
    /// <param name="parChar">Добавляемый символ</param>
    public void AddChar(char parChar)
    {
      if (_itemStatus == ItemStatuses.Selected)
      {
        _text += parChar;
      }

      PaintEvent?.Invoke();
    }

    /// <summary>
    /// Удаляет последний символ из текстового поля
    /// </summary>
    public void DeleteLastChar()
    {
      if (_itemStatus == ItemStatuses.Selected && _text.Length > 0)
      {
        _text = _text.Substring(0, _text.Length - 1);
      }

      PaintEvent?.Invoke();
    }
  }
}
