using Bichis_Andrei_Lab2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Bichis_Andrei_Lab2.Pages.BookPages;

public class IndexModel : PageModel
{
    private readonly Bichis_Andrei_Lab2Context _context;

    public IndexModel(Bichis_Andrei_Lab2Context context)
    {
        _context = context;
    }

    public IList<Book> Book { get; set; } = default!;

    public async Task OnGetAsync(int? authorID)
    {
        ViewData["AuthorID"] = new SelectList(_context.Set<Author>(), "ID", "FullName");

        var booksQuery = _context.Book
            .Include(b => b.Publisher)
            .Include(b => b.Author)
            .AsQueryable();

        if (authorID.HasValue)
        {
            booksQuery = booksQuery.Where(b => b.AuthorID == authorID.Value);
        }

        Book = await booksQuery.ToListAsync();
    }
}
