using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,IdentityRole,string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
           
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; } = null!;
        public DbSet<Skills> Skills { get; set; } = null!;
        public DbSet<Projects> Projects { get; set; } = null!;
        public DbSet<Categories> Categories { get; set; } = null!;
        public DbSet<Technologies> Technologies { get; set; } = null!;
        public DbSet<TimelineEvents> TimelineEvents { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //user entity configuration, user have many skills, user have many projects
            builder.Entity<ApplicationUser>()
                .HasMany(u => u.Skills)
                .WithOne()
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<ApplicationUser>()
                .HasMany(u => u.Projects)
                .WithOne()
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            //user have many TimelineEvents belong to user
            builder.Entity<ApplicationUser>()
                .HasMany(u => u.TimelineEvents)
                .WithOne()
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            //projects and categories many to many relationship, new table CategoryProjects
            builder.Entity<Projects>()
                .HasMany(p => p.Categories)
                .WithMany(c => c.Projects)
                .UsingEntity<Dictionary<string, object>>(
                    "CategoryProjects",
                    j => j
                        .HasOne<Categories>()
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade),
                    j => j
                        .HasOne<Projects>()
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade),
                    j =>
                    {
                        j.HasKey("ProjectId", "CategoryId");
                    });

            //projects and technologies many to many relationship, new table ProjectTechnologies
            builder.Entity<Projects>()
                .HasMany(p => p.Technologies)
                .WithMany(t => t.Projects)
                .UsingEntity<Dictionary<string, object>>(
                    "ProjectTechnologies",
                    j => j
                        .HasOne<Technologies>()
                        .WithMany()
                        .HasForeignKey("TechnologyId")
                        .OnDelete(DeleteBehavior.Cascade),
                    j => j
                        .HasOne<Projects>()
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade),
                    j =>
                    {
                        j.HasKey("ProjectId", "TechnologyId");
                    });
            //project belong to user have many projects
            //  
            builder.Entity<Projects>()
                .HasOne(p => p.User)
                .WithMany(u => u.Projects)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            //skill belong to user have many skills
            builder.Entity<Skills>()
                .HasOne(s => s.User)
                .WithMany(u => u.Skills)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            //timeline event belong to user have many timeline events
            builder.Entity<TimelineEvents>()
                .HasOne(t => t.User)
                .WithMany(u => u.TimelineEvents)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
