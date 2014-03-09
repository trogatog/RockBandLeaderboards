ALTER TABLE [dbo].[Score]
    ADD CONSTRAINT [FK_Score_Difficulty] FOREIGN KEY ([DifficultyId]) REFERENCES [dbo].[Difficulty] ([DifficultyId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

