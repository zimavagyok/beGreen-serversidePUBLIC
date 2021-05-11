CREATE PROCEDURE [dbo].[LikeDeleteByBoth]
	@RecyclingBankId INT,
	@ProfileId NVARCHAR(255)
AS
BEGIN
delete 
[dbo].[Like]
where
[dbo].[Like].[RecyclingBankId] = @RecyclingBankId AND [dbo].[Like].[ProfileId] = @ProfileId
END
