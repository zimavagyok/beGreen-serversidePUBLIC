CREATE PROCEDURE [dbo].[LikeCount]
	@RecyclingBankId int
AS
BEGIN
SELECT count(*) as count
FROM [dbo].[Like]
WHERE [dbo].[Like].[RecyclingBankId] = @RecyclingBankId;
END