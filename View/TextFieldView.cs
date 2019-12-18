using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace View
{
  public class TextFieldView : BaseView
  {
    private TextField _textField;
    public TextFieldView(TextField parTextField, Platform parPlatform) : base(parPlatform)
    {
      _textField = parTextField;

      _textField.PaintEvent += Draw;
    }

    public override void Draw()
    {
      
    }
  }
}
