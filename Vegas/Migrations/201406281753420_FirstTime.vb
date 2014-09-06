Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class FirstTime
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.Dealers",
                Function(c) New With
                    {
                        .DealerID = c.Int(nullable := False, identity := True)
                    }) _
                .PrimaryKey(Function(t) t.DealerID)
            
            CreateTable(
                "dbo.Decks",
                Function(c) New With
                    {
                        .DeckId = c.Int(nullable := False, identity := True),
                        .Style = c.Int()
                    }) _
                .PrimaryKey(Function(t) t.DeckId)
            
            CreateTable(
                "dbo.Cards",
                Function(c) New With
                    {
                        .CardID = c.Int(nullable := False, identity := True),
                        .Value = c.Int(nullable := False),
                        .Suit = c.Int(nullable := False),
                        .FaceUp = c.Boolean(nullable := False),
                        .FaceUpTop = c.Boolean(nullable := False),
                        .PositionStack = c.Int(nullable := False),
                        .LocationStack = c.Int(nullable := False),
                        .Width = c.Int(nullable := False),
                        .Height = c.Int(nullable := False),
                        .DeckNumber = c.Int(nullable := False),
                        .Style = c.Int(nullable := False),
                        .Deck_DeckId = c.Int(),
                        .Deck_DeckId1 = c.Int(),
                        .Deck_DeckId2 = c.Int(),
                        .Deck_DeckId3 = c.Int(),
                        .Deck_DeckId4 = c.Int(),
                        .Deck_DeckId5 = c.Int(),
                        .Deck_DeckId6 = c.Int(),
                        .Deck_DeckId7 = c.Int(),
                        .Deck_DeckId8 = c.Int(),
                        .Deck_DeckId9 = c.Int(),
                        .Deck_DeckId10 = c.Int(),
                        .Deck_DeckId11 = c.Int(),
                        .Deck_DeckId12 = c.Int(),
                        .Deck_DeckId13 = c.Int(),
                        .Deck_DeckId14 = c.Int(),
                        .Deck_DeckId15 = c.Int(),
                        .Deck_DeckId16 = c.Int()
                    }) _
                .PrimaryKey(Function(t) t.CardID) _
                .ForeignKey("dbo.Decks", Function(t) t.Deck_DeckId) _
                .ForeignKey("dbo.Decks", Function(t) t.Deck_DeckId1) _
                .ForeignKey("dbo.Decks", Function(t) t.Deck_DeckId2) _
                .ForeignKey("dbo.Decks", Function(t) t.Deck_DeckId3) _
                .ForeignKey("dbo.Decks", Function(t) t.Deck_DeckId4) _
                .ForeignKey("dbo.Decks", Function(t) t.Deck_DeckId5) _
                .ForeignKey("dbo.Decks", Function(t) t.Deck_DeckId6) _
                .ForeignKey("dbo.Decks", Function(t) t.Deck_DeckId7) _
                .ForeignKey("dbo.Decks", Function(t) t.Deck_DeckId8) _
                .ForeignKey("dbo.Decks", Function(t) t.Deck_DeckId9) _
                .ForeignKey("dbo.Decks", Function(t) t.Deck_DeckId10) _
                .ForeignKey("dbo.Decks", Function(t) t.Deck_DeckId11) _
                .ForeignKey("dbo.Decks", Function(t) t.Deck_DeckId12) _
                .ForeignKey("dbo.Decks", Function(t) t.Deck_DeckId13) _
                .ForeignKey("dbo.Decks", Function(t) t.Deck_DeckId14) _
                .ForeignKey("dbo.Decks", Function(t) t.Deck_DeckId15) _
                .ForeignKey("dbo.Decks", Function(t) t.Deck_DeckId16) _
                .Index(Function(t) t.Deck_DeckId) _
                .Index(Function(t) t.Deck_DeckId1) _
                .Index(Function(t) t.Deck_DeckId2) _
                .Index(Function(t) t.Deck_DeckId3) _
                .Index(Function(t) t.Deck_DeckId4) _
                .Index(Function(t) t.Deck_DeckId5) _
                .Index(Function(t) t.Deck_DeckId6) _
                .Index(Function(t) t.Deck_DeckId7) _
                .Index(Function(t) t.Deck_DeckId8) _
                .Index(Function(t) t.Deck_DeckId9) _
                .Index(Function(t) t.Deck_DeckId10) _
                .Index(Function(t) t.Deck_DeckId11) _
                .Index(Function(t) t.Deck_DeckId12) _
                .Index(Function(t) t.Deck_DeckId13) _
                .Index(Function(t) t.Deck_DeckId14) _
                .Index(Function(t) t.Deck_DeckId15) _
                .Index(Function(t) t.Deck_DeckId16)
            
            CreateTable(
                "dbo.Games",
                Function(c) New With
                    {
                        .GameID = c.Int(nullable := False, identity := True),
                        .NumberOfDecks = c.Int(),
                        .StartingBalance = c.Int(),
                        .AggressiveFactor = c.Int(),
                        .EndingBalance = c.Int(),
                        .AmountWonLost = c.Int(),
                        .NumberOfMoves = c.Int(),
                        .NumberOfCardsUnplayed = c.Int(),
                        .GamePlayTimeSeconds = c.Double(),
                        .VegasSet_VegasSetID = c.Int()
                    }) _
                .PrimaryKey(Function(t) t.GameID) _
                .ForeignKey("dbo.VegasSets", Function(t) t.VegasSet_VegasSetID) _
                .Index(Function(t) t.VegasSet_VegasSetID)
            
            CreateTable(
                "dbo.VegasSets",
                Function(c) New With
                    {
                        .VegasSetID = c.Int(nullable := False, identity := True),
                        .SetName = c.String(),
                        .NumberOfGames = c.Int(),
                        .WinLossGameAverage = c.Int(),
                        .WinLossGameTotal = c.Int()
                    }) _
                .PrimaryKey(Function(t) t.VegasSetID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.Games", "VegasSet_VegasSetID", "dbo.VegasSets")
            DropForeignKey("dbo.Cards", "Deck_DeckId16", "dbo.Decks")
            DropForeignKey("dbo.Cards", "Deck_DeckId15", "dbo.Decks")
            DropForeignKey("dbo.Cards", "Deck_DeckId14", "dbo.Decks")
            DropForeignKey("dbo.Cards", "Deck_DeckId13", "dbo.Decks")
            DropForeignKey("dbo.Cards", "Deck_DeckId12", "dbo.Decks")
            DropForeignKey("dbo.Cards", "Deck_DeckId11", "dbo.Decks")
            DropForeignKey("dbo.Cards", "Deck_DeckId10", "dbo.Decks")
            DropForeignKey("dbo.Cards", "Deck_DeckId9", "dbo.Decks")
            DropForeignKey("dbo.Cards", "Deck_DeckId8", "dbo.Decks")
            DropForeignKey("dbo.Cards", "Deck_DeckId7", "dbo.Decks")
            DropForeignKey("dbo.Cards", "Deck_DeckId6", "dbo.Decks")
            DropForeignKey("dbo.Cards", "Deck_DeckId5", "dbo.Decks")
            DropForeignKey("dbo.Cards", "Deck_DeckId4", "dbo.Decks")
            DropForeignKey("dbo.Cards", "Deck_DeckId3", "dbo.Decks")
            DropForeignKey("dbo.Cards", "Deck_DeckId2", "dbo.Decks")
            DropForeignKey("dbo.Cards", "Deck_DeckId1", "dbo.Decks")
            DropForeignKey("dbo.Cards", "Deck_DeckId", "dbo.Decks")
            DropIndex("dbo.Games", New String() { "VegasSet_VegasSetID" })
            DropIndex("dbo.Cards", New String() { "Deck_DeckId16" })
            DropIndex("dbo.Cards", New String() { "Deck_DeckId15" })
            DropIndex("dbo.Cards", New String() { "Deck_DeckId14" })
            DropIndex("dbo.Cards", New String() { "Deck_DeckId13" })
            DropIndex("dbo.Cards", New String() { "Deck_DeckId12" })
            DropIndex("dbo.Cards", New String() { "Deck_DeckId11" })
            DropIndex("dbo.Cards", New String() { "Deck_DeckId10" })
            DropIndex("dbo.Cards", New String() { "Deck_DeckId9" })
            DropIndex("dbo.Cards", New String() { "Deck_DeckId8" })
            DropIndex("dbo.Cards", New String() { "Deck_DeckId7" })
            DropIndex("dbo.Cards", New String() { "Deck_DeckId6" })
            DropIndex("dbo.Cards", New String() { "Deck_DeckId5" })
            DropIndex("dbo.Cards", New String() { "Deck_DeckId4" })
            DropIndex("dbo.Cards", New String() { "Deck_DeckId3" })
            DropIndex("dbo.Cards", New String() { "Deck_DeckId2" })
            DropIndex("dbo.Cards", New String() { "Deck_DeckId1" })
            DropIndex("dbo.Cards", New String() { "Deck_DeckId" })
            DropTable("dbo.VegasSets")
            DropTable("dbo.Games")
            DropTable("dbo.Cards")
            DropTable("dbo.Decks")
            DropTable("dbo.Dealers")
        End Sub
    End Class
End Namespace
