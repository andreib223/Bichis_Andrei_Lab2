using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bichis_Andrei_Lab2.Models;

namespace Bichis_Andrei_Lab2.Pages.PublisherPages;

public class IndexModel : PageModel
{
    private readonly Bichis_Andrei_Lab2Context _context;

    public IndexModel(Bichis_Andrei_Lab2Context context)
    {
        _context = context;
    }

    public IList<Publisher> Publisher { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Publisher = await _context.Publisher.ToListAsync();
    }
}
