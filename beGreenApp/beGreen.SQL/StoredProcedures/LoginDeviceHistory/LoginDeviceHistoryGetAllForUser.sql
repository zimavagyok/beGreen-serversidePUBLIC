CREATE PROCEDURE [dbo].[LoginDeviceHistoryGetAllForUser]
	@PublicID NVARCHAR(255)
AS
BEGIN
select
[dbo].[loginDeviceHistory].[Id],
[dbo].[loginDeviceHistory].[PublicID],
[dbo].[loginDeviceHistory].[DeviceID],
[dbo].[loginDeviceHistory].[loginDate]
FROM
[dbo].[loginDeviceHistory]
WHERE
[dbo].[loginDeviceHistory].[PublicID] = @PublicID
END
