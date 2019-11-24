using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View;

namespace Controller
{
  public abstract class FactoryOfContollers
  {
    public abstract BaseContoller CreateController(Platform parPlatform);
  }
}
