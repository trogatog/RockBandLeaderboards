ALTER TABLE [dbo].[Player]
    ADD CONSTRAINT [FK_Player_Platform] FOREIGN KEY ([PlatformId]) REFERENCES [dbo].[Platform] ([PlatformId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

