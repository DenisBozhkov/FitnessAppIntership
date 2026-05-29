using FitnessAppIntership.Data;
using FitnessAppIntership.Data.Entities;
using FitnessAppIntership.Models;

namespace FitnessAppIntership.Mappers
{
    public class SubscriptionMapper(ApplicationDbContext context) : IMapper<SubscriptionViewModel, SubscriptionEntity>
    {
        public SubscriptionEntity ToEntity(SubscriptionViewModel model)
        {
            SubscriptionEntity entity = new()
            {
                SubscriptionType = context.SubscriptionTypes.Find(model.SubscriptionTypeId),
                DateOfPurchase = model.DateOfPurchase,
                Member = context.Members.Find(model.MemberId),
                PaidAmount = model.PaidAmount,
                PaymentMethod = model.PaymentMethod,
                ResponsibleUser = context.Users.Find(model.ResponsibleUserId)
            };
            entity.ExpirationDate = entity.DateOfPurchase.AddDays(entity.SubscriptionType.DurationInDays);
            return entity;
        }

        public SubscriptionViewModel ToModel(SubscriptionEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
