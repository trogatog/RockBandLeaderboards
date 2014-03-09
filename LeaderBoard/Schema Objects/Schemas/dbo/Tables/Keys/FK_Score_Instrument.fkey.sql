ALTER TABLE [dbo].[Score]
    ADD CONSTRAINT [FK_Score_Instrument] FOREIGN KEY ([InstrumentId]) REFERENCES [dbo].[Instrument] ([InstrumentId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

