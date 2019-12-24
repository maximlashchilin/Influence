using View;

namespace Controller.FactoriesOfGameStateControllers
{
  /// <summary>
  /// Абстрактная фабрика контроллеров
  /// </summary>
  public abstract class FactoryOfContollers
  {
    /// <summary>
    /// Создает контроллер состояния приложения
    /// </summary>
    /// <param name="parPlatform">Платформа</param>
    /// <returns>Контроллер состояния приложения</returns>
    public abstract BaseContoller CreateController(Platform parPlatform);
  }
}
