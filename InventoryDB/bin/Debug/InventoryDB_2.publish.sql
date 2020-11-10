﻿/*
Deployment script for InventoryDB

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "InventoryDB"
:setvar DefaultFilePrefix "InventoryDB"
:setvar DefaultDataPath "C:\Users\emilg\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB"
:setvar DefaultLogPath "C:\Users\emilg\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
/*
The column [dbo].[InventoryTable].[Product_ID] is being dropped, data loss could occur.
*/

IF EXISTS (select top 1 1 from [dbo].[InventoryTable])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
PRINT N'The following operation was generated from a refactoring log file a6e22fbb-feba-4303-accc-e2cadd973485';

PRINT N'Rename [dbo].[InventoryTable].[Id] to Product_ID';


GO
EXECUTE sp_rename @objname = N'[dbo].[InventoryTable].[Id]', @newname = N'Product_ID', @objtype = N'COLUMN';


GO
PRINT N'The following operation was generated from a refactoring log file 923e191b-fdb8-47a1-9a48-ebab29afbc1d';

PRINT N'Rename [dbo].[InventoryTable].[Name] to Product';


GO
EXECUTE sp_rename @objname = N'[dbo].[InventoryTable].[Name]', @newname = N'Product', @objtype = N'COLUMN';


GO
PRINT N'Starting rebuilding table [dbo].[InventoryTable]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_InventoryTable] (
    [Id]      INT           IDENTITY (1, 1) NOT NULL,
    [Product] NVARCHAR (50) NOT NULL,
    [Amount]  INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[InventoryTable])
    BEGIN
        INSERT INTO [dbo].[tmp_ms_xx_InventoryTable] ([Product], [Amount])
        SELECT [Product],
               [Amount]
        FROM   [dbo].[InventoryTable];
    END

DROP TABLE [dbo].[InventoryTable];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_InventoryTable]', N'InventoryTable';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
-- Refactoring step to update target server with deployed transaction logs

IF OBJECT_ID(N'dbo.__RefactorLog') IS NULL
BEGIN
    CREATE TABLE [dbo].[__RefactorLog] (OperationKey UNIQUEIDENTIFIER NOT NULL PRIMARY KEY)
    EXEC sp_addextendedproperty N'microsoft_database_tools_support', N'refactoring log', N'schema', N'dbo', N'table', N'__RefactorLog'
END
GO
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'a6e22fbb-feba-4303-accc-e2cadd973485')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('a6e22fbb-feba-4303-accc-e2cadd973485')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '923e191b-fdb8-47a1-9a48-ebab29afbc1d')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('923e191b-fdb8-47a1-9a48-ebab29afbc1d')

GO

GO
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

//INSERT INTO InventoryTable (Name, Amount)
//VALUES ("Banan",5);
*/
GO

GO
PRINT N'Update complete.';


GO
