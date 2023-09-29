using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExamenServiciosWebCL1.Models;

namespace ExamenServiciosWebCL1.Database.ExamenContext
{
    public class ExamenContext:DbContext
    {
        public DbSet<Alumno> Alumnos { get; set; }

        public ExamenContext(DbContextOptions<ExamenContext> options) : base(options)
        {

        }
    }
}
