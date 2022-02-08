using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly IBookRepository BookRepository;

        public SearchController(IBookRepository bookRepository)
        {
            BookRepository = bookRepository;
        }

        public IActionResult Index(string query)
        {
            var books = BookRepository.GetAllByTitle(query);
            return View(books);
        }
    }
}
