
CREATE PROCEDURE [dbo].[InsertNewScoresBySongShortName] 
@SongShortName VARCHAR(50)
AS
BEGIN
DECLARE @UnstagedRecords Table
(
	Id INT
)

DECLARE @ObsoleteScore Table
(
	Id INT
)
DECLARE @OldSongDisplayName varchar(50)
	SET NOCOUNT ON;
	
INSERT INTO Player(OnlineName, PlatformId)
SELECT PlayerName, PlatformId FROM ScoreStage ss
WHERE NOT EXISTS (SELECT 1 FROM Player p WHERE p.OnlineName = ss.PlayerName AND p.PlatformId = ss.PlatformId)
	
INSERT INTO @UnstagedRecords(Id)
SELECT ScoreStageId FROM ScoreStage ss 
INNER JOIN Player p on ss.PlayerName = p.OnlineName
AND ss.PlatformId = p.PlatformId
WHERE ss.SongShortName = @SongShortName
AND NOT EXISTS(
	SELECT 1 FROM Score sc
	inner join Song s on sc.SongId = sc.SongId
	WHERE sc.PlayerId = p.PlayerId 
	AND sc.InstrumentId = ss.InstrumentId
	AND sc.Score = ss.Score
	and s.ShortName = ss.SongShortName)
	

INSERT INTO Score(GameId, SongId, InstrumentId, Score, StarScore, Percentage, PlayerId, DifficultyId, ScoreAddedDate)
(SELECT GameId, s.SongId, InstrumentId, Score, StarScore, Percentage, p.PlayerId, DifficultyId, GETDATE()
 FROM ScoreStage ss inner join @UnstagedRecords ur on ss.ScoreStageId = ur.Id
 INNER JOIN Player p on ss.PlayerName = p.OnlineName AND ss.PlatformId = p.PlatformId
 INNER JOIN Song s on s.ShortName = ss.SongShortName)

UPDATE s1 set ObsoleteScore = 1, Ranking = NULL
FROM Score s1 
INNER JOIN Score s2 on s1.PlayerId = s2.PlayerId 
inner join Song so on s1.SongId = so.SongId
AND s1.Score < s2.Score
AND s1.InstrumentId = s2.InstrumentId
AND s1.SongId = s2.SongId
AND s1.ObsoleteScore <> 1
and so.ShortName = @SongShortName

DELETE FROM ScoreStage WHERE SongShortName = @SongShortName

EXEC dbo.UpdateRankings @SongShortName
END