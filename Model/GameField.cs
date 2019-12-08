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
    /// Игрок, совершающий ход
    /// </summary>
    private int _currentPlayer;

    private int _currentPlayerScore;

    /// <summary>
    /// Текущее состояние игры
    /// </summary>
    private GameState _currentGameState;

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
      _cells = new Cell[parVerticalSize, parHorizontalSize];
      _players = parPlayers;
      _currentPlayer = 0;
      _button = new Button(35.0f, 5.0f, 60.0f, 15.0f, "Complete atack");
    }

    public void Initialize()
    {
      BuildMap();
      SetPlayers();
      _currentGameState = GameState.Select;
    }

    /// <summary>
    /// 
    /// </summary>
    private void BuildMap()
    {
      int rows = _cells.GetUpperBound(0) + 1;
      int colomns = _cells.GetUpperBound(1) + 1;
      for (int i = 0; i < rows; i++)
      {
        for (int j = 0; j < colomns; j++)
        {
          if (i % 2 == 0)
          {
            _cells[i, j] = new Cell((j * 10 + 30) + 5, i * 10 + 30);
          }
          else
          {
            _cells[i, j] = new Cell(j * 10 + 30, i * 10 + 30);
          }
        }
      }
      
      for (int i = 0; i < rows; i++)
      {
        if (i % 2 == 0)
        {
          _cells[i, _cells.GetUpperBound(1)] = null;
        }
      }

      PaintEvent?.Invoke();
    }
    
    /// <summary>
    /// 
    /// </summary>
    private void SetPlayers()
    {
      _cells[0, 0].Owner = _players[0];
      _cells[0, 2].Owner = _players[1];

      _cells[0, 0].Score = 5;
      _cells[0, 2].Score = 5;

      PaintEvent?.Invoke();
    }

    private void SelectCell()
    {
      Coords clickedCellCoords = GetFocusedCellCoords();
      
      if (clickedCellCoords != null)
      {
        UnselectAllCells();
        if (_cells[clickedCellCoords.I, clickedCellCoords.J]?.Owner == _players[_currentPlayer])
        {
          _cells[clickedCellCoords.I, clickedCellCoords.J].CellStatus = CellStatus.Active;
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
      int numOfPoints = GetPlayerNumOfCells(_players[_currentPlayer]);
      Coords clickedCellCoords = GetFocusedCellCoords();

      _button.CallPaintEvent();
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
            _cells[i, j].CellStatus = CellStatus.NotChoosed;
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
          && IsCellFree(parDestinationVerticalCoord, parDestinationHorizontalCoord))
      {
        _cells[parDestinationVerticalCoord, parDestinationHorizontalCoord].Owner = _players[0];
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
          _cells[parDestinationVerticalCoord, parDestinationHorizontalCoord].Owner = _players[_currentPlayer];
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

    public void CompleteAtack()
    {
      _currentGameState = GameState.ScoreSetting;
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
        case GameState.ScoreSetting:
          DistributeScore();
          break;
        case GameState.MovePassing:
          PassMove();
          break;
      }
    }
  }
}
