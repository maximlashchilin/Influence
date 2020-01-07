using View;

namespace Controller.FactoriesOfGameStateControllers
{
  /// <summary>
  /// Фабрика контроллера просмотра справки
  /// </summary>
  public class FactoryOfHelperControllers : FactoryOfContollers
  {
    /// <summary>
    /// Создает контроллер просмотра справки
    /// </summary>
    /// <param name="parPlatform">Объект платформы</param>
    /// <returns>Контроллер просмотра справки</returns>
    public override BaseContoller CreateController(Platform parPlatform)
    {
      return new HelperController(parPlatform);
    }
  }
}
