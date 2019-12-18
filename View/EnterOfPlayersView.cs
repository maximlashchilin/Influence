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

    //private 

    public EnterOfPlayersView(EnterOfPlayers parEnterOfPlayers, Platform parPlatform) : base(parPlatform)
    {
      _enterOfPlayers = parEnterOfPlayers;
      parEnterOfPlayers.PaintEvent += Draw;
    }

    public override void Draw()
    {
      Platform.Clear();
      Platform.PrintTextInRectangle(35.0f, 10.0f, 55.0f, 25.0f, "Enter players");

      float delta = 10.0f;
      for (int i = 0; i < _enterOfPlayers.NamesOfPlayers.Count; i++)
      {
        Platform.PrintTextInRectangle(35.0f, (i * delta) + 30.0f, 55.0f, (i * delta) + 45.0f, _enterOfPlayers.NamesOfPlayers[i].Text);
      }
    }
  }
}
