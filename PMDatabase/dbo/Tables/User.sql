﻿CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [PasswordHash] NVARCHAR(128) NOT NULL, 
    [Email] NVARCHAR(50) NOT NULL
)
