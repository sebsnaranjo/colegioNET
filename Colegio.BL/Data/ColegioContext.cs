using Colegio.BL.Models;
using System.Data.Entity;

namespace Colegio.BL.Data
{
    public class ColegioContext : DbContext
    {
        private static ColegioContext colegioContext = null;
        public ColegioContext() : base ("ColegioContext")
        {
            
        }

        public DbSet<Profesor> Profesor { get; set; }
        public DbSet<Estudiante> Estudiante { get; set; }
        public DbSet<Nota> Nota { get; set; }

        public static ColegioContext Create()
        {
            if(colegioContext == null)
            {
                colegioContext = new ColegioContext();
            }

            return new ColegioContext();
        }
    }
}
