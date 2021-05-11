CREATE PROCEDURE [dbo].[ManufacturerDelete]

--parameterek
@Id int

AS
BEGIN
delete 
[dbo].[Manufacturer]
where
[dbo].[Manufacturer].[Id] = @Id
END
