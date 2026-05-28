using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FitnessAppIntership.Data.Entities
{
    public class HallEntity : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public List<EquipmentEntity> Equipment { get; set; } = [];
        public List<TrainingEntity> Trainings { get; set; } = [];
    }
}