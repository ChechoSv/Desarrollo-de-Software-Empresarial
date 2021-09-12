namespace MVC_Biblioteca.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migracionPrestamo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.prestamo",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        fechaPrestamo = c.DateTime(nullable: false),
                        fechaDevolucion = c.DateTime(nullable: false),
                        estudiante_id = c.Int(),
                        libro_id = c.Int(),
                        estudiantes_id = c.Int(),
                        libros_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.estudiante", t => t.estudiantes_id)
                .ForeignKey("dbo.libro", t => t.libros_id)
                .Index(t => t.estudiantes_id)
                .Index(t => t.libros_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.prestamo", "libros_id", "dbo.libro");
            DropForeignKey("dbo.prestamo", "estudiantes_id", "dbo.estudiante");
            DropIndex("dbo.prestamo", new[] { "libros_id" });
            DropIndex("dbo.prestamo", new[] { "estudiantes_id" });
            DropTable("dbo.prestamo");
        }
    }
}
