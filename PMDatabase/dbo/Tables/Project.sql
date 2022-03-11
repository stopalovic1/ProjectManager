CREATE TABLE [dbo].[Project]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [UserId] INT NOT NULL,
    [Owner] nvarchar(50) NULL,
    [ProjectName] NVARCHAR(50) NULL, 
    [ContractedValue] MONEY NULL, 
    [GrossValue] MONEY NULL,
    [Status] NVARCHAR(50) NULL, 
    [FundSource] NVARCHAR(50) NULL, 
    [Notes] NVARCHAR(800) NULL, 
    CONSTRAINT [FK_Project_ToUser] FOREIGN KEY ([UserId]) REFERENCES [User]([Id])
)
