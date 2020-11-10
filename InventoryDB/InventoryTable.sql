CREATE TABLE [dbo].[InventoryTable]
(
	[Product_ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Suppier_ID] INT NOT NULL, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Quantity] INT NOT NULL
)
