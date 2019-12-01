using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  /// <summary>
  /// Меню
  /// </summary>
  public class Menu
  {
    private string _name;
    private SortedList<int, MenuItem> _menuItems = new SortedList<int, MenuItem>();

    public delegate void dChangeSelectedElement();

    public event dChangeSelectedElement ChangeStateEvent;

    public string Name
    {
      get
      {
        return _name;
      }
    }

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

    public Menu(string parName)
    {
      _name = parName;
    }

    public void AddItem(int parId, string parName)
    {
      if (null != parName)
      {
        _menuItems.Add(parId, new MenuItem(parId, parName));
        if (parId == 0)
        {
          _menuItems[parId].MenuItemStatus = MenuItemStatus.Selected;
        }
        else
        {
          _menuItems[parId].MenuItemStatus = MenuItemStatus.Unselected;
        }
        ChangeStateEvent?.Invoke();
      }
    }

    public void Next()
    {
      for (int i = 0; i < _menuItems.Count; i++)
      {
        if (_menuItems[i].MenuItemStatus == MenuItemStatus.Selected)
        {
          _menuItems[i].MenuItemStatus = MenuItemStatus.Unselected;

          if (i == _menuItems.Count - 1)
          {
            _menuItems[0].MenuItemStatus = MenuItemStatus.Selected;
            break;
          }
          else
          {
            _menuItems[i + 1].MenuItemStatus = MenuItemStatus.Selected;
            break;
          }
        }
      }

      ChangeStateEvent?.Invoke();
    }

    public void Previous()
    {
      for (int i = 0; i < _menuItems.Count; i++)
      {
        if (_menuItems[i].MenuItemStatus == MenuItemStatus.Selected)
        {
          _menuItems[i].MenuItemStatus = MenuItemStatus.Unselected;

          if (i == 0)
          {
            _menuItems[_menuItems.Count - 1].MenuItemStatus = MenuItemStatus.Selected;
            break;
          }
          else
          {
            _menuItems[i - 1].MenuItemStatus = MenuItemStatus.Selected;
            break;
          }
        }
      }

      ChangeStateEvent?.Invoke();
    }

    public void SelectItem()
    {

    }
  }
}
