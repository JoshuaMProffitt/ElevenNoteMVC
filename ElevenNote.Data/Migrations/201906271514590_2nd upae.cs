namespace ElevenNote.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2ndupae : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Note", "Isstarred", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Note", "Isstarred");
        }
    }
}
