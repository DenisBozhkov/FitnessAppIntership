using FitnessAppIntership.Data.Entities;

namespace FitnessAppIntership.Models
{
    public class SubscriptionViewModel
    {
        public Guid MemberId { get; set; }
        public Guid SubscriptionTypeId { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal PaidAmount { get; set; }
        public string PaymentMethod { get; set; }
        public string ResponsibleUserId { get; set; }
    }
}
