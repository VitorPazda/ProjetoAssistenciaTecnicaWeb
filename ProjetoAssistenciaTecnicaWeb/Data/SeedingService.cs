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

            Endereco endereco1 = new Endereco(1, "SC", "Canoinhas", "89460000", "Rua bonita", "Bairro legal", "Casa grande", "200");

            Cliente cliente1 = new Cliente(1, "Vitor", "11111111111", "47 9999999", "vitor@gmail.com", new DateTime(2005, 09, 18), DateTime.Now, "Cliente", endereco1);

            Endereco endereco2 = new Endereco(2, "SC", "Canoinhas", "89460000", "Rua legal", "Bairro show", "Casa Bonita", "200");

            Cliente cliente2 = new Cliente(2, "Filipe Sandero", "51939388090", "47 9999999", "filipe@gmail.com", new DateTime(2005, 09, 06), DateTime.Now, "Cliente", endereco2);

            Endereco endereco3 = new Endereco(3, "SC", "Canoinhas", "89460000", "Rua do Gueto", "Bairro Perigoso", "Casa com piscina", "200");

            Cliente cliente3 = new Cliente(3, "Vinicius Saquinho", "24076541022", "47 9999999", "vinicius_saquinho@gmail.com", new DateTime(2005, 09, 06), DateTime.Now, "Cliente", endereco3);
            // Add no banco

            _context.Cliente.AddRange(cliente1, cliente2, cliente3);
            _context.Endereco.AddRange(endereco1, endereco2, endereco3);

            _context.SaveChanges();
        }
    }
}
