using System.ComponentModel.DataAnnotations;

namespace FitnessAppIntership.Data.Entities
{
    public class SubscriptionTypeEntity : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int DurationInDays { get; set; }
        public List<TrainingEntity> Trainings { get; set; } = [];
        public List<SubscriptionEntity> ConcreteSubscriptions { get; set; } = [];
    }
}
