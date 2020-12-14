using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Thaz.DAL.Entities;

namespace Thaz.DAL
{
    public class ThazDbContext : DbContext
    {

        public DbSet<BillItem> BillItems { get; set; }
        public DbSet<BillFile> BillFiles { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Transaction> Transactions { get; set;}
        public DbSet<Condominium> Condominiums { get; set;   }
        public DbSet<User> Users { get; set;   }
        public DbSet<BillTag> BillTags {get; set; }
        public DbSet<TransactionTag> TransactionTags {get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=homzdb;Username=postgres;Password=password");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BillItem>()
                .HasOne(x => x.Bill)
                .WithMany(g => g.Items)
                .HasForeignKey("bill_id");
            
            modelBuilder.Entity<Bill>()
                .HasOne(x => x.Partner)
                .WithMany(x => x.Bills)
                .HasForeignKey("partner_id");
            
            modelBuilder.Entity<Transaction>()
                .HasOne(x => x.Partner)
                .WithMany(x => x.Transactions)
                .HasForeignKey("partner_id");
            
            modelBuilder.Entity<Bill>()
                .HasOne(x => x.Condominium)
                .WithMany(x => x.Bills)
                .HasForeignKey("condominium_id");
            
            modelBuilder.Entity<Transaction>()
                .HasOne(x => x.Condominium)
                .WithMany(x => x.Transactions)
                .HasForeignKey("condominium_id");

            modelBuilder.Entity<Transaction>()
                .HasOne(x => x.Owner)
                .WithMany()
                .HasForeignKey("owner_id");
            modelBuilder.Entity<Condominium>()
                .HasOne(x => x.Owner)
                .WithMany()
                .HasForeignKey("owner_id");
            modelBuilder.Entity<Partner>()
                .HasOne(x => x.Owner)
                .WithMany()
                .HasForeignKey("owner_id");
            modelBuilder.Entity<Bill>()
                .HasOne(x => x.Owner)
                .WithMany()
                .HasForeignKey("owner_id");

            modelBuilder.Entity<Partner>()
                .OwnsOne(x => x.Address);

            modelBuilder.Entity<Condominium>()
                .OwnsOne(x => x.Address);

            modelBuilder.Entity<Condominium>()
                .HasMany(x => x.Residents)
                .WithMany(x => x.ResidentOf)
                .UsingEntity<ResidentOfCondominiumConnector>(
                    x => x
                        .HasOne(y => y.Partner)
                        .WithMany(y => y.ResidentConnectors)
                        .HasForeignKey(x => x.PartnerId),
                    x => x
                        .HasOne(y => y.Condominium)
                        .WithMany(y => y.ResidentConnectors)
                        .HasForeignKey(x => x.CondominiumId),
                    x => x
                        .HasKey(k => new {k.CondominiumId, k.PartnerId})
                );
            modelBuilder.Entity<TransactionTag>()
                .HasOne(x => x.Transaction)
                .WithMany(x => x.Tags)
                .HasForeignKey("transaction_id");

            modelBuilder.Entity<BillTag>()
                .HasOne(x => x.Bill)
                .WithMany(x => x.Tags)
                .HasForeignKey("bill_id");
        }
    }
}