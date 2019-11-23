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
    //private int _currentItem;

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

    //public int CurrentItem
    //{
    //  get
    //  {
    //    return _currentItem;
    //  }
    //  set
    //  {
    //    _currentItem = value;
    //  }
    //}

    public Menu(string parName)
    {
      _name = parName;
      //_currentItem = -1;
    }

    public void AddItem(int id, string parName)
    {
      if (null != parName)
      {
        // проверять id на существование
        _menuItems.Add(id, new MenuItem(id, parName));
      }
    }

    public void DeleteItem(string parName)
    {
      throw new NotImplementedException();
    }

    public void Next()
    {
      foreach (KeyValuePair<int, MenuItem> elItem in _menuItems)
      {
        if (MenuItemStatus.Selected == elItem.Value.MenuItemStatus)
        {
          elItem.Value.MenuItemStatus = MenuItemStatus.Unselected;
          
          if (elItem.Key == _menuItems.Count - 1)
          {
            _menuItems[0].MenuItemStatus = MenuItemStatus.Selected;
          }
          else
          {
            _menuItems[elItem.Key + 1].MenuItemStatus = MenuItemStatus.Selected;
          }
        }
      }
    }

    public void Previous()
    {
      foreach (KeyValuePair<int, MenuItem> elItem in _menuItems)
      {
        if (MenuItemStatus.Selected == elItem.Value.MenuItemStatus)
        {
          elItem.Value.MenuItemStatus = MenuItemStatus.Unselected;

          if (elItem.Key == 0)
          {
            _menuItems[_menuItems.Count - 1].MenuItemStatus = MenuItemStatus.Selected;
          }
          else
          {
            _menuItems[elItem.Key - 1].MenuItemStatus = MenuItemStatus.Selected;
          }
        }
      }
    }

    public void SelectItem()
    {

    }
  }
}
