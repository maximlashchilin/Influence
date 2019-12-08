using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public class Button
  {
    private string _name;

    private float _x1;

    private float _y1;

    private float _x2;

    private float _y2;

    public event EventHandler Click;

    public event dPaintHandler PaintEvent;

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

    public Button(float parX1, float parY1, float parX2, float parY2, string parName)
    {
      _x1 = parX1;
      _y1 = parY1;
      _x2 = parX2;
      _y2 = parY2;
      _name = parName;
    }

    public void CallClick()
    {
      Cursor cursor = Cursor.GetInstance();
      if ((cursor.X <= _x2) && (cursor.Y <= _y2)
          && (cursor.X >= _x1) && (cursor.Y >= _y1))
      {
        Click?.Invoke(this, EventArgs.Empty);
      }
    }

    public void CallPaintEvent()
    {
      PaintEvent?.Invoke();
    }
  }
}
