CREATE PROCEDURE [dbo].[DeviceProfileConCreate]
	@DeviceID NVARCHAR(128),
	@ProfileID NVARCHAR(255)
AS
BEGIN
INSERT INTO [dbo].[DeviceProfileCon]
(
[DeviceID],
[ProfileID]
)
VALUES
(
@DeviceID,
@ProfileID
)
END