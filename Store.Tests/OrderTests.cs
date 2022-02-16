using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Xunit;

namespace Store.Tests
{
    public class OrderTests
    {
        [Fact]
        public void Order_WithNullItems_ThrowsArgumentNullExceptions()
        {
            Assert.Throws<ArgumentNullException>(() => new Order(null, 1));
        }

        [Fact]
        public void TotalCount_WithEmptyItems_ReturnsZero()
        {
            var order = new Order(new OrderItem[0], 1);
            Assert.Equal(0, order.TotalCount);
        }

        [Fact]
        public void TotalPrice_WithEmptyItems_ReturnsZero()
        {
            var order = new Order(new OrderItem[0], 1);
            Assert.Equal(0m, order.TotalPrice);
        }

        [Fact]
        public void TotalCount_WithNonEmptyItems_CalculatesTotalCount()
        {
            var order = new Order(new[]
            {
                new OrderItem(1, 3, 10m),
                new OrderItem(2, 5, 100m)
            }, 1);

            Assert.Equal(3 + 5, order.TotalCount);
        }

        [Fact]
        public void TotalPrice_WithNonEmptyItems_CalculatesTotalPricet()
        {
            var order = new Order(new[]
            {
                new OrderItem(1, 3, 10m),
                new OrderItem(2, 5, 100m)
            }, 1);

            Assert.Equal(3 * 10m + 5 * 100m, order.TotalPrice);
        }
    }
}