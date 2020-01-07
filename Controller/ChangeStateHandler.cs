namespace Controller
{
  /// <summary>
  /// Делегат события изменения состояния приложения
  /// </summary>
  /// <param name="parSender">Источник события</param>
  /// <param name="parE">Параметры события</param>
  public delegate void dChangeStateHandler(object parSender, ChangeStateArgs parE);
}
