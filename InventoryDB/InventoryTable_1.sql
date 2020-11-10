CREATE TABLE [dbo].[InventoryTable]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Product] NVARCHAR(50) NOT NULL, 
    [Amount] INT NOT NULL
);

