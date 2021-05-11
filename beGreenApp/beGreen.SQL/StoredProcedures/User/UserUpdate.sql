CREATE PROCEDURE [dbo].[UserUpdate]
	@id NVARCHAR(255),
	@password NVARCHAR(255)
AS
BEGIN
	UPDATE
	[dbo].[User]
	set
	[Password]=@password

	where
	[dbo].[User].[PublicID] = @id

END