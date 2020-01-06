using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller.FactoriesOfGameStateControllers;
using Model;
using View;

namespace Controller
{
  /// <summary>
  /// Контроллер справки
  /// </summary>
  public class HelperController : BaseContoller
  {
    /// <summary>
    /// Объект справки
    /// </summary>
    private Helper _helper;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parPlatform">Объект платформы</param>
    public HelperController(Platform parPlatform)
    {
      _helper = new Helper();
      View = new HelperView(parPlatform, _helper);
      _helper.Initialize();

      parPlatform.EscDown += OnEscDown;
    }

    /// <summary>
    /// Обрабатывает нажатие Esc
    /// </summary>
    /// <param name="parSender">Источник события</param>
    /// <param name="parE">Параметры события</param>
    private void OnEscDown(object parSender, EventArgs parE)
    {
      CallChangeState(this, new ChangeStateArgs(new FactoryOfMenuControllers(), ApplicationStates.MenuWork));
    }

    public override void Start()
    {
      throw new NotImplementedException();
    }
  }
}
