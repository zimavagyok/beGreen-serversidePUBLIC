CREATE PROCEDURE [dbo].[RecyclingBankGetAll]

AS
BEGIN
SELECT
[dbo].[RecyclingBank].[Id],
[dbo].[RecyclingBank].[Position],
[dbo].[RecyclingBank].[Plastic],
[dbo].[RecyclingBank].[Paper],
[dbo].[RecyclingBank].[WhiteGlass],
[dbo].[RecyclingBank].[ColouredGlass],
[dbo].[RecyclingBank].[Metal],
[dbo].[RecyclingBank].[Capacity],
[dbo].[RecyclingBank].[CreateDate],
[dbo].[RecyclingBank].[Creator]
FROM
[dbo].[RecyclingBank]
END