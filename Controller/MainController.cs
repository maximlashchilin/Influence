using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Model;

namespace Controller
{
  public class MainController
  {
    private ApplicationModel _applicationModel;

    public void Start()
    {
      _applicationModel = new ApplicationModel();
      _applicationModel.Start();
      _applicationModel.ApplicationStateEvent += ProcessCurrentStatus;
    }

    private void ProcessCurrentStatus()
    {
      //int k = 0;
      while (_applicationModel.State != ApplicationState.Exit)
      {
        Thread.Sleep(100);

        switch (_applicationModel.State)
        {
          case ApplicationState.MenuWork:
            new MenuController();
            break;
          default:
            throw new NotImplementedException();
        }
        //if (k == 10)
        //{
        //  _applicationModel.State = ApplicationState.Exit;
        //}
        //k++;
      }
    }
  }
}
