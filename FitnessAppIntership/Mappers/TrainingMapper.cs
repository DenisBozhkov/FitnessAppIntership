using FitnessAppIntership.Data;
using FitnessAppIntership.Data.Entities;
using FitnessAppIntership.Models;

namespace FitnessAppIntership.Mappers
{
    public class TrainingMapper(ApplicationDbContext context) : IMapper<TrainingViewModel, TrainingEntity>
    {
        public TrainingEntity ToEntity(TrainingViewModel model)
        {
            return new()
            {
                Coach = context.Coaches.Find(model.CoachId),
                Hall = context.Halls.Find(model.HallId),
                StartTime = model.StartTime,
                Type = context.TrainingTypes.Find(model.TypeId)
            };
        }

        public TrainingViewModel ToModel(TrainingEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
