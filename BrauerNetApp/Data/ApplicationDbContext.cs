using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BrauerNetApp.Models;

namespace BrauerNetApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() { }

        public virtual DbSet<QUESTOR> QUESTORs { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Goal> Goals { get; set; }
        public virtual DbSet<Standard> Standards { get; set; }
        public virtual DbSet<Stakeholder> Stakeholders { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<Step> Steps { get; set; }
        public virtual DbSet<Response> Responses { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(@"Server=localhost;Port=3306;database=brauernetdb;uid=root;pwd=root");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<ProjectStandard>()
                .HasKey(p => new { p.StandardId, p.ProjectId });

            builder.Entity<ProjectStandard>()
                .HasOne(ps => ps.Standard)
                .WithMany(s => s.ProjectStandards)
                .HasForeignKey(ps => ps.StandardId);

            builder.Entity<ProjectStandard>()
                .HasOne(ps => ps.Project)
                .WithMany(p => p.ProjectStandards)
                .HasForeignKey(ps => ps.ProjectId);
        }
    }
}
