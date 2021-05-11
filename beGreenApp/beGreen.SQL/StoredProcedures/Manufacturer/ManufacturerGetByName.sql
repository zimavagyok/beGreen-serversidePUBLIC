CREATE PROCEDURE [dbo].[ManufacturerGetByName]

--parameterek
@Name NVARCHAR(255)

AS
BEGIN
select
[dbo].[Manufacturer].[Id],
[dbo].[Manufacturer].[Name]
from
[dbo].[Manufacturer]
where
[dbo].[Manufacturer].[Name] = @Name
END
