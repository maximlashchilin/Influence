using System;
using System.Collections.Generic;
using Model;
using View;
using Controller.FactoriesOfGameStateControllers;

namespace Controller
{
  /// <summary>
  /// Контроллер ввода игроков
  /// </summary>
  public class EnterOfPlayersController : BaseContoller
  {
    /// <summary>
    /// Событие завершения ввода игроков
    /// </summary>
    public event dCompleteEnterOfPlayers CompleteEnterOfPlayers;

    /// <summary>
    /// Экземпляр ввода игроков
    /// </summary>
    private EnterOfPlayers _enterOfPlayers;

    /// <summary>
    /// Контроллеры текстовых полей
    /// </summary>
    private List<TextFieldController> _textFieldControllers;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parPlatform">Платформа</param>
    public EnterOfPlayersController(Platform parPlatform)
    {
      _enterOfPlayers = new EnterOfPlayers();
      _textFieldControllers = InitizlizeTextFieldControllers(parPlatform, _enterOfPlayers.NamesOfPlayers);
      View = new EnterOfPlayersView(_enterOfPlayers, GetTextFieldViews(), parPlatform);
      _enterOfPlayers.Initialize();

      parPlatform.ArrowUp += OnArrowUp;
      parPlatform.ArrowDown += OnArrowDown;
      parPlatform.EnterDown += OnEnterDown;
      parPlatform.TabDown += OnTabDown;
      parPlatform.EscDown += OnEscDown;
    }

    /// <summary>
    /// Обрабатывает нажатие Tab
    /// </summary>
    /// <param name="parSender">Источник события</param>
    /// <param name="parE">Параметры события</param>
    private void OnTabDown(object parSender, EventArgs parE)
    {
      _enterOfPlayers.Next();
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
    /// Инициализирует контроллеры текстовых полей
    /// </summary>
    /// <param name="parPlatform">Платформа</param>
    /// <param name="parTextFields">Текстовые поля</param>
    /// <returns>Список контроллеров текстовых полей</returns>
    private List<TextFieldController> InitizlizeTextFieldControllers(Platform parPlatform, List<TextField> parTextFields)
    {
      List<TextFieldController> controllers = new List<TextFieldController>();
      foreach (TextField elItem in parTextFields)
      {
        controllers.Add(new TextFieldController(elItem, parPlatform));
      }

      return controllers;
    }

    /// <summary>
    /// Получает представления текстовых полей
    /// </summary>
    /// <returns>Список представлений текстовых полей</returns>
    private List<TextFieldView> GetTextFieldViews()
    {
      List<TextFieldView> views = new List<TextFieldView>();
      foreach (TextFieldController elTextFieldController in _textFieldControllers)
      {
        views.Add((TextFieldView)elTextFieldController.View);
      }

      return views;
    }

    /// <summary>
    /// Обрабатывает нажатие кнопки Enter
    /// </summary>
    /// <param name="parSender">Источник события</param>
    /// <param name="parE">Параметры события</param>
    private void OnEnterDown(object parSender, EventArgs parE)
    {
      List<Player> players = new List<Player>();
      players.Add(new Player(_enterOfPlayers.NamesOfPlayers[0].Text, ItemColors.Red));
      players.Add(new Player(_enterOfPlayers.NamesOfPlayers[1].Text, ItemColors.Green));

      CompleteEnterOfPlayers(this, new CompleteEnterOfPlayersArgs(players));
    }

    /// <summary>
    /// Обрабатывает нажатие стрелки вниз
    /// </summary>
    /// <param name="parSender">Источник события</param>
    /// <param name="parE">Параметры события</param>
    private void OnArrowDown(object parSender, EventArgs parE)
    {
      _enterOfPlayers.Next();
    }

    /// <summary>
    /// Обрабатывает нажатие стрелки вверх
    /// </summary>
    /// <param name="parSender">Источник события</param>
    /// <param name="parE">Параметры события</param>
    private void OnArrowUp(object parSender, EventArgs parE)
    {
      _enterOfPlayers.Previous();
    }
  }
}
