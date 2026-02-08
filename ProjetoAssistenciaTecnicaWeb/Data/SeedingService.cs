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

            // Endereco: Estado, Municipio, CEP, Logradouro, Bairro, Complemento, Nº Casa

            Endereco endereco1 = new Endereco(1, "SC", "Canoinhas", "89460000", "Rua bonita", "Bairro legal", "Casa grande", "200");

            Cliente cliente1 = new Cliente(1, "Vitor", "11111111111", "47 9999999", "vitor@gmail.com", new DateTime(2005, 09, 18), DateTime.Now, "Cliente", endereco1);

            Endereco endereco2 = new Endereco(2, "SC", "Canoinhas", "89460000", "Rua legal", "Bairro show", "Casa Bonita", "300");

            Cliente cliente2 = new Cliente(2, "Filipe Sandero", "51939388090", "47 9999999", "filipe@gmail.com", new DateTime(2005, 09, 06), DateTime.Now, "Cliente", endereco2);

            Endereco endereco3 = new Endereco(3, "SC", "Canoinhas", "89460000", "Rua do Gueto", "Bairro Perigoso", "Casa com piscina", "400");

            Cliente cliente3 = new Cliente(3, "Vinicius Saquinho", "24076541022", "47 9999999", "vinicius_saquinho@gmail.com", new DateTime(2001, 11, 17), DateTime.Now, "Cliente", endereco3);

            Endereco endereco4 = new Endereco(4, "SC", "Rio da Areia", "89460000", "Terreno Baudio", "Bairro Interior", "Casa no Mato", "500");

            Cliente cliente4 = new Cliente(4, "Ana Paula Nogath", "77341157054", "47 9999999", "ana@gmail.com", new DateTime(2006, 06, 29), DateTime.Now, "Cliente", endereco4);

            Endereco endereco5 = new Endereco(5, "SC", "Canoinhas", "89460000", "Rua Willibaldo Hoffmann", "Jardim Especança", "Casa Verde", "260");

            Cliente cliente5 = new Cliente(5, "Leomar Dolizete Cardoso", "12257810007", "47 9999999", "leomar@gmail.com", new DateTime(1973, 09, 08), DateTime.Now, "Cliente", endereco5);

            Cliente cliente6 = new Cliente(6, "Miria de Fatima Pazda", "90001491008", "47 9999999", "miria@gmail.com", new DateTime(1972, 09, 28), DateTime.Now, "Cliente", endereco5);

            // Add no banco

            _context.Cliente.AddRange(cliente1, cliente2, cliente3, cliente4, cliente5, cliente6);
            _context.Endereco.AddRange(endereco1, endereco2, endereco3, endereco4, endereco5);

            _context.SaveChanges();
        }
    }
}
