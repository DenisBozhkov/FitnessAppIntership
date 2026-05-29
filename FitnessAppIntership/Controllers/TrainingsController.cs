using Microsoft.AspNetCore.Mvc;
using FitnessAppIntership.Data.Entities;
using FitnessAppIntership.Models;
using FitnessAppIntership.Services.Interfaces;
using FitnessAppIntership.Mappers;
using Microsoft.AspNetCore.Authorization;

namespace FitnessAppIntership.Controllers
{
    [Authorize]
    public class TrainingsController : Controller
    {
        private readonly ITrainingService _service;
        private readonly IMapper<TrainingViewModel, TrainingEntity> _mapper;

        public TrainingsController(ITrainingService service, IMapper<TrainingViewModel, TrainingEntity> mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View(_service.ListAllTrainingsOnDate(DateTime.Now));
        }

        public IActionResult Week()
        {
            ViewData["ThisWeek"] = true;
            return View("Index", _service.ListAllTrainingsOnWeek(DateTime.Now));
        }

        public IActionResult Details(Guid? id)
        {
            if (id == null || !_service.ExistsTraining(id.Value))
            {
                return NotFound();
            }
            return View(_service.GetTraining(id.Value));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TrainingViewModel model)
        {
            if (ModelState.IsValid)
            {
                _service.CreateTraining(_mapper.ToEntity(model));
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}
