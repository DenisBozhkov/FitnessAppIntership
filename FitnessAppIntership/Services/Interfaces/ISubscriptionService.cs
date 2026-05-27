using FitnessAppIntership.Data.Entities;

namespace FitnessAppIntership.Services.Interfaces
{
    public interface ISubscriptionService
    {
        void CreateSubscription(SubscriptionEntity entity);
        bool ExistsSubscription(Guid value);
        ICollection<SubscriptionEntity> GetAllSubscriptions();
        ICollection<SubscriptionEntity> GetMemberSubscriptionHistory(Guid memberId);
        SubscriptionEntity GetSubscription(Guid value);
        bool IsSubscriptionExpired(Guid subscriptionId);
        bool IsSubscriptionExpiring(Guid subscriptionId, int hours);
    }
}
