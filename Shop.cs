namespace Napilnik1
{
    public class Shop
    {
        private Warehouse _warehouse;

        public Shop(Warehouse warehouse)
        {
            _warehouse = warehouse;
        }

        public Cart Cart()
        {
            return new Cart(this);
        }

        public bool TryReserveGood(Good good, int amount)
        {
            return _warehouse.Reserve(good, amount);
        }

        public void Sell(Cart cart)
        {
            if (cart.IsPaid)
            {
                _warehouse.RemoveReserve(cart);
                cart.Ravage();
            }
        }
    }
}
