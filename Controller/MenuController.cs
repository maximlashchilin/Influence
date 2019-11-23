using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
{
  public class MenuController
  {
    private Menu _menu;

    public MenuController()
    {
      _menu = new Menu("Main");
      _menu.AddItem(0, "New game");
      _menu.AddItem(1, "Records");
      _menu.AddItem(2, "Exit");
    }

    private void OnClick(object parSender, EventArgs parEventArgs)
    {

    }

    private void OnMove(object parSender, EventArgs parEventArgs)
    {

    }

    private void OnArrowUp(object parSender, EventArgs parEventArgs)
    {
      _menu.Next();
    }

    private void OnArrowDown(object parSender, EventArgs parEventArgs)
    {
      _menu.Previous();
    }

    private void OnEnter(object parSender, EventArgs parEventArgs)
    {

    }
  }
}
