/*-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SelectSongIdByShortName
	-- Add the parameters for the stored procedure here
	@ShortName varchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT SongId
	FROM Song WHERE ShortName = @ShortName
    
END*/