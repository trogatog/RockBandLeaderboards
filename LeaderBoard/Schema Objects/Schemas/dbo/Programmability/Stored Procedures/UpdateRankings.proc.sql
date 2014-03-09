
CREATE PROCEDURE [dbo].[UpdateRankings]
@SongShortName VARCHAR(50)
AS
BEGIN
DECLARE @SongId INT
SET @SongId = (SELECT SongId FROM Song WHERE ShortName = @SongShortName)

UPDATE Score Set Ranking = RankCalc.Ranking
FROM Score sc1 inner join
	(SELECT	sc.ScoreId,
			RANK() OVER(PARTITION BY s.SongId, p.PlatformId, i.InstrumentId ORDER BY Score Desc) as Ranking
	FROM Score sc
	INNER JOIN Song s on sc.SongId = s.SongId
	INNER JOIN Instrument i on sc.InstrumentId = i.InstrumentId
	INNER JOIN Player p on sc.PlayerId = p.PlayerId
	INNER JOIN [Platform] pl on p.PlatformId = pl.PlatformId
	WHERE ObsoleteScore = 0 and sc.SongId = @SongId) as RankCalc
on sc1.ScoreId = RankCalc.ScoreId
END