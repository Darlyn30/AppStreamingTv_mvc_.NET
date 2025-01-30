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

            modelBuilder.Entity<Serie>().HasData(
                new Serie
                {
                    Id = 1,
                    Name = "Mad Max: Fury Road",
                    Description = "Una persecución sin límites",
                    GenderName = "Action",
                    ProducerName = "HBO",
                    ImagePath = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTPnd7rHMzB99xyxJM_I0qMx4CfBbU3X5lWZw&s",
                    DateLaunch = new DateOnly(2022, 6, 15)
                },
                new Serie
                {
                    Id = 2,
                    Name = "John Wick: Chapter 3",
                    Description = "El destino de un asesino",
                    GenderName = "Action",
                    ProducerName = "HBO",
                    ImagePath = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTnw3TERg5WgeeQfPkEOKfvUa9ozkQnK9Kwpg&s",
                    DateLaunch = new DateOnly(2021, 7, 20)
                },
                new Serie
                {
                    Id = 3,
                    Name = "The Equalizer",
                    Description = "Venganza y justicia",
                    GenderName = "Action",
                    ProducerName = "HBO",
                    ImagePath = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSBDDqyVkCGitgwrNGC0-4ncraXHB8AkICCAA&s",
                    DateLaunch = new DateOnly(2020, 12, 5)
                },
                new Serie
                {
                    Id = 4,
                    Name = "The Batman",
                    Description = "El renacimiento de un héroe",
                    GenderName = "Action",
                    ProducerName = "HBO",
                    ImagePath = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQcS_VtG0teuMR4fRh3lHKASF5DgRYFJJ12xg&s",
                    DateLaunch = new DateOnly(2023, 9, 10)
                },
                new Serie
                {
                    Id = 5,
                    Name = "James Bond: No Time to Die",
                    Description = "Espías en acción",
                    GenderName = "Action",
                    ProducerName = "HBO",
                    ImagePath = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQw33BwddJK9hCCB4fLXYzeMQAIOVbLeKZoww&s",
                    DateLaunch = new DateOnly(2019, 5, 22)
                },
                new Serie
                {
                    Id = 6,
                    Name = "The Hangover",
                    Description = "Una comedia que desafía todo",
                    GenderName = "Comedy",
                    ProducerName = "Netflix",
                    ImagePath = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTSzsuhJw9R3Em4QlevtLHubwh8rbWE-LRsIw&s",
                    DateLaunch = new DateOnly(2018, 3, 12)
                },
                new Serie
                {
                    Id = 7,
                    Name = "Dumb and Dumber",
                    Description = "Dos amigos en un problema absurdo",
                    GenderName = "Comedy",
                    ProducerName = "Netflix",
                    ImagePath = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRHmvOC6hQ-HH26kYbCyVlx4rMQNWEehBHZ4g&s",
                    DateLaunch = new DateOnly(2016, 11, 18)
                },
                new Serie
                {
                    Id = 8,
                    Name = "Superbad",
                    Description = "Risas sin parar",
                    GenderName = "Comedy",
                    ProducerName = "Netflix",
                    ImagePath = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR5UxEsOWvisBlyt9VQDUBRWnspIgJVqEEVsg&s",
                    DateLaunch = new DateOnly(2020, 8, 30)
                },
                new Serie
                {
                    Id = 9,
                    Name = "The Pursuit of Happyness",
                    Description = "Una historia de superación",
                    GenderName = "Drama",
                    ProducerName = "Amazon Prime",
                    ImagePath = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTsvSnqLSc7EahZH8SovIf69Xh5xcM8sn3dfQ&s",
                    DateLaunch = new DateOnly(2015, 9, 25)
                },
                new Serie
                {
                    Id = 10,
                    Name = "The Green Mile",
                    Description = "El peso de la justicia",
                    GenderName = "Drama",
                    ProducerName = "Amazon Prime",
                    ImagePath = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcST-_xVIEU6EaLaetNEvlR8B-aTjuRFnNDhZw&s",
                    DateLaunch = new DateOnly(2017, 2, 14)
                },
                new Serie
                {
                    Id = 11,
                    Name = "Stranger Things",
                    Description = "Un grupo de amigos descubre misterios sobrenaturales en su pequeña ciudad.",
                    GenderName = "Drama",
                    ProducerName = "Netflix",
                    ImagePath = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSUPZYoxnwtDUaaVd0DW90jUFpsLUjf5TJ5IA&s",
                    DateLaunch = new DateOnly(2016, 7, 15)
                },
                new Serie
                {
                    Id = 12,
                    Name = "Breaking Bad",
                    Description = "Un profesor de química se convierte en narcotraficante tras ser diagnosticado con cáncer.",
                    GenderName = "Drama",
                    ProducerName = "Netflix",
                    ImagePath = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRZfZpCMlu5Rb-B1bslBSeU3CP1Cx6lSTP-7g&s",
                    DateLaunch = new DateOnly(2008, 1, 20)
                }
            );
            #endregion
        }
    }
}
