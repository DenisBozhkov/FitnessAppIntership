using FitnessAppIntership.Data.Entities;

namespace FitnessAppIntership.Models
{
    public class EquipmentViewModel
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public Guid HallId { get; set; }
        public DateTime DateOfAcquisition { get; set; }
        public EquipmentState State { get; set; }
        public string Notes { get; set; }
    }
}
