using FitnessAppIntership.Data.Entities;

namespace FitnessAppIntership.Services.Interfaces
{
    public interface ITrainingService
    {
        void CreateTraining(TrainingEntity entity);
        ICollection<TrainingEntity> ListAllTrainingsOnDate(DateTime date);
        ICollection<TrainingEntity> ListAllTrainingsOnWeek(DateTime date);
        void EnrollMemberOnTraining(Guid memberId, Guid trainingId);
        void DisenrollMemberFromTraining(Guid memberId, Guid trainingId);
        ICollection<MemberEntity> ListAllMembers(Guid trainingId);
        TrainingEntity GetTraining(Guid trainigId);
        bool ExistsTraining(Guid id);
    }
}
