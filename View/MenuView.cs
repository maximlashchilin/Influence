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
    /// <param name="parPlatform">Объект платформы</param>
    /// <param name="parMenu">Объект меню</param>
    public MenuView(Platform parPlatform, Menu parMenu) : base(parPlatform)
    {
      _menu = parMenu;
      _menu.ChangeStateEvent += Draw;
    }

    /// <summary>
    /// Отрисовывает меню
    /// </summary>
    public override void Draw()
    {
      const string GAME_NAME = "Influence";
      const float DELTA = 10.0f;
      const float X = 48.0f;
      const float Y = 10.0f;
      const float X_POINT = 40.0f;
      const float Y_POINT = 15.0f;

      Platform.Clear();
      Platform.PrintText(X, Y, GAME_NAME);
      for (int i = 0; i < _menu.MenuItems.Count; i++)
      {
        if (_menu.MenuItems[i].MenuItemStatus == ItemStatuses.Selected)
        {
          Platform.PrintMarkedTextInRectangle(X_POINT, Y_POINT + (i * DELTA), 60.0f, 17.0f + (i * DELTA), _menu.MenuItems[i].Name, false);
        }
        else
        {
          Platform.PrintTextInRectangle(X_POINT, Y_POINT + (i * DELTA), 60.0f, 17.0f + (i * DELTA), _menu.MenuItems[i].Name, false);
        }
      }
    }
  }
}
