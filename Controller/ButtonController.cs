﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using View;

namespace Controller
{
  /// <summary>
  /// Контроллер кнопки
  /// </summary>
  public class ButtonController : BaseContoller
  {
    /// <summary>
    /// Экземпляр кнопки
    /// </summary>
    private Button _button;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parPlatform">Платформа</param>
    /// <param name="parButton">Кнопка</param>
    public ButtonController(Platform parPlatform, Button parButton)
    {
      _button = parButton;
      View = new ButtonView(_button, parPlatform);

      parPlatform.Click += OnClick;
    }

    /// <summary>
    /// Инициализирует контроллер кнопки
    /// </summary>
    public void Initialize()
    {
      _button.CallPaintEvent();
    }

    public override void Start()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Обрабатывает нажатие на кнопку
    /// </summary>
    /// <param name="parSender">Отправитель события</param>
    /// <param name="parE">Параметры события</param>
    private void OnClick(object parSender, EventArgs parE)
    {
      _button.CallClick();
    }
  }
}
