Imports System.Data.Entity
Imports System.Data.Entity.ModelConfiguration
Imports System.ComponentModel.DataAnnotations

Interface IGame
    Property GameID As Integer
End Interface
Public Class Game
    Implements IGame

    Public Property GameID As Integer Implements IGame.GameID
    '
    ' represents how the game was started, played, and ultimately won or lost
    '
    Public Property NumberOfDecks As Integer
    Public Property StartingBalance As Integer
    Public Property AggressiveFactor As Integer
    '
    ' end game stats
    '
    Public Property EndingBalance As Integer
    Public Property AmountWonLost As Integer
    Public Property NumberOfMoves As Integer
    Public Property NumberOfCardsUnplayed As Integer
    Public Property GamePlayTimeSeconds As Double
    '
End Class

Public Class GameConfiguration
    Inherits EntityTypeConfiguration(Of Game)
    Sub New()
        'Dim strategy As System.Data.Entity.IDatabaseInitializer(Of vASASysContext)
        'strategy = New System.Data.Entity.NullDatabaseInitializer(Of vASASysContext)
        'Database.SetInitializer(strategy)
        '
        With Me.Property(Function(g) g.GameID)
            .HasDatabaseGeneratedOption(Schema.DatabaseGeneratedOption.Identity)
        End With
        With Me.Property(Function(g) g.NumberOfDecks)
            .IsOptional()
        End With
        With Me.Property(Function(g) g.StartingBalance)
            .IsOptional()
        End With
        With Me.Property(Function(g) g.AggressiveFactor)
            .IsOptional()
        End With
        With Me.Property(Function(g) g.EndingBalance)
            .IsOptional()
        End With
        With Me.Property(Function(g) g.AmountWonLost)
            .IsOptional()
        End With
        With Me.Property(Function(g) g.NumberOfMoves)
            .IsOptional()
        End With
        With Me.Property(Function(g) g.NumberOfCardsUnplayed)
            .IsOptional()
        End With
        With Me.Property(Function(g) g.GamePlayTimeSeconds)
            .IsOptional()
        End With
    End Sub

End Class
