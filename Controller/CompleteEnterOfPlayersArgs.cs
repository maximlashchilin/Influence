using System;
using System.Collections.Generic;
using Model;

namespace Controller
{
  /// <summary>
  /// Параметры события завершения ввода игроков
  /// </summary>
  public class CompleteEnterOfPlayersArgs : EventArgs
  {
    /// <summary>
    /// Список игроков
    /// </summary>
    private List<Player> _players;

    /// <summary>
    /// Список игроков
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
    /// <param name="parPlayers">Список игроков</param>
    public CompleteEnterOfPlayersArgs(List<Player> parPlayers)
    {
      _players = parPlayers;
    }
  }
}
