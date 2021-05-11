CREATE PROCEDURE [dbo].[UserFindEmail]
	@Email NVARCHAR(255)
AS
BEGIN
SELECT
[dbo].[User].[Email]
FROM
[dbo].[User]
WHERE
LOWER([dbo].[User].[Email]) = @Email
END
