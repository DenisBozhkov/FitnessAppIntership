using Microsoft.AspNetCore.Mvc;
using FitnessAppIntership.Data;
using FitnessAppIntership.Data.Entities;
using FitnessAppIntership.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace FitnessAppIntership.Controllers
{
    [Authorize(Roles = "admin")]
    public class HallsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHallService _halls;

        public HallsController(ApplicationDbContext context, IHallService halls)
        {
            _context = context;
            _halls = halls;
        }

        public IActionResult Index()
        {
            return View(_halls.ListAllHalls());
        }

        public IActionResult Details(Guid? id)
        {
            if (id == null || !_halls.ExistsHall(id.Value))
            {
                return NotFound();
            }
            return View(_halls.GetHall(id.Value));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(HallEntity hallEntity)
        {
            if (ModelState.IsValid)
            {
                _halls.CreateHall(hallEntity);
                return RedirectToAction(nameof(Index));
            }
            return View(hallEntity);
        }

        public IActionResult Edit(Guid? id)
        {
            if (id == null || !_halls.ExistsHall(id.Value))
            {
                return NotFound();
            }
            return View(_halls.GetHall(id.Value));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, HallEntity hallEntity)
        {
            if (id != hallEntity.Id || !_halls.ExistsHall(id))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _halls.EditHall(id, hallEntity);
                return RedirectToAction(nameof(Index));
            }
            return View(hallEntity);
        }

        public IActionResult Delete(Guid? id)
        {
            if (id == null || !_halls.ExistsHall(id.Value))
            {
                return NotFound();
            }
            return View(_halls.GetHall(id.Value));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _halls.DeleteHall(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
