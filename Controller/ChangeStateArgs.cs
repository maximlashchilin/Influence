using System;
using Model;
using Controller.FactoriesOfGameStateControllers;

namespace Controller
{
  /// <summary>
  /// Параметры события изменения состояния приложения
  /// </summary>
  public class ChangeStateArgs : EventArgs
  {
    /// <summary>
    /// Фабрика контроллеров
    /// </summary>
    private FactoryOfContollers _factoryOfContollers;

    /// <summary>
    /// Состояние приложения
    /// </summary>
    private ApplicationState _applicationState;

    /// <summary>
    /// Фабрика контроллеров
    /// </summary>
    public FactoryOfContollers FactoryOfContollers
    {
      get
      {
        return _factoryOfContollers;
      }
    }

    /// <summary>
    /// Состояние приложения
    /// </summary>
    public ApplicationState ApplicationState
    {
      get
      {
        return _applicationState;
      }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parFactory">Фабрика контроллеров</param>
    /// <param name="parState">Состояние приложения</param>
    public ChangeStateArgs(FactoryOfContollers parFactory, ApplicationState parState)
    {
      _factoryOfContollers = parFactory;
      _applicationState = parState;
    }
  }
}
