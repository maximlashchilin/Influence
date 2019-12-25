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
    /// <param name="parPlatform">Платформа</param>
    public TextFieldController(TextField parTextField, Platform parPlatform)
    {
      _textField = parTextField;

      parPlatform.KeyDown += OnKeyDown;
    }

    /// <summary>
    /// Обрабатывает событие нажатия клавиши
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnKeyDown(object sender, KeyDownEventArgs e)
    {
      _textField.AddChar(e.InputChar);
    }

    public override void Start()
    {
      throw new NotImplementedException();
    }
  }
}
