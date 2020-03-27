using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TW.Dominio.Entidades.Entidades;
using static TW.Aplicacion.Conexion.CadenaConexion;

namespace TW.Infraestructura.Context
{
    public class Context : DbContext
    {
        public Context()
        {

        }

        public Context(DbContextOptions<Context> Option) : base(Option)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(AccesoCadenaConexion)
                    .EnableSensitiveDataLogging(true);
                //.UseLoggerFactory(new LoggerFactory().((category,level)=>level==LogLevel.Information
                //&& category == DbLoggerCategory.Database.Command.Name, true));
            }
        }

        public DbSet<Empresa> Empresa { get; set; }

        public DbSet<Categoria> Categoria { get; set; }

        public DbSet<SubCategoria> SubCategoria { get; set; }

        public DbSet<Lugar> Lugar { get; set; }

        public DbSet<Fecha> Fecha { get; set; }

        public DbSet<Horario> Horario { get; set; }

        public DbSet<Comprobante> Comprobante { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Categoria>()
                .HasOne(x => x.Empresa)
                .WithMany(y => y.Categorias)
                .HasForeignKey(x => x.EmpresaId);

            modelBuilder.Entity<SubCategoria>()
                .HasOne(x => x.Categoria)
                .WithMany(y => y.SubCategorias)
                .HasForeignKey(x => x.CategoriaId);

            modelBuilder.Entity<Lugar>()
                .HasOne(x => x.SubCategoria)
                .WithMany(y => y.Lugares)
                .HasForeignKey(x => x.SubCategoriaId);

            modelBuilder.Entity<Fecha>()
                .HasOne(x => x.Lugar)
                .WithMany(y => y.Fechas)
                .HasForeignKey(x => x.LugarId);

            modelBuilder.Entity<Horario>()
                .HasOne(x => x.Fecha)
                .WithMany(y => y.Horarios)
                .HasForeignKey(x => x.FechaId);

            modelBuilder.Entity<Comprobante>()
                .HasOne(x => x.Horario)
                .WithMany(y => y.Comprobantes)
                .HasForeignKey(x => x.HorarioId);

        }
    }
}
