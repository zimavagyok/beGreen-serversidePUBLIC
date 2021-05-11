CREATE PROCEDURE [dbo].[UserDeleteByUniq]
	@PublicID NVARCHAR(255)
AS
BEGIN
	delete
	[dbo].[User]
	where
	[dbo].[User].[PublicID]=@PublicID
END
