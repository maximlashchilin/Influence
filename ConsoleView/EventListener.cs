using System.ComponentModel;
using System.Threading;

namespace ConsoleView
{
  /// <summary>
  /// Слушатель событий Windows
  /// </summary>
  public class EventListener
  {
    /// <summary>
    /// Событие работы с мышью в консоли
    /// </summary>
    public event dConsoleMouseEventHandler ConsoleMouseEvent;

    /// <summary>
    /// Событие работы с клавиатурой в консоли
    /// </summary>
    public event dConsoleKeyboardEventHandler ConsoleKeyboardEvent;

    /// <summary>
    /// Экземпляр слушателя
    /// </summary>
    private static EventListener _instance;

    /// <summary>
    /// Поток слушателя
    /// </summary>
    private Thread _listenerThread;

    /// <summary>
    /// Признак выполнения потока
    /// </summary>
    private bool _isRun;

    /// <summary>
    /// Объект синхронизации
    /// </summary>
    private static object _syncObject = new object();

    /// <summary>
    /// Конструктор слушателя
    /// </summary>
    private EventListener()
    {
      _listenerThread = new Thread(ProcessWinEvent);
    }

    /// <summary>
    /// Возвращает экземпляр слушателя
    /// </summary>
    /// <returns>Экземпляр слушателя</returns>
    public static EventListener GetIntance()
    {
      if (null == _instance)
      {
        lock (_syncObject)
        {
          if (null == _instance)
          {
            _instance = new EventListener();
          }
        }
      }

      return _instance;
    }
    /// <summary>
    /// Инициализирует слушателя
    /// </summary>
    public void Initialize()
    {
      _isRun = true;
      _listenerThread.Start();
    }

    /// <summary>
    /// Останавливает слушателя
    /// </summary>
    public void Stop()
    {
      _isRun = false;
    }

    /// <summary>
    /// Обрабатывает события Windows
    /// </summary>
    private void ProcessWinEvent()
    {
      var handle = NativeMethodsProvider.GetStdHandle(NativeMethodsProvider.STD_INPUT_HANDLE);

      int mode = 0;
      if (!(NativeMethodsProvider.GetConsoleMode(handle, ref mode)))
      {
        throw new Win32Exception();
      }

      mode |= NativeMethodsProvider.ENABLE_MOUSE_INPUT;
      mode &= ~NativeMethodsProvider.ENABLE_QUICK_EDIT_MODE;
      mode |= NativeMethodsProvider.ENABLE_EXTENDED_FLAGS;

      if (!(NativeMethodsProvider.SetConsoleMode(handle, mode)))
      {
        throw new Win32Exception();
      }

      var record = new NativeMethodsProvider.INPUT_RECORD();
      uint recordLen = 0;
      while (_isRun)
      {
        if (!(NativeMethodsProvider.ReadConsoleInput(handle, ref record, 1, ref recordLen))) { throw new Win32Exception(); }
        switch (record.EventType)
        {
          case NativeMethodsProvider.MOUSE_EVENT:
            ConsoleMouseEvent?.Invoke(this, new ConsoleMouseEventArgs(record.MouseEvent.dwMousePosition.X, record.MouseEvent.dwMousePosition.Y, record.MouseEvent.dwButtonState));
            break;

          case NativeMethodsProvider.KEY_EVENT:
            ConsoleKeyboardEvent?.Invoke(this, new ConsoleKeyboardEventArgs(record.KeyEvent.bKeyDown, record.KeyEvent.wVirtualKeyCode));
            break;
        }
      }
    }
  }
}
