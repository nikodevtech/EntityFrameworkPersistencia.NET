using DAL.Entidades.DAO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{

    /// <summary>
    ///     Clase que extiende de DbContext y que representa el contexto de la aplicación
    /// </summary>
    public class Contexto : DbContext
    {

        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }

        public DbSet<Nota> Notas { get; set; }
        public DbSet<Evaluacion> Evaluaciones { get; set; }

    }
}
