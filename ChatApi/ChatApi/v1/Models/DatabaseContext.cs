using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ChatApi.v1.Models
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<GroupMember> GroupMember { get; set; }
        public virtual DbSet<GroupMessage> GroupMessage { get; set; }
        public virtual DbSet<GroupMessageState> GroupMessageState { get; set; }
        public virtual DbSet<PersonalMessage> PersonalMessage { get; set; }
        public virtual DbSet<PersonalMessageState> PersonalMessageState { get; set; }
        public virtual DbSet<Photo> Photo { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("data source=(localdb)\\MSSQLLocalDB;attachdbfilename=C:\\Users\\SuxrobGM\\ChatAppDB.mdf;integrated security=True;MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Admin)
                    .WithMany(p => p.GroupAdmin)
                    .HasForeignKey(d => d.AdminId)
                    .HasConstraintName("FK_Group_AdminId");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.GroupOwner)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("FK_Group_OwnerId");
            });

            modelBuilder.Entity<GroupMember>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupMember)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GroupMember_GroupId");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.GroupMember)
                    .HasForeignKey<GroupMember>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GroupMember_UserId");
            });

            modelBuilder.Entity<GroupMessage>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Text).HasColumnType("ntext");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupMessage)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GroupMessage_GroupId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.GroupMessage)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GroupMessage_UserId");
            });

            modelBuilder.Entity<GroupMessageState>(entity =>
            {
                entity.HasKey(e => e.GroupMessageId);

                entity.Property(e => e.GroupMessageId).ValueGeneratedNever();

                entity.Property(e => e.IsNotified).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsRead).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.GroupMessage)
                    .WithOne(p => p.GroupMessageState)
                    .HasForeignKey<GroupMessageState>(d => d.GroupMessageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GroupMessageState_GroupMessageId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.GroupMessageState)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GroupMessageState_UserId");
            });

            modelBuilder.Entity<PersonalMessage>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Text).HasColumnType("ntext");

                entity.HasOne(d => d.ReceivedUser)
                    .WithMany(p => p.PersonalMessageReceivedUser)
                    .HasForeignKey(d => d.ReceivedUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonalMessage_ReceivedUserId");

                entity.HasOne(d => d.SenderUser)
                    .WithMany(p => p.PersonalMessageSenderUser)
                    .HasForeignKey(d => d.SenderUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonalMessage_SenderUserId");
            });

            modelBuilder.Entity<PersonalMessageState>(entity =>
            {
                entity.HasKey(e => e.PersonalMessageId);

                entity.Property(e => e.PersonalMessageId).ValueGeneratedNever();

                entity.Property(e => e.IsNotified).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsRead).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.PersonalMessage)
                    .WithOne(p => p.PersonalMessageState)
                    .HasForeignKey<PersonalMessageState>(d => d.PersonalMessageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonalMessageState_PersonalMessageId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PersonalMessageState)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonalMessageState_UserId");
            });

            modelBuilder.Entity<Photo>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.PhotoBinary).HasColumnType("image");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Login)
                    .HasName("UQ__tmp_ms_x__5E55825B4996A4A0")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RegistrationDate).HasColumnType("date");

                entity.Property(e => e.TelephoneNumber).HasMaxLength(50);

                entity.HasOne(d => d.MainPhoto)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.MainPhotoId)
                    .HasConstraintName("FK_User_MainPhotoId");
            });
        }
    }
}
