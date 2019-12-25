using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace View
{
  public class EnterOfPlayersView : BaseView
  {
    private EnterOfPlayers _enterOfPlayers;

    private List<TextFieldView> _textFieldViews;

    public EnterOfPlayersView(EnterOfPlayers parEnterOfPlayers, Platform parPlatform) : base(parPlatform)
    {
      _enterOfPlayers = parEnterOfPlayers;
      parEnterOfPlayers.PaintEvent += Draw;
    }

    public override void Draw()
    {
      Platform.Clear();
      Platform.PrintText(35.0f, 10.0f, "Enter names of players:");

      float delta = 10.0f;
      //for (int i = 0; i < _textFieldViews.Count; i++)
      //{
      //  _textFieldViews[i].Draw();
      //}
      for (int i = 0; i < _enterOfPlayers.NamesOfPlayers.Count; i++)
      {
        if (_enterOfPlayers.NamesOfPlayers[i].ItemStatus != MenuItemStatus.Selected)
        {
          Platform.PrintTextInRectangle(35.0f, (i * delta) + 30.0f, 55.0f, (i * delta) + 35.0f, _enterOfPlayers.NamesOfPlayers[i].Text, false);
        }
      }

      for (int i = 0; i < _enterOfPlayers.NamesOfPlayers.Count; i++)
      {
        if (_enterOfPlayers.NamesOfPlayers[i].ItemStatus == MenuItemStatus.Selected)
        {
          Platform.PrintMarkedTextInRectangle(35.0f, (i * delta) + 30.0f, 55.0f, (i * delta) + 35.0f, _enterOfPlayers.NamesOfPlayers[i].Text, true);
        }
      }
    }
  }
}
