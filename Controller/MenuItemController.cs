using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using View;

namespace Controller
{
  public class MenuItemController : BaseContoller
  {
    private MenuItem _menuItem;

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
