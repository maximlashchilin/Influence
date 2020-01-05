using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  /// <summary>
  /// Элемент меню
  /// </summary>
  public class MenuItem
  {
    #region Поля класса
    /// <summary>
    /// Идентификатор элемента меню
    /// </summary>
    private int _id;
    /// <summary>
    /// Название элемента меню
    /// </summary>
    private string _name;
    /// <summary>
    /// Статус элемента меню
    /// </summary>
    private ItemStatuses _menuItemStatus;
    /// <summary>
    /// 
    /// </summary>
    public delegate void dChangeStatusHandler();
    /// <summary>
    /// Событие изменения статуса элемента
    /// </summary>
    public event dChangeStatusHandler ChangeStatus;
    #endregion

    #region Свойства класса
    public int Id
    {
      get
      {
        return _id;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    public string Name
    {
      get
      {
        return _name;
      }
    }
    public ItemStatuses MenuItemStatus
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
    #endregion

    #region Конструктор класса
    /// <summary>
    /// 
    /// </summary>
    /// <param name="parId"></param>
    /// <param name="parName"></param>
    public MenuItem(int parId, string parName)
    {
      _id = parId;
      _name = parName;
    }
    #endregion

    /// <summary>
    /// 
    /// </summary>
    public void CallChangeStatus()
    {
      ChangeStatus?.Invoke();
    }
  }
}
