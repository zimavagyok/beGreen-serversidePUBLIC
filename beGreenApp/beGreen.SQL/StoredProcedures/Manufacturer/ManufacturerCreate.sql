CREATE PROCEDURE [dbo].[ManufacturerCreate]

--parameterek
@Name nvarchar(255)

AS
BEGIN
INSERT INTO [dbo].[Manufacturer]
(
[Name]
)
VALUES
(
@Name
)

SELECT CONVERT(int,scope_identity())

END
