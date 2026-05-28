using Microsoft.AspNetCore.Mvc;
using FitnessAppIntership.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using FitnessAppIntership.Services.Interfaces;

namespace FitnessAppIntership.Controllers
{
    [Authorize(Roles = "admin")]
    public class CoachesController : Controller
    {
        private readonly ICoachService _service;
        private readonly IWebHostEnvironment _env;

        public CoachesController(ICoachService service, IWebHostEnvironment env)
        {
            _service = service;
            _env = env;
        }

        public IActionResult Index()
        {
            return View(_service.ListAllCoaches());
        }

        public IActionResult Details(Guid? id)
        {
            if (id == null || !_service.ExistsCoach(id.Value))
            {
                return NotFound();
            }
            return View(_service.GetCoach(id.Value));
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(CoachEntity coachEntity)
        {
            if (ModelState.IsValid)
            {
                IFormFile? file = Request.Form.Files["image"];
                if (file != null)
                {
                    string ext = Path.GetExtension(file.FileName);
                    coachEntity.ImagePath = Guid.NewGuid() + ext;
                    using var saveAs = System.IO.File.Create(Path.Combine(_env.WebRootPath, "files", coachEntity.ImagePath));
                    file.CopyTo(saveAs);
                }
                _service.RegisterCoach(coachEntity);
                return RedirectToAction(nameof(Index));
            }
            return View(coachEntity);
        }

        public IActionResult Edit(Guid? id)
        {
            if (id == null || !_service.ExistsCoach(id.Value))
            {
                return NotFound();
            }
            return View(_service.GetCoach(id.Value));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, CoachEntity coachEntity)
        {
            if (id != coachEntity.Id || !_service.ExistsCoach(id))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                CoachEntity original = _service.GetCoach(id);
                if (Request.Form.TryGetValue("ImageChange", out _))
                {
                    IFormFile? file = Request.Form.Files["image"];
                    if (original.ImagePath != null)
                        System.IO.File.Delete(Path.Combine(_env.WebRootPath, "files", original.ImagePath));
                    if (file != null)
                    {
                        string ext = Path.GetExtension(file.FileName);
                        coachEntity.ImagePath = Guid.NewGuid() + ext;
                        using var saveAs = System.IO.File.Create(Path.Combine(_env.WebRootPath, "files", coachEntity.ImagePath));
                        file.CopyTo(saveAs);
                    }
                }
                else
                    coachEntity.ImagePath = original.ImagePath;
                _service.EditCoach(id, coachEntity);
                return RedirectToAction(nameof(Index));
            }
            return View(coachEntity);
        }

        public IActionResult Delete(Guid? id)
        {
            if (id == null || !_service.ExistsCoach(id.Value))
            {
                return NotFound();
            }
            return View(_service.GetCoach(id.Value));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            CoachEntity entity = _service.GetCoach(id);
            if (entity.ImagePath != null)
                System.IO.File.Delete(Path.Combine(_env.WebRootPath, "files", entity.ImagePath));
            _service.DeleteCoach(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
