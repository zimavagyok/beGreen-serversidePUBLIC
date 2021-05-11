CREATE PROCEDURE [dbo].[DeviceDelete]

--parameterek
@Id NVARCHAR(128)

AS
BEGIN
delete 
[dbo].[Device]
where
[dbo].[Device].[Id] = @Id
END
