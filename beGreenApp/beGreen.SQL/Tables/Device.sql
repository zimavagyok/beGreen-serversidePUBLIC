CREATE TABLE [dbo].[Device]
(
[Id] NVARCHAR(128) NOT NULL PRIMARY KEY,
[ManufacturerID] INT NOT NULL,
[Model] NVARCHAR(255) NOT NULL,
[Ram] INT NOT NULL,
[ScreenSize] float NOT NULL,
[OperatingSystem] NVARCHAR(255) NOT NULL,
)
