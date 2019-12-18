using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
      parPlatform.Click += OnClick;
    }

    public override void Start()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Обрабатывает событие нажатия клавиши Enter
    /// </summary>
    /// <param name="parSender"></param>
    /// <param name="parE"></param>
    private void OnEnter(object parSender, EventArgs parE)
    {
      if (_menuItem.MenuItemStatus == MenuItemStatus.Selected)
      {
        switch (_menuItem.Id)
        {
          case 0:
            CallChangeState(this, new ChangeStateArgs(new FactoryOfGameControllers(), ApplicationState.Gaming));
            break;
          case 1:
            CallChangeState(this, new ChangeStateArgs(new FactoryOfGameControllers(), ApplicationState.Gaming));
            break;
          case 2:
            CallChangeState(this, new ChangeStateArgs(new FactoryOfGameControllers(), ApplicationState.Gaming));
            break;
          case 3:
            CallChangeState(this, new ChangeStateArgs(null, ApplicationState.Exit));
            break;
        }
      }
    }

    private void OnClick(object parSender, EventArgs parE)
    {

    }
  }
}
