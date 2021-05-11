CREATE PROCEDURE [dbo].[DeviceProfileConFindByProfile]
	@ProfileID NVARCHAR(255)

AS
BEGIN
select
[dbo].[DeviceProfileCon].[DeviceID],
[dbo].[DeviceProfileCon].[ProfileID]
from
[dbo].[DeviceProfileCon]
where
[dbo].[DeviceProfileCon].[ProfileID] = @ProfileID
END
