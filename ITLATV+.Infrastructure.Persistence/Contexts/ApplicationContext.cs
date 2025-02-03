using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITLATV_.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ITLATV_.Infrastructure.Persistence.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            :base(options)
        {
        }

        public DbSet<Serie> Series { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Producer> Producers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //FLUENT API
            #region Tables
            modelBuilder.Entity<Serie>().ToTable("Series");
            modelBuilder.Entity<Gender>().ToTable("Genders");
            modelBuilder.Entity<Producer>().ToTable("Producers");
            #endregion

            #region Setting Props Tables

            modelBuilder.Entity<Gender>(entity => {

                entity.ToTable("Genders");
                entity.HasKey(fk => fk.Id);
                entity.Property(g => g.Name)
                      .IsRequired()
                      .HasMaxLength(100);
                entity.HasMany(g => g.Series)
                      .WithOne(s => s.Gender)
                      .HasForeignKey(g => g.GenderId); //FK
            });

            modelBuilder.Entity<Serie>(entity => {

                entity.ToTable("Series");
                entity.HasKey(fk => fk.Id);
                entity.Property(s => s.Name)
                      .HasMaxLength(150)
                      .IsRequired();
                entity.Property(s => s.imgPath)
                      .IsRequired();
                entity.Property(s => s.LinkVideo)
                      .IsRequired();

            });

            modelBuilder.Entity<Producer>(entity => {

                entity.ToTable("Producers");
                entity.HasKey(fk => fk.Id);
                entity.Property(p => p.Name)
                      .HasMaxLength(150)
                      .IsRequired();
                entity.HasMany(p => p.Series)
                      .WithOne(p => p.Producer)
                      .HasForeignKey(p => p.ProducerId) // FK
                      .OnDelete(DeleteBehavior.Cascade);
            });
            #endregion

            #region Seed Data
            //Inject Data genders & producers
            modelBuilder.Entity<Gender>().HasData(
                new Gender { Id = 1, Name = "Action" },
                new Gender { Id = 2, Name = "Drama" },
                new Gender { Id = 3, Name = "Comedy" }
            );

            modelBuilder.Entity<Producer>().HasData(
                new Producer { Id = 1, Name = "Netflix", ImgPath = "https://i.blogs.es/4285e7/netflix-portada/500_333.jpeg" },
                new Producer { Id = 2, Name = "HBO", ImgPath = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS0CJ1Hes6NEmEew2gvgVtFZ02yCEPpDtKLKw&s" },
                new Producer { Id = 3, Name = "Amazon Prime", ImgPath = "https://m.media-amazon.com/images/I/31W9hs7w0JL.png" }
            );

            //serie data default
            modelBuilder.Entity<Serie>().HasData(
                new Serie
                {
                    Id = 1,
                    Name = "Mad Max: Fury Road",
                    Description = "Una persecución sin límites",
                    imgPath = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTPnd7rHMzB99xyxJM_I0qMx4CfBbU3X5lWZw&s",
                    ReleaseDate = DateOnly.Parse("2022-06-15"),
                    GenderId = 1,
                    ProducerId = 2,
                    LinkVideo = "https://www.youtube.com/watch?v=kvU4uf8bI0o"
                },
                new Serie
                {
                    Id = 2,
                    Name = "John Wick: Chapter 3",
                    Description = "El destino de un asesino",
                    imgPath = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTnw3TERg5WgeeQfPkEOKfvUa9ozkQnK9Kwpg&s",
                    ReleaseDate = DateOnly.Parse("2021-07-20"),
                    GenderId = 1,
                    ProducerId = 2,
                    LinkVideo = "https://www.youtube.com/watch?v=NbUt7Apl_Z0"
                },
                new Serie
                {
                    Id = 3,
                    Name = "The Equalizer",
                    Description = "Venganza y justicia",
                    imgPath = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSBDDqyVkCGitgwrNGC0-4ncraXHB8AkICCAA&s",
                    ReleaseDate = DateOnly.Parse("2020-12-05"),
                    GenderId = 1,
                    ProducerId = 2,
                    LinkVideo = "https://www.youtube.com/watch?v=VjctHUEmutw"
                },
                new Serie
                {
                    Id = 4,
                    Name = "The Batman",
                    Description = "El renacimiento de un héroe",
                    imgPath = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQcS_VtG0teuMR4fRh3lHKASF5DgRYFJJ12xg&s",
                    ReleaseDate = DateOnly.Parse("2023-09-10"),
                    GenderId = 1,
                    ProducerId = 2,
                    LinkVideo = "https://www.youtube.com/watch?v=NLOp_6uPccQ"
                },
                new Serie
                {
                    Id = 5,
                    Name = "James Bond: No Time to Die",
                    Description = "Espías en acción",
                    imgPath = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQw33BwddJK9hCCB4fLXYzeMQAIOVbLeKZoww&s",
                    ReleaseDate = DateOnly.Parse("2019-05-22"),
                    GenderId = 1,
                    ProducerId = 2,
                    LinkVideo = "https://www.youtube.com/watch?v=BIhNsAtPbPI"
                },
                new Serie
                {
                    Id = 6,
                    Name = "The Hangover",
                    Description = "Una comedia que desafía todo",
                    imgPath = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTSzsuhJw9R3Em4QlevtLHubwh8rbWE-LRsIw&s",
                    ReleaseDate = DateOnly.Parse("2018-03-12"),
                    GenderId = 3,
                    ProducerId = 1,
                    LinkVideo = "https://www.youtube.com/watch?v=tcdUhdOlz9M"
                },
                new Serie
                {
                    Id = 7,
                    Name = "Dumb and Dumber",
                    Description = "Dos amigos en un problema absurdo",
                    imgPath = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRHmvOC6hQ-HH26kYbCyVlx4rMQNWEehBHZ4g&s",
                    ReleaseDate = DateOnly.Parse("2016-11-18"),
                    GenderId = 3,
                    ProducerId = 1,
                    LinkVideo = "https://www.youtube.com/watch?v=l13yPhimE3o"
                },
                new Serie
                {
                    Id = 8,
                    Name = "Superbad",
                    Description = "Risas sin parar",
                    imgPath = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR5UxEsOWvisBlyt9VQDUBRWnspIgJVqEEVsg&s",
                    ReleaseDate = DateOnly.Parse("2020-08-30"),
                    GenderId = 3,
                    ProducerId = 1,
                    LinkVideo = "https://www.youtube.com/watch?v=4eaZ_48ZYog"
                },
                new Serie
                {
                    Id = 9,
                    Name = "The Pursuit of Happyness",
                    Description = "Una historia de superación",
                    imgPath = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTsvSnqLSc7EahZH8SovIf69Xh5xcM8sn3dfQ&s",
                    ReleaseDate = DateOnly.Parse("2015-09-25"),
                    GenderId = 2,
                    ProducerId = 3,
                    LinkVideo = "https://www.youtube.com/watch?v=DMOBlEcRuw8"
                },
                new Serie
                {
                    Id = 10,
                    Name = "The Green Mile",
                    Description = "El peso de la justicia",
                    imgPath = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcST-_xVIEU6EaLaetNEvlR8B-aTjuRFnNDhZw&s",
                    ReleaseDate = DateOnly.Parse("2017-02-14"),
                    GenderId = 2,
                    ProducerId = 3,
                    LinkVideo = "https://www.youtube.com/watch?v=Ki4haFrqSrw"
                }
            );
            #endregion
        }
    }
}
