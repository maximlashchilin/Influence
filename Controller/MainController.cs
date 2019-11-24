using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Model;
using View;

namespace Controller
{
  public class MainController
  {
    private ApplicationModel _applicationModel;

    private Platform _platform;

    private ApplicationState _previousState;

    private BaseContoller _currentController;

    public MainController(Platform parPlatform)
    {
      _platform = parPlatform;
    }

    public void Start()
    {
      _applicationModel = new ApplicationModel();
      _previousState = _applicationModel.State;
      _applicationModel.Start();
      _applicationModel.ApplicationStateEvent += ProcessCurrentStatus;
    }

    private void ProcessCurrentStatus()
    {
      //int k = 0;
      while (_applicationModel.State != ApplicationState.Exit)
      {
        Thread.Sleep(100);

        ChangeState(_applicationModel.State, new FactoryOfMenuControllers());
        if (_previousState != _applicationModel.State)
        {
          

          switch (_applicationModel.State)
          {
            case ApplicationState.MenuWork:
              new FactoryOfMenuControllers().CreateController(_platform);
              break;
            default:
              throw new NotImplementedException();
          }
        }
        //if (k == 10)
        //{
        //  _applicationModel.State = ApplicationState.Exit;
        //}
        //k++;
      }
    }

    private void ChangeState(ApplicationState parState, FactoryOfContollers parFactoryOfContollers)
    {
      _previousState = _applicationModel.State;

      _currentController = parFactoryOfContollers.CreateController(_platform);
    }
  }
}
