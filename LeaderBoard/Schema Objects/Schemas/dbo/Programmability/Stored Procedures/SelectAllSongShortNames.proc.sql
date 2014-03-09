/*
CREATE PROCEDURE [dbo].[SelectAllSongShortNames] 

AS
BEGIN
	SET NOCOUNT ON;
	
    SELECT ShortName from dbo.Song order by Song.LastUpdatedDate
    
END*/