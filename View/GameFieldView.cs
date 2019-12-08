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
      _gameField.PaintEvent += Draw;
    }

    public override void Draw()
    {
      int rows = _gameField.Cells.GetUpperBound(0) + 1;
      int colomns = _gameField.Cells.GetUpperBound(1) + 1;

      Platform.Clear();
      for (int i = 0; i < rows; i++)
      {
        for (int j = 0; j < colomns; j++)
        {
          if (null != _gameField.Cells[i, j])
          {
            if (null != _gameField.Cells[i, j].Owner)
            {
              Platform.DrawHexagonWithScore(_gameField.Cells[i, j].X, _gameField.Cells[i, j].Y, _gameField.Cells[i, j].Score, _gameField.Cells[i, j].Owner.ItemColor);
            }
            else
            {
              Platform.DrawHexagonWithScore(_gameField.Cells[i, j].X, _gameField.Cells[i, j].Y, _gameField.Cells[i, j].Score, ItemColor.Default);
            }
          }
        }
      }
    }
  }
}
