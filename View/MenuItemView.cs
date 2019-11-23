using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace View
{
  public class MenuItemView : BaseView
  {
    private MenuItem _menuItem;

    public MenuItemView(MenuItem parMenuItem, Platform parPlatform) : base(parPlatform)
    {
      _menuItem = parMenuItem;
    }

    public override void Draw()
    {
      throw new NotImplementedException();
    }
  }
}
