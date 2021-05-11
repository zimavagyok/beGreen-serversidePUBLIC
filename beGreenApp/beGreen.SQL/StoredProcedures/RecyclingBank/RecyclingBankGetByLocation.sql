CREATE PROCEDURE [dbo].[RecyclingBankGetByLocation]
		@Location NVARCHAR(255)

AS
BEGIN
select
[dbo].[RecyclingBank].[Id]
from
[dbo].[RecyclingBank]
where
[dbo].[RecyclingBank].[Position] = @Location
END

