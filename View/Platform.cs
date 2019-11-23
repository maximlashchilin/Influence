using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
  public abstract class Platform
  {
    public abstract void PrintText(float parX, float parY, string parText);

    public abstract void DrawRectangle(float parX1, float parY1, float parX2, float parY2);

    public abstract void PrintTextInRectangle(float parX1, float parY1, float parX2, float parY2, string parText);

    public abstract void DrawHexagonWithScore(float parX, float parY, int parScore);
  }
}
