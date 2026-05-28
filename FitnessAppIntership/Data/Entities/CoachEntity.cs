using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FitnessAppIntership.Data.Entities
{
    public class CoachEntity : BaseEntity
    {
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Second Name")]
        public string SecondName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
        [Required]
        [DisplayName("E-Mail")]
        public string Email { get; set; }
        [Required]
        public string Specializations { get; set; }
        [Required]
        public string CV { get; set; }
        [DisplayName("Image")]
        public string? ImagePath { get; set; }
        public List<TrainingEntity> Trainings { get; set; } = [];
    }
}
