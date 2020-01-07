namespace Model
{
  /// <summary>
  /// Класс игрока
  /// </summary>
  public class Player
  {
    /// <summary>
    /// Имя игрока
    /// </summary>
    private readonly string _name;

    /// <summary>
    /// Цвет ячеек игрока
    /// </summary>
    private readonly ItemColors _itemColor;

    /// <summary>
    /// Счёт игрока
    /// </summary>
    private int _score;

    /// <summary>
    /// Имя игрока
    /// </summary>
    public string Name
    {
      get
      {
        return _name;
      }
    }

    /// <summary>
    /// Цвет ячеек игрока
    /// </summary>
    public ItemColors ItemColor
    {
      get
      {
        return _itemColor;
      }
    }

    /// <summary>
    /// Счёт игрока
    /// </summary>
    public int Score
    {
      get
      {
        return _score;
      }
      set
      {
        _score = value;
      }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parName">Имя игрока</param>
    /// <param name="parItemColor">Цвет ячеек игрока</param>
    public Player(string parName, ItemColors parItemColor)
    {
      _name = parName;
      _itemColor = parItemColor;
    }
  }
}
