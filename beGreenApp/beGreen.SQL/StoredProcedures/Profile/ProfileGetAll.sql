CREATE PROCEDURE [dbo].[ProfileGetAll]

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
END
