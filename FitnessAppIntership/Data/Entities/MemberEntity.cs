using System.ComponentModel.DataAnnotations;

namespace FitnessAppIntership.Data.Entities
{
    public class MemberEntity : BaseEntity
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string SecondName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string PIN { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        public string? ImagePath { get; set; }
        public DateTime JoinDate { get; set; } = DateTime.Now;
        public string HealthNotes { get; set; } = string.Empty;
        public bool Active { get; set; } = true;
        public List<SubscriptionEntity> Subscriptions { get; set; } = [];
        public List<TrainingEntity> Trainings { get; set; } = [];
    }
}
