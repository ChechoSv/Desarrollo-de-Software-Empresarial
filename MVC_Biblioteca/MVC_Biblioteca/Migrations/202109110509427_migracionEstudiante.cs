namespace MVC_Biblioteca.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migracionEstudiante : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.estudiante",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(maxLength: 100),
                        primerApellido = c.String(maxLength: 100),
                        SegundaApellido = c.String(maxLength: 100),
                        email = c.String(),
                        telefono = c.String(),
                        carrera = c.String(maxLength: 100),
                        sexo = c.String(),
                        fechaNac = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.estudiante");
        }
    }
}
