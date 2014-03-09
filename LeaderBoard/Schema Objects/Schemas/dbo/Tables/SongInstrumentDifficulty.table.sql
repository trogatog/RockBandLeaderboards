CREATE TABLE [dbo].[SongInstrumentDifficulty] (
    [SongInstrumentDifficultyId] INT      IDENTITY (1, 1) NOT NULL,
    [SongId]                     INT      NOT NULL,
    [InstrumentId]               TINYINT  NOT NULL,
    [StarRank]                   SMALLINT NOT NULL
);



