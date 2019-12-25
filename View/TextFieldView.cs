using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// <param name="parTextField">Объект текстового поля</param>
    /// <param name="parPlatform">Объект платформы</param>
    public TextFieldView(TextField parTextField, Platform parPlatform) : base(parPlatform)
    {
      _textField = parTextField;

      _textField.PaintEvent += Draw;
    }

    /// <summary>
    /// Отрисовывает текстовое поле
    /// </summary>
    public override void Draw()
    {
      
    }
  }
}
