namespace Model
{
  /// <summary>
  /// Отвечает за логику совершения ходов
  /// </summary>
  public class MoveRunner
  {
    /// <summary>
    /// Массив ячеек
    /// </summary>
    private Cell[,] _cells;

    /// <summary>
    /// Массив ячеек
    /// </summary>
    public Cell[,] Cells
    {
      get
      {
        return _cells;
      }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parMap">Массив ячеек</param>
    public MoveRunner(Cell[,] parMap)
    {
      _cells = parMap;
    }

    /// <summary>
    /// Совершает ход
    /// </summary>
    /// <param name="parSourceCell">Исходная ячейка</param>
    /// <param name="parDestinationCell">Ячейка назначения</param>
    /// <param name="parCurrentPlayer">Текущий игрок</param>
    public void Move(Cell parSourceCell, Cell parDestinationCell, Player parCurrentPlayer)
    {
      if (IsMove(parSourceCell.I, parSourceCell.J, parDestinationCell.I, parDestinationCell.J)
          && parSourceCell.Score > 1
          && parDestinationCell.IsCellFree())
      {
        parDestinationCell.Owner = parCurrentPlayer;
        parDestinationCell.Score = parSourceCell.Score - 1;
        parSourceCell.Score = 1;
        parSourceCell.DisactiveCell();
        parDestinationCell.ActiveCell();
      }
      else if (IsMove(parSourceCell.I, parSourceCell.J, parDestinationCell.I, parDestinationCell.J)
          && parSourceCell.Score > 1
          && IsCellOccupied(parDestinationCell, parCurrentPlayer))
      {
        if (parSourceCell.Score > parDestinationCell.Score)
        {
          parSourceCell.Score = 1;
          parDestinationCell.Score = parSourceCell.Score - parDestinationCell.Score;
          parSourceCell.DisactiveCell();
          parDestinationCell.ActiveCell();
          parDestinationCell.Owner = parCurrentPlayer;
        }
        else if (parSourceCell.Score == parDestinationCell.Score)
        {
          parDestinationCell.Score = 1;
          parSourceCell.Score = 1;
        }
        else
        {
          parDestinationCell.Score = parDestinationCell.Score - (parSourceCell.Score - 1);
          parSourceCell.Score = 1;
        }
      }
    }

    /// <summary>
    /// Проверяет возможность совершения хода
    /// </summary>
    /// <param name="parSourceVerticalCoord">Индекс ряда исходной ячейки</param>
    /// <param name="parSourceHorizontalCoord">Индекс колонки исходной ячейки</param>
    /// <param name="parDestinationVerticalCoord">Индекс ряда ячейки назначения</param>
    /// <param name="parDestinationHorizontalCoord">Индекс колонки ячейки назначения</param>
    /// <returns>Признак возможности совершения хода</returns>
    public bool IsMove(int parSourceVerticalCoord, int parSourceHorizontalCoord,
        int parDestinationVerticalCoord, int parDestinationHorizontalCoord)
    {
      if (parDestinationHorizontalCoord < 0 || parDestinationVerticalCoord < 0)
      {
        return false;
      }

      if (parDestinationVerticalCoord > _cells.GetUpperBound(0) || parDestinationHorizontalCoord > _cells.GetUpperBound(1))
      {
        return false;
      }

      if (_cells[parDestinationVerticalCoord, parDestinationHorizontalCoord] == null)
      {
        return false;
      }

      if ((parSourceHorizontalCoord + 1 == parDestinationHorizontalCoord) && (parSourceVerticalCoord == parDestinationVerticalCoord)
        || (parSourceHorizontalCoord - 1 == parDestinationHorizontalCoord) && (parSourceVerticalCoord == parDestinationVerticalCoord))
      {
        return true;
      }

      if ((parSourceVerticalCoord + 1 == parDestinationVerticalCoord) && (parSourceHorizontalCoord == parDestinationHorizontalCoord)
        || (parSourceVerticalCoord - 1 == parDestinationVerticalCoord) && (parSourceHorizontalCoord == parDestinationHorizontalCoord))
      {
        return true;
      }

      if ((parSourceVerticalCoord % 2 == 0) 
          && (parSourceHorizontalCoord - 1 == parDestinationHorizontalCoord || parSourceHorizontalCoord == parDestinationHorizontalCoord))
      {
        return true;
      }

      if ((parSourceVerticalCoord % 2 == 1)
          && (parSourceHorizontalCoord + 1 == parDestinationHorizontalCoord || parSourceHorizontalCoord == parDestinationHorizontalCoord))
      {
        return true;
      }

      return false;
    }

    /// <summary>
    /// Проверяет, занята ли ячейка другим игроком
    /// </summary>
    /// <param name="parCell">Объект ячейки</param>
    /// <param name="parCurrentPlayer">Текущий игрок</param>
    /// <returns>Признак того, занята ли ячейка</returns>
    public bool IsCellOccupied(Cell parCell, Player parCurrentPlayer)
    {
      return parCell.Owner != parCurrentPlayer;
    }
  }
}
