
CREATE PROCEDURE [dbo].[SelectNextTopShortNames] 

AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @ShortNameIds TABLE (Id VARCHAR(50))
	
	INSERT INTO @ShortNameIds
    SELECT TOP 10 ShortName from dbo.Song order by Song.LastUpdatedDate
    
    UPDATE s SET LastUpdatedDate = GETDATE() FROM dbo.Song s WHERE EXISTS (SELECT Id FROM @ShortNameIds where Id = s.ShortName)
    
    SELECT Id from @ShortNameIds
    
END