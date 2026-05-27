using Microsoft.AspNetCore.Identity;

namespace FitnessAppIntership.Data.Entities
{
    public class AccountEntity : IdentityUser
    {
        public bool Active { get; set; } = true;
    }
}
