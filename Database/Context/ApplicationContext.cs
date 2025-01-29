using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {   
        }

        public DbSet<Serie> Series { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Producer> Producers { get; set; }

        // ORM configured
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //FLUENT API
            #region Tables
            modelBuilder.Entity<Serie>().ToTable("Series");
            modelBuilder.Entity<Gender>().ToTable("Genders");
            modelBuilder.Entity<Producer>().ToTable("Producers");
            #endregion

            #region PK
            modelBuilder.Entity<Serie>().HasKey(serie =>  serie.Id);
            modelBuilder.Entity<Gender>().HasKey(gender => gender.Name);
            modelBuilder.Entity<Producer>().HasKey(producer => producer.Name);
            #endregion

            #region FK
            //set relation with FK

            //1FN
            modelBuilder.Entity<Gender>().HasMany<Serie>(gender => gender.Series) // 1:N
                .WithOne(serie => serie.Gender) // N:1
                .HasForeignKey(serie => serie.GenderName)
                .OnDelete(DeleteBehavior.Cascade); // if any category is deleted with data product, the products will be deleted

            #endregion

            #region Seed Data
            //Inject Data genders & producers
            modelBuilder.Entity<Gender>().HasData(
                new Gender { Name = "Action" },
                new Gender { Name = "Drama" },
                new Gender { Name = "Comedy" }
            );

            modelBuilder.Entity<Producer>().HasData(
                new Producer { Name = "Netflix" },
                new Producer { Name = "HBO" },
                new Producer { Name = "Amazon Prime" }
            );
            #endregion
        }
    }
}
