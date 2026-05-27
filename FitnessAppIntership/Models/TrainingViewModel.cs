namespace FitnessAppIntership.Models
{
    public class TrainingViewModel
    {
        public Guid TypeId { get; set; }
        public DateTime StartTime { get; set; }
        public Guid CoachId { get; set; }
        public Guid HallId { get; set; }
    }
}
