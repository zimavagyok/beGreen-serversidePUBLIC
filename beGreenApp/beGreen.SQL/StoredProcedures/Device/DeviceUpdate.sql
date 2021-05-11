CREATE PROCEDURE [dbo].[DeviceUpdate]

--parameterek
@Id NVARCHAR(128),
@ManufacturerID INT,
@Model NVARCHAR(255),
@Ram INT,
@ScreenSize float,
@OperatingSystem nvarchar(255)

AS
BEGIN
update
[dbo].[Device]
set
[ManufacturerID] = @ManufacturerID,
[Model] = @Model,
[Ram] = @Ram,
[ScreenSize] = @ScreenSize,
[OperatingSystem] = @OperatingSystem
where
[dbo].[Device].[Id] = @Id

END
