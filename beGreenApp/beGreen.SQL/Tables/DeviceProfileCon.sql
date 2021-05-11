CREATE TABLE [dbo].[DeviceProfileCon]
(
	[DeviceID] NVARCHAR(128) NOT NULL,
	[ProfileID] NVARCHAR(255) NOT NULL,
	primary key(DeviceID,ProfileID)
)
