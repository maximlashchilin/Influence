using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  /// <summary>
  /// Координаты ячейки в массиве
  /// </summary>
  public class Coords
  {
    /// <summary>
    /// Индекс ряда
    /// </summary>
    private int _i;

    /// <summary>
    /// Индекс колонки
    /// </summary>
    private int _j;

    /// <summary>
    /// Индекс ряда
    /// </summary>
    public int I
    {
      get
      {
        return _i;
      }
      set
      {
        _i = value;
      }
    }

    /// <summary>
    /// Индекс колонки
    /// </summary>
    public int J
    {
      get
      {
        return _j;
      }
      set
      {
        _j = value;
      }
    }

    /// <summary>
    /// Конструктор координат ячейки в массиве
    /// </summary>
    /// <param name="parI">Индекс ряда</param>
    /// <param name="parJ">Индекс колонки</param>
    public Coords(int parI, int parJ)
    {
      _i = parI;
      _j = parJ;
    }
  }
}
