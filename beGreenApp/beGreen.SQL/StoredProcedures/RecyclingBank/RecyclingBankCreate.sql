CREATE PROCEDURE [dbo].[RecyclingBankCreate]
	@plastic BIT,
	@paper BIT,
	@whiteGlass BIT,
	@colouredGlass BIT,
	@metal BIT,
	@capacity INT,
	@position NVARCHAR(255),
	@creator NVARCHAR(255)
AS
BEGIN
	INSERT INTO [dbo].[RecyclingBank]
	(
	[Plastic],[Paper],[WhiteGlass],[ColouredGlass],[Metal],[Capacity],[Position],[CreateDate],[Creator]
	)
	VALUES
	(
	@plastic,@paper,@whiteGlass,@colouredGlass,@metal,@capacity,@position,GetDate(),@creator
	)

	SELECT CONVERT(int,scope_identity())

END