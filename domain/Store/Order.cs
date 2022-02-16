using System;
using System.Collections.Generic;
using System.Linq;

namespace Store
{
    public class Order
    {
        public int Id { get; }

        private List<OrderItem> items;

        public IReadOnlyCollection<OrderItem> Items => items;

        public int TotalCount
        {
            get
            {
                return items.Sum(item => item.Count);
            }
        }

        public decimal TotalPrice
        {
            get
            {
                return items.Sum(item => item.Price * item.Count);
            }
        }

        public Order(IEnumerable<OrderItem> items, int id)
        {
            if(items == null)
                throw new ArgumentNullException(nameof(items));

            this.items = new List<OrderItem>(items);
            Id = id;
        }

        public void AddItem(Book book, int count)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            var item = Items.SingleOrDefault(x => x.BookId == book.Id);
            if (item == null)
            {
                items.Add(new OrderItem(book.Id, count, book.Price));
            }
            else
            {
                items.Remove(item);
                items.Add(new OrderItem(book.Id, item.Count + count, book.Price));
            }
        }
    }
}