using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoAssistenciaTecnicaWeb.Models;

namespace ProjetoAssistenciaTecnicaWeb.Data
{
    public class ProjetoAssistenciaTecnicaWebContext : DbContext
    {
        public ProjetoAssistenciaTecnicaWebContext (DbContextOptions<ProjetoAssistenciaTecnicaWebContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Peca> Peca { get; set; }
        public DbSet<Produto> Produto { get; set; }
    }
}
