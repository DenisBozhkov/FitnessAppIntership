using FitnessAppIntership.Data.Entities;

namespace FitnessAppIntership.Services.Interfaces
{
    public interface ITrainingTypeService
    {
        void CreateTrainingType(TrainingTypeEntity entity);
        void EditTrainingType(Guid id, TrainingTypeEntity entity);
        void DeleteTrainingType(Guid id);
        TrainingTypeEntity GetTrainingType(Guid id);
        ICollection<TrainingTypeEntity> ListAllTrainingTypes();
        bool ExistsTrainingType(Guid value);
    }
}
