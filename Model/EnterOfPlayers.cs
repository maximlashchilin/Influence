using System.Collections.Generic;

namespace Model
{
  /// <summary>
  /// Отвечает за ввод игроков
  /// </summary>
  public class EnterOfPlayers
  {
    /// <summary>
    /// Событие перерисовки
    /// </summary>
    public event dPaintHandler PaintEvent;

    /// <summary>
    /// Список текстовых полей
    /// </summary>
    private List<TextField> _playersFields;

    /// <summary>
    /// Список текстовых полей
    /// </summary>
    public List<TextField> NamesOfPlayers
    {
      get
      {
        return _playersFields;
      }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    public EnterOfPlayers()
    {
      _playersFields = new List<TextField>(2);
      _playersFields.Add(new TextField(0, 38.0f, 30.0f, 60.0f, 35.0f));
      _playersFields.Add(new TextField(1, 38.0f, 40.0f, 60.0f, 45.0f));
      _playersFields[0].ItemStatus = ItemStatuses.Selected;
    }

    /// <summary>
    /// Инициализирует ввод имен игроков
    /// </summary>
    public void Initialize()
    {
      PaintEvent?.Invoke();
    }

    /// <summary>
    /// Переводит фокус на следующее текстовое поле
    /// </summary>
    public void Next()
    {
      for (int i = 0; i < _playersFields.Count; i++)
      {
        if (_playersFields[i].ItemStatus == ItemStatuses.Selected)
        {
          _playersFields[i].ItemStatus = ItemStatuses.Unselected;

          if (i == _playersFields.Count - 1)
          {
            _playersFields[0].ItemStatus = ItemStatuses.Selected;
            break;
          }
          else
          {
            _playersFields[i + 1].ItemStatus = ItemStatuses.Selected;
            break;
          }
        }
      }

      PaintEvent?.Invoke();
    }

    /// <summary>
    /// Переводит фокус на предыдущее текстовое поле
    /// </summary>
    public void Previous()
    {
      for (int i = 0; i < _playersFields.Count; i++)
      {
        if (_playersFields[i].ItemStatus == ItemStatuses.Selected)
        {
          _playersFields[i].ItemStatus = ItemStatuses.Unselected;

          if (i == 0)
          {
            _playersFields[_playersFields.Count - 1].ItemStatus = ItemStatuses.Selected;
            break;
          }
          else
          {
            _playersFields[i - 1].ItemStatus = ItemStatuses.Selected;
            break;
          }
        }
      }

      PaintEvent?.Invoke();
    }
  }
}
