using FitnessAppIntership.Data.Entities;
using FitnessAppIntership.Services.Interfaces;

namespace FitnessAppIntership.Services
{
    public class TmpCoachService : ICoachService
    {
        private static readonly Dictionary<Guid, CoachEntity> _coaches = [];
        public void DeleteCoach(Guid id)
        {
            if(ExistsCoach(id))
                _coaches.Remove(id);
        }

        public void EditCoach(Guid id, CoachEntity entity)
        {
            if (ExistsCoach(id))
            {
                entity.Id = id;
                _coaches[id] = entity;
            }
        }

        public bool ExistsCoach(Guid value)
        {
            return _coaches.ContainsKey(value);
        }

        public CoachEntity GetCoach(Guid id)
        {
            return _coaches[id];
        }

        public ICollection<CoachEntity> ListAllCoaches()
        {
            return _coaches.Values;
        }

        public void RegisterCoach(CoachEntity entity)
        {
            if(!ExistsCoach(entity.Id))
                _coaches[entity.Id] = entity;
        }
    }
}
