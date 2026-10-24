using Bichis_Andrei_Lab2.Models;
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
    public BookData BookD { get; set; } = default!;
    public int BookID { get; set; }
    public int CategoryID { get; set; }

    public async Task OnGetAsync(int? id, int? categoryID, int? authorID)
    {
        BookD = new BookData();

        ViewData["AuthorID"] = new SelectList(_context.Set<Author>(), "ID", "FullName");

        var booksQuery = _context.Book
            .Include(b => b.Publisher)
            .Include(b => b.Author)
            .Include(b => b.BookCategories)
                .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Title)
            .AsQueryable();

        if (authorID.HasValue)
        {
            booksQuery = booksQuery.Where(b => b.AuthorID == authorID.Value);
        }

        BookD.Books = await booksQuery.ToListAsync();

        if (id != null)
        {
            BookID = id.Value;
            Book book = BookD.Books
                .Single(i => i.ID == id.Value);
            BookD.Categories = book.BookCategories.Select(s => s.Category!);
        }
    }
}