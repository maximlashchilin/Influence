using System.Collections.Generic;
using Model;

namespace View
{
  /// <summary>
  /// Представление ввода игроков
  /// </summary>
  public class EnterOfPlayersView : BaseView
  {
    /// <summary>
    /// Объект ввода игроков
    /// </summary>
    private EnterOfPlayers _enterOfPlayers;

    /// <summary>
    /// Список представлений текстовых полей
    /// </summary>
    private List<TextFieldView> _textFieldViews;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parEnterOfPlayers">Объект ввода игроков</param>
    /// <param name="parTextFieldViews">Список представлений текстовых полей</param>
    /// <param name="parPlatform">Объект платформы</param>
    public EnterOfPlayersView(EnterOfPlayers parEnterOfPlayers, List<TextFieldView> parTextFieldViews, Platform parPlatform) : base(parPlatform)
    {
      _enterOfPlayers = parEnterOfPlayers;
      _textFieldViews = parTextFieldViews;

      parEnterOfPlayers.PaintEvent += Draw;
      SubcribeOnTextFieldEvents();
    }

    /// <summary>
    /// Подписывает метод Draw на события перерисовки модели
    /// </summary>
    private void SubcribeOnTextFieldEvents()
    {
      foreach (TextField elItem in _enterOfPlayers.NamesOfPlayers)
      {
        elItem.PaintEvent += Draw;
      }
    }

    /// <summary>
    /// Отрисовывает ввод имен игроков
    /// </summary>
    public override void Draw()
    {
      const float X = 42.0f;
      const float Y_HEAD = 20.0f;
      const float Y_HINT = 60.0f;
      const string HEAD = "Enter names of players:";
      const string HINT = "Press Enter to start game";

      Platform.Clear();
      Platform.PrintText(X, Y_HEAD, HEAD);
      Platform.PrintText(X, Y_HINT, HINT);
      for (int i = 0; i < _textFieldViews.Count; i++)
      {
        if (_enterOfPlayers.NamesOfPlayers[i].ItemStatus != ItemStatuses.Selected)
        {
          _textFieldViews[i].Draw();
        }
      }

      for (int i = 0; i < _textFieldViews.Count; i++)
      {
        if (_enterOfPlayers.NamesOfPlayers[i].ItemStatus == ItemStatuses.Selected)
        {
          _textFieldViews[i].Draw();
        }
      }
    }
  }
}
