using COMP2139_ICE.Data;
using COMP2139_ICE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace COMP2139_ICE.Controllers
{
    public class ProjectTaskController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectTaskController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProjectTask?projectId=5
        public async Task<IActionResult> Index(int projectId)
        {
            var project = await _context.Projects
                .Include(p => p.Tasks)
                .FirstOrDefaultAsync(p => p.ProjectId == projectId);

            if (project == null)
            {
                return NotFound();
            }

            ViewBag.ProjectId = projectId;
            ViewBag.ProjectName = project.Name;

            return View(project.Tasks ?? new List<ProjectTask>());
        }

        // GET: ProjectTask/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var task = await _context.ProjectTasks
                .Include(t => t.Project)
                .FirstOrDefaultAsync(t => t.ProjectTaskId == id);

            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // GET: ProjectTask/Create?projectId=5
        public IActionResult Create(int projectId)
        {
            var task = new ProjectTask
            {
                ProjectId = projectId
            };
            return View(task);
        }

        // POST: ProjectTask/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,ProjectId")] ProjectTask projectTask)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectTask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { projectId = projectTask.ProjectId });
            }
            return View(projectTask);
        }

        // GET: ProjectTask/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var task = await _context.ProjectTasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        // POST: ProjectTask/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectTaskId,Title,Description,ProjectId")] ProjectTask projectTask)
        {
            if (id != projectTask.ProjectTaskId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(projectTask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { projectId = projectTask.ProjectId });
            }
            return View(projectTask);
        }

        // GET: ProjectTask/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var task = await _context.ProjectTasks
                .Include(t => t.Project)
                .FirstOrDefaultAsync(t => t.ProjectTaskId == id);

            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // POST: ProjectTask/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var task = await _context.ProjectTasks.FindAsync(id);
            if (task != null)
            {
                int projectId = task.ProjectId;
                _context.ProjectTasks.Remove(task);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { projectId = projectId });
            }
            return RedirectToAction("Index", "Project");
        }
    }
}