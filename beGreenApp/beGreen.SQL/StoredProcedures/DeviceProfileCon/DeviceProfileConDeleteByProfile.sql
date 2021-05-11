CREATE PROCEDURE [dbo].[DeviceProfileConDeleteByProfile]
	@ProfileID NVARCHAR(255)

AS
BEGIN
delete 
[dbo].[DeviceProfileCon]
where
[dbo].[DeviceProfileCon].[ProfileID] = @ProfileID
END
