CREATE TABLE [dbo].[Contract]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [ProjectId] INT NULL, 
    [ContractTypeId] INT NULL,
    [ContractorId] INT NULL,
    [ContractName] NVARCHAR(50) NULL, 
    [Investor] NVARCHAR(50) NULL, 
    [Client] NVARCHAR(50) NULL,
    [DateOfBeginning] DATETIME2 NULL, 
    [DateOfEnding] DATETIME2 NULL, 
    [ContractNumber] NVARCHAR(50) NULL, 
    [FinancingMethod] NVARCHAR(50) NULL,
    [Notes] NVARCHAR(100) NULL,
    CONSTRAINT [FK_Contract_ToProject] FOREIGN KEY ([ProjectId]) REFERENCES [Project]([Id]), 
    CONSTRAINT [FK_Contract_ToContractType] FOREIGN KEY ([ContractTypeId]) REFERENCES [ContractType]([Id]), 
    CONSTRAINT [FK_Contract_ToContractor] FOREIGN KEY ([ContractorId]) REFERENCES [Contractor]([Id])
)
