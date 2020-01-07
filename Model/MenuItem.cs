namespace Model
{
  /// <summary>
  /// Элемент меню
  /// </summary>
  public class MenuItem
  {
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
    /// Идентификатор элемента меню
    /// </summary>
    public int Id
    {
      get
      {
        return _id;
      }
    }

    /// <summary>
    /// Название элемента меню
    /// </summary>
    public string Name
    {
      get
      {
        return _name;
      }
    }

    /// <summary>
    /// Статус элемента меню
    /// </summary>
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

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parId">Идентификатор</param>
    /// <param name="parName">Название элемента</param>
    public MenuItem(int parId, string parName)
    {
      _id = parId;
      _name = parName;
    }
  }
}
