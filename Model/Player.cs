using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  /// <summary>
  /// Класс игрока
  /// </summary>
  public class Player
  {
    private readonly string _name;

    private readonly ItemColor _itemColor;

    private bool _signOfMove;

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

    public bool IsActivePlayer
    {
      get
      {
        return _signOfMove;
      }
    }

    public Player(string parName, ItemColor parItemColor)
    {
      _name = parName;
      _itemColor = parItemColor;
    }

    public void StartMove()
    {
      _signOfMove = true;
    }

    public void FinishMove()
    {
      _signOfMove = false;
    }
  }
}
