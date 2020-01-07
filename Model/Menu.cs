using System.Collections.Generic;

namespace Model
{
  /// <summary>
  /// Меню
  /// </summary>
  public class Menu
  {
    /// <summary>
    /// Событие перерисовки
    /// </summary>
    public event dPaintHandler PaintEvent;

    /// <summary>
    /// Название меню
    /// </summary>
    private string _name;

    /// <summary>
    /// Список пунктов меню
    /// </summary>
    private SortedList<int, MenuItem> _menuItems = new SortedList<int, MenuItem>();

    /// <summary>
    /// Название меню
    /// </summary>
    public string Name
    {
      get
      {
        return _name;
      }
    }

    /// <summary>
    /// Список пунктов меню
    /// </summary>
    public SortedList<int, MenuItem> MenuItems
    {
      get
      {
        return _menuItems;
      }
      set
      {
        _menuItems = value;
      }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parName">Название меню</param>
    public Menu(string parName)
    {
      _name = parName;
    }

    /// <summary>
    /// Инициализирует меню
    /// </summary>
    public void Initialize()
    {
      PaintEvent?.Invoke();
    }

    /// <summary>
    /// Добавляет элемент в меню
    /// </summary>
    /// <param name="parId">Идентификатор</param>
    /// <param name="parName">Название пункта</param>
    public void AddItem(int parId, string parName)
    {
      if (null != parName)
      {
        _menuItems.Add(parId, new MenuItem(parId, parName));
        if (parId == 0)
        {
          _menuItems[parId].MenuItemStatus = ItemStatuses.Selected;
        }
        else
        {
          _menuItems[parId].MenuItemStatus = ItemStatuses.Unselected;
        }
      }
    }

    /// <summary>
    /// Переводит фокус на следующиий элемент меню
    /// </summary>
    public void Next()
    {
      for (int i = 0; i < _menuItems.Count; i++)
      {
        if (_menuItems[i].MenuItemStatus == ItemStatuses.Selected)
        {
          _menuItems[i].MenuItemStatus = ItemStatuses.Unselected;

          if (i == _menuItems.Count - 1)
          {
            _menuItems[0].MenuItemStatus = ItemStatuses.Selected;
            break;
          }
          else
          {
            _menuItems[i + 1].MenuItemStatus = ItemStatuses.Selected;
            break;
          }
        }
      }

      PaintEvent?.Invoke();
    }

    /// <summary>
    /// Переводит фокус на предыдущий элемент меню
    /// </summary>
    public void Previous()
    {
      for (int i = 0; i < _menuItems.Count; i++)
      {
        if (_menuItems[i].MenuItemStatus == ItemStatuses.Selected)
        {
          _menuItems[i].MenuItemStatus = ItemStatuses.Unselected;

          if (i == 0)
          {
            _menuItems[_menuItems.Count - 1].MenuItemStatus = ItemStatuses.Selected;
            break;
          }
          else
          {
            _menuItems[i - 1].MenuItemStatus = ItemStatuses.Selected;
            break;
          }
        }
      }

      PaintEvent?.Invoke();
    }
  }
}
