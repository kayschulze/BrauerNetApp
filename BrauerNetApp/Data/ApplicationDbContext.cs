using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BrauerNetApp.Models;

namespace BrauerNetApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() { }

        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Goal> Goals { get; set; }
        public virtual DbSet<Standard> Standards { get; set; }
        public virtual DbSet<Stakeholder> Stakeholders { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<Step> Steps { get; set; }

        public virtual DbSet<GoalProject> GoalProject { get; set; }
        //public virtual DbSet<ModuleProject> ModuleProjects { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(@"Server=localhost;Port=3306;database=brauernetdbmigrations;uid=root;pwd=root;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            /*builder.Entity<ModuleProject>()
                .HasKey(p => new { p.ModuleId, p.ProjectId });

            builder.Entity<ModuleProject>()
                .HasOne(mp => mp.Module)
                .WithMany(mp => mp.ModuleProjects)
                .HasForeignKey(mp => mp.ModuleId);

            builder.Entity<ModuleProject>()
                .HasOne(mp => mp.Project)
                .WithMany(mp => mp.ModuleProjects)
                .HasForeignKey(mp => mp.ProjectId); */

            builder.Entity<GoalProject>()
                .HasKey(p => new { p.GoalId, p.ProjectId });

            builder.Entity<GoalProject>()
                .HasOne(gp => gp.Goal)
                .WithMany(gp => gp.GoalProjects)
                .HasForeignKey(gp => gp.GoalId);

            builder.Entity<GoalProject>()
                .HasOne(gp => gp.Project)
                .WithMany(p => p.GoalProjects)
                .HasForeignKey(gp => gp.ProjectId);
        }
    }
}
