using Microsoft.AspNetCore.Mvc;

namespace ProjetoAssistenciaTecnicaWeb.Controllers
{
    public class ProdutosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
