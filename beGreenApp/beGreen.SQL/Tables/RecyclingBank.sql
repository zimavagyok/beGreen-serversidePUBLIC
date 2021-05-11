CREATE TABLE [dbo].[RecyclingBank]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Plastic] BIT NOT NULL,
	[Paper] BIT NOT NULL,
	[WhiteGlass] BIT NOT NULL,
	[ColouredGlass] BIT NOT NULL,
	[Metal] BIT NOT NULL,
	[Capacity] INT NOT NULL,
	[Position] NVARCHAR(255) NOT NULL,
	[CreateDate] DATETIME NOT NULL,
	[Creator] NVARCHAR(255) NOT NULL
)
