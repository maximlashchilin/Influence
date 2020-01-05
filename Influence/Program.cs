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
    /// <param name="args">Аргументы командной строки</param>
    static void Main(string[] args)
    {
      new MainController(new ConsolePlatform()).Start();
    }
  }
}
