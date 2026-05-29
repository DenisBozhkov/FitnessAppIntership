using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FitnessAppIntership.Data;
using FitnessAppIntership.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using FitnessAppIntership.Mappers;
using FitnessAppIntership.Models;
using FitnessAppIntership.Services.Interfaces;

namespace FitnessAppIntership.Controllers
{
    [Authorize]
    public class SubscriptionsController : Controller
    {
        private readonly ISubscriptionService _service;
        private readonly IMapper<SubscriptionViewModel,SubscriptionEntity> _mapper;

        public SubscriptionsController(ISubscriptionService service, IMapper<SubscriptionViewModel, SubscriptionEntity> mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public IActionResult Index(Guid? memberId)
        {
            if(memberId == null)
                return View(_service.GetAllSubscriptions());
            return View(_service.GetMemberSubscriptionHistory(memberId.Value).OrderByDescending(x => x.DateOfPurchase));
        }

        public IActionResult Details(Guid? id)
        {
            if (id == null || !_service.ExistsSubscription(id.Value))
            {
                return NotFound();
            }
            return View(_service.GetSubscription(id.Value));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SubscriptionViewModel subscriptionModel)
        {
            if (ModelState.IsValid)
            {
                _service.CreateSubscription(_mapper.ToEntity(subscriptionModel));
                return RedirectToAction(nameof(Index));
            }
            return View(subscriptionModel);
        }
    }
}
