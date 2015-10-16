namespace FoodSocial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblBAICHIASE",
                c => new
                    {
                        idBaiDang = c.Int(nullable: false, identity: true),
                        idNguoiViet = c.String(),
                        tenNguoiViet = c.String(),
                        noiDung = c.String(),
                        thoiGianViet = c.DateTime(nullable: false),
                        vote = c.Int(nullable: false),
                        linkAnh = c.String(),
                        diaDiem = c.String(),
                    })
                .PrimaryKey(t => t.idBaiDang);
            
            CreateTable(
                "dbo.tblCOMMENT",
                c => new
                    {
                        idComment = c.Int(nullable: false, identity: true),
                        idBaiDang = c.Int(nullable: false),
                        idNguoiViet = c.String(),
                        tenNguoiViet = c.String(),
                        idAvatar = c.Int(nullable: false),
                        noiDung = c.String(),
                        thoiGianViet = c.DateTime(nullable: false),
                        vote = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idComment)
                .ForeignKey("dbo.tblBAICHIASE", t => t.idBaiDang, cascadeDelete: true)
                .Index(t => t.idBaiDang);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblCOMMENT", "idBaiDang", "dbo.tblBAICHIASE");
            DropIndex("dbo.tblCOMMENT", new[] { "idBaiDang" });
            DropTable("dbo.tblCOMMENT");
            DropTable("dbo.tblBAICHIASE");
        }
    }
}
