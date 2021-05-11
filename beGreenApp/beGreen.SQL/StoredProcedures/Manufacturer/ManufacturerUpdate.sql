CREATE PROCEDURE [dbo].[ManufacturerUpdate]

--parameterek
@Id int,
@Name nvarchar(255)

AS
BEGIN
update 
[dbo].[Manufacturer]
set
[Name] = @Name
where
[dbo].[Manufacturer].[Id] = @Id

END
