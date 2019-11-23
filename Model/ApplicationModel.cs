﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Model
{
  public class ApplicationModel
  {
    public ApplicationState State { get; set; }
    public Thread ModelThread { get; set; }

    public delegate void dApplicationState();

    public event dApplicationState ApplicationStateEvent;

    public void Start()
    {
      ModelThread = new Thread(RunApplication);
      State = ApplicationState.MenuWork;
      ModelThread.Start();
    }

    private void RunApplication()
    {
      while (State != ApplicationState.Exit)
      {
        ApplicationStateEvent?.Invoke();
      }
    }
  }
}