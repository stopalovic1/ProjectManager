CREATE TABLE [dbo].[Contract]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [ProjectId] INT NULL, 
    [ContractTypeId] INT NULL,
    [Name] NVARCHAR(50) NULL, 
    [DateOfBegining] DATETIME2 NULL, 
    [DateOfEnding] DATETIME2 NULL, 
    [ContractNumber] NVARCHAR(50) NULL, 
    [Investor] NVARCHAR(50) NULL, 
    CONSTRAINT [FK_Contract_ToProject] FOREIGN KEY ([ProjectId]) REFERENCES [Project]([Id]), 
    CONSTRAINT [FK_Contract_ToContractType] FOREIGN KEY ([ContractTypeId]) REFERENCES [ContractType]([Id])
)
