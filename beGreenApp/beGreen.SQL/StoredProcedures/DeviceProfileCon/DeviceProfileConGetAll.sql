CREATE PROCEDURE [dbo].[DeviceProfileConGetAll]
AS
BEGIN
select
[dbo].[DeviceProfileCon].[DeviceID],
[dbo].[DeviceProfileCon].[ProfileID]
from
[dbo].[DeviceProfileCon]
END
