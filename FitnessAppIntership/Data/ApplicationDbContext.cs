using FitnessAppIntership.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FitnessAppIntership.Data
{
    public class ApplicationDbContext : IdentityDbContext<AccountEntity>
    {
        public DbSet<CoachEntity> Coaches { get; set; }
        public DbSet<EquipmentEntity> Equipment { get; set; }
        public DbSet<HallEntity> Halls { get; set; }
        public DbSet<MemberEntity> Members { get; set; }
        public DbSet<SubscriptionEntity> Subscriptions { get; set; }
        public DbSet<SubscriptionTypeEntity> SubscriptionTypes { get; set; }
        public DbSet<TrainingEntity> Trainings { get; set; }
        public DbSet<TrainingTypeEntity> TrainingTypes { get; set; }
        public DbSet<VisitEntity> Visits { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CoachEntity>().ToTable("Coaches");
            modelBuilder.Entity<EquipmentEntity>().ToTable("Equpments");
            modelBuilder.Entity<HallEntity>().ToTable("Halls");
            modelBuilder.Entity<MemberEntity>().ToTable("Members");
            modelBuilder.Entity<SubscriptionEntity>().ToTable("Subscriptions");
            modelBuilder.Entity<SubscriptionTypeEntity>().ToTable("SubscriptionTypes");
            modelBuilder.Entity<TrainingEntity>().ToTable("Trainings");
            modelBuilder.Entity<TrainingTypeEntity>().ToTable("TrainingTypes");
            modelBuilder.Entity<VisitEntity>().ToTable("Visits");

            modelBuilder.ApplyConfiguration(new CoachConfiguration());
            modelBuilder.ApplyConfiguration(new EquipmentConfiguration());
            modelBuilder.ApplyConfiguration(new HallConfiguration());
            modelBuilder.ApplyConfiguration(new MemberConfiguration());
            modelBuilder.ApplyConfiguration(new SubscriptionConfiguration());
            modelBuilder.ApplyConfiguration(new SubscriptionTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TrainingConfiguration());
            modelBuilder.ApplyConfiguration(new TrainingTypeConfiguration());
            modelBuilder.ApplyConfiguration(new VisitConfiguration());
        }
    }
}
