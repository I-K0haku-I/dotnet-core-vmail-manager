using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace mail_manager.Controllers
{
    public class AccountController : Controller
    {
        private readonly Models.MailDBContext _context;

        public AccountController(Models.MailDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var Accounts = _context.Accounts.ToList();
            return View("Index", Accounts);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Models.Accounts Account)
        {
            return RedirectToAction("Index");
        }
    }
}