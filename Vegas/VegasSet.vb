Imports System.Data.Entity
Imports System.Data.Entity.ModelConfiguration
Imports System.ComponentModel.DataAnnotations

Interface IVegasSet
    Property VegasSetID As Integer
    Property SetName As String
    Property NumberOfGames As Integer
    Property WinLossGameAverage As Integer
    Property WinLossGameTotal As Integer
    Property GamesPlayed As List(Of Game)
End Interface
Public Class VegasSet
    Implements IVegasSet

    <Key>
    Public Property VegasSetID As Integer Implements IVegasSet.VegasSetID
    '
    ' A "Set" is a group of Game()s, and it controls the type of games that are played, as well as the results.
    '   A run can control a series of games that have different characteristics...
    '
    Public Property SetName As String Implements IVegasSet.SetName
    Public Property NumberOfGames As Integer Implements IVegasSet.NumberOfGames
    Public Property WinLossGameAverage As Integer Implements IVegasSet.WinLossGameAverage
    Public Property WinLossGameTotal As Integer Implements IVegasSet.WinLossGameTotal
    '
    '
    '
    Public Property GamesPlayed As List(Of Game) Implements IVegasSet.GamesPlayed

End Class
Public Class VegasSetConfiguration
    Inherits EntityTypeConfiguration(Of VegasSet)
    Sub New()
        'Dim strategy As System.Data.Entity.IDatabaseInitializer(Of vASASysContext)
        'strategy = New System.Data.Entity.NullDatabaseInitializer(Of vASASysContext)
        'Database.SetInitializer(strategy)
        '
        With Me.Property(Function(g) g.VegasSetID)
            .HasDatabaseGeneratedOption(Schema.DatabaseGeneratedOption.Identity)
        End With
        With Me.Property(Function(g) g.SetName)
            .IsOptional()
        End With
        With Me.Property(Function(g) g.NumberOfGames)
            .IsOptional()
        End With
        With Me.Property(Function(g) g.WinLossGameAverage)
            .IsOptional()
        End With
        With Me.Property(Function(g) g.WinLossGameTotal)
            .IsOptional()
        End With
    End Sub

End Class