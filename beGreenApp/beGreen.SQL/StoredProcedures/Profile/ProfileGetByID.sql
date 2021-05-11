CREATE PROCEDURE [dbo].[ProfileGetByID]
	@id NVARCHAR(255)
AS
BEGIN
	select
	[dbo].[Profile].[ID],
	[dbo].[Profile].[Name],
	[dbo].[Profile].[DOB],
	[dbo].[Profile].[Role],
	[dbo].[Profile].[Email]
	from
	[dbo].[Profile]
		/*inner join
		[dbo].[User]
		on
		[dbo].[Profile].[ID] = [dbo].[User].[PublicID]*/
	where
	[dbo].[Profile].[ID]=@id
END