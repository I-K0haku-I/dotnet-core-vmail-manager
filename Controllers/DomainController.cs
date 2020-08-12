using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace mail_manager.Controllers
{
    public class DomainController : Controller
    {
        private readonly Models.MailDBContext _context;

        public DomainController(Models.MailDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var Domains = _context.Domains.ToList();
            return View("Index", Domains);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Models.Domains domain)
        {
            return RedirectToAction("Index");
        }
    }
}