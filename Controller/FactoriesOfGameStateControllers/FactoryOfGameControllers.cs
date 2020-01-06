using View;

namespace Controller.FactoriesOfGameStateControllers
{
  /// <summary>
  /// Фабрика контроллера игры
  /// </summary>
  class FactoryOfGameControllers : FactoryOfContollers
  {
    /// <summary>
    /// Создает контроллер состояния игры
    /// </summary>
    /// <param name="parPlatform">Платформа</param>
    /// <returns>Контроллер состояния игры</returns>
    public override BaseContoller CreateController(Platform parPlatform)
    {
      return new GameController(parPlatform);
    }
  }
}
