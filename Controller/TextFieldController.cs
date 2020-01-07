using System;
using Model;
using View;

namespace Controller
{
  /// <summary>
  /// Контроллер текстового поля
  /// </summary>
  public class TextFieldController : BaseContoller
  {
    /// <summary>
    /// Экзмепляр текстового поля
    /// </summary>
    private TextField _textField;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parTextField">Текстовое поле</param>
    /// <param name="parPlatform">Объект платформы</param>
    public TextFieldController(TextField parTextField, Platform parPlatform)
    {
      _textField = parTextField;
      View = new TextFieldView(parPlatform, parTextField);

      parPlatform.KeyDown += OnKeyDown;
      parPlatform.BackspaceDown += OnBackspaceDown;
    }

    /// <summary>
    /// Обрабатывает событие нажатия клавиши
    /// </summary>
    /// <param name="parSender">Источник события</param>
    /// <param name="parE">Параметры события</param>
    private void OnKeyDown(object parSender, KeyDownEventArgs parE)
    {
      _textField.AddChar(parE.InputChar);
    }

    /// <summary>
    /// Обрабатывает нажатие Backspace
    /// </summary>
    /// <param name="parSender">Источник события</param>
    /// <param name="parE">Параметры события</param>
    private void OnBackspaceDown(object parSender, EventArgs parE)
    {
      _textField.DeleteLastChar();
    }
  }
}
