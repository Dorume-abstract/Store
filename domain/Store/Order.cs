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

        public void RemoveItem(Book book, int count)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            if (items.Count == 0)
                throw new InvalidOperationException("Cart must contain items");

            var item = items.SingleOrDefault(x => x.BookId == book.Id);
            if (item == null)
                throw new InvalidOperationException("Cart does not contain item with ID: " + book.Id);

            items.Remove(item);
            if (item.Count - count == 0)
                return;
            
            items.Add(new OrderItem(book.Id, item.Count - count, book.Price));
        }

        public void RemoveItems(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            if (items.Count == 0)
                throw new InvalidOperationException("Cart must contain items");

            var item = items.SingleOrDefault(x => x.BookId == book.Id);
            if (item == null)
                throw new InvalidOperationException("Cart does not contain item with ID: " + book.Id);

            items.RemoveAll(x => x.BookId == book.Id);
        }
    }
}