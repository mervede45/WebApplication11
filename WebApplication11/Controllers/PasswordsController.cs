using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebApplication11.Models;

namespace WebApplication11.Controllers
{
    [Authorize]
    public class PasswordsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Passwords
        public async Task<ActionResult> Index(string search, int? categoryId)
        {
            var userId = User.Identity.GetUserId();

            var passwords = db.PasswordEntries
                .Include(p => p.Category)
                .Where(p => p.UserId == userId);

            // Arama filtresi
            if (!string.IsNullOrEmpty(search))
            {
                passwords = passwords.Where(p => p.Title.Contains(search) ||
                                               p.Username.Contains(search) ||
                                               p.Url.Contains(search));
                ViewBag.Search = search;
            }

            // Kategori filtresi
            if (categoryId.HasValue)
            {
                passwords = passwords.Where(p => p.CategoryId == categoryId.Value);
                ViewBag.CategoryId = categoryId;
            }

            // Kategoriler için dropdown
            ViewBag.Categories = new SelectList(
                db.Categories.Where(c => c.UserId == userId),
                "Id", "Name");

            return View(await passwords.OrderByDescending(p => p.CreatedDate).ToListAsync());
        }

        // GET: Passwords/Create
        public ActionResult Create()
        {
            var userId = User.Identity.GetUserId();
            ViewBag.CategoryId = new SelectList(
                db.Categories.Where(c => c.UserId == userId),
                "Id", "Name");
            return View();
        }

        // POST: Passwords/Create - GÜNCELLENMIŞ
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PasswordEntry passwordEntry)
        {
            if (ModelState.IsValid)
            {
                passwordEntry.UserId = User.Identity.GetUserId();
                passwordEntry.CreatedDate = DateTime.Now;
                passwordEntry.LastAccessDate = DateTime.Now;

                // Şifre gücünü hesapla
                passwordEntry.PasswordStrength = PasswordHelper.CalculatePasswordStrength(passwordEntry.Password);

                db.PasswordEntries.Add(passwordEntry);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            var userId = User.Identity.GetUserId();
            ViewBag.CategoryId = new SelectList(
                db.Categories.Where(c => c.UserId == userId),
                "Id", "Name", passwordEntry.CategoryId);
            return View(passwordEntry);
        }

        // GET: Passwords/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var userId = User.Identity.GetUserId();
            var passwordEntry = await db.PasswordEntries
                .FirstOrDefaultAsync(p => p.Id == id && p.UserId == userId);

            if (passwordEntry == null)
            {
                return HttpNotFound();
            }

            ViewBag.CategoryId = new SelectList(
                db.Categories.Where(c => c.UserId == userId),
                "Id", "Name", passwordEntry.CategoryId);
            return View(passwordEntry);
        }

        // POST: Passwords/Edit/5 - GÜNCELLENMIŞ
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(PasswordEntry passwordEntry)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                var existingEntry = await db.PasswordEntries
                    .FirstOrDefaultAsync(p => p.Id == passwordEntry.Id && p.UserId == userId);

                if (existingEntry == null)
                {
                    return HttpNotFound();
                }

                existingEntry.Title = passwordEntry.Title;
                existingEntry.Url = passwordEntry.Url;
                existingEntry.Username = passwordEntry.Username;
                existingEntry.Password = passwordEntry.Password;
                existingEntry.CategoryId = passwordEntry.CategoryId;

                // Şifre gücünü tekrar hesapla
                existingEntry.PasswordStrength = PasswordHelper.CalculatePasswordStrength(passwordEntry.Password);

                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            var userIdForDropdown = User.Identity.GetUserId();
            ViewBag.CategoryId = new SelectList(
                db.Categories.Where(c => c.UserId == userIdForDropdown),
                "Id", "Name", passwordEntry.CategoryId);
            return View(passwordEntry);
        }

        // GET: Passwords/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var userId = User.Identity.GetUserId();
            var passwordEntry = await db.PasswordEntries
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id && p.UserId == userId);

            if (passwordEntry == null)
            {
                return HttpNotFound();
            }

            return View(passwordEntry);
        }

        // POST: Passwords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var userId = User.Identity.GetUserId();
            var passwordEntry = await db.PasswordEntries
                .FirstOrDefaultAsync(p => p.Id == id && p.UserId == userId);

            if (passwordEntry != null)
            {
                db.PasswordEntries.Remove(passwordEntry);
                await db.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        // POST: Passwords/GeneratePassword (AJAX)
        [HttpPost]
        public JsonResult GeneratePassword(int length = 12, bool includeNumbers = true, bool includeSymbols = true)
        {
            const string letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string numbers = "0123456789";
            const string symbols = "!@#$%^&*";

            string chars = letters;
            if (includeNumbers) chars += numbers;
            if (includeSymbols) chars += symbols;

            var random = new Random();
            var password = new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            return Json(new { password = password });
        }

        // YENİ ÖZELLİKLER - Favori İşlemi
        [HttpPost]
        public async Task<JsonResult> ToggleFavorite(int id)
        {
            var userId = User.Identity.GetUserId();
            var passwordEntry = await db.PasswordEntries
                .FirstOrDefaultAsync(p => p.Id == id && p.UserId == userId);

            if (passwordEntry != null)
            {
                passwordEntry.IsFavorite = !passwordEntry.IsFavorite;
                await db.SaveChangesAsync();
                return Json(new { success = true, isFavorite = passwordEntry.IsFavorite });
            }

            return Json(new { success = false });
        }

        // YENİ ÖZELLİKLER - Son kullanım tarihini güncelle
        [HttpPost]
        public async Task<JsonResult> UpdateLastAccess(int id)
        {
            var userId = User.Identity.GetUserId();
            var passwordEntry = await db.PasswordEntries
                .FirstOrDefaultAsync(p => p.Id == id && p.UserId == userId);

            if (passwordEntry != null)
            {
                passwordEntry.LastAccessDate = DateTime.Now;
                await db.SaveChangesAsync();
                return Json(new { success = true });
            }

            return Json(new { success = false });
        }

        // YENİ ÖZELLİKLER - Şifre gücü analizi
        public async Task<ActionResult> SecurityAnalysis()
        {
            var userId = User.Identity.GetUserId();
            var passwords = await db.PasswordEntries
                .Include(p => p.Category)
                .Where(p => p.UserId == userId)
                .ToListAsync();

            ViewBag.WeakPasswords = passwords.Where(p => p.PasswordStrength == 0).Count();
            ViewBag.MediumPasswords = passwords.Where(p => p.PasswordStrength == 1).Count();
            ViewBag.StrongPasswords = passwords.Where(p => p.PasswordStrength == 2).Count();

            // Tekrar eden şifreler
            var duplicatePasswords = passwords
                .GroupBy(p => p.Password)
                .Where(g => g.Count() > 1)
                .Select(g => new { Password = g.Key, Count = g.Count(), Entries = g.ToList() })
                .ToList();

            ViewBag.DuplicatePasswords = duplicatePasswords;

            return View(passwords);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}