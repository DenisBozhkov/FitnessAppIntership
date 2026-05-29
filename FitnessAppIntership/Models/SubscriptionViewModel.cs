#nullable disable

using System.ComponentModel;

namespace FitnessAppIntership.Models
{
    public class SubscriptionViewModel
    {
        [DisplayName("Member")]
        public Guid MemberId { get; set; }
        [DisplayName("Subscription Type")]
        public Guid SubscriptionTypeId { get; set; }
        [DisplayName("Date of purchase")]
        public DateTime DateOfPurchase { get; set; }
        [DisplayName("Paid Amount")]
        public decimal PaidAmount { get; set; }
        [DisplayName("Payment Method")]
        public string PaymentMethod { get; set; }
        [DisplayName("Responsible User")]
        public string ResponsibleUserId { get; set; }
    }
}
