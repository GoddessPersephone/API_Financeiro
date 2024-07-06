using Entities.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infra.Configuracao
{
    public class ContextBase : IdentityDbContext<ApplicationUser>
    {
        public ContextBase(DbContextOptions options) : base(options)
        {
        }

        public DbSet<SistemaFinanceiro> TabelaSistemaFinanceiro { set; get; }
        public DbSet<UsuarioSistemaFinanceiro> TabelaUsuarioSistemaFinanceiro { set; get; }
        public DbSet<Categoria> TabelaCategoria { set; get; }
        public DbSet<Despesa> TabelaDespesa { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ObterStringConexao());
                base.OnConfiguring(optionsBuilder);
            }
           
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);
            base.OnModelCreating(builder);
        }
        public string ObterStringConexao()
        {
           // return "Data Sourse=NBQSP-FC693;Inicial Catalog=FINANCEIRO_2023;Integrated Security=False;User ID=sa;Password=1234;Connection ";
           
            return "Data Sourse=NBQSP-FC693;Inicial Catalog=FINANCEIRO_2023;Integrated Security=true;";
        
        
        }


    }
}