CREATE PROCEDURE [dbo].[LoginDeviceHistoryDelete]

@PublicID NVARCHAR(255)

AS
BEGIN
delete 
[dbo].[loginDeviceHistory]
where
[dbo].[loginDeviceHistory].[PublicID] = @PublicID
END
