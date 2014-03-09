ALTER TABLE [dbo].[SongInstrumentDifficulty]
    ADD CONSTRAINT [FK_SongInstrumentDifficulty_Instrument] FOREIGN KEY ([InstrumentId]) REFERENCES [dbo].[Instrument] ([InstrumentId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

