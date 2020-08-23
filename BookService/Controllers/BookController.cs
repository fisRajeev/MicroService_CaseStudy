using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookService;
using BookService.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookService.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        // GET api/books
        [HttpGet]
        public ActionResult<Book[]> Get()
        {
            Books obj = new Books();
            return obj.GetBooks();
        }

        // GET api/books/5
        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            Books obj = new Books();
            Book b = obj.GetBookByID(id);

            if(b.bookName.Length > 0)
            {
                return b;
            }
            else
            {
                return NotFound();
            }
        }

       

        // PUT api/books/UpdateAvailability/{bookId}/{incremental_count}
        [HttpPut("UpdateAvailability/{bookId}/{incremental_count}")]
        public Book UpdateAvailability(int bookId, int incremental_count)
        {
            Books obj = new Books();
            bool result = obj.UpdateAvailability(bookId, incremental_count);

            if (result)
            {
                return obj.GetBookByID(bookId);
            }
            else
            {
                return null;
            }
        }

       
    }
}
