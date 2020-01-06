using System;
using Model;
using View;
using Controller.FactoriesOfGameStateControllers;

namespace Controller
{
  /// <summary>
  /// Контроллер рекордов
  /// </summary>
  public class RecordsController : BaseContoller
  {
    /// <summary>
    /// Объект рекордов
    /// </summary>
    private Records _records;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parPlatform">Объект платформы</param>
    public RecordsController(Platform parPlatform)
    {
      _records = new Records();
      View = new RecordsView(parPlatform, _records);
      _records.Initialize();

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
