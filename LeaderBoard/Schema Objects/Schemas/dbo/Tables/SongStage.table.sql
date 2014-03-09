﻿CREATE TABLE [dbo].[SongStage] (
    [SongStageId]         INT           IDENTITY (1, 1) NOT NULL,
    [HmxSongId]           INT           NOT NULL,
    [ShortName]           VARCHAR (250) NOT NULL,
    [Artist]              VARCHAR (250) NOT NULL,
    [ArtistTr]            VARCHAR (250) NOT NULL,
    [Name]                VARCHAR (250) NOT NULL,
    [NameTr]              VARCHAR (250) NOT NULL,
    [Genre]               VARCHAR (250) NOT NULL,
    [Source]              VARCHAR (15)  NOT NULL,
    [Rating]              TINYINT       NOT NULL,
    [VocalDifficulty]     SMALLINT      NULL,
    [GuitarDifficulty]    SMALLINT      NULL,
    [ProGuitarDifficulty] SMALLINT      NULL,
    [DrumsDifficulty]     SMALLINT      NULL,
    [ProDrumsDifficulty]  SMALLINT      NULL,
    [KeysDifficulty]      SMALLINT      NULL,
    [ProKeysDifficulty]   SMALLINT      NULL,
    [BassDifficulty]      SMALLINT      NULL,
    [ProBassDifficulty]   SMALLINT      NULL,
    [BandDifficulty]      SMALLINT      NULL,
    [VocalParts]          TINYINT       NOT NULL,
    [YearReleased]        INT           NOT NULL,
    [Decade]              VARCHAR (6)   NOT NULL,
    [StartsWith]          CHAR (1)      NOT NULL,
    [Cover]               VARCHAR (250) NOT NULL,
    [SongDisplayName]     VARCHAR (250) NOT NULL,
    [LastUpdatedDate]     DATETIME      NOT NULL,
    [SongId]              INT           NOT NULL
);
