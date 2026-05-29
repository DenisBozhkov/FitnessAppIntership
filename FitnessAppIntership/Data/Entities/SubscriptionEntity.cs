#nullable disable

using System.ComponentModel;
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
        [DisplayName("Purchase Date")]
        public DateTime DateOfPurchase { get; set; }
        [Required]
        [DisplayName("Expiration Date")]
        public DateTime ExpirationDate { get; set; }
        [Required]
        [DisplayName("Paid Amount")]
        public decimal PaidAmount { get; set; }
        [Required]
        [DisplayName("Paid Amount")]
        public string PaymentMethod { get; set; }
        [Required]
        public AccountEntity ResponsibleUser { get; set; }
        public List<VisitEntity> Visits { get; set; } = [];
    }
}
