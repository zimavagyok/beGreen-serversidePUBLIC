CREATE PROCEDURE [dbo].[LikeDelete]
	@RecyclingBankId INT
AS
BEGIN
delete 
[dbo].[Like]
where
[dbo].[Like].[RecyclingBankId] = @RecyclingBankId
END
