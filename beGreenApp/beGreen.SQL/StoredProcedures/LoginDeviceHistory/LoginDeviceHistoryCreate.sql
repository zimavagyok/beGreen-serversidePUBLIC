CREATE PROCEDURE [dbo].[LoginDeviceHistoryCreate]
	@PublicID NVARCHAR(255),
	@DeviceID NVARCHAR(128)

AS
BEGIN 
INSERT INTO [dbo].[loginDeviceHistory]
(
[PublicID],[DeviceID],[loginDate]
)
VALUES
(
@PublicID,@DeviceID,GETDATE()
)
END
