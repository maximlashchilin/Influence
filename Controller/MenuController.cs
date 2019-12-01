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

    public MenuController(Platform parPlatform)
    {
      string menuName = "Main menu";
      _menu = new Menu(menuName);
      View = new MenuView(_menu, parPlatform);
      _menu.AddItem(0, "New game");
      _menu.AddItem(1, "Records");
      _menu.AddItem(2, "Exit");

      parPlatform.EnterDown += OnEnter;
      parPlatform.ArrowUp += OnArrowUp;
      parPlatform.ArrowDown += OnArrowDown;
    }

    private void OnClick(object parSender, EventArgs parEventArgs)
    {

    }

    private void OnMove(object parSender, EventArgs parEventArgs)
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

    private void OnEnter(object parSender, EventArgs parEventArgs)
    {

    }
  }
}
