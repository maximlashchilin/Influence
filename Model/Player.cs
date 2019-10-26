using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Класс игрока
    /// </summary>
    public class Player
    {
        private readonly string _name;
        private bool _signOfMove;
        private readonly ItemColor _itemColor;

        public string Name {
            get
            {
                return _name;
            }
        }

        public ItemColor ItemColor
        {
            get
            {
                return _itemColor;
            }
        }
        public Player(string parName, ItemColor parItemColor)
        {
            _name = parName;
            _itemColor = parItemColor;
        }

        public void StartMove()
        {
            _signOfMove = true;
        }

        public void FinishMove()
        {
            _signOfMove = false;
        }
    }
}
