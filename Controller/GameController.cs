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

    private ButtonController _buttonController;

    private EnterOfPlayersController _enterOfPlayersController;

    public GameController(Platform parPlatform)
    {
      List<Player> players = new List<Player>();

      players.Add(new Player("Maxim", ItemColor.Green));
      players.Add(new Player("Takis", ItemColor.Red));
      _game = new GameField(VERTICAL_SIZE, HORIZONTAL_SIZE, players);
      View = new GameFieldView(_game, parPlatform);
      _buttonController = new ButtonController(parPlatform, _game.Button);
      _game.Initialize();
      _buttonController.Initialize();
      _game.Button.Click += OnButtonClick;

      parPlatform.Move += OnMove;
      parPlatform.Click += OnClick;
    }

    public override void Start()
    {

    }

    private void OnButtonClick(object parSender, EventArgs parE)
    {
      _game.CompleteAtack();
      _game.Button.Name = "Pass move";
    }

    private void OnClick(object parSender, EventArgs parE)
    {
      _game.PerformGameAction();
    }

    private void OnMove(object parSender, MoveEventArgs parE)
    {
      Cursor.GetInstance().Move(parE.X, parE.Y);
    }
  }
}
