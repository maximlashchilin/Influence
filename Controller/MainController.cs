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
    private ApplicationStates _currentState;

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
      _currentState = ApplicationStates.MenuWork;
      _currentFactoryOfControllers = new FactoryOfMenuControllers();
      ChangeState(_currentState, _currentFactoryOfControllers);
      _platform.Initialize();
    }

    /// <summary>
    /// Изменяет состояние приложения
    /// </summary>
    /// <param name="parState">Состояние приложения</param>
    /// <param name="parFactoryOfContollers">Фабрика контроллера</param>
    private void ChangeState(ApplicationStates parState, FactoryOfContollers parFactoryOfContollers)
    { 
      _currentState = parState;
      _currentFactoryOfControllers = parFactoryOfContollers;
      if (parState != ApplicationStates.Exit)
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
