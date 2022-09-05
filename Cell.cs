using System;

namespace Napilnik1
{
    public class Cell
    {
        public Good Good { get; }
        public int Amount { get; private set; }

        public Cell(Good good, int amount)
        {
            Good = good;
            Amount = amount;
        }

        public void ReserveAmount(int amount)
        {
            if (amount <= 0 || Amount < amount)
                throw new ArgumentOutOfRangeException($"{Good.Name} is not available in amount {amount}.");

            Amount -= amount;
        }

        public void AddAmount(int amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException($"Invalid amount for adding an {Good.Name}.");

            Amount += amount;
        }

        public void ShowGood()
        {
            Console.WriteLine($"Good name: {Good.Name} - amount: {Amount}");
        }
    }
}