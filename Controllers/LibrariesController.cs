using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROAssignment2.Models;

namespace PROAssignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrariesController : ControllerBase
    {
        private readonly LibraryContext _context;

        private readonly BookContext _bookContext;

        public LibrariesController(LibraryContext context)
        {
            _context = context;
        }

        // GET: api/Libraries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Library>>> GetLibrary()
        {
            return await _context.Library.ToListAsync();
        }

        // GET: api/Libraries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Library>> GetLibrary(int id)
        {
            var library = await _context.Library.FindAsync(id);

            if (library == null)
            {
                return NotFound();
            }

            return library;
        }

        // GET: api/Libraries/5/books
        [HttpGet("{id}/books")]
        public async Task<ActionResult<IEnumerable<Book>>> GetLibraryBooks(int id)
        {

            var books = await _bookContext.Book.Where(b => b.libraryID == id).ToListAsync();

            if(books == null)
            {
                return NotFound();
            }
            else
            {
                return books;
            }
        }

        
        // PUT: api/Libraries/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibrary(int id, Library library)
        {
            if (id != library.libraryID)
            {
                return BadRequest();
            }

            _context.Entry(library).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibraryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Libraries
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Library>> PostLibrary(Library library)
        {
            _context.Library.Add(library);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLibrary", new { id = library.libraryID }, library);
        }

        // DELETE: api/Libraries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Library>> DeleteLibrary(int id)
        {
            var library = await _context.Library.FindAsync(id);
            if (library == null)
            {
                return NotFound();
            }

            _context.Library.Remove(library);
            await _context.SaveChangesAsync();

            return library;
        }

        private bool LibraryExists(int id)
        {
            return _context.Library.Any(e => e.libraryID == id);
        }
    }
}
