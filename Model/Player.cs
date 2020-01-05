namespace Model
{
  /// <summary>
  /// Класс игрока
  /// </summary>
  public class Player
  {
    private readonly string _name;

    private readonly ItemColor _itemColor;

    private int _score;

    public string Name
    {
      get
      {
        return _name;
      }
    }

    public ItemColor ItemColor
    {
      get
      {
        return _itemColor;
      }
    }

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

    public Player(string parName, ItemColor parItemColor)
    {
      _name = parName;
      _itemColor = parItemColor;
    }
  }
}
