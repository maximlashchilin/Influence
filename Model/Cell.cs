using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  /// <summary>
  /// Класс игровой ячейки
  /// </summary>
  public class Cell
  {
    private const int MAX_SCORE = 8;
    /// <summary>
    /// Текущий статус ячейки
    /// </summary>
    private CellStatus _cellStatus;
    /// <summary>
    /// Число очков ячейки
    /// </summary>
    private int _score;

    private Player _owner;

    private int _x;
    private int _y;

    /// <summary>
    /// Текущий статус ячейки
    /// </summary>
    public CellStatus CellStatus
    {
      get
      {
        return _cellStatus;
      }
      set
      {
        _cellStatus = value;
      }
    }

    /// <summary>
    /// Число очков ячейки
    /// </summary>
    public int Score
    {
      get
      {
        return _score;
      }
      set
      {
        if (value > 0 || value <= MAX_SCORE)
        {
          _score = value;
        }
      }
    }

    public Player Owner
    {
      get
      {
        return _owner;
      }
      set
      {
        _owner = value;
      }
    }
    public int X
    {
      get
      {
        return _x;
      }
    }

    public int Y
    {
      get
      {
        return _y;
      }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    public Cell()
    {
      _score = 0;
      _cellStatus = CellStatus.NotChoosed;
    }

    /// <summary>
    /// Метод увеличения счёта на единицу
    /// </summary>
    public void IncreaseScore()
    {
      _score++;
    }

    /// <summary>
    /// Метод уменьшения счёта на единицу
    /// </summary>
    public void DecreaseScore()
    {
      _score--;
    }

    /// <summary>
    /// Метод, делающий ячейку активной
    /// </summary>
    public void ActiveCell()
    {
      _cellStatus = CellStatus.Active;
    }

    /// <summary>
    /// Метод, делающий ячейку неактивной
    /// </summary>
    public void DisactiveCell()
    {
      _cellStatus = CellStatus.NotChoosed;
    }
  }
}
