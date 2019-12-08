using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using View;

namespace Controller
{
  public class ButtonController : BaseContoller
  {
    private Button _button;

    public ButtonController(Platform parPlatform, Button parButton)
    {
      _button = parButton;
      View = new ButtonView(_button, parPlatform);

      parPlatform.Click += OnClick;
    }

    public void Initialize()
    {
      _button.CallPaintEvent();
    }

    public override void Start()
    {
      throw new NotImplementedException();
    }

    private void OnClick(object parSender, EventArgs parE)
    {
      _button.CallClick();
    }
  }
}
