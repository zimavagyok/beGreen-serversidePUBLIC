CREATE PROCEDURE [dbo].[LikeCreate]
	@RecyclingBankId int,
	@ProfileId NVARCHAR(255)
AS
BEGIN
INSERT INTO [dbo].[Like]
(
[RecyclingBankId],[ProfileId]
)
VALUES
(
@RecyclingBankId,@ProfileId
)

SELECT CONVERT(int,scope_identity())

END
