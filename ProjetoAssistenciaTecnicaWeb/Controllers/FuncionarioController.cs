using Microsoft.AspNetCore.Mvc;

namespace ProjetoAssistenciaTecnicaWeb.Controllers
{
    public class FuncionarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
