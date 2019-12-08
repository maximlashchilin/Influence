using Controller;
using ConsoleView;

namespace Influence
{
  /// <summary>
  /// Класс запуска программы
  /// </summary>
  class Program
  {
    /// <summary>
    /// Точка входа в программу
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
      new MainController(new ConsolePlatform()).Start();
    }
  }
}
