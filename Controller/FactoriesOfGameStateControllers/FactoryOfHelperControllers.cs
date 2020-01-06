using View;

namespace Controller.FactoriesOfGameStateControllers
{
  public class FactoryOfHelperControllers : FactoryOfContollers
  {
    public override BaseContoller CreateController(Platform parPlatform)
    {
      return new HelperController(parPlatform);
    }
  }
}
