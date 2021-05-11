CREATE PROCEDURE [dbo].[ResetPasswordHashCreate]
	@PublicID NVARCHAR(255),
	@Hash NVARCHAR(1024),
	@Date DateTime
AS
BEGIN
INSERT INTO [dbo].[ResetPasswordHash]
(
[PublicID],[Hash],[Date]
)
VALUES
(
@PublicID,@Hash,@Date
)
END
