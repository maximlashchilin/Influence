using System;
using System.Collections.Generic;
using Controller.FactoriesOfGameStateControllers;
using Model;
using View;

namespace Controller
{
  /// <summary>
  /// Контроллер игрового поля
  /// </summary>
  public class GameFieldController : BaseContoller
  {
    /// <summary>
    /// Число рядов
    /// </summary>
    private const int VERTICAL_SIZE = 6;

    /// <summary>
    /// Число ячеек в строке
    /// </summary>
    private const int HORIZONTAL_SIZE = 4;

    /// <summary>
    /// Экземпляр игрового поля
    /// </summary>
    private GameField _game;

    /// <summary>
    /// Контроллер кнопки
    /// </summary>
    private ButtonController _buttonController;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parPlayers">Игроки</param>
    /// <param name="parPlatform">Платформа</param>
    public GameFieldController(List<Player> parPlayers, Platform parPlatform)
    {
      _game = new GameField(VERTICAL_SIZE, HORIZONTAL_SIZE, parPlayers);
      _buttonController = new ButtonController(parPlatform, _game.Button);
      View = new GameFieldView(parPlatform, _game, (ButtonView)_buttonController.View);
      _game.Initialize();
      _buttonController.Initialize();
      _game.Button.Click += OnButtonClick;

      parPlatform.EscDown += OnEscDown;
      parPlatform.Move += OnMove;
      parPlatform.Click += OnClick;
    }

    /// <summary>
    /// Обрабатывает нажатие Esc
    /// </summary>
    /// <param name="parSender">Источник события</param>
    /// <param name="parE">Параметры события</param>
    private void OnEscDown(object parSender, EventArgs parE)
    {
      CallChangeState(this, new ChangeStateArgs(new FactoryOfMenuControllers(), ApplicationStates.MenuWork));
    }

    /// <summary>
    /// Обрабатывает нажатие на кнопку
    /// </summary>
    /// <param name="parSender">Источник события</param>
    /// <param name="parE">Параметры события</param>
    private void OnButtonClick(object parSender, EventArgs parE)
    {
      _game.CompleteAtackOrPassMove();
    }

    /// <summary>
    /// Обрабатывает событие клика по поверхности платформы
    /// </summary>
    /// <param name="parSender">Источник события</param>
    /// <param name="parE">Параметры события</param>
    private void OnClick(object parSender, EventArgs parE)
    {
      _game.PerformGameAction();
    }

    /// <summary>
    /// Обрабатывает событие перемещения мыши
    /// </summary>
    /// <param name="parSender">Источник события</param>
    /// <param name="parE">Параметры события</param>
    private void OnMove(object parSender, MoveEventArgs parE)
    {
      Cursor.GetInstance().Move(parE.X, parE.Y);
    }
  }
}
