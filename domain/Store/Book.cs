using System;
using System.Text.RegularExpressions;
using System.Threading;

namespace Store
{
    public class Book
    {
        public int Id { get; }

        public string Title { get; }

        public string Isbn { get; }

        public string Author { get; }

        public Book(int id, string title, string isbn, string author)
        {
            Id = id;
            Title = title;
            Isbn = isbn;
            Author = author;
        }

        internal static bool IsIsbn(string query)
        {
            if (query == null) return false;

            var isbn = query.Replace("-", "")
                .Replace(" ", "")
                .ToUpper();


            return Regex.IsMatch(isbn, @"^ISBN\d{10}(\d{3})?$");
        }
    }
}
