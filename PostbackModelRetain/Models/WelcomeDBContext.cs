using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PostbackModelRetain.Models
{
    public partial class WelcomeDBContext : DbContext
    {
        public WelcomeDBContext()
        {
        }

        public WelcomeDBContext(DbContextOptions<WelcomeDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SavingsDetails> SavingsDetails { get; set; }
        public virtual DbSet<SavingsType> SavingsType { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer(@"Server=tcp:ikhaleelahamed.database.windows.net,1433;Persist Security Info=False;User ID=XXXXXX;Password=XXXXX;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Database=WelcomeDB");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SavingsDetails>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SavingsType).HasColumnName("Savings_Type");

                entity.Property(e => e.TransactionDate)
                    .HasColumnName("Transaction_Date")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.SavingsTypeNavigation)
                    .WithMany(p => p.InverseSavingsTypeNavigation)
                    .HasForeignKey(d => d.SavingsType)
                    .HasConstraintName("FK__SavingsDe__Savin__2FCF1A8A");
            });

            modelBuilder.Entity<SavingsType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EndDate)
                    .HasColumnName("End_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.SavingsType1)
                    .HasColumnName("Savings_Type")
                    .HasMaxLength(200);

                entity.Property(e => e.StartDate)
                    .HasColumnName("Start_Date")
                    .HasColumnType("datetime");
            });

            modelBuilder.HasSequence<int>("SalesOrderNumber");
        }
    }
}
