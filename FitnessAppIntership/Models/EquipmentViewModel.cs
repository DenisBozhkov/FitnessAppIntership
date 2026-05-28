using FitnessAppIntership.Data.Entities;
using System.ComponentModel;

namespace FitnessAppIntership.Models
{
    public class EquipmentViewModel
    {
        public string Name { get; set; }
        public string Type { get; set; }
        [DisplayName("Hall")]
        public Guid HallId { get; set; }
        [DisplayName("Date of acquisition")]
        public DateTime DateOfAcquisition { get; set; }
        public EquipmentState State { get; set; }
        public string Notes { get; set; }
    }
}
