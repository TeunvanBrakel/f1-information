using Microsoft.EntityFrameworkCore;
using f1_information_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace f1_information_backend.Database
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContext(DbContextOptions<DbContext> options) : base(options)
        {

        }

        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<RaceSeason> RaceSeasons { get; set; }
        public DbSet<RaceDrivers> RaceDrivers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>()
                .HasMany(a => a.currentDrivers)
                .WithOne(b => b.Team)
                .HasForeignKey(b => b.Id);

            modelBuilder.Entity<RaceSeason>()
                .HasKey(rs => new { rs.SeasonId, rs.RaceId });

            modelBuilder.Entity<RaceSeason>()
                .HasOne(rs => rs.Race)
                .WithMany(r => r.Seasons)
                .HasForeignKey(rs => rs.RaceId);

            modelBuilder.Entity<RaceSeason>()
                .HasOne(rs => rs.Season)
                .WithMany(s => s.Races)
                .HasForeignKey(rs => rs.SeasonId);

            modelBuilder.Entity<RaceDrivers>()
                .HasKey(rd => new { rd.RaceId, rd.DriverId });

            modelBuilder.Entity<RaceDrivers>()
                .HasOne(rd => rd.Race)
                .WithMany(r => r.Drivers)
                .HasForeignKey(rd => rd.RaceId);

            modelBuilder.Entity<RaceDrivers>()
                .HasOne(rd => rd.Driver)
                .WithMany(d => d.Races)
                .HasForeignKey(rd => rd.DriverId);

            modelBuilder.Entity<RaceResult>()
                .HasKey(rr => new { rr.RaceId, rr.ResultId });

            modelBuilder.Entity<RaceResult>()
                .HasOne(rr => rr.Race)
                .WithMany(ra => ra.Results)
                .HasForeignKey(rr => rr.RaceId);

            modelBuilder.Entity<RaceResult>()
                .HasOne(rr => rr.Result)
                .WithMany(re => re.Races)
                .HasForeignKey(rr => rr.ResultId);

            modelBuilder.Entity<RaceFavorites>()
                .HasKey(rf => new { rf.RaceId, rf.UserId });

            modelBuilder.Entity<RaceFavorites>()
                .HasOne(rf => rf.Race)
                .WithMany(r => r.RaceFavoritesUser)
                .HasForeignKey(rf => rf.RaceId);

            modelBuilder.Entity<RaceFavorites>()
                .HasOne(rf => rf.User)
                .WithMany(u => u.RaceFavorites)
                .HasForeignKey(rf => rf.UserId);

            modelBuilder.Entity<DriverFavorites>()
                .HasKey(df => new { df.DriverId, df.UserId });

            modelBuilder.Entity<DriverFavorites>()
                .HasOne(df => df.Driver)
                .WithMany(d => d.FavoritesUser)
                .HasForeignKey(df => df.DriverId);

            modelBuilder.Entity<DriverFavorites>()
                .HasOne(df => df.User)
                .WithMany(u => u.DriverFavorites)
                .HasForeignKey(df => df.UserId);

            modelBuilder.Entity<DriverResult>()
                .HasKey(dr => new { dr.DriverId, dr.ResultId });

            modelBuilder.Entity<DriverResult>()
                .HasOne(dr => dr.Result)
                .WithMany(r => r.Drivers)
                .HasForeignKey(dr => dr.ResultId);

            modelBuilder.Entity<DriverResult>()
                .HasOne(dr => dr.Driver)
                .WithMany(d => d.Results)
                .HasForeignKey(dr => dr.DriverId);

            modelBuilder.Entity<GameSettings>()
                .HasMany(g => g.User)
                .WithOne(u => u.GameSettings)
                .HasForeignKey(u => u.GameSettingsId);
        }
    }
}
