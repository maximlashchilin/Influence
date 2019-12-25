using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
  public class MoveEventArgs : EventArgs
  {
    private float _x;
    private float _y;

    public float X
    {
      get
      {
        return _x;
      }
    }

    public float Y
    {
      get
      {
        return _y;
      }
    }

    public MoveEventArgs(float parX, float parY)
    {
      _x = parX;
      _y = parY;
    }
  }
}
