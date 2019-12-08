using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using View;

namespace Controller
{
  public class MenuController : BaseContoller
  {
    private Menu _menu;

    private List<MenuItemController> _menuItemControllers;

    public MenuController(Platform parPlatform)
    {
      string menuName = "Main menu";
      _menu = new Menu(menuName);
      View = new MenuView(_menu, parPlatform);
      _menu.AddItem(0, "New game");
      _menu.AddItem(1, "Records");
      _menu.AddItem(2, "Help");
      _menu.AddItem(3, "Exit");
      _menu.Initialize();
      _menuItemControllers = InitMenuItemsControllers(parPlatform, _menu.MenuItems.ToList());

      parPlatform.ArrowUp += OnArrowUp;
      parPlatform.ArrowDown += OnArrowDown;
      Subscribe();
    }

    public override void Start()
    {
      
    }

    private List<MenuItemController> InitMenuItemsControllers(Platform parPlatform, List<KeyValuePair<int, MenuItem>> parMenuItems)
    {
      List<MenuItemController> controllers = new List<MenuItemController>();
      foreach (KeyValuePair<int, MenuItem> elItem in parMenuItems)
      {
        controllers.Add(new MenuItemController(parPlatform, elItem.Value));
      }

      return controllers;
    }

    private void Subscribe()
    {
      for (int i = 0; i < _menuItemControllers.Count; i++)
      {
        _menuItemControllers[i].ChangeState += OnChangeState;
      }
    }

    private void OnMove(object parSender, MoveEventArgs parEventArgs)
    {

    }

    private void OnArrowUp(object parSender, EventArgs parEventArgs)
    {
      _menu.Previous();
    }

    private void OnArrowDown(object parSender, EventArgs parEventArgs)
    {
      _menu.Next();
    }

    private void OnChangeState(object parSender, ChangeStateArgs parE)
    {
      CallChangeState(this, parE);
    }
  }
}
