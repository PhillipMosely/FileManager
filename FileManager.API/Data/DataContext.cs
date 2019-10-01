using datingapp.api.Models;
using Microsoft.EntityFrameworkCore;

namespace datingapp.api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options){}

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRole { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserRole>()
                .HasKey(k => new {k.UserId, k.RoleId});

            builder.Entity<UserRole>()
                .HasOne(u => u.User)
                .WithMany(u => u.Role)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            
             builder.Entity<UserRole>()
                .HasOne(u => u.Role)
                .WithMany(u => u.User)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}