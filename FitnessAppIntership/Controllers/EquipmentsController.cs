using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FitnessAppIntership.Data;
using FitnessAppIntership.Data.Entities;
using FitnessAppIntership.Models;
using FitnessAppIntership.Mappers;
using Microsoft.AspNetCore.Authorization;
using FitnessAppIntership.Services.Interfaces;

namespace FitnessAppIntership.Controllers
{
    [Authorize]
    public class EquipmentController : Controller
    {
        private readonly IEquipmentService _service;
        private readonly IMapper<EquipmentViewModel, EquipmentEntity> _mapper;

        public EquipmentController(IEquipmentService service, IMapper<EquipmentViewModel,EquipmentEntity> mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View(_service.ListAllNotOutOfUseEquipment());
        }

        public IActionResult Details(Guid? id)
        {
            if (id == null || _service.ExistsEquipment(id.Value))
            {
                return NotFound();
            }
            return View(_service.GetEquipment(id.Value));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EquipmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                _service.AddEquipment(_mapper.ToEntity(model));
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public IActionResult Edit(Guid? id)
        {
            if (id == null || !_service.ExistsEquipment(id.Value))
            {
                return NotFound();
            }
            return View(_mapper.ToModel(_service.GetEquipment(id.Value)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, EquipmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                EquipmentEntity entity = _mapper.ToEntity(model);
                entity.Id = id;
                _service.EditEqipment(id, entity);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}
