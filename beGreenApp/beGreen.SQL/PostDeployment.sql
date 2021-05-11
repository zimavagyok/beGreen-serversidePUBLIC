/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

ALTER TABLE 
[dbo].[Device]
ADD CONSTRAINT 
Device__FK_Cascade__Manufacturer
FOREIGN KEY 
(ManufacturerID) 
REFERENCES 
[dbo].[Manufacturer](ID)
ON DELETE CASCADE

ALTER TABLE
[dbo].[DeviceProfileCon]
ADD CONSTRAINT
Device_FK_Cascade_Usage
FOREIGN KEY
(DeviceID)
REFERENCES
[dbo].[Device](Id)
ON DELETE CASCADE

ALTER TABLE
[dbo].[DeviceProfileCon]
ADD CONSTRAINT
Profile_FK_Cascade_Usage
FOREIGN KEY
(ProfileID)
REFERENCES
[dbo].[Profile](ID)
ON DELETE CASCADE