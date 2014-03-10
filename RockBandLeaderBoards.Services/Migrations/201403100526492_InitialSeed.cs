namespace RockBandLeaderBoards.Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSeed : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Difficulty",
                c => new
                    {
                        DifficultyId = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 50),
                        SmallDescription = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.DifficultyId);
            
            CreateTable(
                "dbo.Game",
                c => new
                    {
                        GameId = c.Int(nullable: false, identity: true),
                        GameName = c.String(maxLength: 50),
                        ShortName = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.GameId);
            
            CreateTable(
                "dbo.Instrument",
                c => new
                    {
                        InstrumentId = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 15),
                        SongInstrumentDifficulty_SongInstrumentDifficultyId = c.Int(),
                    })
                .PrimaryKey(t => t.InstrumentId)
                .ForeignKey("dbo.SongInstrumentDifficulty", t => t.SongInstrumentDifficulty_SongInstrumentDifficultyId)
                .Index(t => t.SongInstrumentDifficulty_SongInstrumentDifficultyId);
            
            CreateTable(
                "dbo.Platform",
                c => new
                    {
                        PlatformId = c.Int(nullable: false, identity: true),
                        ConsoleName = c.String(maxLength: 50),
                        ShortName = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.PlatformId);
            
            CreateTable(
                "dbo.Player",
                c => new
                    {
                        PlayerId = c.Int(nullable: false, identity: true),
                        OnlineName = c.String(maxLength: 50),
                        Platform_PlatformId = c.Int(),
                    })
                .PrimaryKey(t => t.PlayerId)
                .ForeignKey("dbo.Platform", t => t.Platform_PlatformId)
                .Index(t => t.Platform_PlatformId);
            
            CreateTable(
                "dbo.Score",
                c => new
                    {
                        ScoreId = c.Int(nullable: false, identity: true),
                        SongScore = c.Int(nullable: false),
                        StarScore = c.Byte(nullable: false),
                        Percentage = c.Byte(nullable: false),
                        ObsoleteScore = c.Boolean(nullable: false),
                        ScoreAddedDate = c.DateTime(nullable: false),
                        Ranking = c.Int(nullable: false),
                        Difficulty_DifficultyId = c.Int(),
                        Game_GameId = c.Int(),
                        Instrument_InstrumentId = c.Int(),
                        Player_PlayerId = c.Int(),
                        Song_SongId = c.Int(),
                    })
                .PrimaryKey(t => t.ScoreId)
                .ForeignKey("dbo.Difficulty", t => t.Difficulty_DifficultyId)
                .ForeignKey("dbo.Game", t => t.Game_GameId)
                .ForeignKey("dbo.Instrument", t => t.Instrument_InstrumentId)
                .ForeignKey("dbo.Player", t => t.Player_PlayerId)
                .ForeignKey("dbo.Song", t => t.Song_SongId)
                .Index(t => t.Difficulty_DifficultyId)
                .Index(t => t.Game_GameId)
                .Index(t => t.Instrument_InstrumentId)
                .Index(t => t.Player_PlayerId)
                .Index(t => t.Song_SongId);
            
            CreateTable(
                "dbo.Song",
                c => new
                    {
                        SongId = c.Int(nullable: false, identity: true),
                        HmxSongId = c.Int(nullable: false),
                        ShortName = c.String(nullable: false, maxLength: 50),
                        Artist = c.String(nullable: false, maxLength: 50),
                        ArtistTr = c.String(nullable: false, maxLength: 50),
                        Name = c.String(nullable: false, maxLength: 100),
                        NameTr = c.String(nullable: false, maxLength: 100),
                        Genre = c.String(nullable: false, maxLength: 50),
                        Source = c.String(nullable: false, maxLength: 15),
                        Rating = c.Byte(nullable: false),
                        VocalParts = c.Byte(nullable: false),
                        YearReleased = c.Int(nullable: false),
                        Decade = c.String(nullable: false, maxLength: 6),
                        Cover = c.String(nullable: false, maxLength: 50),
                        SongDisplyName = c.String(nullable: false, maxLength: 100),
                        LastUpdatedDate = c.DateTime(nullable: false),
                        SongInstrumentDifficulty_SongInstrumentDifficultyId = c.Int(),
                    })
                .PrimaryKey(t => t.SongId)
                .ForeignKey("dbo.SongInstrumentDifficulty", t => t.SongInstrumentDifficulty_SongInstrumentDifficultyId)
                .Index(t => t.SongInstrumentDifficulty_SongInstrumentDifficultyId);
            
            CreateTable(
                "dbo.SongInstrumentDifficulty",
                c => new
                    {
                        SongInstrumentDifficultyId = c.Int(nullable: false, identity: true),
                        StarRank = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.SongInstrumentDifficultyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Song", "SongInstrumentDifficulty_SongInstrumentDifficultyId", "dbo.SongInstrumentDifficulty");
            DropForeignKey("dbo.Instrument", "SongInstrumentDifficulty_SongInstrumentDifficultyId", "dbo.SongInstrumentDifficulty");
            DropForeignKey("dbo.Score", "Song_SongId", "dbo.Song");
            DropForeignKey("dbo.Score", "Player_PlayerId", "dbo.Player");
            DropForeignKey("dbo.Score", "Instrument_InstrumentId", "dbo.Instrument");
            DropForeignKey("dbo.Score", "Game_GameId", "dbo.Game");
            DropForeignKey("dbo.Score", "Difficulty_DifficultyId", "dbo.Difficulty");
            DropForeignKey("dbo.Player", "Platform_PlatformId", "dbo.Platform");
            DropIndex("dbo.Song", new[] { "SongInstrumentDifficulty_SongInstrumentDifficultyId" });
            DropIndex("dbo.Instrument", new[] { "SongInstrumentDifficulty_SongInstrumentDifficultyId" });
            DropIndex("dbo.Score", new[] { "Song_SongId" });
            DropIndex("dbo.Score", new[] { "Player_PlayerId" });
            DropIndex("dbo.Score", new[] { "Instrument_InstrumentId" });
            DropIndex("dbo.Score", new[] { "Game_GameId" });
            DropIndex("dbo.Score", new[] { "Difficulty_DifficultyId" });
            DropIndex("dbo.Player", new[] { "Platform_PlatformId" });
            DropTable("dbo.SongInstrumentDifficulty");
            DropTable("dbo.Song");
            DropTable("dbo.Score");
            DropTable("dbo.Player");
            DropTable("dbo.Platform");
            DropTable("dbo.Instrument");
            DropTable("dbo.Game");
            DropTable("dbo.Difficulty");
        }
    }
}
