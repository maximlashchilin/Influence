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

    private FactoryOfContollers _currentFactoryOfControllers;

    public MainController(Platform parPlatform)
    {
      _platform = parPlatform;
      _platform.Initialize();
    }

    public void Start()
    {
      _applicationModel = new ApplicationModel();
      _previousState = _applicationModel.State;
      _currentFactoryOfControllers = new FactoryOfMenuControllers();
      _applicationModel.Start();
      _applicationModel.ApplicationStateEvent += ProcessCurrentStatus;
    }

    private void ProcessCurrentStatus()
    {
      ChangeState(_applicationModel.State, _currentFactoryOfControllers);
      while (_applicationModel.State != ApplicationState.Exit)
      {
        Thread.Sleep(10);

        if (_previousState != _applicationModel.State)
        {
          ChangeState(_applicationModel.State, _currentFactoryOfControllers);
        }
      }
    }

    private void ChangeState(ApplicationState parState, FactoryOfContollers parFactoryOfContollers)
    {
      _previousState = _applicationModel.State;

      switch (_applicationModel.State)
      {
        case ApplicationState.MenuWork:
          _currentFactoryOfControllers = new FactoryOfMenuControllers();
          break;
        case ApplicationState.Gaming:
          break;
        case ApplicationState.RecordsWatch:
          break;
      }

      _currentController = _currentFactoryOfControllers.CreateController(_platform);
    }
  }
}
