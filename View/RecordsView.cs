using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace View
{
  public class RecordsView : BaseView
  {
    private Records _records;

    public RecordsView(Platform parPlatform, Records parRecords) : base(parPlatform)
    {
      _records = parRecords;

      _records.PaintEvent += Draw;
    }

    public override void Draw()
    {
      float delta = 10.0f;

      Platform.Clear();
      for (int i = 0; i < _records.BestResults.Count; i++)
      {
        Platform.PrintText(40.0f, 5.0f + (i * delta), _records.BestResults[i]);
      }
    }
  }
}
