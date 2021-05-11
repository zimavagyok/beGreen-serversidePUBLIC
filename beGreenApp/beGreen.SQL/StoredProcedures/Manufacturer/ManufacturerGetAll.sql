CREATE PROCEDURE [dbo].[ManufacturerGetAll]

--parameterek
AS
BEGIN
select
[dbo].[Manufacturer].[Id],
[dbo].[Manufacturer].[Name]
from
[dbo].[Manufacturer]
END
