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

        public CoachesController(ICoachService service)
        {
            _service = service;
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(CoachEntity coachEntity)
        {
            if (ModelState.IsValid)
            {
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
            _service.DeleteCoach(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
