﻿ALTER TABLE [dbo].[Score]
    ADD CONSTRAINT [FK_Score_Player] FOREIGN KEY ([PlayerId]) REFERENCES [dbo].[Player] ([PlayerId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

