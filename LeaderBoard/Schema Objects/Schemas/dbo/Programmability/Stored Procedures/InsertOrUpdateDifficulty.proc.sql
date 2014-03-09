/*
CREATE PROCEDURE [dbo].[InsertOrUpdateDifficulty]
	@SongId INT,
	@InstrumentId INT,
	@Difficulty INT
AS
BEGIN
	DECLARE @RecordId INT
	SET NOCOUNT ON;
	
	SET @RecordId = (select Songinstrumentdifficultyid from songinstrumentdifficulty where SongId = @SongId AND InstrumentId = @InstrumentId)
	
	IF @RecordId IS NULL
	BEGIN
		INSERT INTO SongInstrumentDifficulty(SongId, InstrumentId, StarRank)
		VALUES(@SongId, @InstrumentId, @Difficulty)
	END
	ELSE
	BEGIN
		UPDATE SongInstrumentDifficulty
		SET StarRank = @Difficulty where SongInstrumentDifficultyId = @RecordId
	END
	
END*/