using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  /// <summary>
  /// Класс игрового поля
  /// </summary>
  public class GameField
  {
    /// <summary>
    /// Ячейки игрового поля
    /// </summary>
    private Cell[,] _cells;

    /// <summary>
    /// 
    /// </summary>
    private List<Player> _players;

    /// <summary>
    /// 
    /// </summary>
    private int _currentPlayer;

    /// <summary>
    /// Конструктор игрового поля
    /// </summary>
    /// <param name="parVerticalSize"></param>
    /// <param name="parHorizontalSize"></param>
    public GameField(int parVerticalSize, int parHorizontalSize, List<Player> parPlayers)
    {
      _cells = new Cell[parVerticalSize, parHorizontalSize];
      _players = parPlayers;
      _currentPlayer = 0;
      BuildMap();
      SetPlayers();
    }

    /// <summary>
    /// 
    /// </summary>
    private void BuildMap()
    {
      int rows = _cells.GetUpperBound(0) + 1;
      for (int i = 0; i < rows; i++)
      {
        if (i % 2 == 0)
        {
          _cells[i, _cells.GetUpperBound(1)] = null;
        }
      }
    }
    
    /// <summary>
    /// 
    /// </summary>
    private void SetPlayers()
    {
      _cells[0, 0].Owner = _players[0];
      _cells[_cells.GetUpperBound(0), 0].Owner = _players[1];
    }

    /// <summary>
    /// Выполнить занятие ячейки
    /// </summary>
    /// <param name="parSourceVerticalCoord"></param>
    /// <param name="parSourceHorizontalCoord"></param>
    /// <param name="parDestinationVerticalCoord"></param>
    /// <param name="parDestinationHorizontalCoord"></param>
    private void Move(int parSourceVerticalCoord, int parSourceHorizontalCoord,
        int parDestinationVerticalCoord, int parDestinationHorizontalCoord)
    {
      if (IsMove(parSourceVerticalCoord, parSourceHorizontalCoord, parDestinationVerticalCoord, parDestinationHorizontalCoord)
          && _cells[parSourceVerticalCoord, parSourceHorizontalCoord].Score >= 1
          && IsCellFree(parDestinationVerticalCoord, parDestinationHorizontalCoord))
      {
        _cells[parDestinationVerticalCoord, parDestinationHorizontalCoord].Owner = _players[0];
        _cells[parSourceVerticalCoord, parSourceHorizontalCoord].DecreaseScore();
        _cells[parDestinationVerticalCoord, parDestinationHorizontalCoord].IncreaseScore();
      }

      if (IsMove(parSourceVerticalCoord, parSourceHorizontalCoord, parDestinationVerticalCoord, parDestinationHorizontalCoord)
          && IsCellOccupied(parDestinationVerticalCoord, parDestinationHorizontalCoord))
      {
        if (_cells[parSourceVerticalCoord, parSourceHorizontalCoord].Score 
            > _cells[parDestinationVerticalCoord, parDestinationHorizontalCoord].Score)
        {
          _cells[parSourceVerticalCoord, parSourceHorizontalCoord].Score = 1;
          _cells[parDestinationVerticalCoord, parDestinationHorizontalCoord].Score
              = _cells[parSourceVerticalCoord, parSourceHorizontalCoord].Score - 1 
              - _cells[parDestinationVerticalCoord, parDestinationHorizontalCoord].Score;
        }
      }
    }

    /// <summary>
    /// Проверить, возможен ли ход из исходной ячейки
    /// в ячейку назначения
    /// </summary>
    /// <param name="parSourceVerticalCoord"></param>
    /// <param name="parSourceHorizontalCoord"></param>
    /// <param name="parDestinationVerticalCoord"></param>
    /// <param name="parDestinationHorizontalCoord"></param>
    /// <returns></returns>
    private bool IsMove(int parSourceVerticalCoord, int parSourceHorizontalCoord,
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

      if (_cells[parDestinationVerticalCoord, parSourceHorizontalCoord] == null)
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

      if ((parSourceVerticalCoord % 2 == 0) && (parSourceHorizontalCoord - 1 == parDestinationHorizontalCoord))
      {
        return true;
      }

      if ((parSourceVerticalCoord % 2 == 1) && (parSourceHorizontalCoord + 1 == parDestinationHorizontalCoord))
      {
        return true;
      }

      return false;
    }

    /// <summary>
    /// Проверить, свободна ли ячейка
    /// </summary>
    /// <param name="parVerticalCoord"></param>
    /// <param name="parHorizontalCoord"></param>
    /// <returns></returns>
    private bool IsCellFree(int parVerticalCoord, int parHorizontalCoord)
    {
      return _cells[parVerticalCoord, parHorizontalCoord].Owner == null;
    }

    /// <summary>
    /// Проверить, занята ли ячейка другим игроком
    /// </summary>
    /// <param name="parVerticalCoord"></param>
    /// <param name="parHorizontalCoord"></param>
    /// <returns></returns>
    private bool IsCellOccupied(int parVerticalCoord, int parHorizontalCoord)
    {
      return _cells[parVerticalCoord, parHorizontalCoord].Owner != _players[_currentPlayer];
    }

    /// <summary>
    /// Передать ход следующему игроку
    /// </summary>
    private void PassMove()
    {
      if (_currentPlayer >= _players.Count)
      {
        _currentPlayer = 0;
      }
      else
      {
        _currentPlayer++;
      }
    }
  }
}
