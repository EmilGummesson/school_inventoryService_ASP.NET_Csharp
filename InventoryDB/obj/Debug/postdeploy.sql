/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
INSERT INTO InventoryTable (Product, Amount)
VALUES ("Banan",5);
*/

INSERT INTO InventoryTable (Product, Amount) VALUES ('bananer',37);
INSERT INTO InventoryTable (Product, Amount) VALUES ('gurkor',2);
INSERT INTO InventoryTable (Product, Amount) VALUES ('vindruvor',5);
INSERT INTO InventoryTable (Product, Amount) VALUES ('dynamit',5000);
INSERT INTO InventoryTable (Product, Amount) VALUES ('potatisar',468);
INSERT INTO InventoryTable (Product, Amount) VALUES ('torskar',1);
INSERT INTO InventoryTable (Product, Amount) VALUES ('fotbollar',9000);
INSERT INTO InventoryTable (Product, Amount) VALUES ('kastanjer',4);
GO
