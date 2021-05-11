CREATE PROCEDURE [dbo].[DeviceCreate]

--parameterek
@Id NVARCHAR(128),
@ManufacturerID INT,
@Model NVARCHAR(255),
@Ram INT,
@ScreenSize float,
@OperatingSystem nvarchar(255)

AS
BEGIN
INSERT INTO [dbo].[Device]
(
[Id],
[ManufacturerID],
[Model],
[Ram],
[ScreenSize],
[OperatingSystem]
)
VALUES
(
@Id,
@ManufacturerID,
@Model,
@Ram,
@ScreenSize,
@OperatingSystem
)

END
