CREATE PROCEDURE [dbo].[LikeGetByBoth]
	@RecyclingBankId INT,
	@ProfileId NVARCHAR(255)

AS
BEGIN
select
[dbo].[Like].[Id],
[dbo].[Like].[RecyclingBankId],
[dbo].[Like].[ProfileId]
from
[dbo].[Like]
where
[dbo].[Like].[RecyclingBankId] = @RecyclingBankId AND [dbo].[Like].[ProfileId] = @ProfileId
END

