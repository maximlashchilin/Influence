using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace View
{
  /// <summary>
  /// Представление просмотра справки
  /// </summary>
  public class HelperView : BaseView
  {
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parHelper">Объект просмотра справки</param>
    /// <param name="parPlatform">Объект платформы</param>
    public HelperView(Helper parHelper, Platform parPlatform) : base(parPlatform)
    {

    }

    /// <summary>
    /// Отрисовывает просмотр справки
    /// </summary>
    public override void Draw()
    {
      throw new NotImplementedException();
    }
  }
}
