using System.ComponentModel.DataAnnotations;

namespace FitnessAppIntership.Data.Entities
{
    public class TrainingTypeEntity : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int DurationInMinutes { get; set; }
        [Required]
        public int MaximumParticipantsCount { get; set; }
        public List<TrainingEntity> ConcreteTrainings { get; set; } = [];
    }
}
