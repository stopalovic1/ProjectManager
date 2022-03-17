CREATE TABLE [dbo].[Contractor]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [FirmName] NVARCHAR(50) NULL, 
    [OwnerName] NVARCHAR(50) NULL, 
    [OwnerLastName] NVARCHAR(50) NULL, 
    [JMBG] NVARCHAR(50) NULL, 
    [OIB] NVARCHAR(50) NULL, 
    [Email] NVARCHAR(50) NULL, 
    [Fax] NVARCHAR(50) NULL,
    [Address] NVARCHAR(50) NULL,
    [PersonalPhone] NVARCHAR(50) NULL, 
    [BusinessPhone] NVARCHAR(50) NULL, 
    [City] NVARCHAR(50) NULL, 
    [PostalCode] NVARCHAR(50) NULL, 
    [WebSite] NVARCHAR(50) NULL, 
    [Notes] NVARCHAR(50) NULL
)
