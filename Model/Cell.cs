using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  /// <summary>
  /// Игровая ячейка
  /// </summary>
  public class Cell
  {
    /// <summary>
    /// Максимальное число очков в ячейке
    /// </summary>
    private const int MAX_SCORE = 8;

    /// <summary>
    /// Текущий статус ячейки
    /// </summary>
    private CellStatus _cellStatus;

    /// <summary>
    /// Число очков ячейки
    /// </summary>
    private int _score;

    /// <summary>
    /// Владелец ячейки
    /// </summary>
    private Player _owner;

    /// <summary>
    /// Горизонтальная координата ячейки
    /// </summary>
    private float _x;

    /// <summary>
    /// Вертикальная координата ячейки
    /// </summary>
    private float _y;

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

    /// <summary>
    /// Владелец ячейки
    /// </summary>
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

    /// <summary>
    /// Горизонтальная координата ячейки
    /// </summary>
    public float X
    {
      get
      {
        return _x;
      }
      set
      {
        _x = value;
      }
    }

    /// <summary>
    /// Вертикальная координата ячейки
    /// </summary>
    public float Y
    {
      get
      {
        return _y;
      }
      set
      {
        _y = value;
      }
    }

    /// <summary>
    /// Конструктор ячейки
    /// </summary>
    /// <param name="parX">Горизонтальная координата</param>
    /// <param name="parY">Вертикальная координата</param>
    public Cell(float parX, float parY)
    {
      _x = parX;
      _y = parY;
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
