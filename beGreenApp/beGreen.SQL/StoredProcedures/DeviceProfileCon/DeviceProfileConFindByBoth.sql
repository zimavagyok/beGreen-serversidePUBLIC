CREATE PROCEDURE [dbo].[DeviceProfileConFindByBoth]
	@DeviceID NVARCHAR(128),
	@ProfileID NVARCHAR(255)

AS
BEGIN
select
[dbo].[DeviceProfileCon].[DeviceID],
[dbo].[DeviceProfileCon].[ProfileID]
from
[dbo].[DeviceProfileCon]
where
[dbo].[DeviceProfileCon].[DeviceID] = @DeviceID AND [dbo].[DeviceProfileCon].[ProfileID] = @ProfileID
END

