using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CSSD_Subtask2_Group16.Models
{
    public partial class TollAppContext : DbContext
    {
        public TollAppContext()
            : base("name=TollAppContext")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<Gate> Gates { get; set; }
        public virtual DbSet<Journey> Journeys { get; set; }
        public virtual DbSet<PaymentDate> PaymentDates { get; set; }
        public virtual DbSet<Preference> Preferences { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<UserCar> UserCars { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .Property(e => e.Email)
                .IsFixedLength();

            modelBuilder.Entity<Admin>()
                .Property(e => e.Password)
                .IsFixedLength();

            modelBuilder.Entity<Admin>()
                .Property(e => e.Motorway)
                .IsFixedLength();

            modelBuilder.Entity<Bank>()
                .HasMany(e => e.PaymentDates)
                .WithRequired(e => e.Bank)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Bank>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Bank)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Gate>()
                .Property(e => e.Location)
                .IsFixedLength();

            modelBuilder.Entity<Gate>()
                .HasMany(e => e.Journeys)
                .WithRequired(e => e.Gate)
                .HasForeignKey(e => e.EndGateId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Gate>()
                .HasMany(e => e.Journeys1)
                .WithRequired(e => e.Gate1)
                .HasForeignKey(e => e.StartGateId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Journey>()
                .Property(e => e.PlateNo)
                .IsFixedLength();

            modelBuilder.Entity<Journey>()
                .HasMany(e => e.Transactions)
                .WithRequired(e => e.Journey)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Transaction>()
                .HasMany(e => e.PaymentDates)
                .WithRequired(e => e.Transaction)
                .HasForeignKey(e => new { e.TransactionId, e.JourneyId })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserCar>()
                .Property(e => e.PlateNo)
                .IsFixedLength();

            modelBuilder.Entity<UserCar>()
                .HasMany(e => e.Journeys)
                .WithRequired(e => e.UserCar)
                .HasForeignKey(e => new { e.UserId, e.PlateNo })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.FirstName)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.LastName)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.HomeAddress)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .HasOptional(e => e.Preference)
                .WithRequired(e => e.User);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserCars)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
