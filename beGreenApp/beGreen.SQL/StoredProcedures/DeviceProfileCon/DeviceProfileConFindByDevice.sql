CREATE PROCEDURE [dbo].[DeviceProfileConFindByDevice]
	@DeviceID NVARCHAR(128)

AS
BEGIN
select
[dbo].[DeviceProfileCon].[DeviceID],
[dbo].[DeviceProfileCon].[ProfileID]
from
[dbo].[DeviceProfileCon]
where
[dbo].[DeviceProfileCon].[DeviceID] = @DeviceID
END
