using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Список текстовых полей
    /// </summary>
    private List<TextFieldView> _textFieldViews;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parEnterOfPlayers">Объект ввода игроков</param>
    /// <param name="parPlatform">Объект платформы</param>
    public EnterOfPlayersView(EnterOfPlayers parEnterOfPlayers, Platform parPlatform) : base(parPlatform)
    {
      _enterOfPlayers = parEnterOfPlayers;
      parEnterOfPlayers.PaintEvent += Draw;
    }

    /// <summary>
    /// Отрисовывает ввод имен игроков
    /// </summary>
    public override void Draw()
    {
      Platform.Clear();
      Platform.PrintText(35.0f, 10.0f, "Enter names of players:");
      Platform.PrintText(35.0f, 70.0f, "Press Enter to start game");
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
