using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System;

namespace mail_manager.Controllers
{
    public class AliasController : Controller
    {
        private readonly Models.MailDBContext _context;

        public AliasController(Models.MailDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var Aliases = _context.Aliases.ToList();
            return View("Index", Aliases);
        }

        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Models.Aliases aliases)
        {
            _context.Aliases.Add(aliases);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult UpdateEnabled(int id, bool state)
        {
            var result = new Dictionary<string, string> { { "success", true.ToString() } };
            try
            {
                var alias = _context.Aliases.Find(id);
                alias.Enabled = state;
                _context.SaveChanges();
                result["success"] = true.ToString();
            }
            catch
            {
                result["success"] = false.ToString();
            }
            return Json(result);
        }

        // [ValidateAntiForgeryToken]
        public IActionResult ConfirmDelete(int? id)
        {
            // var alias = from a in _context.Aliases where a.Id == id select a;
            var alias = _context.Aliases.Find(id);
            // if (isConfirmed)
            // {
            //     try {
            //         _context.Remove();
            //     }
            // }
            // return NotFound();
            return View("ConfirmDelete", alias);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // return View("Index", _context.Aliases.ToList());
                    // _context.Remove(alias);
                    // _context.SaveChanges();
                }
                catch
                {

                }
            }
            return RedirectToAction("Index");
        }
    }
}