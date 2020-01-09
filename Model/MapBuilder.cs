using System.Collections.Generic;

namespace Model
{
  /// <summary>
  /// Строитель карты
  /// </summary>
  public class MapBuilder
  {
    /// <summary>
    /// Строит карту
    /// </summary>
    /// <param name="parVerticalSize">Вертикальный размер</param>
    /// <param name="parHorizontalSize">Горизонтальный размер</param>
    /// <param name="parPlayers">Список игроков</param>
    /// <returns>Массив игровых ячеек</returns>
    public Cell[,] BuildMap(int parVerticalSize, int parHorizontalSize, List<Player> parPlayers)
    {
      Cell[,] map = CreateGameCells(parVerticalSize, parHorizontalSize);
      map = SetPlayers(map, parPlayers);      

      return map;
    }

    /// <summary>
    /// Создает массив игровых ячеек
    /// </summary>
    /// <param name="parVerticalSize">Вертикальный размер массива</param>
    /// <param name="parHorizontalSize">Горизонтальный размер массива</param>
    /// <returns>Массив ячеек</returns>
    private Cell[,] CreateGameCells(int parVerticalSize, int parHorizontalSize)
    {
      const int DELTA = 10;
      const int X = 30;
      const int Y = 30;
      const int Y_SHIFT = 5;

      Cell[,] cells = new Cell[parVerticalSize, parHorizontalSize];

      int rows = cells.GetLength(0);
      int colomns = cells.GetLength(1);
      for (int i = 0; i < rows; i++)
      {
        for (int j = 0; j < colomns; j++)
        {
          if (i % 2 == 1)
          {
            cells[i, j] = new Cell(j * DELTA + Y + Y_SHIFT, i * DELTA + X);
            cells[i, j].I = i;
            cells[i, j].J = j;
          }
          else
          {
            cells[i, j] = new Cell(j * DELTA + Y, i * DELTA + X);
            cells[i, j].I = i;
            cells[i, j].J = j;
          }
        }
      }

      for (int i = 0; i < rows; i++)
      {
        if (i % 2 == 1)
        {
          cells[i, cells.GetUpperBound(1)] = null;
        }
      }

      return cells;
    }

    /// <summary>
    /// Устанавливает игроков для первоначальных ячеек
    /// </summary>
    /// <param name="parCells">Массив ячеек</param>
    /// <param name="parPlayers">Список игроков</param>
    /// <returns>Массив ячеек</returns>
    private Cell[,] SetPlayers(Cell[,] parCells, List<Player> parPlayers)
    {
      Cell[,] map = parCells;

      map[0, 0].Owner = parPlayers[0];
      map[0, 3].Owner = parPlayers[1];

      map[0, 0].Score = 5;
      map[0, 3].Score = 5;

      return map;
    }
  }
}
