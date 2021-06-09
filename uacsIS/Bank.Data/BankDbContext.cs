using Bank.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;

namespace Bank.Data
{
    public class BankDbContext
    : DbContext
    {
        public BankDbContext(DbContextOptions<BankDbContext> options)
        : base(options)
        {

        }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                        .HasMaxLength(200)
                        .IsUnicode(true)
                        .IsRequired(false);
                entity.Property(e => e.Balance)
                        .HasMaxLength(200)
                        .IsUnicode(true)
                        .IsRequired(false);
                entity.Property(e => e.AccountTypeId)
                        .HasMaxLength(200)
                        .IsUnicode(true)
                        .IsRequired(false);
                entity.Property(e => e.IsActive)
                        .HasMaxLength(200)
                        .IsUnicode(true)
                        .IsRequired(false);
            });
            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Street)
                        .HasMaxLength(200)
                        .IsUnicode(true)
                        .IsRequired(false);
                entity.Property(e => e.City)
                        .HasMaxLength(200)
                        .IsUnicode(true)
                        .IsRequired(false);
                entity.Property(e => e.Country)
                        .HasMaxLength(200)
                        .IsUnicode(true)
                        .IsRequired(false);
               
            });
            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                        .HasMaxLength(200)
                        .IsUnicode(true)
                        .IsRequired(false);
                entity.Property(e => e.PhoneNumber)
                        .HasMaxLength(200)
                        .IsUnicode(true)
                        .IsRequired(false);
                entity.Property(e => e.Email)
                        .HasMaxLength(200)
                        .IsUnicode(true)
                        .IsRequired(false);
                entity.Property(e => e.ClientTypeId)
                        .HasMaxLength(200)
                        .IsUnicode(true)
                        .IsRequired(false);
            });
        }
    }
}