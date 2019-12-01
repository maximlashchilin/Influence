using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using View;

namespace Controller
{
  public class GameController : BaseContoller
  {
    private const int VERTICAL_SIZE = 6;

    private const int HORIZONTAL_SIZE = 4;

    private GameField _game;

    public GameController(Platform parPlatform)
    {
      _game = new GameField(VERTICAL_SIZE, HORIZONTAL_SIZE, new List<Player>());
      View = new GameFieldView(_game, parPlatform);
    }

    private void OnClick()
    {

    }
  }
}
