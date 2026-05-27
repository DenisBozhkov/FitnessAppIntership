using System.ComponentModel.DataAnnotations;

namespace FitnessAppIntership.Data.Entities
{
    public class TrainingEntity : BaseEntity
    {
        [Required]
        public TrainingTypeEntity Type { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public CoachEntity Coach { get; set; }
        [Required]
        public HallEntity Hall { get; set; }
        public List<SubscriptionTypeEntity> SubscriptionTypes { get; set; } = [];
        public List<MemberEntity> Members { get; set; } = [];
    }
}
