using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
{
  /// <summary>
  /// Параметры события завершения ввода игроков
  /// </summary>
  public class CompleteEnterOfPlayersArgs : EventArgs
  {
    /// <summary>
    /// Игроки
    /// </summary>
    private List<Player> _players;

    /// <summary>
    /// Игроки
    /// </summary>
    public List<Player> Players
    {
      get
      {
        return _players;
      }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parPlayers">Игроки</param>
    public CompleteEnterOfPlayersArgs(List<Player> parPlayers)
    {
      _players = parPlayers;
    }
  }
}
