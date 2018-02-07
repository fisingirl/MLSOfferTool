CREATE TABLE [MLSOffer].[Offer]
(
	[Id]					INT			NOT NULL	IDENTITY, 
    [PropertyId]			INT			NOT NULL, 
    [OfferPrice]			MONEY		NOT NULL, 
    [CounterOfferPrice]		MONEY		NULL, 
	[AcceptedPrice]			MONEY		NULL,
    [OfferStatusId]			INT			NOT NULL,
    [CreatedDate]			DATETIME2	NOT NULL	CONSTRAINT [DF_Offer_CreateDate] DEFAULT (getdate()),
    [UpdatedDate]			DATETIME2	NOT NULL	CONSTRAINT [DF_SOffer_UpdatedDate] DEFAULT (getdate()),
    CONSTRAINT [PK_Offer] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Offer_PropertyId] FOREIGN KEY ([PropertyId]) REFERENCES [MLSOffer].[Property] ([Id]),
	CONSTRAINT [FK_Offer_OfferStatusId] FOREIGN KEY ([OfferStatusId]) REFERENCES [MLSOffer].[OfferStatus] ([Id]),
)
