
CREATE PROCEDURE [dbo].[UpdateScoreAcquireDate]
	@SongShortName INT
AS
BEGIN
DECLARE @SongId INT
SET @SongId = (SELECT SongId FROM Song WHERE ShortName = @SongShortName)
	UPDATE Song set LastUpdatedDate = GETDATE()
	WHERE SongId = @SongId
END