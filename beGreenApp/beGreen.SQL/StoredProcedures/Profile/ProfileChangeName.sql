CREATE PROCEDURE [dbo].[ProfileChangeName]
	@ID NVARCHAR(255),
	@Name NVARCHAR(255)
AS
BEGIN
	update
	[dbo].[Profile]
	set
	[Name]=@Name
	where
	[dbo].[Profile].[ID]=@id

END