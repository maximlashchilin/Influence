using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace View
{
  public class MenuView : BaseView
  {
    private Menu _menu;

    public MenuView(Menu parMenu, Platform parPlatform) : base(parPlatform)
    {
      _menu = parMenu;
    }

    public override void Draw()
    {
      float delta = 1.0f;
      for (int i = 0; i < _menu.MenuItems.Count; i++)
      {
        Platform.PrintTextInRectangle(5.0f, 5.0f + i * delta, 15.0f, 7 + i * delta, _menu.MenuItems[i].Name);
      }
    }
  }
}
