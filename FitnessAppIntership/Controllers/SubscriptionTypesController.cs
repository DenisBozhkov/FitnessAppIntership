using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FitnessAppIntership.Data;
using FitnessAppIntership.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using FitnessAppIntership.Services.Interfaces;

namespace FitnessAppIntership.Controllers
{
    [Authorize(Roles = "admin")]
    public class SubscriptionTypesController : Controller
    {
        private readonly ISubscriptionTypeService _service;

        public SubscriptionTypesController(ISubscriptionTypeService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View(_service.ListAllSubscriptionTypes());
        }

        public IActionResult Details(Guid? id)
        {
            if (id == null || !_service.ExistsSubscriptionType(id.Value))
            {
                return NotFound();
            }
            return View(_service.GetSubscriptionType(id.Value));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SubscriptionTypeEntity subscriptionTypeEntity)
        {
            if (ModelState.IsValid)
            {
                _service.CreateSubscriptionType(subscriptionTypeEntity);
                return RedirectToAction(nameof(Index));
            }
            return View(subscriptionTypeEntity);
        }

        public IActionResult Edit(Guid? id)
        {
            if (id == null || !_service.ExistsSubscriptionType(id.Value))
            {
                return NotFound();
            }
            return View(_service.GetSubscriptionType(id.Value));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, SubscriptionTypeEntity subscriptionTypeEntity)
        {
            if (id != subscriptionTypeEntity.Id || !_service.ExistsSubscriptionType(id))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _service.EditSubscriptionType(id, subscriptionTypeEntity);
                return RedirectToAction(nameof(Index));
            }
            return View(subscriptionTypeEntity);
        }

        public IActionResult Delete(Guid? id)
        {
            if (id == null || !_service.ExistsSubscriptionType(id.Value))
            {
                return NotFound();
            }
            return View(_service.GetSubscriptionType(id.Value));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            if (_service.ExistsSubscriptionType(id))
                _service.DeleteSubscriptionType(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
