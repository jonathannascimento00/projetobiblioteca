using BibliotecaJoia2.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaJoia2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<EmprestimoModel> Emprestimos { get; set; }
    }
}
