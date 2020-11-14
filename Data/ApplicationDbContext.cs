using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TesorosApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<AppUser> Usuarios { get; set; }
        public DbSet<Tesoros> Tesoro { get; set; }
        public DbSet<Coordenadas> Cordenadas { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<AppUser>(entityTypeBuilder =>
            {
                entityTypeBuilder.ToTable("Users");
                entityTypeBuilder.Property(u => u.Id_users).HasMaxLength(100).IsRequired();
                entityTypeBuilder.Property(u => u.Nombre).HasMaxLength(100);
                entityTypeBuilder.Property(u => u.Color).HasMaxLength(8).HasDefaultValue("#ffffff");
            });
        }
    }
    public class AppUser : IdentityUser
    {
        public Guid Id_users { get; set; }
        public string Nombre { get; set; }
        public string Color { get; set; }
    }
    public class Tesoros
    {
        public Guid Uid { get; set; }
        public Guid Id { get; set; }
        public string Nombre_t { get; set; }
        public string Descripcion_t { get; set; }
        public DateTime Fecha_t { get; set; }
        public Coordenadas Cordenadas { get; set; }
        public string Valor { get; set; }
        public string Lugar { get; set; }
        public string Peso { get; set; }
        public string UrlRef { get; set; }


    }
    public class Coordenadas
    {
        public Guid Id { get; set; }
        public Guid Tid { get; set; }
        public Guid Uid { get; set; }
        public float Lat { get; set; }
        public float Lng { get; set; }
    }
}
