using NuGet.Protocol.Plugins;
using ProjetoAssistenciaTecnicaWeb.Models;

namespace ProjetoAssistenciaTecnicaWeb.Data
{
    public class SeedingService
    {
        private ProjetoAssistenciaTecnicaWebContext _context;
        public SeedingService(ProjetoAssistenciaTecnicaWebContext context)
        {
            _context = context;
        }

        // Funcao para popular a base de dados
        public void Seed()
        {
            // Verificar se existe algum dado nas tabelas

            if (_context.Cliente.Any())
            {
                return; // bd ja populado
            }


            // Instanciar os dados no bd

            Endereco endereco1 = new Endereco(1, "SC", "Canoinhas", "89460000", "Rua bonita", "Bairro legal", "Casa grande", "200", 1);

            Cliente cliente1 = new Cliente(1, "Vitor", "11111111111", "47 9999999", "vitor@gmail.com", new DateTime(2005, 00, 18), DateTime.Now, "Cliente", endereco1);
            // Add no banco

            _context.Cliente.AddRange(cliente1);
            _context.Endereco.AddRange(endereco1);

            _context.SaveChanges();
        }
    }
}
