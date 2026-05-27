using System.ComponentModel.DataAnnotations;

namespace FitnessAppIntership.Data.Entities
{
    public class VisitEntity : BaseEntity
    {
        public SubscriptionEntity Subscription { get; set; }
        [Required]
        public DateTime VisitTime { get; set; }
    }
}