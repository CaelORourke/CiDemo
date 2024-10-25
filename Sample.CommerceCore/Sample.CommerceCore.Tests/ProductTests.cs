namespace Sample.CommerceCore.Tests
{
    public class ProductTests
    {
        [Fact]
        public void Product_ShouldHaveCorrectNameAndPrice()
        {
            // Arrange
            string expectedName = "Laptop";
            decimal expectedPrice = 999.99m;
            int expectedQuantity = 5;

            // Act
            var product = new Product(expectedName, expectedPrice, expectedQuantity);

            // Assert
            Assert.Equal(expectedName, product.Name);
            Assert.Equal(expectedPrice, product.Price);
            Assert.Equal(expectedQuantity, product.Stock);
        }

        [Fact]
        public void Product_ShouldAllowPriceUpdate()
        {
            // Arrange
            var product = new Product("Laptop", 999.99m, 5);

            // Act
            product.UpdatePrice(899.99m);

            // Assert
            Assert.Equal(899.99m, product.Price);
        }

        #region Stock Management Tests

        [Fact]
        public void Product_InitializesWithStockQuantity()
        {
            // Arrange
            int initialStock = 10;

            // Act
            var product = new Product("Laptop", 999.99m, initialStock);

            // Assert
            Assert.Equal(initialStock, product.Stock);
        }

        [Fact]
        public void Product_ThrowsException_WhenCreatedWithNegativeStock()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentException>(() => new Product("Laptop", 999.99m, -5));
        }

        #endregion

        #region Stock Reduction Tests

        [Fact]
        public void ReduceStock_DecreasesStockBySpecifiedAmount()
        {
            // Arrange
            var product = new Product("Laptop", 999.99m, 10);

            // Act
            product.ReduceStock(3);

            // Assert
            Assert.Equal(7, product.Stock);
        }

        [Fact]
        public void ReduceStock_ThrowsException_WhenStockGoesBelowZero()
        {
            // Arrange
            var product = new Product("Laptop", 999.99m, 5);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => product.ReduceStock(6));
        }

        [Fact]
        public void ReduceStock_ThrowsException_WhenReductionAmountIsZeroOrNegative()
        {
            // Arrange
            var product = new Product("Laptop", 999.99m, 10);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => product.ReduceStock(0));
            Assert.Throws<ArgumentException>(() => product.ReduceStock(-1));
        }

        #endregion

        #region Restocking Tests

        [Fact]
        public void Restock_IncreasesStockBySpecifiedAmount()
        {
            // Arrange
            var product = new Product("Laptop", 999.99m, 5);

            // Act
            product.Restock(10);

            // Assert
            Assert.Equal(15, product.Stock);
        }

        [Fact]
        public void Restock_ThrowsException_WhenAmountIsZeroOrNegative()
        {
            // Arrange
            var product = new Product("Laptop", 999.99m, 5);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => product.Restock(0));
            Assert.Throws<ArgumentException>(() => product.Restock(-3));
        }

        #endregion

        #region Price Validation Tests

        [Fact]
        public void Product_ThrowsException_WhenPriceIsLessThanMinValue()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentException>(() => new Product("Laptop", 0.00m, 10));
        }

        [Fact]
        public void Product_ThrowsException_WhenPriceIsNegative()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentException>(() => new Product("Laptop", -1.00m, 10));
        }

        [Fact]
        public void UpdatePrice_ChangesPriceWhenValid()
        {
            // Arrange
            var product = new Product("Laptop", 999.99m, 5);

            // Act
            product.UpdatePrice(899.99m);

            // Assert
            Assert.Equal(899.99m, product.Price);
        }

        [Fact]
        public void UpdatePrice_ThrowsException_WhenNewPriceIsInvalid()
        {
            // Arrange
            var product = new Product("Laptop", 999.99m, 5);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => product.UpdatePrice(0.00m));
            Assert.Throws<ArgumentException>(() => product.UpdatePrice(-10.00m));
        }

        #endregion
    }
}
