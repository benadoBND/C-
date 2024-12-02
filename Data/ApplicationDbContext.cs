using Microsoft.EntityFrameworkCore;
using GerenciamentoAPI.Models;

namespace GerenciamentoAPI.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<Fornecedor> Fornecedores { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }
}