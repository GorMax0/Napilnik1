using System;
using System.Collections.Generic;

namespace Napilnik1
{
    public class Cart
    {
        private Shop _shop;
        private List<Cell> _cells = new List<Cell>();

        public string Paylink { get; private set; }
        public bool IsPaid { get; private set; }

        public Cart(Shop shop)
        {
            _shop = shop;
        }

        public void Add(Good good, int amount)
        {
            if (good == null)
                throw new ArgumentNullException("Cannot add an null good to cart.");

            if (amount <= 0)
                throw new ArgumentOutOfRangeException("Added amount cannot be equals to zero or less than zero.");

            if (_shop.TryReserveGood(good, amount))
            {
                foreach (Cell cell in _cells)
                {
                    if (cell.Good == good)
                    {
                        cell.AddAmount(amount);
                        return;
                    }
                }

                _cells.Add(new Cell(good, amount));
            }
            else
            {
                throw new ArgumentException($"{good.Name} cannot be added to the cart. Not in the requested amount.");
            }
        }

        public void ShowGoods()
        {
            if (_cells.Count == 0)
            {
                Console.WriteLine("Cart is empty!");
                return;
            }

            Console.WriteLine("Goods in cart:");

            foreach (Cell cell in _cells)
                cell.ShowGood();
        }

        public Cart Order()
        {
            Random random = new Random();

            Paylink = random.Next().ToString();
            IsPaid = true;

            return this;
        }

        public void Ravage()
        {
            if (IsPaid == false)
                throw new ArgumentException("The goods have not been paid yet.");

            _cells.Clear();
        }

        public List<Cell> GetGoods()
        {
            List<Cell> goods = new List<Cell>();

            foreach (Cell good in _cells)
            {
                goods.Add(good);
            }

            return goods;
        }
    }
}
