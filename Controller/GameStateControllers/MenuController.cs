using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using View;

namespace Controller
{
  /// <summary>
  /// Контроллер меню
  /// </summary>
  public class MenuController : BaseContoller
  {
    /// <summary>
    /// Меню
    /// </summary>
    private Menu _menu;

    /// <summary>
    /// Контроллеры элементов меню
    /// </summary>
    private List<MenuItemController> _menuItemControllers;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parPlatform">Платформа</param>
    public MenuController(Platform parPlatform)
    {
      string menuName = "Main menu";
      _menu = new Menu(menuName);
      View = new MenuView(parPlatform, _menu);
      _menu.AddItem(0, "Новая игра");
      _menu.AddItem(1, "Рекорды");
      _menu.AddItem(2, "Справка");
      _menu.AddItem(3, "Выход");
      _menu.Initialize();
      _menuItemControllers = InitMenuItemsControllers(parPlatform, _menu.MenuItems.ToList());

      parPlatform.ArrowUp += OnArrowUp;
      parPlatform.ArrowDown += OnArrowDown;
      SubscribeOnChangeState();
    }

    public override void Start()
    {
      
    }

    /// <summary>
    /// Инициализирует контроллеры элементов меню
    /// </summary>
    /// <param name="parPlatform">Платформа</param>
    /// <param name="parMenuItems">Элементы меню</param>
    /// <returns>Контроллеры элементов меню</returns>
    private List<MenuItemController> InitMenuItemsControllers(Platform parPlatform, List<KeyValuePair<int, MenuItem>> parMenuItems)
    {
      List<MenuItemController> controllers = new List<MenuItemController>();
      foreach (KeyValuePair<int, MenuItem> elItem in parMenuItems)
      {
        controllers.Add(new MenuItemController(parPlatform, elItem.Value));
      }

      return controllers;
    }

    /// <summary>
    /// Подписывает на событие изменения состояния
    /// приложения
    /// </summary>
    private void SubscribeOnChangeState()
    {
      for (int i = 0; i < _menuItemControllers.Count; i++)
      {
        _menuItemControllers[i].ChangeState += OnChangeState;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="parSender"></param>
    /// <param name="parEventArgs"></param>
    private void OnMove(object parSender, MoveEventArgs parEventArgs)
    {

    }

    /// <summary>
    /// Обрабатывает нажатие стрелки вверх
    /// </summary>
    /// <param name="parSender">Отправитель события</param>
    /// <param name="parEventArgs">Параметры события</param>
    private void OnArrowUp(object parSender, EventArgs parEventArgs)
    {
      _menu.Previous();
    }

    /// <summary>
    /// Обрабатывает нажатие стрелки вниз
    /// </summary>
    /// <param name="parSender">Отправитель события</param>
    /// <param name="parEventArgs">Параметры события</param>
    private void OnArrowDown(object parSender, EventArgs parEventArgs)
    {
      _menu.Next();
    }

    /// <summary>
    /// Обрабатывает изменение состояния приложения
    /// </summary>
    /// <param name="parSender">Отправитель события</param>
    /// <param name="parE">Параметры события</param>
    private void OnChangeState(object parSender, ChangeStateArgs parE)
    {
      CallChangeState(this, parE);
    }
  }
}
