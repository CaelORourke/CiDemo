namespace Sample.CommerceCore
{
    public class Product
    {
        public string Name { get; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }

        public Product(string name, decimal price, int stock)
        {
            if (price < 0.01m)
                throw new ArgumentException("Price must be at least 0.01.");

            if (stock < 0)
                throw new ArgumentException("Stock cannot be negative.");

            Name = name;
            Price = price;
            Stock = stock;
        }

        public void UpdatePrice(decimal newPrice)
        {
            if (newPrice < 0.01m)
                throw new ArgumentException("Price must be at least 0.01.");

            Price = newPrice;
        }

        public void ReduceStock(int amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Reduction amount must be positive.");

            if (amount > Stock)
                throw new InvalidOperationException("Insufficient stock.");

            Stock -= amount;
        }

        public void Restock(int amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Restock amount must be positive.");

            Stock += amount;
        }
    }
}
