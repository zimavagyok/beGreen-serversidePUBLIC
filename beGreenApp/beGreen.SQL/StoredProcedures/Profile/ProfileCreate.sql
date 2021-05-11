CREATE PROCEDURE [dbo].[ProfileCreate]
	@ID NVARCHAR(255),
	@DOB DATE,
	@Name NVARCHAR(255),
	@role NVARCHAR(255),
	@email NVARCHAR(255)
AS
BEGIN
	INSERT INTO [dbo].[Profile]
	(
	[Name],
	[Role],
	[DOB],
	[ID],
	[Email]
	)
	VALUES
	(
	@Name,
	@role,
	@DOB,
	@ID,
	@email
	)

	SELECT @ID
    SELECT @ID AS Id

END