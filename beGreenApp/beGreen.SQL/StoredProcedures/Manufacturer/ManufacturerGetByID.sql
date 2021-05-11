CREATE PROCEDURE [dbo].[ManufacturerGetByID]

--parameterek
@Id int

AS
BEGIN
select
[dbo].[Manufacturer].[Id],
[dbo].[Manufacturer].[Name]
from
[dbo].[Manufacturer]
where
[dbo].[Manufacturer].[Id] = @Id
END
