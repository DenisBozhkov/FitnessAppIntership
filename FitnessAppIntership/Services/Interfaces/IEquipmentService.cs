using FitnessAppIntership.Data.Entities;

namespace FitnessAppIntership.Services.Interfaces
{
    public interface IEquipmentService
    {
        void AddEquipment(EquipmentEntity entity);
        void EditEqipment(Guid id, EquipmentEntity entity);
        void RegisterRepairOrMaintenance(RepairAndMaintenanceEntity entity);
        void RegisterRepairOrMaintenance(Guid equipmentId, RepairAndMaintenanceEntity entity);
        EquipmentEntity GetEquipment(Guid id);
        ICollection<EquipmentEntity> ListAllNotOutOfUseEquipment();
        ICollection<EquipmentEntity> ListAllEquipment();
        void ScrapEquipment(Guid id);
        bool ExistsEquipment(Guid value);
    }
}
