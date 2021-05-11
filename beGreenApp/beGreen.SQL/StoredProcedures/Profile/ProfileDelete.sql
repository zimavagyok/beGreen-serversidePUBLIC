CREATE PROCEDURE [dbo].[ProfileDelete]
	@id NVARCHAR(255)
AS
BEGIN
	delete
	[dbo].[Profile]
	where
	[dbo].[Profile].[ID] = @id
END