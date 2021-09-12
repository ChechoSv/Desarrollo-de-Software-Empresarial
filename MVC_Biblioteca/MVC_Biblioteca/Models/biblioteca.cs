using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace MVC_Biblioteca.Models
{
    public class biblioteca : DbContext
    {
        // El contexto se ha configurado para usar una cadena de conexión 'biblioteca' del archivo 
        // de configuración de la aplicación (App.config o Web.config). De forma predeterminada, 
        // esta cadena de conexión tiene como destino la base de datos 'MVC_Biblioteca.Models.biblioteca' de la instancia LocalDb. 
        // 
        // Si desea tener como destino una base de datos y/o un proveedor de base de datos diferente, 
        // modifique la cadena de conexión 'biblioteca'  en el archivo de configuración de la aplicación.
        public biblioteca()
            : base("name=biblioteca")
        {
        }
        
        // Agregue un DbSet para cada tipo de entidad que desee incluir en el modelo. Para obtener más información 
        // sobre cómo configurar y usar un modelo Code First, vea http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<libro> libro { get; set; }
        public virtual DbSet<estudiante> estudiante { get; set; }
        public virtual DbSet<prestamo> prestamo { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}

}