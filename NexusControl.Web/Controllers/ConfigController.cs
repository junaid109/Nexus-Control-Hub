using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NexusControl.Core.Entities;
using NexusControl.Infrastructure.Data;

namespace NexusControl.Web.Controllers
{
    public class ConfigController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConfigController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Config
        public async Task<IActionResult> Index()
        {
            var flags = await _context.FeatureFlags.ToListAsync();
            return View(flags);
        }

        // GET: Config/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Config/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Key,IsEnabled,RulesJson")] FeatureFlag featureFlag)
        {
            if (ModelState.IsValid)
            {
                _context.Add(featureFlag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(featureFlag);
        }

        // GET: Config/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null) return NotFound();

            var featureFlag = await _context.FeatureFlags.FindAsync(id);
            if (featureFlag == null) return NotFound();
            return View(featureFlag);
        }

        // POST: Config/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Key,IsEnabled,RulesJson")] FeatureFlag featureFlag)
        {
            if (id != featureFlag.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(featureFlag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeatureFlagExists(featureFlag.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(featureFlag);
        }
        
        // POST: Config/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var featureFlag = await _context.FeatureFlags.FindAsync(id);
            if (featureFlag != null)
            {
                _context.FeatureFlags.Remove(featureFlag);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool FeatureFlagExists(Guid id)
        {
            return _context.FeatureFlags.Any(e => e.Id == id);
        }
    }
}
