using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
{
  public class ChangeStateArgs : EventArgs
  {
    private FactoryOfContollers _factoryOfContollers;

    private ApplicationState _applicationState;

    public FactoryOfContollers FactoryOfContollers
    {
      get
      {
        return _factoryOfContollers;
      }
    }

    public ApplicationState ApplicationState
    {
      get
      {
        return _applicationState;
      }
    }

    public ChangeStateArgs(FactoryOfContollers parFactory, ApplicationState parState)
    {
      _factoryOfContollers = parFactory;
      _applicationState = parState;
    }
  }
}
