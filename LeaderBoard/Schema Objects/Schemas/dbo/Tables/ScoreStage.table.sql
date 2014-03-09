CREATE TABLE [dbo].[ScoreStage] (
    [ScoreStageId]  INT          IDENTITY (1, 1) NOT NULL,
    [GameId]        INT          NOT NULL,
    [SongShortName] VARCHAR (50) NOT NULL,
    [InstrumentId]  TINYINT      NOT NULL,
    [Score]         INT          NOT NULL,
    [StarScore]     TINYINT      NULL,
    [Percentage]    TINYINT      NOT NULL,
    [PlayerName]    VARCHAR (50) NOT NULL,
    [PlatformId]    INT          NOT NULL,
    [DifficultyId]  TINYINT      NOT NULL
);



