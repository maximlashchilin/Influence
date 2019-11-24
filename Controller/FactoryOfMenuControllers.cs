using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View;

namespace Controller
{
  public class FactoryOfMenuControllers : FactoryOfContollers
  {
    public override BaseContoller CreateController(Platform parPlatform)
    {
      return new MenuController(parPlatform);
    }
  }
}
