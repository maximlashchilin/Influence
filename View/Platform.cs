﻿using System;
using Model;

namespace View
{
  /// <summary>
  /// Абстрактная графическая платформа
  /// </summary>
  public abstract class Platform
  {
    /// <summary>
    /// Ширина платформы
    /// </summary>
    private int _widthPlatform;

    /// <summary>
    /// Высота платформы
    /// </summary>
    private int _heightPlatform;

    /// <summary>
    /// Событие нажатия клавиши со стрелкой вверх
    /// </summary>
    public event EventHandler ArrowUp;

    /// <summary>
    /// Событие нажатия клавиши со стрелкой вниз
    /// </summary>
    public event EventHandler ArrowDown;

    /// <summary>
    /// Событие нажатия Enter
    /// </summary>
    public event EventHandler EnterDown;

    /// <summary>
    /// Событие нажатия Esc
    /// </summary>
    public event EventHandler EscDown;

    /// <summary>
    /// Событие нажатия клавиши
    /// </summary>
    public event dKeyDownEventHandler KeyDown;

    /// <summary>
    /// Событие перемещения курсора мыши
    /// </summary>
    public event dMoveEventHander Move;

    /// <summary>
    /// Событие клика мыши
    /// </summary>
    public event EventHandler Click;

    /// <summary>
    /// Ширина платформы
    /// </summary>
    public int WidthPlatform
    {
      get
      {
        return _widthPlatform;
      }
      set
      {
        _widthPlatform = value;
      }
    }

    /// <summary>
    /// Высота платформы
    /// </summary>
    public int HeightPlatform
    {
      get
      {
        return _heightPlatform;
      }
      set
      {
        _heightPlatform = value;
      }
    }

    /// <summary>
    /// Вызывает событие нажатия клавиши со стрелкой вверх
    /// </summary>
    protected virtual void CallArrowUpDown()
    {
      ArrowUp?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// Вызывает событие нажатия клавиши со стрелкой вниз
    /// </summary>
    protected virtual void CallArrowDown()
    {
      ArrowDown?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// Вызывает событие нажатия клавиши Enter
    /// </summary>
    protected virtual void CallEnterDown()
    {
      EnterDown?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// Вызывает событиие нажатия клавиши Esc
    /// </summary>
    protected virtual void CallEscDown()
    {
      EscDown?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// Вызывает событие нажатия клавиши
    /// </summary>
    /// <param name="parE">Параметры события</param>
    protected virtual void CallKeyDown(KeyDownEventArgs parE)
    {
      KeyDown?.Invoke(this, parE);
    }

    /// <summary>
    /// Вызывает событие перемещения курсора мыши
    /// </summary>
    /// <param name="parE"></param>
    protected virtual void CallMove(MoveEventArgs parE)
    {
      Move?.Invoke(this, parE);
    }

    /// <summary>
    /// Вызывает событие клика мышью
    /// </summary>
    protected virtual void CallClick()
    {
      Click?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// Удаляет обработчики всех событий
    /// </summary>
    public void UnsubscribeAllEvents()
    {
      ArrowUp = null;
      ArrowDown = null;
      EnterDown = null;
      KeyDown = null;
      Move = null;
      Click = null;
    }

    /// <summary>
    /// Переводит исходную координату X в координату X платформы
    /// </summary>
    /// <param name="parBaseX">Исходная координата X</param>
    /// <returns>Координата X платформы</returns>
    public int TranslateBaseXToPlatformX(float parBaseX)
    {
      return (int)(parBaseX / 100.0f * _widthPlatform);
    }

    /// <summary>
    /// Переводит исходную координату Y в координату Y платформы
    /// </summary>
    /// <param name="parBaseY">Исходная координата Y</param>
    /// <returns>Координата Y платформы</returns>
    public int TranslateBaseYToPlatformY(float parBaseY)
    {
      return (int)(parBaseY / 100.0f * _heightPlatform);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="parPlatformX"></param>
    /// <returns></returns>
    public float TranslatePlatformXToBaseX(int parPlatformX)
    {
      return (float)parPlatformX / _widthPlatform * 100.0f;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="parPlatformY"></param>
    /// <returns></returns>
    public float TranslatePlatformYToBaseY(int parPlatformY)
    {
      return (float)parPlatformY / _heightPlatform * 100;
    }

    /// <summary>
    /// Инициализирует платформу
    /// </summary>
    public abstract void Initialize();

    /// <summary>
    /// Уничтожает платформу
    /// </summary>
    public abstract void Drop();

    /// <summary>
    /// Очищает область отрисовки
    /// </summary>
    public abstract void Clear();

    /// <summary>
    /// Печатает текст
    /// </summary>
    /// <param name="parX"></param>
    /// <param name="parY"></param>
    /// <param name="parText"></param>
    public abstract void PrintText(float parX, float parY, string parText);

    /// <summary>
    /// Отрисовывает прямоугольник
    /// </summary>
    /// <param name="parX1"></param>
    /// <param name="parY1"></param>
    /// <param name="parX2"></param>
    /// <param name="parY2"></param>
    public abstract void DrawRectangle(float parX1, float parY1, float parX2, float parY2);

    /// <summary>
    /// Печатает текст в прямоугольнике
    /// </summary>
    /// <param name="parX1"></param>
    /// <param name="parY1"></param>
    /// <param name="parX2"></param>
    /// <param name="parY2"></param>
    /// <param name="parText"></param>
    /// <param name="parCursorVisible"></param>
    public abstract void PrintTextInRectangle(float parX1, float parY1, float parX2, float parY2, string parText, bool parCursorVisible);

    /// <summary>
    /// Печатает текст в выделенном прямоугольнике
    /// </summary>
    /// <param name="parX1"></param>
    /// <param name="parY1"></param>
    /// <param name="parX2"></param>
    /// <param name="parY2"></param>
    /// <param name="parText"></param>
    /// <param name="parCursorVisible"></param>
    public abstract void PrintMarkedTextInRectangle(float parX1, float parY1, float parX2, float parY2, string parText, bool parCursorVisible);

    /// <summary>
    /// Отрисовывает игровую ячейку
    /// </summary>
    /// <param name="parX"></param>
    /// <param name="parY"></param>
    /// <param name="parScore"></param>
    /// <param name="parColor"></param>
    public abstract void DrawHexagonWithScore(float parX, float parY, int parScore, ItemColor parColor);
  }
}
