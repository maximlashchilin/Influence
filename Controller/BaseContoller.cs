using View;

namespace Controller
{
  /// <summary>
  /// Базовый контроллер
  /// </summary>
  public abstract class BaseContoller
  {
    /// <summary>
    /// Представление
    /// </summary>
    private BaseView _view;

    /// <summary>
    /// Событие изменения состояния приложения
    /// </summary>
    public event dChangeStateHandler ChangeState;

    /// <summary>
    /// Представление
    /// </summary>
    public BaseView View
    {
      get
      {
        return _view;
      }
      set
      {
        _view = value;
      }
    }

    /// <summary>
    /// Вызывает событие изменения состояния приложения
    /// </summary>
    /// <param name="parSender">Отправитель события</param>
    /// <param name="parE">Параметры события</param>
    public void CallChangeState(object parSender, ChangeStateArgs parE)
    {
      ChangeState?.Invoke(parSender, parE);
    }
  }
}
