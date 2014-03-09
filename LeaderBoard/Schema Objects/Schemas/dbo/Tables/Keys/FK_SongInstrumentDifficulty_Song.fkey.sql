ALTER TABLE [dbo].[SongInstrumentDifficulty]
    ADD CONSTRAINT [FK_SongInstrumentDifficulty_Song] FOREIGN KEY ([SongId]) REFERENCES [dbo].[Song] ([SongId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

