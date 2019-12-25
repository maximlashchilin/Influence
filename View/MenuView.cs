using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace View
{
  /// <summary>
  /// Представление меню
  /// </summary>
  public class MenuView : BaseView
  {
    /// <summary>
    /// Объект меню
    /// </summary>
    private Menu _menu;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parMenu">Объект меню</param>
    /// <param name="parPlatform">Объект платформы</param>
    public MenuView(Menu parMenu, Platform parPlatform) : base(parPlatform)
    {
      _menu = parMenu;
      _menu.ChangeStateEvent += Draw;
    }

    /// <summary>
    /// Отрисовывает меню
    /// </summary>
    public override void Draw()
    {
      float delta = 10.0f;

      Platform.Clear();
      for (int i = 0; i < _menu.MenuItems.Count; i++)
      {
        if (_menu.MenuItems[i].MenuItemStatus == MenuItemStatus.Selected)
        {
          Platform.PrintMarkedTextInRectangle(40.0f, 5.0f + (i * delta), 60.0f, 7.0f + (i * delta), _menu.MenuItems[i].Name, false);
        }
        else
        {
          Platform.PrintTextInRectangle(40.0f, 5.0f + (i * delta), 60.0f, 7.0f + (i * delta), _menu.MenuItems[i].Name, false);
        }
      }
    }
  }
}
