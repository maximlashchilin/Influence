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

    public GameField(int parVerticalSize, int parHorizontalSize)
    {
      _cells = new Cell[parVerticalSize, parHorizontalSize];
    }

    private void Move(int parSourceVerticalCoord, int parSourceHorizontalCoord,
        int parDestinationVerticalCoord, int parDestinationHorizontalCoord)
    {
      if (IsMove(parSourceVerticalCoord, parSourceHorizontalCoord, parDestinationVerticalCoord, parDestinationHorizontalCoord)
          && (true))
      {
        // TODO
      }
    }

    private bool IsMove(int parSourceVerticalCoord, int parSourceHorizontalCoord,
        int parDestinationVerticalCoord, int parDestinationHorizontalCoord)
    {
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


  }
}
