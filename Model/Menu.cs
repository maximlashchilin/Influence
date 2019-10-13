using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public class Menu
  {
    private string _name;
    private SortedList<string, MenuItem> _menuItems;

    public Menu(string parName)
    {
      _name = parName;
    }

    public void AddItem(string parName)
    {
      if (null != parName)
      {
        _menuItems.Add(parName, new MenuItem(1, parName));
      }
    }
  }
}
