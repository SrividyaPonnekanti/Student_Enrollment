namespace InventoryProvider.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SampleV3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TInventoryItem", "InventoryNumber", c => c.String());
            CreateStoredProcedure(
                "dbo.InventoryItemDto_Insert",
                p => new
                    {
                        InventoryNumber = p.String(),
                        Name = p.String(),
                        Quantity = p.Int(),
                        Lowwatermark = p.Int(),
                        RetirementDate = p.DateTime(),
                    },
                body:
                    @"INSERT [dbo].[TInventoryItem]([InventoryNumber], [Name], [Quantity], [Lowwatermark], [RetirementDate])
                      VALUES (@InventoryNumber, @Name, @Quantity, @Lowwatermark, @RetirementDate)
                      
                      DECLARE @InventoryItemId int
                      SELECT @InventoryItemId = [InventoryItemId]
                      FROM [dbo].[TInventoryItem]
                      WHERE @@ROWCOUNT > 0 AND [InventoryItemId] = scope_identity()
                      
                      SELECT t0.[InventoryItemId]
                      FROM [dbo].[TInventoryItem] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[InventoryItemId] = @InventoryItemId"
            );
            
            CreateStoredProcedure(
                "dbo.InventoryItemDto_Update",
                p => new
                    {
                        InventoryItemId = p.Int(),
                        InventoryNumber = p.String(),
                        Name = p.String(),
                        Quantity = p.Int(),
                        Lowwatermark = p.Int(),
                        RetirementDate = p.DateTime(),
                    },
                body:
                    @"UPDATE [dbo].[TInventoryItem]
                      SET [InventoryNumber] = @InventoryNumber, [Name] = @Name, [Quantity] = @Quantity, [Lowwatermark] = @Lowwatermark, [RetirementDate] = @RetirementDate
                      WHERE ([InventoryItemId] = @InventoryItemId)"
            );
            
            CreateStoredProcedure(
                "dbo.InventoryItemDto_Delete",
                p => new
                    {
                        InventoryItemId = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[TInventoryItem]
                      WHERE ([InventoryItemId] = @InventoryItemId)"
            );
            
            DropStoredProcedure("dbo.InventoryItemDto_Insert");
            DropStoredProcedure("dbo.InventoryItemDto_Update");
            DropStoredProcedure("dbo.InventoryItemDto_Delete");
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.InventoryItemDto_Delete");
            DropStoredProcedure("dbo.InventoryItemDto_Update");
            DropStoredProcedure("dbo.InventoryItemDto_Insert");
            AlterColumn("dbo.TInventoryItem", "InventoryNumber", c => c.Int(nullable: false));
            throw new NotSupportedException("Scaffolding create or alter procedure operations is not supported in down methods.");
        }
    }
}
