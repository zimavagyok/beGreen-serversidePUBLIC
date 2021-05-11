CREATE PROCEDURE [dbo].[LoginDeviceHistoryFindByID]
	
@PublicID NVARCHAR(255)

AS
BEGIN
SELECT 
[dbo].[loginDeviceHistory].[Id],
[dbo].[loginDeviceHistory].[PublicID],
[dbo].[loginDeviceHistory].[DeviceID],
[dbo].[loginDeviceHistory].[loginDate]
FROM
[dbo].[loginDeviceHistory]
WHERE
[dbo].[loginDeviceHistory].[PublicID] = @PublicID
END