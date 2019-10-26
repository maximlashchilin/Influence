using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Класс игровой ячейки
    /// </summary>
    public class Cell
    {
        /// <summary>
        /// Связи ячейки
        /// </summary>
        private List<Link> _links;
        /// <summary>
        /// Текущий статус ячейки
        /// </summary>
        private CellStatus _cellStatus;
        /// <summary>
        /// Число очков ячейки
        /// </summary>
        private int _score;

        /// <summary>
        /// Связи ячейки
        /// </summary>
        public List<Link> Links
        {
            get
            {
                return _links;
            }
        }
        /// <summary>
        /// Текущий статус ячейки
        /// </summary>
        public CellStatus CellStatus
        {
            get
            {
                return _cellStatus;
            }
            set
            {
                _cellStatus = value;
            }
        }

        /// <summary>
        /// Число очков ячейки
        /// </summary>
        public int Score
        {
            get
            {
                return _score;
            }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public Cell()
        {
        }

        /// <summary>
        /// Метод увеличения счёта на единицу
        /// </summary>
        public void IncreaseScore()
        {
            _score++;
        }

        /// <summary>
        /// Метод уменьшения счёта на единицу
        /// </summary>
        public void DecreaseScore()
        {
            _score--;
        }

        /// <summary>
        /// Метод, делающий ячейку активной
        /// </summary>
        public void ActiveCell()
        {
            _cellStatus = CellStatus.Active;
        }

        /// <summary>
        /// Метод, делающий ячейку неактивной
        /// </summary>
        public void DisactiveCell()
        {
            _cellStatus = CellStatus.NotChoosed;
        }
    }
}
