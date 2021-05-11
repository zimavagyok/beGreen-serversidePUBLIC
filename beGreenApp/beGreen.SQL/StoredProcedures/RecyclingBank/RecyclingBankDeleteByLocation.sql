CREATE PROCEDURE [dbo].[RecyclingBankDeleteByLocation]
	@Location NVARCHAR(255)

AS
BEGIN
delete 
[dbo].[RecyclingBank]
where
[dbo].[RecyclingBank].[Position] = @Location
END
