using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Класс связи между ячейками
    /// </summary>
    public class Link
    {
        /// <summary>
        /// Ячейки, которые соединяет связь
        /// </summary>
        private Cell[] _cells = new Cell[2];

        /// <summary>
        /// Ячейки, которые соединяет связь
        /// </summary>
        public Cell[] Cells
        {
            get
            {
                return _cells;
            }
        }

        /// <summary>
        /// Конструктор связи
        /// </summary>
        /// <param name="parFirstCell">Первая ячейка</param>
        /// <param name="parSecondCell">Вторая ячейка</param>
        public Link(Cell parFirstCell, Cell parSecondCell)
        {
            _cells[0] = parFirstCell;
            _cells[1] = parSecondCell;

            parFirstCell.Links.Add(this);
            parSecondCell.Links.Add(this);
        }
    }
}
