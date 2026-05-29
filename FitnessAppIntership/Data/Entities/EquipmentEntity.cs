using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FitnessAppIntership.Data.Entities
{
    public class EquipmentEntity : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public HallEntity Hall { get; set; }
        [Required]
        [DisplayName("Date of acquisition")]
        public DateTime DateOfAcquisition { get; set; }
        public virtual EquipmentState State { get; set; } = EquipmentState.Properly;
        public string Notes { get; set; } = string.Empty;
        public virtual List<RepairAndMaintenanceEntity> RepairsAndMaintenances { get; set; } = [];
    }
}
