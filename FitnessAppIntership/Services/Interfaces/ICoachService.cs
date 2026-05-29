using FitnessAppIntership.Data.Entities;

namespace FitnessAppIntership.Services.Interfaces
{
    public interface ICoachService
    {
        void RegisterCoach(CoachEntity entity);
        void EditCoach(Guid id, CoachEntity entity);
        void DeleteCoach(Guid id);
        CoachEntity GetCoach(Guid id);
        ICollection<CoachEntity> ListAllCoaches();
        bool ExistsCoach(Guid id);
    }
}
