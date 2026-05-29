#nullable disable

using System.ComponentModel;
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
        [DisplayName("Duration (minutes)")]
        public int DurationInMinutes { get; set; }
        [Required]
        [DisplayName("Maximum participant count")]
        public int MaximumParticipantsCount { get; set; }
        public List<TrainingEntity> ConcreteTrainings { get; set; } = [];
    }
}
