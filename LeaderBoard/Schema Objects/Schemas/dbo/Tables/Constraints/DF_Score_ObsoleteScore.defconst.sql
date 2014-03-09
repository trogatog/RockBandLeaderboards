ALTER TABLE [dbo].[Score]
    ADD CONSTRAINT [DF_Score_ObsoleteScore] DEFAULT ((0)) FOR [ObsoleteScore];

