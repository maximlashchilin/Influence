using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public class MenuItem
  {
    private int _id;
    private string _name;
    private MenuItemStatus _menuItemStatus;
    public delegate void dChangeStatusHandler();
    public event dChangeStatusHandler ChangeStatus = null;

    public MenuItemStatus MenuItemStatus
    {
      get
      {
        return _menuItemStatus;
      }
      set
      {
        _menuItemStatus = value;
      }
    }

    public MenuItem(int parId, string parName)
    {
      _name = parName;
    }

    public void CallChangeStatus()
    {
      ChangeStatus?.Invoke();
    }
  }
}
