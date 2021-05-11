CREATE PROCEDURE [dbo].[LoginDeviceHistoryGetAll]
	
AS
BEGIN
select
[dbo].[loginDeviceHistory].[Id],
[dbo].[loginDeviceHistory].[PublicID],
[dbo].[loginDeviceHistory].[DeviceID],
[dbo].[loginDeviceHistory].[loginDate]
FROM
[dbo].[loginDeviceHistory]
END
