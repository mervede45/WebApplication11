using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebApplication11.Models;

namespace WebApplication11.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Categories
        public async Task<ActionResult> Index()
        {
            var userId = User.Identity.GetUserId();
            var categories = await db.Categories
                .Where(c => c.UserId == userId)
                .ToListAsync();
            return View(categories);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                category.UserId = User.Identity.GetUserId();
                db.Categories.Add(category);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Categories/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var userId = User.Identity.GetUserId();
            var category = await db.Categories
                .FirstOrDefaultAsync(c => c.Id == id && c.UserId == userId);

            if (category == null)
            {
                return HttpNotFound();
            }

            return View(category);
        }

        // POST: Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                var existingCategory = await db.Categories
                    .FirstOrDefaultAsync(c => c.Id == category.Id && c.UserId == userId);

                if (existingCategory == null)
                {
                    return HttpNotFound();
                }

                existingCategory.Name = category.Name;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Categories/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var userId = User.Identity.GetUserId();
            var category = await db.Categories
                .FirstOrDefaultAsync(c => c.Id == id && c.UserId == userId);

            if (category == null)
            {
                return HttpNotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var userId = User.Identity.GetUserId();
            var category = await db.Categories
                .FirstOrDefaultAsync(c => c.Id == id && c.UserId == userId);

            if (category != null)
            {
                db.Categories.Remove(category);
                await db.SaveChangesAsync();
            }

            return RedirectToAction("Index");
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