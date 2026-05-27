using FitnessAppIntership.Data.Entities;

namespace FitnessAppIntership.Services.Interfaces
{
    public interface IHallService
    {
        void CreateHall(HallEntity entity);
        void EditHall(Guid id, HallEntity entity);
        void DeleteHall(Guid id);
        HallEntity GetHall(Guid id);
        ICollection<HallEntity> ListAllHalls();
        bool ExistsHall(Guid id);
    }
}
