using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolos_2.Models
{
    public class EfDbContext : DbContext
    {
        public DbSet<Organiser> Organisers { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Artist_Event> Artist_Events { get; set; }
        public DbSet<Event_Organiser> Event_Organisers { get; set; }

        public EfDbContext()
        {

        }
        public EfDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Organiser>(o =>
            {
                o.HasKey(p => p.IdOrganiser);
                o.Property(p => p.IdOrganiser).ValueGeneratedOnAdd();
                o.Property(p => p.Name).HasMaxLength(30).IsRequired();

                o.HasMany(p => p.Event_Organisers).WithOne(p => p.Organiser).HasForeignKey(p => p.IdOrganiser);



            });
            modelBuilder.Entity<Event>(o =>
            {
                o.HasKey(p => p.IdEvent);
                o.Property(p => p.IdEvent).ValueGeneratedOnAdd();
                o.Property(p => p.Name).HasMaxLength(100).IsRequired();
                o.Property(p => p.StartDate).IsRequired();
                o.Property(p => p.EndDate).IsRequired();

                o.HasMany(p => p.Event_Organisers).WithOne(p => p.Event).HasForeignKey(p => p.IdEvent);
                o.HasMany(p=>p.Artist_Events).WithOne(p => p.Event).HasForeignKey(p => p.IdEvent);

            });

            modelBuilder.Entity<Artist>(o =>
            {
                o.HasKey(p => p.IdArtist);
                o.Property(p => p.IdArtist).ValueGeneratedOnAdd();
                o.Property(p => p.Nickname).HasMaxLength(30).IsRequired();
                o.HasMany(p => p.Artist_Events).WithOne(p => p.Artist).HasForeignKey(p => p.IdArtist);
                
            });
            modelBuilder.Entity<Artist_Event>(o =>
            {
                o.HasKey(p => new
                {
                    p.IdEvent,
                    p.IdArtist
                });

                o.Property(p => p.PerformanceDate).IsRequired();

                

            });
            modelBuilder.Entity<Event_Organiser>(o =>
            {
                o.HasKey(p => new
                {
                    p.IdOrganiser,
                    p.IdEvent
                });

                

            });

        }
    }
}
