/*-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SelectAllPlayers
	@PlatformId as TINYINT = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	IF @PlatformId is NULL
	BEGIN
		SELECT PlayerId, OnlineName, PlatformId
		FROM Player
	END
	ELSE
	BEGIN
		SELECT PlayerId, OnlineName, PlatformId
		FROM Player
		WHERE PlatformId = @PlatformId
	END
END*/