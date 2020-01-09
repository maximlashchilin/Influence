using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace View
{
  /// <summary>
  /// Представление просмотра справки
  /// </summary>
  public class HelperView : BaseView
  {
    /// <summary>
    /// Объект справки
    /// </summary>
    private Helper _helper;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parPlatform">Объект платформы</param>
    /// <param name="parHelper">Объект справки</param>
    public HelperView(Platform parPlatform, Helper parHelper) : base(parPlatform)
    {
      _helper = parHelper;

      _helper.PaintEvent += Draw;
    }

    /// <summary>
    /// Отрисовывает просмотр справки
    /// </summary>
    public override void Draw()
    {
      const float DELTA = 4.0f;
      const float X = 40.0f;
      const float Y = 15.0f;
      const string HEAD_STRING = "Help";
      Platform.Clear();
      Platform.PrintText(X, Y, HEAD_STRING);
      for (int i = 0; i < _helper.HelpText.Count; i++)
      {
        Platform.PrintText(X - 5, Y + 7 + (i * DELTA), _helper.HelpText[i]);
      }

      Platform.CallReadyFrame();
    }
  }
}
