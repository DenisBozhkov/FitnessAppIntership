using FitnessAppIntership.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessAppIntership.Data
{
    public class CoachConfiguration : IEntityTypeConfiguration<CoachEntity>
    {
        public void Configure(EntityTypeBuilder<CoachEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Trainings);
        }
    }
    public class EquipmentConfiguration : IEntityTypeConfiguration<EquipmentEntity>
    {
        public void Configure(EntityTypeBuilder<EquipmentEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Hall);
            builder.HasMany(x => x.RepairsAndMaintenances);
            builder.Navigation(x => x.Hall).AutoInclude();
        }
    }
    public class HallConfiguration : IEntityTypeConfiguration<HallEntity>
    {
        public void Configure(EntityTypeBuilder<HallEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Equipment);
            builder.HasMany(x => x.Trainings);
        }
    }
    public class MemberConfiguration : IEntityTypeConfiguration<MemberEntity>
    {
        public void Configure(EntityTypeBuilder<MemberEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Subscriptions);
            builder.HasMany(x => x.Trainings);
        }
    }
    public class RepairAndMaintenanceConfiguration : IEntityTypeConfiguration<RepairAndMaintenanceEntity>
    {
        public void Configure(EntityTypeBuilder<RepairAndMaintenanceEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Equipment);
            builder.Navigation(x => x.Equipment).AutoInclude();
        }
    }
    public class SubscriptionConfiguration : IEntityTypeConfiguration<SubscriptionEntity>
    {
        public void Configure(EntityTypeBuilder<SubscriptionEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.ResponsibleUser);
            builder.HasOne(x => x.Member);
            builder.HasOne(x => x.SubscriptionType);
            builder.HasMany(x => x.Visits);
            builder.Navigation(x => x.ResponsibleUser).AutoInclude();
            builder.Navigation(x => x.Member).AutoInclude();
            builder.Navigation(x => x.SubscriptionType).AutoInclude();
        }
    }
    public class SubscriptionTypeConfiguration : IEntityTypeConfiguration<SubscriptionTypeEntity>
    {
        public void Configure(EntityTypeBuilder<SubscriptionTypeEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.ConcreteSubscriptions);
            builder.HasMany(x => x.Trainings);
        }
    }
    public class TrainingConfiguration : IEntityTypeConfiguration<TrainingEntity>
    {
        public void Configure(EntityTypeBuilder<TrainingEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Hall);
            builder.HasOne(x => x.Coach);
            builder.HasMany(x => x.SubscriptionTypes);
            builder.HasMany(x => x.Members);
            builder.Navigation(x => x.Hall).AutoInclude();
            builder.Navigation(x => x.Coach).AutoInclude();
            builder.Navigation(x => x.Members).AutoInclude();
        }
    }
    public class TrainingTypeConfiguration : IEntityTypeConfiguration<TrainingTypeEntity>
    {
        public void Configure(EntityTypeBuilder<TrainingTypeEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.ConcreteTrainings);
        }
    }
    public class VisitConfiguration : IEntityTypeConfiguration<VisitEntity>
    {
        public void Configure(EntityTypeBuilder<VisitEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Subscription);
            builder.Navigation(x => x.Subscription).AutoInclude();
        }
    }
}
