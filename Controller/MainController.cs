using System.Threading;
using Model;
using View;
using Controller.FactoriesOfGameStateControllers;

namespace Controller
{
  /// <summary>
  /// Главный контроллер
  /// </summary>
  public class MainController
  {
    /// <summary>
    /// Платформа
    /// </summary>
    private Platform _platform;

    /// <summary>
    /// Текущее состояние
    /// </summary>
    private ApplicationState _currentState;

    /// <summary>
    /// Предыдущее состояние
    /// </summary>
    private ApplicationState _previousState;

    /// <summary>
    /// Экземпляр текущего контроллера состояния
    /// приложения
    /// </summary>
    private BaseContoller _currentController;

    /// <summary>
    /// Экземпляр текущей фабрики контроллера
    /// </summary>
    private FactoryOfContollers _currentFactoryOfControllers;

    /// <summary>
    /// Поток главного контроллера
    /// </summary>
    private Thread _mainControllerThread;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parPlatform">Платформа</param>
    public MainController(Platform parPlatform)
    {
      _platform = parPlatform;
    }

    /// <summary>
    /// Запускает главный контроллер
    /// </summary>
    public void Start()
    {
      _currentState = ApplicationState.MenuWork;
      _previousState = _currentState;
      _currentFactoryOfControllers = new FactoryOfMenuControllers();
      _mainControllerThread = new Thread(ProcessCurrentStatus);
      _mainControllerThread.Start();
      _platform.Initialize();
    }

    /// <summary>
    /// Обрабатывает текущее состояние приложения
    /// </summary>
    private void ProcessCurrentStatus()
    {
      ChangeState(_currentState, _currentFactoryOfControllers);
      while (_currentState != ApplicationState.Exit)
      {
        if (_previousState != _currentState)
        {
        //  ChangeState(_currentState, _currentFactoryOfControllers);
        }
      }
    }

    /// <summary>
    /// Изменяет состояние приложения
    /// </summary>
    /// <param name="parState">Состояние приложения</param>
    /// <param name="parFactoryOfContollers">Фабрика контроллера</param>
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

    /// <summary>
    /// Обрабатывает событие изменения
    /// состояния приложения
    /// </summary>
    /// <param name="parSender">Источник события</param>
    /// <param name="parE">Параметры события</param>
    private void OnChangeState(object parSender, ChangeStateArgs parE)
    {
      _currentController.View?.Platform.UnsubscribeAllEvents();
      ChangeState(parE.ApplicationState, parE.FactoryOfContollers);
    }
  }
}
