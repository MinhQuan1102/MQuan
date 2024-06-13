using api.Entities;
using api.Entities.MQSocial;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace api.Data
{
    public class DataContext : IdentityDbContext<
        User, Role, int, IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>
    >
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Image> Images { get; set; }
        //public DbSet<Friendship> Friendship { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostReaction> PostReactions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId)
                .IsRequired();

            builder.Entity<Role>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.Role)
                .HasForeignKey(u => u.RoleId)
                .IsRequired();

            builder.Entity<Friendship>()
                .HasKey(k => new { k.User1Id, k.User2Id });

            builder.Entity<Friendship>()
                .HasOne(u => u.User1)
                .WithMany(f => f.Friendship1)
                .HasForeignKey(u => u.User1Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Friendship>()
               .HasOne(u => u.User2)
               .WithMany(f => f.Friendship2)
               .HasForeignKey(u => u.User2Id)
               .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<User>()
                .HasMany(u => u.Posts)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<User>()
                .HasMany(x => x.UserGroups)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .IsRequired();

            builder.Entity<Group>()
                .HasMany(x => x.UserGroups)
                .WithOne(x => x.Group)
                .HasForeignKey(x => x.GroupId)
                .IsRequired();

            builder.Entity<PostReaction>()
                .HasOne(u => u.User)
                .WithMany(pr => pr.PostReactions)
                .HasForeignKey(p =>p. UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<PostReaction>()
                .HasOne(p => p.Post)
                .WithMany(r => r.Reactions)
                .HasForeignKey(p => p.PostId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
