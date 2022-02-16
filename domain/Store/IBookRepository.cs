using System.Collections.Generic;

namespace Store
{
    public interface IBookRepository
    {
        Book[] GetAllByTitleOrAuthor(string titleOrAuthor);

        Book[] GetAllByIsbn(string isbn);

        Book GetById(int id);

        Book[] GetAllByIds(IEnumerable<int> bookIds);
    }
}