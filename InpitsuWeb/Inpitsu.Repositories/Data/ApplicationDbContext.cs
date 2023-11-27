using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Inpitsu.Data.Models;

namespace Inpitsu.Repositories.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ReleaseDrugItem> ReleaseDrugItems { get; set;}
        public DbSet<ReleaseDrugs> ReleaseDrugs { get; set; }
        public DbSet<Process> Processes { get; set; }
        public DbSet<Attach> Attaches { get; set; }
        public DbSet<Contragent> Contragents{ get; set; }
        public DbSet<Email> Email_base { get; set; }
        public DbSet<Emails> Emails { get; set; }
        public DbSet<Phones> Phones { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<BankCard> BankCards { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<ApplicationFor> ApplicationFor { get; set; }
        public DbSet<ComingDrug> ComingDrug { get; set;}
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Currency> Currency { get; set; }
        public DbSet<Deal> Deal { get; set; }
        public DbSet<DeliveryObject> DeliveryObjects { get; set;}
        public DbSet<District> District { get; set; }
        public DbSet<Drug> Drug { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<Sex> Sex { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<Inpitsu.Data.Models.Task> Tasks { get; set; }
        public DbSet<Chat> Chat { get; set; }
    }
}