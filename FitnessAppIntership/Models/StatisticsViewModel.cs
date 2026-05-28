using FitnessAppIntership.Data.Entities;

namespace FitnessAppIntership.Models
{
    public class StatisticsViewModel
    {
        public double IncomeForPeriod { get; set; }
        public List<double> IncomeOfSubscriptionTypes { get; set; } = [];
        public List<double> IncomeOfUsers { get; set; } = [];
        public int ActiveMembersCount { get; set; }
        public List<MemberEntity> MembersInPeriod { get; set; } = [];
        public List<SubscriptionEntity> SubscriptionsExpiringIn7Days { get; set; } = [];
        public List<SubscriptionEntity> SubscriptionsExpiringIn30Days { get; set; } = [];
    }
}
