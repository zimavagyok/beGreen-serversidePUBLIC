CREATE PROCEDURE [dbo].[ProfileUpdate]
	@id NVARCHAR(255),
	@DOB DATE,
	@Name NVARCHAR(255),
	@role NVARCHAR(255)
AS
BEGIN
	update
	[dbo].[Profile]
	set
	[Name]=@Name,
	[Role]=@role,
	[DOB]=@DOB
	where
	[dbo].[Profile].[ID]=@id

END