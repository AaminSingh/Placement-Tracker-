using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlacementTracker.Data;
using PlacementTracker.Models;

namespace PlacementTracker.Controllers
{
    public class JobApplicationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JobApplicationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: JobApplications
        public async Task<IActionResult> Index()
        {
            return View(await _context.JobApplications.ToListAsync());
        }

        // GET: JobApplications/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JobApplications/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CompanyName,JobRole,Status,AppliedDate,Notes")] JobApplication jobApplication)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobApplication);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jobApplication);
        }

        // GET: JobApplications/Delete/5
public async Task<IActionResult> Delete(int? id)
{
    if (id == null) return NotFound();
    var jobApplication = await _context.JobApplications.FirstOrDefaultAsync(m => m.Id == id);
    if (jobApplication == null) return NotFound();
    return View(jobApplication);
}

// POST: JobApplications/Delete/5
[HttpPost, ActionName("Delete")]
[ValidateAntiForgeryToken]
public async Task<IActionResult> DeleteConfirmed(int id)
{
    var jobApplication = await _context.JobApplications.FindAsync(id);
    if (jobApplication != null) { _context.JobApplications.Remove(jobApplication); }
    await _context.SaveChangesAsync();
    return RedirectToAction(nameof(Index));
}
    }
}