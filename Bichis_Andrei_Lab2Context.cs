using Microsoft.EntityFrameworkCore;

public class Bichis_Andrei_Lab2Context(DbContextOptions<Bichis_Andrei_Lab2Context> options) : DbContext(options)
{
    public DbSet<Bichis_Andrei_Lab2.Models.Book> Book { get; set; } = default!; 
    public DbSet<Bichis_Andrei_Lab2.Models.Publisher> Publisher { get; set; } = default!;
    public DbSet<Bichis_Andrei_Lab2.Models.Author> Author { get; set; } = default!;
}
