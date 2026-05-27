using Microsoft.AspNetCore.Mvc;
using FitnessAppIntership.Data.Entities;
using FitnessAppIntership.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using FitnessAppIntership.Services;

namespace FitnessAppIntership.Controllers
{
    [Authorize]
    public class MembersController : Controller
    {
        private readonly IMemberService _memberService;
        private readonly IMemberListService _memberListService;

        public MembersController(IMemberListService memberListService, IMemberService memberService)
        {
            _memberListService = memberListService;
            _memberService = memberService;
        }

        public IActionResult Index(int page = 1, 
            FilterType searchAndFilterType = FilterType.None,
            string filterToken="")
        {
            _memberListService.EntitiesPerPage = 20;
            _memberListService.FilterToken = filterToken;
            _memberListService.FilterType = searchAndFilterType;
            _memberListService.Page = page;
            return View(_memberListService.ListAllMembers());
        }

        public IActionResult Details(Guid? id)
        {
            if (id == null || !_memberService.ExistsMember(id.Value))
            {
                return NotFound();
            }
            return View(_memberService.GetMember(id.Value));
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
                _memberService.RegisterMember(memberEntity);
                return RedirectToAction(nameof(Index));
            }
            return View(memberEntity);
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
                _memberService.EditMember(id, memberEntity);
                return RedirectToAction(nameof(Index));
            }
            return View(memberEntity);
        }

        public IActionResult ActivateMember(Guid id)
        {
            if (!_memberService.ExistsMember(id))
                return NotFound();
            _memberService.ActivateMember(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DeactivateMember(Guid id)
        {
            if (!_memberService.ExistsMember(id))
                return NotFound();
            _memberService.DeactivateMember(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
