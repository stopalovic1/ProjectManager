CREATE TABLE [dbo].[Project]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [UserId] INT NOT NULL,
    [ProjectName] NVARCHAR(50) NULL, 
    [ContractedValue] MONEY NULL, 
    [Status] NVARCHAR(50) NULL, 
    [FundSource] NVARCHAR(50) NULL, 
    [Notes] NVARCHAR(800) NULL
)
