CREATE PROCEDURE [dbo].[UserFindByCredencials]
		@Email NVARCHAR(255),
		@Password NVARCHAR(255)
AS
BEGIN
	select
	[dbo].[User].[Id],
	[dbo].[User].[Email],
	[dbo].[User].[Password],
	[dbo].[User].[PublicID],
	[dbo].[User].[Role]
	from
	[dbo].[User]
	where
	[dbo].[User].[Email] = @Email AND [dbo].[User].[Password] = @Password
END
