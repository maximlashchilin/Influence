using Model;

namespace View
{
  /// <summary>
  /// Представление игрового поля
  /// </summary>
  public class GameFieldView : BaseView
  {
    /// <summary>
    /// Объект игрового поля
    /// </summary>
    private GameField _gameField;

    /// <summary>
    /// Объект представления кнопки
    /// </summary>
    private ButtonView _buttonView;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parPlatform">Объект платформы</param>
    /// <param name="parGameField">Объект игрового поля</param>
    /// /// <param name="parButtonView">Объект представления кнопки</param>
    public GameFieldView(Platform parPlatform, GameField parGameField, ButtonView parButtonView) : base(parPlatform)
    {
      _gameField = parGameField;
      _buttonView = parButtonView;

      _gameField.PaintEvent += Draw;
      SubscribeOnButtonViewEvent();
    }

    /// <summary>
    /// Подписывает метод Draw на событие перерисовки кнопки
    /// </summary>
    private void SubscribeOnButtonViewEvent()
    {
      _gameField.Button.PaintEvent += Draw;
    }

    /// <summary>
    /// Отрисовывает игровое поле
    /// </summary>
    public override void Draw()
    {
      const float X_HINT = 42.0f;
      const float Y_HINT = 90.0f;

      int rows = _gameField.Cells.GetLength(0);
      int colomns = _gameField.Cells.GetLength(1);

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
              Platform.DrawHexagonWithScore(_gameField.Cells[i, j].X, _gameField.Cells[i, j].Y, _gameField.Cells[i, j].Score, ItemColors.Default);
            }
          }
        }
      }

      string currentPlayer = "Current player: " + _gameField.GetActivePlayer().Name;
      Platform.PrintText(X_HINT, Y_HINT, currentPlayer);
      _buttonView.Draw();
      Platform.CallReadyFrame();
    }
  }
}
