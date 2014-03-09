ALTER TABLE [dbo].[SongStage]
    ADD CONSTRAINT [DF_SongStage_LastUpdatedDate] DEFAULT ('1/1/1900') FOR [LastUpdatedDate];

