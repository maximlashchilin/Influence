using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View;

namespace Controller
{
  /// <summary>
  /// Фабрика контроллера игры
  /// </summary>
  class FactoryOfGameControllers : FactoryOfContollers
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="parPlatform"></param>
    /// <returns></returns>
    public override BaseContoller CreateController(Platform parPlatform)
    {
      return new GameController(parPlatform);
    }
  }
}
