using System;

namespace View
{
  public abstract class Platform
  {
    /// <summary>
    /// 
    /// </summary>
    public event EventHandler ArrowUp;

    /// <summary>
    /// 
    /// </summary>
    public event EventHandler ArrowDown;

    /// <summary>
    /// 
    /// </summary>
    public event EventHandler EnterDown;

    public abstract void Initialize();

    public abstract void Drop();

    protected virtual void OnArrowUpDown()
    {
      ArrowUp?.Invoke(this, EventArgs.Empty);
    }

    protected virtual void OnArrowDown()
    {
      ArrowDown?.Invoke(this, EventArgs.Empty);
    }

    protected virtual void OnEnterDown()
    {
      EnterDown?.Invoke(this, EventArgs.Empty);
    }

    public abstract void PrintText(float parX, float parY, string parText);

    public abstract void DrawRectangle(float parX1, float parY1, float parX2, float parY2);

    public abstract void PrintTextInRectangle(float parX1, float parY1, float parX2, float parY2, string parText);

    public abstract void PrintMarkedTextInRectangle(float parX1, float parY1, float parX2, float parY2, string parText);

    public abstract void DrawHexagonWithScore(float parX, float parY, int parScore);
  }
}
