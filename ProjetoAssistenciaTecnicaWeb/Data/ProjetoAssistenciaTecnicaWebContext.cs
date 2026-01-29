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

        public DbSet<ProjetoAssistenciaTecnicaWeb.Models.Cliente> Cliente { get; set; } = default!;
        public DbSet<ProjetoAssistenciaTecnicaWeb.Models.Endereco> Endereco { get; set; } = default!;
    }
}
