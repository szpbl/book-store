using BookShop.Data.Context;
using BookShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        #region Fields

        private readonly BooksDbContext context;

        #endregion

        #region Constructor

        public BooksController(BooksDbContext context)
        {
            this.context = context; 
        }

        #endregion

        #region Methods

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var books = await context.Books.ToListAsync();

            return Ok(books);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var book = await context.Books.FindAsync(id);

            if(book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Book book)
        {

            context.Books.Add(book);

            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
    
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put([FromRoute] int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            if (!VerifyIfBookExists(book.Id))
            {
                return NotFound();
            }

            context.Entry(book).State = EntityState.Modified;

            await context.SaveChangesAsync();

            return NoContent();
        } 

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var book = await context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            context.Books.Remove(book);

            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool VerifyIfBookExists(int id)
        {
            return context.Books.Any(book => book.Id == id);
        }
        #endregion
    }
}
