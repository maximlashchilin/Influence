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
    /// Событие перерисовки игрового поля
    /// </summary>
    public event dPaintHandler PaintEvent;

    /// <summary>
    /// Ячейки игрового поля
    /// </summary>
    private Cell[,] _cells;

    /// <summary>
    /// Текущие игроки
    /// </summary>
    private List<Player> _players;

    /// <summary>
    /// Номер текущего игрока
    /// </summary>
    private int _currentPlayer;

    /// <summary>
    /// Текущее состояние игры
    /// </summary>
    private GameState _currentGameState;

    /// <summary>
    /// Кнопка переключения состояний игры
    /// </summary>
    private Button _button;

    /// <summary>
    /// Ячейки игрового поля
    /// </summary>
    public Cell[,] Cells
    {
      get
      {
        return _cells;
      }
    }

    /// <summary>
    /// Кнопка переключения состояний игры
    /// </summary>
    public Button Button
    {
      get
      {
        return _button;
      }
      set
      {
        _button = value;
      }
    }

    /// <summary>
    /// Конструктор игрового поля
    /// </summary>
    /// <param name="parVerticalSize"></param>
    /// <param name="parHorizontalSize"></param>
    public GameField(int parVerticalSize, int parHorizontalSize, List<Player> parPlayers)
    {
      _cells = new MapBuilder().BuildMap(parVerticalSize, parHorizontalSize, parPlayers);
      _currentGameState = GameState.Select;
      _players = parPlayers;
      _currentPlayer = 0;
      _button = new Button(35.0f, 5.0f, 60.0f, 15.0f, "Complete atack");
    }

    public void Initialize()
    {
      PaintEvent?.Invoke();
    }

    private void SelectCell()
    {
      Coords clickedCellCoords = GetFocusedCellCoords();

      if (clickedCellCoords != null)
      {
        UnselectAllCells();
        if (_cells[clickedCellCoords.I, clickedCellCoords.J]?.Owner == GetActivePlayer())
        {
          _cells[clickedCellCoords.I, clickedCellCoords.J].ActiveCell();
          _currentGameState = GameState.Atack;
        }
      }

      _button.CallPaintEvent();
    }

    private void AtackCell()
    {
      Coords selectedCellCoords = GetSelectedCellCoords();
      Coords clickedCellCoords = GetFocusedCellCoords();

      if (selectedCellCoords != null && clickedCellCoords != null)
      {
        Move(selectedCellCoords.I, selectedCellCoords.J, clickedCellCoords.I, clickedCellCoords.J);
      }

      PaintEvent?.Invoke();
      _button.CallPaintEvent();
    }

    private void DistributeScore()
    {
      Coords clickedCellCoords = GetFocusedCellCoords();

      if (null != clickedCellCoords)
      {
        if (_cells[clickedCellCoords.I, clickedCellCoords.J].Owner == GetActivePlayer())
        {
          if (GetActivePlayer().Score > 0)
          {
            GetActivePlayer().Score -= 1;
            _cells[clickedCellCoords.I, clickedCellCoords.J].Score += 1;
          }
        }
        PaintEvent?.Invoke();
        _button.CallPaintEvent();
      }
    }

    private void UnselectAllCells()
    {
      int rows = _cells.GetLength(0);
      int colomns = _cells.GetLength(1);

      for (int i = 0; i < rows; i++)
      {
        for (int j = 0; j < colomns; j++)
        {
          if (_cells[i, j] != null)
          {
            _cells[i, j].DisactiveCell();
          }
        }
      }
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
          && _cells[parDestinationVerticalCoord, parDestinationHorizontalCoord].IsCellFree())
      {
        _cells[parDestinationVerticalCoord, parDestinationHorizontalCoord].Owner = GetActivePlayer();
        _cells[parDestinationVerticalCoord, parDestinationHorizontalCoord].Score = _cells[parSourceVerticalCoord, parSourceHorizontalCoord].Score - 1;
        _cells[parSourceVerticalCoord, parSourceHorizontalCoord].Score = 1;
        _cells[parSourceVerticalCoord, parSourceHorizontalCoord].CellStatus = CellStatus.NotChoosed;
        _cells[parDestinationVerticalCoord, parDestinationHorizontalCoord].CellStatus = CellStatus.Active;
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
          _cells[parSourceVerticalCoord, parSourceHorizontalCoord].CellStatus = CellStatus.NotChoosed;
          _cells[parDestinationVerticalCoord, parDestinationHorizontalCoord].CellStatus = CellStatus.Active;
          _cells[parDestinationVerticalCoord, parDestinationHorizontalCoord].Owner = GetActivePlayer();
        }
        else
        {
          _cells[parDestinationVerticalCoord, parDestinationHorizontalCoord].Score = _cells[parDestinationVerticalCoord, parDestinationHorizontalCoord].Score - (_cells[parSourceVerticalCoord, parSourceHorizontalCoord].Score - 1);
          _cells[parSourceVerticalCoord, parSourceHorizontalCoord].Score = 1;
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
    /// Проверить, занята ли ячейка другим игроком
    /// </summary>
    /// <param name="parVerticalCoord"></param>
    /// <param name="parHorizontalCoord"></param>
    /// <returns></returns>
    private bool IsCellOccupied(int parVerticalCoord, int parHorizontalCoord)
    {
      return _cells[parVerticalCoord, parHorizontalCoord].Owner != GetActivePlayer();
    }

    /// <summary>
    /// Передать ход следующему игроку
    /// </summary>
    private void PassMove()
    {
      if (_currentPlayer >= _players.Count - 1)
      {
        _currentPlayer = 0;
      }
      else
      {
        _currentPlayer++;
      }

      _currentGameState = GameState.Select;
      _button.CallPaintEvent();
    }

    private Coords GetFocusedCellCoords()
    {
      Cursor cursor = Cursor.GetInstance();
      int rows = _cells.GetUpperBound(0) + 1;
      int colomns = _cells.GetUpperBound(1) + 1;
      for (int i = 0; i < rows; i++)
      {
        for (int j = 0; j < colomns; j++)
        {
          if (null != _cells[i, j])
          {
            if ((cursor.X >= _cells[i, j].X - 1.5f) && (cursor.Y >= _cells[i, j].Y - 1.5f)
                && (cursor.X <= _cells[i, j].X + 1.5f) && (cursor.Y <= _cells[i, j].Y + 1.5f))
            {
              return new Coords(i, j);
            }
          }
        }
      }

      return null;
    }

    private Coords GetSelectedCellCoords()
    {
      int rows = _cells.GetUpperBound(0) + 1;
      int colomns = _cells.GetUpperBound(1) + 1;
      for (int i = 0; i < rows; i++)
      {
        for (int j = 0; j < colomns; j++)
        {
          if (null != _cells[i, j])
          {
            if (_cells[i, j].CellStatus == CellStatus.Active)
            {
              return new Coords(i, j);
            }
          }
        }
      }

      return null;
    }

    private int GetPlayerNumOfCells(Player parPlayer)
    {
      int result = 0;
      int rows = _cells.GetUpperBound(0) + 1;
      int colomns = _cells.GetUpperBound(1) + 1;
      for (int i = 0; i < rows; i++)
      {
        for (int j = 0; j < colomns; j++)
        {
          if (null != _cells[i, j])
          {
            if (_cells[i, j].Owner == parPlayer)
            {
              result++;
            }
          }
        }
      }

      return result;
    }

    public void CompleteAtackOrPassMove()
    {
      switch (_currentGameState)
      {
        case GameState.Select:
        case GameState.Atack:
          {
            GetActivePlayer().Score = CalculateScorePlayer();
            _currentGameState = GameState.ScoreDistributing;
            _button.Name = "Pass move";
            break;
          }
        case GameState.ScoreDistributing:
          {
            PassMove();
            _button.Name = "Complete atack";
            break;
          }
      }
    }

    public void PerformGameAction()
    {
      switch (_currentGameState)
      {
        case GameState.Select:
          SelectCell();
          break;
        case GameState.Atack:
          AtackCell();
          break;
        case GameState.ScoreDistributing:
          DistributeScore();
          break;
      }
    }

    private int CalculateScorePlayer()
    {
      int scorePlayer = GetPlayerNumOfCells(GetActivePlayer());
      return scorePlayer;
    }

    public Player GetActivePlayer()
    {
      return _players[_currentPlayer];
    }
  }
}
