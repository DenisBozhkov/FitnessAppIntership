using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FitnessAppIntership.Data.Entities
{
    public class MemberEntity : BaseEntity
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
        public string PIN { get; set; }
        [Required]
        [DisplayName("Birth Date")]
        public DateTime BirthDate { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
        [Required]
        [DisplayName("E-Mail")]
        public string Email { get; set; }
        [DisplayName("Image")]
        public string? ImagePath { get; set; }
        [DisplayName("Join Date")]
        public DateTime JoinDate { get; set; } = DateTime.Now;
        [DisplayName("Health Notes")]
        public string HealthNotes { get; set; } = string.Empty;
        public bool Active { get; set; } = true;
        public List<SubscriptionEntity> Subscriptions { get; set; } = [];
        public List<TrainingEntity> Trainings { get; set; } = [];
    }
}
