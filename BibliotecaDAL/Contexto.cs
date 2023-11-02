
using BibliotecaDAL.Entidades;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using System.Collections.Generic;
using System.Reflection.Emit;
namespace BibliotecaDAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Acceso> accesos { get; set; }
    }
}

