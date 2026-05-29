using FitnessAppIntership.Data.Entities;

namespace FitnessAppIntership.Services.Interfaces
{
    public interface ISubscriptionTypeService
    {
        void CreateSubscriptionType(SubscriptionTypeEntity entity);
        void EditSubscriptionType(Guid id, SubscriptionTypeEntity entity);
        void DeleteSubscriptionType(Guid id);
        SubscriptionTypeEntity GetSubscriptionType(Guid id);
        ICollection<SubscriptionTypeEntity> ListAllSubscriptionTypes();
        bool ExistsSubscriptionType(Guid id);
    }
}
