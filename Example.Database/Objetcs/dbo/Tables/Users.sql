﻿CREATE TABLE [dbo].[Users]
(
	[Id]		UNIQUEIDENTIFIER	NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[FirstName] NVARCHAR(256)		NOT NULL,
	[LastName]	NVARCHAR(256)		NOT NULL
)
