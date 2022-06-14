using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APARTMENTS.Models;

namespace APARTMENTS.Models
{
    public class Context : 
        IdentityDbContext<User, AppRole, int, IdentityUserClaim<int>, AppUserRole, 
        IdentityUserLogin<int>,IdentityRoleClaim<int>,IdentityUserToken<int>>
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Apartment>()
                .HasOne(u=>u.Renter)
                .WithMany(ap=> ap.RentedApartments)
                .HasForeignKey(oi => oi.RenterId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<User>()
                .HasMany(ap => ap.OwnedApartments)
                .WithOne(u => u.Owner)
                .HasForeignKey(oi => oi.OwnerId)
                .OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<Apartment>()
                .HasMany(p => p.Photos)
                .WithOne(u => u.apartment)
                .HasForeignKey(ui => ui.ApId);
            modelBuilder.Entity<User>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
            modelBuilder.Entity<AppRole>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();
            modelBuilder.Entity<Adress>()
                .HasOne(a => a.Apartment)
                .WithMany(ad => ad.Adress)
                .HasForeignKey(d => d.ApartmentId)
                .OnDelete(DeleteBehavior.ClientNoAction);
        }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Comment> Comments { get; set; }
        

    }
        
    }
