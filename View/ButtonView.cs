using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace View
{
  public class ButtonView : BaseView
  {
    private Button _button;

    public ButtonView(Button parButton, Platform parPlatform) : base(parPlatform)
    {
      _button = parButton;
      _button.PaintEvent += Draw;
    }

    public override void Draw()
    {
      Platform.PrintTextInRectangle(_button.X1, _button.Y1, _button.X2, _button.Y2, _button.Name);
    }
  }
}
