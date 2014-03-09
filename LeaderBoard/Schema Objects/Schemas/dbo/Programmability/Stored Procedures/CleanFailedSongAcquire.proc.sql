CREATE PROCEDURE CleanFailedSongAcquire
AS
BEGIN
	UPDATE s1 SET LastUpdatedDate = '1/1/1900'
	FROM Song s1 
	INNER JOIN Song s2 on s1.LastUpdatedDate = s2.LastUpdatedDate
	AND s1.SongId <> s2.SongId
	AND s1.LastUpdatedDate < DATEADD(hh,-1,GETDATE())
END