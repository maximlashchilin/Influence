using Model;

namespace View
{
  /// <summary>
  /// Представление кнопки
  /// </summary>
  public class ButtonView : BaseView
  {
    /// <summary>
    /// Экземпляр кнопки
    /// </summary>
    private Button _button;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parButton">Объект кнопки</param>
    /// <param name="parPlatform">Объект платформы</param>
    public ButtonView(Platform parPlatform, Button parButton) : base(parPlatform)
    {
      _button = parButton;
    }

    /// <summary>
    /// Отрисовывает кнопку
    /// </summary>
    public override void Draw()
    {
      Platform.PrintMarkedTextInRectangle(_button.X1, _button.Y1, _button.X2, _button.Y2, _button.Name, false);
    }
  }
}
