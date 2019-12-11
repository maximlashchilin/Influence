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
  /// <summary>
  /// Главный контроллер
  /// </summary>
  public class MainController
  {
    private Platform _platform;

    private ApplicationState _currentState;

    private ApplicationState _previousState;

    private BaseContoller _currentController;

    private FactoryOfContollers _currentFactoryOfControllers;

    private Thread _mainControllerThread;

    public MainController(Platform parPlatform)
    {
      _platform = parPlatform;
    }

    public void Start()
    {
      _currentState = ApplicationState.MenuWork;
      _previousState = _currentState;
      _currentFactoryOfControllers = new FactoryOfMenuControllers();
      _mainControllerThread = new Thread(ProcessCurrentStatus);
      _mainControllerThread.Start();
      _platform.Initialize();
    }

    private void ProcessCurrentStatus()
    {
      ChangeState(_currentState, _currentFactoryOfControllers);
      while (_currentState != ApplicationState.Exit)
      {
        //if (_previousState != _currentState)
        //{
        //  ChangeState(_currentState, _currentFactoryOfControllers);
        //}
      }
    }

    private void ChangeState(ApplicationState parState, FactoryOfContollers parFactoryOfContollers)
    { 
      _previousState = _currentState;
      _currentState = parState;
      _currentFactoryOfControllers = parFactoryOfContollers;
      if (parState != ApplicationState.Exit)
      {
        _currentController = _currentFactoryOfControllers.CreateController(_platform);
        _currentController.ChangeState += OnChangeState;
      }
      else
      {
        _platform.Drop();
      }
    }

    private void OnChangeState(object parSender, ChangeStateArgs parE)
    {
      _currentController.View.Platform.UnsubscribeAllEvents();
      ChangeState(parE.ApplicationState, parE.FactoryOfContollers);
    }
  }
}
