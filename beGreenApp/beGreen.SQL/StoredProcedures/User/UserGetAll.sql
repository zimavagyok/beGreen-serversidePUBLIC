CREATE PROCEDURE [dbo].[UserGetAll]

AS
BEGIN
	select
	[dbo].[User].[Id],
	[dbo].[User].[Email],
	[dbo].[User].[Password],
	[dbo].[User].[PublicID]
	from
	[dbo].[User]
END