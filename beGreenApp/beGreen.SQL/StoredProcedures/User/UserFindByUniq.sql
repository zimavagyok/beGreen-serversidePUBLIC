CREATE PROCEDURE [dbo].[UserFindByUniq]
	@PublicID NVARCHAR(255)
AS
BEGIN
	select
	[dbo].[User].[Id],
	[dbo].[User].[Email],
	[dbo].[User].[Password],
	[dbo].[User].[PublicID]
	from
	[dbo].[User]
	where
	[dbo].[User].[PublicID]=@PublicID
END