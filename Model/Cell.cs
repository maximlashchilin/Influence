namespace Model
{
  /// <summary>
  /// Игровая ячейка
  /// </summary>
  public class Cell : Coords
  {
    /// <summary>
    /// Максимальное число очков в ячейке
    /// </summary>
    private const int MAX_SCORE = 8;

    /// <summary>
    /// Текущий статус ячейки
    /// </summary>
    private CellStatuses _cellStatus;

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
    public CellStatuses CellStatus
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
        if (value > 0 && value <= MAX_SCORE)
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
      _cellStatus = CellStatuses.NotChoosed;
    }

    /// <summary>
    /// Увеличивает счёт на единицу
    /// </summary>
    public void IncreaseScore()
    {
      if (_score <= MAX_SCORE)
      {
        _score++;
      }
    }

    /// <summary>
    /// Уменьшает счёт на единицу
    /// </summary>
    public void DecreaseScore()
    {
      if (_score > 0)
      {
        _score--;
      }
    }

    /// <summary>
    /// Делает ячейку активной
    /// </summary>
    public void ActiveCell()
    {
      _cellStatus = CellStatuses.Active;
    }

    /// <summary>
    /// Делает ячейку неактивной
    /// </summary>
    public void DisactiveCell()
    {
      _cellStatus = CellStatuses.NotChoosed;
    }

    /// <summary>
    /// Проверяет, имеет ли ячейка владельца
    /// </summary>
    /// <returns>Признак наличия владельца</returns>
    public bool IsCellFree()
    {
      return _owner == null;
    }
  }
}
