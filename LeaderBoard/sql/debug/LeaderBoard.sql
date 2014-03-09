/*
Deployment script for LeaderBoard
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, NUMERIC_ROUNDABORT, QUOTED_IDENTIFIER OFF;


GO
:setvar DatabaseName "LeaderBoard"
:setvar DefaultDataPath ""
:setvar DefaultLogPath ""

GO
USE [master]

GO
:on error exit
GO
IF (DB_ID(N'$(DatabaseName)') IS NOT NULL
    AND DATABASEPROPERTYEX(N'$(DatabaseName)','Status') <> N'ONLINE')
BEGIN
    RAISERROR(N'The state of the target database, %s, is not set to ONLINE. To deploy to this database, its state must be set to ONLINE.', 16, 127,N'$(DatabaseName)') WITH NOWAIT
    RETURN
END

GO
IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'Creating $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)]
    ON 
    PRIMARY(NAME = [LeaderBoard], FILENAME = 'D:\Data\LeaderBoard.mdf', SIZE = 2048 KB, FILEGROWTH = 1024 KB)
    LOG ON (NAME = [LeaderBoard_log], FILENAME = 'D:\Log\LeaderBoard_log.ldf', SIZE = 1024 KB, MAXSIZE = 2097152 MB, FILEGROWTH = 10 %) COLLATE SQL_Latin1_General_CP1_CI_AS
GO
EXECUTE sp_dbcmptlevel [$(DatabaseName)], 100;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS OFF,
                ANSI_PADDING OFF,
                ANSI_WARNINGS OFF,
                ARITHABORT OFF,
                CONCAT_NULL_YIELDS_NULL OFF,
                NUMERIC_ROUNDABORT OFF,
                QUOTED_IDENTIFIER OFF,
                ANSI_NULL_DEFAULT OFF,
                CURSOR_DEFAULT GLOBAL,
                RECOVERY FULL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_UPDATE_STATISTICS_ASYNC OFF,
                PAGE_VERIFY CHECKSUM,
                DATE_CORRELATION_OPTIMIZATION OFF,
                DISABLE_BROKER,
                PARAMETERIZATION SIMPLE,
                SUPPLEMENTAL_LOGGING OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET TRUSTWORTHY OFF,
        DB_CHAINING OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET HONOR_BROKER_PRIORITY OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
USE [$(DatabaseName)]

GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


GO
/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

GO
PRINT N'Creating [dbo].[Difficulty]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
CREATE TABLE [dbo].[Difficulty] (
    [DifficultyId]     TINYINT      IDENTITY (1, 1) NOT NULL,
    [Description]      VARCHAR (50) NOT NULL,
    [SmallDescription] CHAR (1)     NOT NULL
);


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating PK_Difficulty...';


GO
ALTER TABLE [dbo].[Difficulty]
    ADD CONSTRAINT [PK_Difficulty] PRIMARY KEY CLUSTERED ([DifficultyId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Game]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
CREATE TABLE [dbo].[Game] (
    [GameId]    INT          IDENTITY (1, 1) NOT NULL,
    [GameName]  VARCHAR (50) NOT NULL,
    [ShortName] VARCHAR (5)  NOT NULL
);


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating PK_Game...';


GO
ALTER TABLE [dbo].[Game]
    ADD CONSTRAINT [PK_Game] PRIMARY KEY CLUSTERED ([GameId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Instrument]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
CREATE TABLE [dbo].[Instrument] (
    [InstrumentId] TINYINT      IDENTITY (1, 1) NOT NULL,
    [Description]  VARCHAR (10) NOT NULL
);


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating PK_Instrument...';


GO
ALTER TABLE [dbo].[Instrument]
    ADD CONSTRAINT [PK_Instrument] PRIMARY KEY CLUSTERED ([InstrumentId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Platform]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
CREATE TABLE [dbo].[Platform] (
    [PlatformId]  TINYINT      IDENTITY (1, 1) NOT NULL,
    [ConsoleName] VARCHAR (50) NOT NULL,
    [ShortName]   VARCHAR (5)  NOT NULL
);


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating PK_Platform...';


GO
ALTER TABLE [dbo].[Platform]
    ADD CONSTRAINT [PK_Platform] PRIMARY KEY CLUSTERED ([PlatformId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Player]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
CREATE TABLE [dbo].[Player] (
    [PlayerId]   INT          IDENTITY (1, 1) NOT NULL,
    [OnlineName] VARCHAR (50) NOT NULL,
    [PlatformId] TINYINT      NOT NULL
);


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating PK_Player...';


GO
ALTER TABLE [dbo].[Player]
    ADD CONSTRAINT [PK_Player] PRIMARY KEY CLUSTERED ([PlayerId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Score]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
CREATE TABLE [dbo].[Score] (
    [ScoreId]      INT     IDENTITY (1, 1) NOT NULL,
    [SongId]       INT     NOT NULL,
    [InstrumentId] TINYINT NOT NULL,
    [Score]        INT     NOT NULL,
    [StarScore]    TINYINT NULL,
    [Percentage]   TINYINT NOT NULL,
    [PlayerId]     INT     NOT NULL,
    [DifficultyId] TINYINT NOT NULL
);


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating PK_Score...';


GO
ALTER TABLE [dbo].[Score]
    ADD CONSTRAINT [PK_Score] PRIMARY KEY CLUSTERED ([ScoreId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Song]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
CREATE TABLE [dbo].[Song] (
    [SongId]          INT           IDENTITY (1, 1) NOT NULL,
    [HmxSongId]       INT           NULL,
    [ShortName]       VARCHAR (50)  NOT NULL,
    [Artist]          VARCHAR (50)  NULL,
    [ArtistTr]        VARCHAR (50)  NULL,
    [Name]            VARCHAR (50)  NULL,
    [NameTr]          VARCHAR (50)  NULL,
    [Genre]           VARCHAR (50)  NULL,
    [Source]          VARCHAR (15)  NULL,
    [Rating]          TINYINT       NULL,
    [VocalParts]      TINYINT       NULL,
    [YearReleased]    INT           NULL,
    [Decade]          VARCHAR (6)   NULL,
    [StartsWith]      CHAR (1)      NULL,
    [Cover]           VARCHAR (50)  NULL,
    [SongDisplayName] VARCHAR (100) NOT NULL
);


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating PK_Song...';


GO
ALTER TABLE [dbo].[Song]
    ADD CONSTRAINT [PK_Song] PRIMARY KEY CLUSTERED ([SongId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[SongInstrumentDifficulty]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
CREATE TABLE [dbo].[SongInstrumentDifficulty] (
    [SongInstrumentDifficultyId] INT NOT NULL,
    [SongId]                     INT NOT NULL,
    [InstrumentId]               INT NOT NULL,
    [DifficultyId]               INT NOT NULL
);


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating PK_SongInstrumentDifficulty...';


GO
ALTER TABLE [dbo].[SongInstrumentDifficulty]
    ADD CONSTRAINT [PK_SongInstrumentDifficulty] PRIMARY KEY CLUSTERED ([SongInstrumentDifficultyId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating FK_Player_Platform...';


GO
ALTER TABLE [dbo].[Player] WITH NOCHECK
    ADD CONSTRAINT [FK_Player_Platform] FOREIGN KEY ([PlatformId]) REFERENCES [dbo].[Platform] ([PlatformId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Score_Difficulty...';


GO
ALTER TABLE [dbo].[Score] WITH NOCHECK
    ADD CONSTRAINT [FK_Score_Difficulty] FOREIGN KEY ([DifficultyId]) REFERENCES [dbo].[Difficulty] ([DifficultyId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Score_Instrument...';


GO
ALTER TABLE [dbo].[Score] WITH NOCHECK
    ADD CONSTRAINT [FK_Score_Instrument] FOREIGN KEY ([InstrumentId]) REFERENCES [dbo].[Instrument] ([InstrumentId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Score_Player...';


GO
ALTER TABLE [dbo].[Score] WITH NOCHECK
    ADD CONSTRAINT [FK_Score_Player] FOREIGN KEY ([PlayerId]) REFERENCES [dbo].[Player] ([PlayerId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Score_Song...';


GO
ALTER TABLE [dbo].[Score] WITH NOCHECK
    ADD CONSTRAINT [FK_Score_Song] FOREIGN KEY ([SongId]) REFERENCES [dbo].[Song] ([SongId]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating CK_Score_StarScoreBetween0and6...';


GO
ALTER TABLE [dbo].[Score] WITH NOCHECK
    ADD CONSTRAINT [CK_Score_StarScoreBetween0and6] CHECK ([StarScore]>(0) AND [StarScore]<=(6) OR [StarScore] IS NULL);


GO
PRINT N'Creating [dbo].[AddNewPlayer]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO

CREATE PROCEDURE [dbo].[AddNewPlayer]
	@OnlineName varchar(50),
	@PlatformId tinyint
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO Player(OnlineName, PlatformId)
	VALUES(@OnlineName, @PlatformId)
	
	SELECT PlayerId from Player where OnlineName = @OnlineName AND PlatformId = @PlatformId
END
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[InsertOrUpdateScore]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO

CREATE PROCEDURE InsertOrUpdateScore 
	-- Add the parameters for the stored procedure here
	@SongId INT,
	@InstrumentId TINYINT,
	@Score INT,
	@PlayerId INT,
	@DifficultyId TINYINT,
	@Percentage TINYINT
AS
BEGIN
	SET NOCOUNT ON;
	IF EXISTS(
		SELECT 1 FROM Score 
		WHERE SongId = @SongId
		AND PlayerId = @PlayerId
		AND InstrumentId = @InstrumentId
		AND DifficultyId = @DifficultyId)
	BEGIN
		UPDATE Score
		SET Score = @Score
		WHERE SongId = @SongId
		AND PlayerId = @PlayerId
		AND InstrumentId = @InstrumentId
		AND DifficultyId = @DifficultyId
	END
	ELSE
	BEGIN
		INSERT INTO Score (SongId, InstrumentId, Score, StarScore, Percentage, PlayerId, DifficultyId)
		VALUES (@SongId, @InstrumentId, @Score, NULL, @Percentage, @PlayerId, @DifficultyId)
	END
    
END
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[SelectAllPlayers]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SelectAllPlayers
	@PlatformId as TINYINT = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	IF @PlatformId is NULL
	BEGIN
		SELECT PlayerId, OnlineName, PlatformId
		FROM Player
	END
	ELSE
	BEGIN
		SELECT PlayerId, OnlineName, PlatformId
		FROM Player
		WHERE PlatformId = @PlatformId
	END
END
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[SelectAllSongShortNames]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO

CREATE PROCEDURE SelectAllSongShortNames 

AS
BEGIN
	SET NOCOUNT ON;
	
    SELECT ShortName from dbo.Song
    
END
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
PRINT N'Creating [dbo].[SelectSongIdByShortName]...';


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
-- =============================================
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
    
END
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER OFF;


GO
-- Refactoring step to update target server with deployed transaction logs
CREATE TABLE  [dbo].[__RefactorLog] (OperationKey UNIQUEIDENTIFIER NOT NULL PRIMARY KEY)
GO
sp_addextendedproperty N'microsoft_database_tools_support', N'refactoring log', N'schema', N'dbo', N'table', N'__RefactorLog'
GO

GO
/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[Player] WITH CHECK CHECK CONSTRAINT [FK_Player_Platform];

ALTER TABLE [dbo].[Score] WITH CHECK CHECK CONSTRAINT [FK_Score_Difficulty];

ALTER TABLE [dbo].[Score] WITH CHECK CHECK CONSTRAINT [FK_Score_Instrument];

ALTER TABLE [dbo].[Score] WITH CHECK CHECK CONSTRAINT [FK_Score_Player];

ALTER TABLE [dbo].[Score] WITH CHECK CHECK CONSTRAINT [FK_Score_Song];

ALTER TABLE [dbo].[Score] WITH CHECK CHECK CONSTRAINT [CK_Score_StarScoreBetween0and6];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        DECLARE @VarDecimalSupported AS BIT;
        SELECT @VarDecimalSupported = 0;
        IF ((ServerProperty(N'EngineEdition') = 3)
            AND (((@@microsoftversion / power(2, 24) = 9)
                  AND (@@microsoftversion & 0xffff >= 3024))
                 OR ((@@microsoftversion / power(2, 24) = 10)
                     AND (@@microsoftversion & 0xffff >= 1600))))
            SELECT @VarDecimalSupported = 1;
        IF (@VarDecimalSupported > 0)
            BEGIN
                EXECUTE sp_db_vardecimal_storage_format N'$(DatabaseName)', 'ON';
            END
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET MULTI_USER 
    WITH ROLLBACK IMMEDIATE;


GO
