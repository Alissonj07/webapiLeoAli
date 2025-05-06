using Microsoft.EntityFrameworkCore;
using ProjetoAliLeo.Models;

namespace ProjetoAliLeo.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Evento> Eventos { get; set; }
}

