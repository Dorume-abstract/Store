using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[]
        {
            new Book(1, "The Art of Computer Programming", "ISBN 0321751043", "D. Knuth", "Descripton The Art of Computer Programming", 7.19m),
            new Book(2, "Refactoring", "ISBN 1234567890", "M. FLower", "Description Refactoring", 12.45m),
            new Book(3, "C Programming Language", "ISBN 1597536548520", "B. Kernigan, D. Ritchie", "Description C Programming Language", 14.98m)
        };

        public Book[] GetAllByTitleOrAuthor(string titleOrAuthor)
        {
            if (titleOrAuthor == null) return new Book[0];
            return books.Where(book => book.Title.Contains(titleOrAuthor) 
                                       || book.Author.Contains(titleOrAuthor))
                .ToArray();
        }

        public Book[] GetAllByIsbn(string isbn)
        {
            if (isbn == null) return new Book[0];
            return books.Where(book => book.Isbn.Contains(isbn))
                .ToArray();
        }

        public Book GetById(int id)
        {
            return books.Single(book => book.Id == id);
        }

        public Book[] GetAllByIds(IEnumerable<int> bookIds)
        {
            var foundBooks = from book in books
                            join bookId in bookIds on book.Id equals bookId
                            select book;
            return foundBooks.ToArray();
        }
    }
}
