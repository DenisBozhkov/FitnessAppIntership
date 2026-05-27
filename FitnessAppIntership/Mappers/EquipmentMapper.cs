using FitnessAppIntership.Data;
using FitnessAppIntership.Data.Entities;
using FitnessAppIntership.Models;

namespace FitnessAppIntership.Mappers
{
    public class EquipmentMapper(ApplicationDbContext context) : IMapper<EquipmentViewModel, EquipmentEntity>
    {
        public EquipmentEntity ToEntity(EquipmentViewModel model)
        {
            return new()
            {
                DateOfAcquisition = model.DateOfAcquisition,
                Hall = context.Halls.Find(model.HallId),
                Name = model.Name,
                Notes = model.Notes,
                State = model.State,
                Type = model.Type
            };
        }

        public EquipmentViewModel ToModel(EquipmentEntity entity)
        {
            return new()
            {
                DateOfAcquisition = entity.DateOfAcquisition,
                HallId = entity.Hall.Id,
                Name = entity.Name,
                Notes = entity.Notes,
                State = entity.State,
                Type = entity.Type
            };
        }
    }
}
