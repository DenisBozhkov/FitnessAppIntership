using Microsoft.AspNetCore.Mvc;
using FitnessAppIntership.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using FitnessAppIntership.Services.Interfaces;

namespace FitnessAppIntership.Controllers
{
    [Authorize(Roles = "admin")]
    public class TrainingTypesController : Controller
    {
        private readonly ITrainingTypeService _service;

        public TrainingTypesController(ITrainingTypeService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View(_service.ListAllTrainingTypes());
        }

        public IActionResult Details(Guid? id)
        {
            if (id == null || !_service.ExistsTrainingType(id.Value))
            {
                return NotFound();
            }
            return View(_service.GetTrainingType(id.Value));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TrainingTypeEntity trainingTypeEntity)
        {
            if (ModelState.IsValid)
            {
                _service.CreateTrainingType(trainingTypeEntity);
                return RedirectToAction(nameof(Index));
            }
            return View(trainingTypeEntity);
        }

        public IActionResult Edit(Guid? id)
        {
            if (id == null || !_service.ExistsTrainingType(id.Value))
            {
                return NotFound();
            }
            return View(_service.GetTrainingType(id.Value));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, TrainingTypeEntity trainingTypeEntity)
        {
            if (id != trainingTypeEntity.Id || !_service.ExistsTrainingType(id))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _service.EditTrainingType(id, trainingTypeEntity);
                return RedirectToAction(nameof(Index));
            }
            return View(trainingTypeEntity);
        }

        public IActionResult Delete(Guid? id)
        {
            if (id == null || !_service.ExistsTrainingType(id.Value))
            {
                return NotFound();
            }
            return View(_service.GetTrainingType(id.Value));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _service.DeleteTrainingType(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
