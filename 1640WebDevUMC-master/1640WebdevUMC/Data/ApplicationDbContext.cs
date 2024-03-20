using _1640WebDevUMC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace _1640WebDevUMC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }  
        public DbSet<Accounts>? Accounts { get; set; }
        public DbSet<AcademicYear>? AcademicYears { get; set; }
        public DbSet<Contribution>? contributions { get; set; }
        public DbSet<DownloadHistory>? DownloadHistory { get; set; } = null;
        public DbSet<Faculty>? Faculties { get; set; }    
        public DbSet<_1640WebDevUMC.Models.File>? Files { get; set; }
        public DbSet<Image>? Images { get; set; }
        public DbSet<Notification>? Notification { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Call base implementation

            // Configure keyless entity type for SelectListItem
            modelBuilder.Entity<SelectListGroup>().HasNoKey();
        }

    }
}
