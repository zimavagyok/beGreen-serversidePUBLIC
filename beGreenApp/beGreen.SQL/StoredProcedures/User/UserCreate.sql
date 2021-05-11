CREATE PROCEDURE [dbo].[UserCreate]
	@email NVARCHAR(255),
	@password NVARCHAR(255),
	@PublicID NVARCHAR(255),
	@Role NVARCHAR(16)
AS
BEGIN
	INSERT INTO [dbo].[User]
	(
	[Password],[PublicID],[Email],[Deactivated],[RegistrationDate],[Role]
	)
	VALUES
	(
	@password, @PublicID,@email,0,GetDate(),@Role
	)

	SELECT CONVERT(int,scope_identity())

END
