CREATE PROCEDURE [dbo].[UserGetByID]
	@id NVARCHAR(255)
AS
BEGIN
	select
	[dbo].[User].[Email],
	[dbo].[User].[Password],
	[dbo].[User].[PublicID]
	from
	[dbo].[User]
	where
	[dbo].[User].[PublicID]=@id
END