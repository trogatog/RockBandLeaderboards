CREATE TABLE [dbo].[Score] (
    [ScoreId]        INT      IDENTITY (1, 1) NOT NULL,
    [GameId]         TINYINT  NOT NULL,
    [SongId]         INT      NOT NULL,
    [InstrumentId]   TINYINT  NOT NULL,
    [Score]          INT      NOT NULL,
    [StarScore]      TINYINT  NULL,
    [Percentage]     TINYINT  NOT NULL,
    [PlayerId]       INT      NOT NULL,
    [DifficultyId]   TINYINT  NOT NULL,
    [ObsoleteScore]  BIT      NOT NULL,
    [ScoreAddedDate] DATETIME NOT NULL,
    [Ranking]        INT      NULL
);











