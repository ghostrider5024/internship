using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC2.Models;

namespace MVC2.Controllers
{
    public class StudentsController : Controller
    {
        private readonly Student studentControl;
        private readonly Class classControl;

        public StudentsController()
        {
            studentControl = new Student();
            classControl = new Class();
        }
        // GET: Students
        public async Task<IActionResult> Index()
        {
            return View(await studentControl.GetAllObjectAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            var data = await studentControl.GetObjectAsync(id);
            if (id == null)
            {
                return NotFound();
            }

            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }

        // GET: Students/Create
        public async Task<IActionResult> Create()
        {
            ViewData["Genders"] = new SelectList(new string[] { "Nam", "Nữ" });
            ViewData["ClassId"] = new SelectList(await classControl.GetAllObjectAsync(), "Id", "Name");
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                await studentControl.AddObjectAsync(student);
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassId"] = new SelectList(await classControl.GetAllObjectAsync(), "Id", "Id", student.ClassId);
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await studentControl.GetObjectAsync(id);

            if (student == null)
            {
                return NotFound();
            }
            ViewData["Genders"] = new SelectList(new string[] { "Nam", "Nữ" });
            ViewData["ClassId"] = new SelectList(await classControl.GetAllObjectAsync(), "Id", "Name");
            return View(student);
        }

        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await studentControl.UpdateObjectAsync(student);
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassId"] = new SelectList(await classControl.GetAllObjectAsync(), "Id", "Name", student.ClassId);
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await studentControl.GetObjectAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            await studentControl.DeleteObjectSync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
