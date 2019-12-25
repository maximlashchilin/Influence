namespace Model
{
  /// <summary>
  /// Состояния игры
  /// </summary>
  public enum GameState
  {
    /// <summary>
    /// Выбор ячейки для атаки
    /// </summary>
    Select,
    /// <summary>
    /// Атака ячейки
    /// </summary>
    Atack,
    /// <summary>
    /// Раздача очков
    /// </summary>
    ScoreDistributing
  }
}
