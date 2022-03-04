CREATE TABLE [dbo].[Contractor]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Firm] NVARCHAR(50) NULL, 
    [Name] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NULL, 
    [JMBG] NVARCHAR(50) NULL, 
    [OIB] NCHAR(10) NULL, 
    [Email] NCHAR(10) NULL, 
    [PersonalPhone] NCHAR(10) NULL, 
    [BusinessPhone] NCHAR(10) NULL, 
    [Adress] NCHAR(10) NULL, 
    [City] NCHAR(10) NULL, 
    [PostalCode] NCHAR(10) NULL, 
    [WebSite] NCHAR(10) NULL, 
    [Notes] NCHAR(10) NULL
)
