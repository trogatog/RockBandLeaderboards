CREATE TABLE [dbo].[Song] (
    [SongId]          INT           IDENTITY (1, 1) NOT NULL,
    [HmxSongId]       INT           NOT NULL,
    [ShortName]       VARCHAR (50)  NOT NULL,
    [Artist]          VARCHAR (50)  NOT NULL,
    [ArtistTr]        VARCHAR (50)  NOT NULL,
    [Name]            VARCHAR (100) NOT NULL,
    [NameTr]          VARCHAR (100) NOT NULL,
    [Genre]           VARCHAR (50)  NOT NULL,
    [Source]          VARCHAR (15)  NOT NULL,
    [Rating]          TINYINT       NOT NULL,
    [VocalParts]      TINYINT       NOT NULL,
    [YearReleased]    INT           NOT NULL,
    [Decade]          VARCHAR (6)   NOT NULL,
    [StartsWith]      CHAR (1)      NOT NULL,
    [Cover]           VARCHAR (50)  NOT NULL,
    [SongDisplayName] VARCHAR (100) NOT NULL,
    [LastUpdatedDate] DATETIME      NOT NULL
);







