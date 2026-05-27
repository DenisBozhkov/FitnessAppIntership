using FitnessAppIntership.Data;
using FitnessAppIntership.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FitnessAppIntership.Controllers
{
    [Authorize(Roles = "admin")]
    public class AccountController(ApplicationDbContext context, UserManager<AccountEntity> userManager) : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<AccountEntity> accounts = context.Users.ToList();
            for (int i = accounts.Count - 1; i >= 0; i--)
            {
                if (await userManager.IsInRoleAsync(accounts[i], "admin"))
                    accounts.RemoveAt(i);
            }
            return View(accounts);
        }

        public IActionResult Register()
        {
            return LocalRedirect("/Identity/Account/Register");
        }

        public IActionResult Activate(string id)
        {
            AccountEntity? account = context.Users.Find(id);
            if (account != null)
            {
                account.Active = true;
                context.Entry(account).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Deactivate(string id)
        {
            AccountEntity? account = context.Users.Find(id);
            if (account != null)
            {
                account.Active = false;
                context.Entry(account).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
