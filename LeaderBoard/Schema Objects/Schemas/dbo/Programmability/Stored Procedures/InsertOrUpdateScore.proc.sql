/*
CREATE PROCEDURE [dbo].[InsertOrUpdateScore] 

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
DECLARE @SongId INT
DECLARE @OldSongDisplayName varchar(50)
	SET NOCOUNT ON;
	
INSERT INTO @UnstagedRecords(Id)
SELECT StageScoreId FROM ScoreStage ss WHERE NOT EXISTS(
	SELECT 1 FROM Score s 
	WHERE s.PlayerId = ss.PlayerId 
	AND s.InstrumentId = ss.InstrumentId
	AND s.Score = ss.Score)

INSERT INTO @ObsoleteScore(Id)
SELECT ScoreId FROM Score s 
INNER JOIN ScoreStage ss on s.PlayerId = ss.PlayerId
	AND s.InstrumentId = ss.InstrumentId
	AND s.Score = ss.Score

INSERT INTO Score(GameId, SongId, InstrumentId, Score, StarScore, Percentage, PlayerId, DifficultyId)
(SELECT GameId, SongId, InstrumentId, Score, StarScore, Percentage, PlayerId, DifficultyId
 FROM ScoreStage ss where EXISTS(SELECT 1 FROM @UnstagedRecords ur WHERE ur.Id = ss.StageScoreId))

UPDATE Score SET ObsoleteScore = 1 WHERE EXISTS(SELECT 1 FROM @ObsoleteScore os where os.Id = ScoreId)

DELETE FROM ScoreStage
END*/