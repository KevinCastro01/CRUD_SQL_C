namespace TALLER_17_11.DAL.DbContext
{
    using Microsoft.EntityFrameworkCore;
    using TALLER_17_11.DAL.Entities;

    public class FichaDbContext : DbContext
    {
        //constructor
        public FichaDbContext(DbContextOptions<FichaDbContext>options):
            base(options)
        {

        }
        //Inyeccion de dependencia por tipo (clase virtuales)
        //Manipulacion de las tablas 
        public virtual DbSet<Matricula> Matricula { get; set; }
        public virtual DbSet<Conductor> Conductor { get; set; }
        public virtual DbSet<Sanciones> Sanciones { get; set; }
    }
}
