CREATE PROCEDURE [dbo].[UserDeactivate]
	@PublicID NVARCHAR(255)
AS
BEGIN
	UPDATE
	[dbo].[User]
	SET
	[dbo].[User].[Deactivated] = 1
	WHERE
	[dbo].[User].[PublicID] = @PublicID
END
