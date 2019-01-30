using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ChatCore.Models;

namespace ChatServer.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Message> Messages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=ChatMessengerDB; Integrated Security=True; MultipleActiveResultSets=True")
                            .UseLazyLoadingProxies();
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {              
                entity.HasOne(m => m.MainPhoto)
                    .WithOne()
                    .HasForeignKey<User>(m => m.MainPhotoId);
            });

            modelBuilder.Entity<Media>(entity =>
            {
                entity.ToTable("Medias");
            });

            modelBuilder.Entity<Message>(entity =>
            {               
                entity.HasOne(m => m.Sender)
                    .WithOne()
                    .HasForeignKey<Message>(m => m.SenderId);
            });

            modelBuilder.Entity<Group>(entity =>
            {               
                entity.HasMany(m => m.Messages)
                    .WithOne(m => m.Group)
                    .HasForeignKey(m => m.GroupId);
            });

            modelBuilder.Entity<UserGroup>(entity =>
            {
                entity.ToTable("UserGroups");

                entity.HasKey(k => new { k.UserId, k.GroupId });

                entity.HasOne(m => m.Group)
                    .WithMany(m => m.UserGroups)
                    .HasForeignKey(m => m.GroupId);

                entity.HasOne(m => m.User)
                    .WithMany(m => m.UserGroups)
                    .HasForeignKey(m => m.UserId);
            });
        }
    }
}
