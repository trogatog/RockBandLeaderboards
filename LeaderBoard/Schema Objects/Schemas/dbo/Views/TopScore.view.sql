

CREATE VIEW [dbo].[TopScore]
AS
SELECT p.PlayerId ,p.OnlineName, sc.Score, i.InstrumentId, s.SongId, s.SongDisplayName, pl.PlatformId, pl.ConsoleName,
    (select COUNT(*) + 1 from Score sc1 
			 inner join Player p1 on sc1.PlayerId = p1.PlayerId
			 where sc1.SongId = s.songId 
			 and sc1.score > sc.Score 
			 and sc1.InstrumentId = sc.InstrumentId) AS 'Ranking'
FROM Score sc
inner join Player p on sc.PlayerId = p.PlayerId
inner join Instrument i on sc.InstrumentId = i.InstrumentId
inner join Song s on sc.SongId = s.SongId
inner join Platform pl on p.PlatformId = pl.PlatformId