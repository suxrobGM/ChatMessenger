using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApi.v1.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {

        }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }    
        public virtual DbSet<UserGroup> UserGroups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=ChatMessengerDB; Integrated Security=True; MultipleActiveResultSets=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasMany(m => m.Photos)
                    .WithOne(m => m.Owner)
                    .HasForeignKey(k => k.OwnerId);
            });

            modelBuilder.Entity<UserGroup>(entity =>
            {
                entity.HasKey(k => new { k.GroupId, k.UserId });

                entity.HasOne(m => m.Group)
                    .WithMany(m => m.UserGroups);

                entity.HasOne(m => m.User)
                    .WithMany(m => m.UserGroups);
            });

            modelBuilder.Entity<PersonalMessage>(entity =>
            {
                entity.HasOne(m => m.Sender)
                    .WithMany(m => m.SentPersonalMessages)
                    .HasForeignKey(k => k.SenderUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(m => m.Receiver)
                     .WithMany(m => m.RecievedPersonalMessages)
                     .HasForeignKey(k => k.ReceiverUserId)
                     .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<GroupMessage>(entity =>
            {
                entity.HasOne(m => m.Group)
                    .WithMany(m => m.GroupMessages)
                    .HasForeignKey(k => k.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(m => m.Sender)
                    .WithMany(m => m.GroupMessages)
                    .HasForeignKey(k => k.GroupSenderUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }
    }
}
