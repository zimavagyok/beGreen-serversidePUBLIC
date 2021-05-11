CREATE PROCEDURE [dbo].[UserDelete]
	@id INT
AS
BEGIN
	delete
	[dbo].[User]
	where
	[dbo].[User].[Id]=@id
END