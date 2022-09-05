using System;
using System.Collections.Generic;

namespace Napilnik1
{
    public class Warehouse
    {
        private List<Cell> _cells = new List<Cell>();
        private List<Cell> _reserves = new List<Cell>();

        public void Delive(Good good, int amount)
        {
            if (good != null && amount > 0)
                AddGood(good, amount, _cells);
        }

        public void ShowRemains()
        {
            Console.WriteLine("Remaining goods in warehous:");

            foreach (Cell cell in _cells)
            {
                cell.ShowGood();
            }
        }

        public bool Reserve(Good good, int amount)
        {
            for (int i = 0; i < _cells.Count; i++)
            {
                if (_cells[i].Good == good && _cells[i].Amount >= amount)
                {
                    _cells[i].ReserveAmount(amount);

                    if (_cells[i].Amount == 0)
                        _cells.RemoveAt(i);

                    return AddGood(good, amount, _reserves);
                }
            }

            return false;
        }

        public void RemoveReserve(Cart cart)
        {
            List<Cell> cellsInCart = cart.GetGoods();

            foreach (Cell cell in cellsInCart)
            {
                for (int i = 0; i < _reserves.Count; i++)
                {
                    if (cell.Good == _reserves[i].Good)
                    {
                        _reserves[i].ReserveAmount(cell.Amount);

                        if (_reserves[i].Amount == 0)
                            _reserves.RemoveAt(i);

                        break;
                    }
                }
            }
        }

        private bool AddGood(Good good, int amount, List<Cell> cells)
        {
            foreach (Cell cell in cells)
            {
                if (cell.Good == good)
                {
                    cell.AddAmount(amount);
                    return true;
                }
            }

            cells.Add(new Cell(good, amount));
            return true;
        }
    }
}
