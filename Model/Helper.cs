using System;
using System.Linq;
using System.Collections.Generic;

namespace Model
{
  /// <summary>
  /// Справка
  /// </summary>
  public class Helper
  {
    /// <summary>
    /// Событие перерисовки
    /// </summary>
    public event dPaintHandler PaintEvent;

    /// <summary>
    /// Текст справки
    /// </summary>
    private List<string> _helpText;

    /// <summary>
    /// Текст справки
    /// </summary>
    public List<string> HelpText
    {
      get
      {
        return _helpText;
      }
    }

    /// <summary>
    /// Инициализирует справку
    /// </summary>
    public void Initialize()
    {
      string text = Resource.Help;
      _helpText = SplitOnStrings(text);
      PaintEvent?.Invoke();
    }

    /// <summary>
    /// Разделяет текст на строки
    /// </summary>
    /// <param name="parText">Исходный текст</param>
    /// <returns>Список строк текста</returns>
    private List<string> SplitOnStrings(string parText)
    {
      string[] strings = parText.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
     
      return strings.ToList<string>();
    }
  }
}
