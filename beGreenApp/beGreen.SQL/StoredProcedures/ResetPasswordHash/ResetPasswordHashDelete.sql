CREATE PROCEDURE [dbo].[ResetPasswordHashDelete]
	@PublicID NVARCHAR(255)
AS
BEGIN
DELETE FROM 
[dbo].[ResetPasswordHash]
WHERE
[dbo].[ResetPasswordHash].[PublicID] = @PublicID
END
