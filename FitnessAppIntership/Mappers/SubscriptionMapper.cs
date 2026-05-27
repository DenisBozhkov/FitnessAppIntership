using FitnessAppIntership.Data;
using FitnessAppIntership.Data.Entities;
using FitnessAppIntership.Models;

namespace FitnessAppIntership.Mappers
{
    public class SubscriptionMapper(ApplicationDbContext context) : IMapper<SubscriptionViewModel, SubscriptionEntity>
    {
        public SubscriptionEntity ToEntity(SubscriptionViewModel model)
        {
            return new()
            {
                DateOfPurchase = model.DateOfPurchase,
                ExpirationDate = model.ExpirationDate,
                Member = context.Members.Find(model.MemberId),
                PaidAmount = model.PaidAmount,
                PaymentMethod = model.PaymentMethod,
                ResponsibleUser = context.Users.Find(model.ResponsibleUserId),
                SubscriptionType = context.SubscriptionTypes.Find(model.SubscriptionTypeId)
            };
        }

        public SubscriptionViewModel ToModel(SubscriptionEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
