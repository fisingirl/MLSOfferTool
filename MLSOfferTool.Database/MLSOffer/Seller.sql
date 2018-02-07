CREATE TABLE [MLSOffer].[Seller]
(
	[Id]			INT				NOT NULL	IDENTITY, 
    [FirstName]		NVARCHAR(100)	NULL, 
    [LastName]		NVARCHAR(100)	NULL, 
    [CreatedDate]	DATETIME2		NULL	CONSTRAINT [DF_Seller_CreatedDate] DEFAULT (getdate()),
	[UpdatedDate]	DATETIME2		NULL	CONSTRAINT [DF_Seller_UpdatedDate] DEFAULT (getdate()),
	CONSTRAINT [PK_Seller] PRIMARY KEY ([Id])
)
