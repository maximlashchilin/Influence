﻿using System;
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
      _menu.ChangeStateEvent += Draw;
    }

    public override void Draw()
    {
      float delta = 3.0f;
      for (int i = 0; i < _menu.MenuItems.Count; i++)
      {
        if (_menu.MenuItems[i].MenuItemStatus == MenuItemStatus.Selected)
        {
          Platform.PrintMarkedTextInRectangle(10.0f, 5.0f + (i * delta), 35.0f, 7.0f + (i * delta), _menu.MenuItems[i].Name);
        }
        else
        {
          Platform.PrintTextInRectangle(10.0f, 5.0f + (i * delta), 35.0f, 7.0f + (i * delta), _menu.MenuItems[i].Name);
        }
      }
    }
  }
}
