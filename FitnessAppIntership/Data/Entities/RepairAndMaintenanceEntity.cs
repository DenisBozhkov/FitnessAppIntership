using System.ComponentModel.DataAnnotations;

namespace FitnessAppIntership.Data.Entities
{
    public class RepairAndMaintenanceEntity : BaseEntity
    {
        [Required]
        public EquipmentEntity Equipment { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
