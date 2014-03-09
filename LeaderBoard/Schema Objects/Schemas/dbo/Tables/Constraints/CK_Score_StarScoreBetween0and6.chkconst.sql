ALTER TABLE [dbo].[Score]
    ADD CONSTRAINT [CK_Score_StarScoreBetween0and6] CHECK ([StarScore]>(0) AND [StarScore]<=(6) OR [StarScore] IS NULL);



