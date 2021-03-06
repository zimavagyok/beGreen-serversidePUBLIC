CREATE PROCEDURE [dbo].[DeviceGetAll]

--parameterek
AS
BEGIN
select
[dbo].[Device].[Id],
[dbo].[Device].[ManufacturerID],
[dbo].[Device].[Model],
[dbo].[Device].[Ram],
[dbo].[Device].[ScreenSize],
[dbo].[Device].[OperatingSystem],
[dbo].[Manufacturer].[Name] as [Manufacturer]
from
[dbo].[Device]
inner join
[dbo].[Manufacturer]
on
[dbo].[Device].[ManufacturerID] = [dbo].[Manufacturer].[Id]
END
