CREATE PROCEDURE [dbo].[ProfileFindUsername]
	@Username NVARCHAR(255)
AS
BEGIN
SELECT
[dbo].[Profile].[Name]
FROM
[dbo].[Profile]
WHERE
LOWER([dbo].[Profile].[Name]) = @Username
END

