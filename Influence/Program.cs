using Controller;
using ConsoleView;

namespace Influence
{
  class Program
  {
    static void Main(string[] args)
    {
      new MainController(new ConsolePlatform()).Start();
    }
  }
}
