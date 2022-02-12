using System;
using System.Linq;

namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[]
        {
            new Book(1, "Art of Programming", "ISBN 123-123-123 0", "D. Knuth"),
            new Book(2, "Refactoring", "ISBN 1234567890", "M. FLower"),
            new Book(3, "C Programming Language", "ISBN 1597536548520", "B. Kernigan, D. Ritchie")
        };

        public Book[] GetAllByTitleOrAuthor(string titleOrAuthor)
        {
            return books.Where(book => book.Title.Contains(titleOrAuthor) 
                                       || book.Author.Contains(titleOrAuthor))
                .ToArray();
        }

        public Book[] GetAllByIsbn(string isbn)
        {
            return books.Where(book => book.Isbn.Contains(isbn))
                .ToArray();
        }
    }
}
