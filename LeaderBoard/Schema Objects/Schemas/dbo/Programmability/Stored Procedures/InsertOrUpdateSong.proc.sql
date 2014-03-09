/*
CREATE PROCEDURE [dbo].[InsertOrUpdateSong]

AS
BEGIN
DECLARE @NewSongs TABLE
(
	Id INT
)

INSERT INTO @NewSongs(Id)
SELECT SongStageId from SongStage ss WHERE NOT EXISTS(
	SELECT 1 FROM Song s where s.ShortName = ss.ShortName)

INSERT INTO Song(HmxSongId, ShortName, Artist, ArtistTr, Name, NameTr, Genre, Source, Rating, VocalParts, YearReleased, Decade, StartsWith, Cover, SongDisplayName, LastUpdatedDate)
SELECT HmxSongId, ShortName, Artist, ArtistTr, Name, NameTr, Genre, Source, Rating, VocalParts, YearReleased, Decade, StartsWith, Cover, SongDisplayName, LastUpdatedDate
FROM SongStage ss WHERE EXISTS(
	SELECT 1 FROM @NewSongs ns WHERE ns.Id = ss.SongStageId)

UPDATE ss SET ss.SongId = s.SongId
FROM SongStage ss
INNER JOIN Song s on s.ShortName = ss.ShortName

DECLARE @SongId INT, @GuitarDifficulty INT, @BassDifficulty INT, @DrumsDifficulty INT
DECLARE @VocalDifficulty INT, @KeysDifficulty INT, @ProGuitarDifficulty INT, @ProBassDifficulty INT
DECLARE @ProDrumsDifficulty INT, @ProKeysDifficulty INT, @BandDifficulty INT
DECLARE row_loop CURSOR FAST_FORWARD FOR
	SELECT SongId, 
		   GuitarDifficulty, 
		   BassDifficulty, 
		   DrumsDifficulty, 
		   VocalDifficulty, 
		   KeysDifficulty, 
		   ProGuitarDifficulty, 
		   ProBassDifficulty, 
		   ProDrumsDifficulty, 
		   ProKeysDifficulty,
		   BandDifficulty FROM SongStage ss WHERE EXISTS(
	SELECT 1 FROM @NewSongs ns WHERE ns.Id = ss.SongStageId)
OPEN row_loop
FETCH NEXT FROM row_loop INTO @SongId, @GuitarDifficulty, @BassDifficulty, @DrumsDifficulty, @VocalDifficulty, @KeysDifficulty, 
							  @ProGuitarDifficulty, @ProBassDifficulty, @ProDrumsDifficulty, @ProKeysDifficulty, @BandDifficulty
WHILE @@fetch_status = 0
BEGIN
	EXEC dbo.InsertOrUpdateDifficulty @SongId, 1, @GuitarDifficulty
	EXEC dbo.InsertOrUpdateDifficulty @SongId, 2, @BassDifficulty
	EXEC dbo.InsertOrUpdateDifficulty @SongId, 3, @DrumsDifficulty
	EXEC dbo.InsertOrUpdateDifficulty @SongId, 4, @VocalDifficulty
	EXEC dbo.InsertOrUpdateDifficulty @SongId, 5, @KeysDifficulty
	EXEC dbo.InsertOrUpdateDifficulty @SongId, 6, @ProGuitarDifficulty
	EXEC dbo.InsertOrUpdateDifficulty @SongId, 7, @ProBassDifficulty
	EXEC dbo.InsertOrUpdateDifficulty @SongId, 8, @ProDrumsDifficulty
	EXEC dbo.InsertOrUpdateDifficulty @SongId, 9, @ProKeysDifficulty
	EXEC dbo.InsertOrUpdateDifficulty @SongId, 11, @BandDifficulty
END
CLOSE row_loop
DEALLOCATE row_loop

DELETE FROM SongStage
END*/