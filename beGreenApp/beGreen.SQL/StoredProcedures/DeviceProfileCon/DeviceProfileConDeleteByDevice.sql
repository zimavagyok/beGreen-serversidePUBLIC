CREATE PROCEDURE [dbo].[DeviceProfileConDeleteByDevice]
	@DeviceID NVARCHAR(128)

AS
BEGIN
delete 
[dbo].[DeviceProfileCon]
where
[dbo].[DeviceProfileCon].[DeviceID] = @DeviceID
END
