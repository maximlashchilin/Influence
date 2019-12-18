﻿using View;

namespace Controller
{
  /// <summary>
  /// Контроллер игры
  /// </summary>
  public class GameController : BaseContoller
  {
    /// <summary>
    /// Платформа
    /// </summary>
    private Platform _platform;

    /// <summary>
    /// Текущий контроллер в игровом состоянии
    /// </summary>
    private BaseContoller _currentControllerInGameState;

    /// <summary>
    /// Контроллер ввода игроков
    /// </summary>
    private EnterOfPlayersController _enterOfPlayersController;

    /// <summary>
    /// Контроллер игрового поля
    /// </summary>
    private GameFieldController _gameFieldController;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parPlatform">Платформа</param>
    public GameController(Platform parPlatform)
    {
      _enterOfPlayersController = new EnterOfPlayersController(parPlatform);
      _currentControllerInGameState = _enterOfPlayersController;
      _enterOfPlayersController.CompleteEnterOfPlayers += OnCompleteEnterOfPlayers;
      _platform = parPlatform;
    }

    /// <summary>
    /// Обрабатывает событие завершения ввода игроков
    /// </summary>
    /// <param name="parObject">Отправитель события</param>
    /// <param name="parE">Параметры события</param>
    private void OnCompleteEnterOfPlayers(object parObject, CompleteEnterOfPlayersArgs parE)
    {
      _platform.UnsubscribeAllEvents();
      _gameFieldController = new GameFieldController(parE.Players, _platform);
      _currentControllerInGameState = _gameFieldController;
      _enterOfPlayersController = null;
    }

    public override void Start()
    {

    }
  }
}
