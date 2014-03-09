
CREATE PROCEDURE [dbo].[InsertSongDifficulty]
	@SongId INT,
	@InstrumentId INT,
	@Difficulty INT
AS
BEGIN
	SET NOCOUNT ON;
	
	INSERT INTO SongInstrumentDifficulty(SongId, InstrumentId, StarRank)
	VALUES(@SongId, @InstrumentId, @Difficulty)
	
END