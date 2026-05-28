using System.ComponentModel;

namespace FitnessAppIntership.Models
{
    public class TrainingViewModel
    {
        [DisplayName("Training Type")]
        public Guid TypeId { get; set; }
        [DisplayName("Starting Time")]
        public DateTime StartTime { get; set; }
        [DisplayName("Coach")]
        public Guid CoachId { get; set; }
        [DisplayName("Hall")]
        public Guid HallId { get; set; }
    }
}
