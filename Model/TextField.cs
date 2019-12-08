using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public class TextField
  {
    private int _id;

    private float _x1;

    private float _y1;

    private float _x2;

    private float _y2;

    private string _text;

    public event EventHandler Click;

    public event dPaintHandler PaintEvent;

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

    public TextField(int parId, float parX1, float parY1, float parX2, float parY2)
    {
      _id = parId;
      _x1 = parX1;
      _y1 = parY1;
      _x2 = parX2;
      _y2 = parY2;
      _text = string.Empty;
    }

    public void Initialize()
    {

    }
  }
}
