/*
Post-Deployment Script - Seed User Data							
--------------------------------------------------------------------------------------
 This script seeds test data for the Users table				
--------------------------------------------------------------------------------------
*/
BEGIN TRY
    BEGIN TRANSACTION 
        PRINT N'Begin seeding users.';
        INSERT INTO [dbo].[Users] ([Id], [FirstName], [LastName]) VALUES (N'11A5840D-E3AE-4AD2-BB32-D5D14B742AB2', N'John', N'Smith')
        INSERT INTO [dbo].[Users] ([Id], [FirstName], [LastName]) VALUES (N'299EBD75-2F9E-43D2-9D20-D096E9B4E98C', N'Jane', N'Green')
        PRINT N'Finished seeding users.';
    COMMIT
END TRY
BEGIN CATCH

    IF @@TRANCOUNT > 0
        PRINT N'Error seeding users.';
        ROLLBACK
END CATCH