using FitnessAppIntership.Data.Entities;
using FitnessAppIntership.Models;
using FitnessAppIntership.Services;
using FitnessAppIntership.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FitnessAppIntership.Controllers
{
    [Authorize]
    public class MembersController : Controller
    {
        private readonly IMemberService _memberService;
        private readonly IMemberListService _memberListService;
        private readonly IVisitService _visitService;
        private readonly ISubscriptionService _subscriptionService;
        private readonly IWebHostEnvironment _env;

        public MembersController(ISubscriptionService subscriptionService, IMemberListService memberListService, IMemberService memberService, IVisitService visitService, IWebHostEnvironment env)
        {
            _subscriptionService = subscriptionService;
            _memberListService = memberListService;
            _memberService = memberService;
            _visitService = visitService;
            _env = env;
        }

        public IActionResult Index(int page = 1, 
            FilterType searchAndFilterType = FilterType.None,
            string filterToken="")
        {
            _memberListService.EntitiesPerPage = 20;
            _memberListService.FilterToken = filterToken;
            _memberListService.FilterType = searchAndFilterType;
            _memberListService.Page = page;
            var members = _memberListService.ListAllMembers().ToList();
            members.ForEach(x => x.Subscriptions = _subscriptionService.GetMemberSubscriptionHistory(x.Id).ToList());
            return View(members);
        }

        public IActionResult Details(Guid? id, MemberViewModel? model)
        {
            if (id == null || !_memberService.ExistsMember(id.Value))
            {
                return NotFound();
            }
            DateTime startDate = model?.StartDate ?? DateTime.MinValue;
            DateTime endDate = model?.EndDate ?? DateTime.MaxValue;
            var serializedParent = JsonConvert.SerializeObject(_memberService.GetMember(id.Value));
            model = JsonConvert.DeserializeObject<MemberViewModel>(serializedParent);
            model.StartDate = startDate;
            model.EndDate = endDate; 
            model.Visits = _visitService.ListVisitsInTimePeriod(startDate, endDate)
                .Where(x => x.Subscription.Member.Id == id).ToList();
            model.Subscriptions = _subscriptionService.GetMemberSubscriptionHistory(id.Value).ToList();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MemberEntity memberEntity)
        {
            if (ModelState.IsValid)
            {
                IFormFile? file = Request.Form.Files["image"];
                if (file != null)
                {
                    string ext = Path.GetExtension(file.FileName);
                    memberEntity.ImagePath = Guid.NewGuid() + ext;
                    using var saveAs = System.IO.File.Create(Path.Combine(_env.WebRootPath, "files", memberEntity.ImagePath));
                    file.CopyTo(saveAs);
                }
                memberEntity.JoinDate = DateTime.Now;
                _memberService.RegisterMember(memberEntity);
                return RedirectToAction(nameof(Index));
            }
            return View(memberEntity);
        }

        public IActionResult Visit(Guid id)
        {
            if (!_memberService.ExistsMember(id))
                return NotFound();
            if (!_memberService.GetMember(id).Active)
                return View(new ErrorViewModel { Message = "the member is no longer active" });
            SubscriptionEntity? sub = _subscriptionService.GetMemberSubscriptionHistory(id).Where(x => !_subscriptionService.IsSubscriptionExpired(x.Id)).FirstOrDefault();
            if (sub == null)
                return View(new ErrorViewModel { Message = "the member does not have active subscription" });
            _visitService.CreateVisit(new VisitEntity { Subscription = sub, VisitTime = DateTime.Now });
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(Guid? id)
        {
            if (id == null || !_memberService.ExistsMember(id.Value))
            {
                return NotFound();
            }
            return View(_memberService.GetMember(id.Value));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, MemberEntity memberEntity)
        {
            if (id != memberEntity.Id || !_memberService.ExistsMember(id))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                MemberEntity original = _memberService.GetMember(id);
                memberEntity.JoinDate = original.JoinDate;
                if (Request.Form.TryGetValue("ImageChange", out _))
                {
                    IFormFile? file = Request.Form.Files["image"];
                    if (original.ImagePath != null)
                        System.IO.File.Delete(Path.Combine(_env.WebRootPath, "files", original.ImagePath));
                    if (file != null)
                    {
                        string ext = Path.GetExtension(file.FileName);
                        memberEntity.ImagePath = Guid.NewGuid() + ext;
                        using var saveAs = System.IO.File.Create(Path.Combine(_env.WebRootPath, "files", memberEntity.ImagePath));
                        file.CopyTo(saveAs);
                    }
                }
                else
                    memberEntity.ImagePath = original.ImagePath;
                _memberService.EditMember(id, memberEntity);
                return RedirectToAction(nameof(Index));
            }
            return View(memberEntity);
        }

        public IActionResult Activate(Guid id)
        {
            if (!_memberService.ExistsMember(id))
                return NotFound();
            _memberService.ActivateMember(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Deactivate(Guid id)
        {
            if (!_memberService.ExistsMember(id))
                return NotFound();
            _memberService.DeactivateMember(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
