/*
CREATE PROCEDURE [dbo].[AddNewPlayer]
	@OnlineName varchar(50),
	@PlatformId tinyint
AS
BEGIN
	SET NOCOUNT ON;
	IF NOT EXISTS (SELECT 1 FROM Player WHERE OnlineName = @OnlineName AND PlatformId = @PlatformId)
	BEGIN
		INSERT INTO Player(OnlineName, PlatformId)
		VALUES(@OnlineName, @PlatformId)
	END
	SELECT PlayerId from Player where OnlineName = @OnlineName AND PlatformId = @PlatformId
END*/