using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace View
{
  public class GameFieldView : BaseView
  {
    public GameField _gameField;

    public GameFieldView(GameField parGameField, Platform parPlatform) : base(parPlatform)
    {
      _gameField = parGameField;
    }

    public override void Draw()
    {
      throw new NotImplementedException();
    }
  }
}
