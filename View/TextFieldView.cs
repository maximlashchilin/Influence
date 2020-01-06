using Model;

namespace View
{
  /// <summary>
  /// Представление текстового поля
  /// </summary>
  public class TextFieldView : BaseView
  {
    /// <summary>
    /// Объект текстового поля
    /// </summary>
    private TextField _textField;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parPlatform">Объект платформы</param>
    /// <param name="parTextField">Объект текстового поля</param>
    public TextFieldView(Platform parPlatform, TextField parTextField) : base(parPlatform)
    {
      _textField = parTextField;
    }

    /// <summary>
    /// Отрисовывает текстовое поле
    /// </summary>
    public override void Draw()
    {
      if (_textField.ItemStatus != ItemStatuses.Selected)
      {
        Platform.PrintTextInRectangle(_textField.X1, _textField.Y1, _textField.X2, _textField.Y2, _textField.Text, false);
      }
      else if (_textField.ItemStatus == ItemStatuses.Selected)
      {
        Platform.PrintMarkedTextInRectangle(_textField.X1, _textField.Y1, _textField.X2, _textField.Y2, _textField.Text, true);
      }
    }
  }
}
