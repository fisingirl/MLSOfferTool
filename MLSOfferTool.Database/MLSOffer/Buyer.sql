CREATE TABLE [MLSOffer].[Buyer]
(
	[Id]			INT				NOT NULL	IDENTITY, 
    [FirstName]		NVARCHAR(100)	NULL, 
    [LastName]		NVARCHAR(100)	NULL, 
    [CreatedDate]	DATETIME2		NULL	CONSTRAINT [DF_Buyer_CreatedDate] DEFAULT (getdate()),
	[UpdatedDate]	DATETIME2		NULL	CONSTRAINT [DF_Buyer_UpdatedDate] DEFAULT (getdate()),
	CONSTRAINT [PK_Buyer] PRIMARY KEY ([Id])
)
