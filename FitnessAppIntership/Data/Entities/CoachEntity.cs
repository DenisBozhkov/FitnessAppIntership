using System.ComponentModel.DataAnnotations;

namespace FitnessAppIntership.Data.Entities
{
    public class CoachEntity : BaseEntity
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string SecondName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Specializations { get; set; }
        [Required]
        public string CV { get; set; }
        public string? ImagePath { get; set; }
        public List<TrainingEntity> Trainings { get; set; } = [];
    }
}
