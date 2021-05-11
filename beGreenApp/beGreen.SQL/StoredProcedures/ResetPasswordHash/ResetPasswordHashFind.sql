CREATE PROCEDURE [dbo].[ResetPasswordHashFind]
	@Hash NVARCHAR(255)
AS
BEGIN
SELECT
[dbo].[ResetPasswordHash].[PublicID],
[dbo].[ResetPasswordHash].[Hash],
[dbo].[ResetPasswordHash].[Date]
FROM
[dbo].[ResetPasswordHash]
WHERE
[dbo].[ResetPasswordHash].[Hash] = @Hash
END