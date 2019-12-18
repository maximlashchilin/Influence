using View;

namespace Controller
{
  /// <summary>
  /// Фабрика контроллера меню
  /// </summary>
  public class FactoryOfMenuControllers : FactoryOfContollers
  {
    /// <summary>
    /// Создает контроллер меню
    /// </summary>
    /// <param name="parPlatform">Платформа</param>
    /// <returns>Контроллер меню</returns>
    public override BaseContoller CreateController(Platform parPlatform)
    {
      return new MenuController(parPlatform);
    }
  }
}
