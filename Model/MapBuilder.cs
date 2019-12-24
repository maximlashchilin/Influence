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
    /// <returns>Массив игровых ячеек</returns>
    public Cell[,] BuildMap(int parVerticalSize, int parHorizontalSize)
    {
      Cell[,] map = new Cell[parVerticalSize, parHorizontalSize];

      int rows = map.GetUpperBound(0) + 1;
      int colomns = map.GetUpperBound(1) + 1;
      for (int i = 0; i < rows; i++)
      {
        for (int j = 0; j < colomns; j++)
        {
          if (i % 2 == 0)
          {
            map[i, j] = new Cell((j * 10 + 30) + 5, i * 10 + 30);
          }
          else
          {
            map[i, j] = new Cell(j * 10 + 30, i * 10 + 30);
          }
        }
      }

      for (int i = 0; i < rows; i++)
      {
        if (i % 2 == 0)
        {
          map[i, map.GetUpperBound(1)] = null;
        }
      }

      return map;
    }
  }
}
