using FitnessAppIntership.Data.Entities;

namespace FitnessAppIntership.Services.Interfaces
{
    public interface IVisitService
    {
        void CreateVisit(VisitEntity entity);
        ICollection<VisitEntity> ListVisitsInTimePeriod(DateTime startDate, DateTime endDate);
    }
}
