using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using GoldenGames.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using GoldenGames.Areas.Admin.ViewModels;

namespace GoldenGames.Data
{
    public partial class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorium> Categoria { get; set; } = null!;
        public virtual DbSet<Compra> Compras { get; set; } = null!;
        public virtual DbSet<Jogo> Jogos { get; set; } = null!;
        public virtual DbSet<JogosCompra> JogosCompras { get; set; } = null!;
        public virtual DbSet<RegistoJogo> RegistoJogos { get; set; } = null!;
        public virtual DbSet<UtilizadoresJogo> UtilizadoresJogos { get; set; } = null!;
        public virtual DbSet<Consola> Consolas { get; set; } = null!;
        public virtual DbSet<FavCategories> FavCategories { get; set; }
        public virtual DbSet<Review> Reviews { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Renomeamento das tabelas Identity 
            modelBuilder.Entity<IdentityUser>().ToTable("Utilizadores"); //AspNetUsers, no proximo update que tiver de fazer a base de dados alterar o nome para Utilizadores simplesmente
            modelBuilder.Entity<IdentityRole>().ToTable("Role_Utilizadores"); //AspNetRoles
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("Utilizador_Role_Utilizadores"); //AspNetUserRole

        }


    }
}
