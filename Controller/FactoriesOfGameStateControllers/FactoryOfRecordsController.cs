using View;

namespace Controller.FactoriesOfGameStateControllers
{
  /// <summary>
  /// Фабрика контроллера рекордов
  /// </summary>
  public class FactoryOfRecordsController : FactoryOfContollers
  {
    /// <summary>
    /// Создает контроллер рекордов
    /// </summary>
    /// <param name="parPlatform">Платформа</param>
    /// <returns>Контроллер рекордов</returns>
    public override BaseContoller CreateController(Platform parPlatform)
    {
      return new RecordsController(parPlatform);
    }
  }
}
