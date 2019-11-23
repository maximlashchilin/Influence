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
      throw new NotImplementedException();
    }
  }
}
