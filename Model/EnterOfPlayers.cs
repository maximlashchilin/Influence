using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public class EnterOfPlayers
  {
    public event dPaintHandler PaintEvent;

    private List<TextField> _playersFields;

    private Button _button;

    public List<TextField> NamesOfPlayers
    {
      get
      {
        return _playersFields;
      }
    }

    public EnterOfPlayers()
    {
      _button = new Button(42.0f, 80.0f, 55.0f, 95.0f, "Next");
      _playersFields = new List<TextField>(2);
      _playersFields.Add(new TextField(0, 38.0f, 30.0f, 60.0f, 35.0f));
      _playersFields.Add(new TextField(1, 38.0f, 40.0f, 60.0f, 45.0f));
      _playersFields[0].ItemStatus = ItemStatuses.Selected;
    }

    public void Initialize()
    {
      PaintEvent?.Invoke();
    }

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
