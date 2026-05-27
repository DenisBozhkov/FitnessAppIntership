using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FitnessAppIntership.Data.Entities
{
    public class SubscriptionEntity : BaseEntity
    {
        [Required]
        public MemberEntity Member { get; set; }
        [Required]
        public SubscriptionTypeEntity SubscriptionType { get; set; }
        [Required]
        public DateTime DateOfPurchase { get; set; }
        [Required]
        public DateTime ExpirationDate { get; set; }
        [Required]
        public decimal PaidAmount { get; set; }
        [Required]
        public string PaymentMethod { get; set; }
        [Required]
        public AccountEntity ResponsibleUser { get; set; }
        public List<VisitEntity> Visits { get; set; } = [];
    }
}
