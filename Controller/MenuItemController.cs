using System;
using Controller.FactoriesOfGameStateControllers;
using Model;
using View;

namespace Controller
{
  /// <summary>
  /// Контроллер элемента меню
  /// </summary>
  public class MenuItemController : BaseContoller
  {
    /// <summary>
    /// Экземпляр элемента меню
    /// </summary>
    private MenuItem _menuItem;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parPlatform">Платформа</param>
    /// <param name="parMenuItem">Элемент меню</param>
    public MenuItemController(Platform parPlatform, MenuItem parMenuItem)
    {
      _menuItem = parMenuItem;
      parPlatform.EnterDown += OnEnter;
    }

    /// <summary>
    /// Обрабатывает событие нажатия клавиши Enter
    /// </summary>
    /// <param name="parSender">Источник события</param>
    /// <param name="parE">Параметры события</param>
    private void OnEnter(object parSender, EventArgs parE)
    {
      if (_menuItem.MenuItemStatus == ItemStatuses.Selected)
      {
        switch (_menuItem.Id)
        {
          case 0:
            CallChangeState(this, new ChangeStateArgs(new FactoryOfGameControllers(), ApplicationStates.Gaming));
            break;
          case 1:
            CallChangeState(this, new ChangeStateArgs(new FactoryOfRecordsController(), ApplicationStates.RecordsWatch));
            break;
          case 2:
            CallChangeState(this, new ChangeStateArgs(new FactoryOfHelperControllers(), ApplicationStates.Help));
            break;
          case 3:
            CallChangeState(this, new ChangeStateArgs(null, ApplicationStates.Exit));
            break;
        }
      }
    }
  }
}
