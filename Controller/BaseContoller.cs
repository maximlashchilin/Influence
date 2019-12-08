using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View;
using Model;

namespace Controller
{
  public abstract class BaseContoller
  {
    private BaseView _view;

    public event dChangeStateHandler ChangeState;

    public BaseView View
    {
      get
      {
        return _view;
      }
      set
      {
        _view = value;
      }
    }

    public abstract void Start();

    public void CallChangeState(object parSender, ChangeStateArgs parE)
    {
      ChangeState?.Invoke(parSender, parE);
    }
  }
}
