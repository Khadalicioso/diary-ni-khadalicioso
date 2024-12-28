using diary_webapp.Data;
using diary_webapp.Models;
using Microsoft.AspNetCore.Mvc;

namespace diary_webapp.Controllers
{
    public class DiaryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DiaryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<DiaryEntry> objDiaryEntryList = _db.DiaryEntries.ToList();
            return View(objDiaryEntryList);
        }

        public IActionResult Create()
        {
            var newDiaryEntry = new DiaryEntry(); // Initialize a new DiaryEntry
            return View(newDiaryEntry); // Pass it to the view
        }

        [HttpPost]
        public IActionResult Create(DiaryEntry obj)
        {
            // Check if obj is null
            if (obj == null)
            {
                ModelState.AddModelError("", "Diary entry cannot be null.");
                return View(obj);
            }

            // Check if Title is null or empty
            if (string.IsNullOrEmpty(obj.Title) || obj.Title.Length < 3)
            {
                ModelState.AddModelError("Title", "Title is too short");
            }

            if (ModelState.IsValid)
            {
                _db.DiaryEntries.Add(obj); // Adds the new diary to the database
                _db.SaveChanges(); // Saves the changes to the database
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            DiaryEntry? diaryEntry = _db.DiaryEntries.Find(id);

            if (diaryEntry == null)
            {
                return NotFound();
            }
            return View(diaryEntry);
        }

        [HttpPost]
        public IActionResult Edit(DiaryEntry obj)
        {
            // Check if obj is null
            if (obj == null)
            {
                ModelState.AddModelError("", "Diary entry cannot be null.");
                return View(obj);
            }

            // Check if Title is null or empty
            if (string.IsNullOrEmpty(obj.Title) || obj.Title.Length < 3)
            {
                ModelState.AddModelError("Title", "Title is too short");
            }

            if (ModelState.IsValid)
            {
                _db.DiaryEntries.Update(obj); // Updates the diary in the database
                _db.SaveChanges(); // Saves the changes to the database
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            DiaryEntry? diaryEntry = _db.DiaryEntries.Find(id);

            if (diaryEntry == null)
            {
                return NotFound();
            }
            return View(diaryEntry);
        }

        [HttpPost]
        public IActionResult Delete(DiaryEntry obj)
        {
            _db.DiaryEntries.Remove(obj); // Deletes the diary in the database
            _db.SaveChanges(); // Saves the changes to the database
            return RedirectToAction("Index");
        }
    }
}