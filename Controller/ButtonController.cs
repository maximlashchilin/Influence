using System;
using Model;
using View;

namespace Controller
{
  /// <summary>
  /// Контроллер кнопки
  /// </summary>
  public class ButtonController : BaseContoller
  {
    /// <summary>
    /// Экземпляр кнопки
    /// </summary>
    private Button _button;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parPlatform">Платформа</param>
    /// <param name="parButton">Объект кнопки</param>
    public ButtonController(Platform parPlatform, Button parButton)
    {
      _button = parButton;
      View = new ButtonView(parPlatform, _button);

      parPlatform.Click += OnClick;
    }

    /// <summary>
    /// Инициализирует контроллер кнопки
    /// </summary>
    public void Initialize()
    {
      _button.CallPaintEvent();
    }

    /// <summary>
    /// Обрабатывает нажатие на кнопку
    /// </summary>
    /// <param name="parSender">Источник события</param>
    /// <param name="parE">Параметры события</param>
    private void OnClick(object parSender, EventArgs parE)
    {
      _button.CallClick();
    }
  }
}
