Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Infrastructure.Annotations

Public Class VegasContext
    Inherits DBContext
    '============================================================================
    Public Sub New()
        MyBase.New("VegasContext")
    End Sub
    '============================================================================
    Public Property Games As DbSet(Of Game)
    Public Property VegasSets As DbSet(Of VegasSet)
    Public Property Dealers As DbSet(Of Dealer)
    Public Property Decks As DbSet(Of Deck)
    '============================================================================
    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        '
        ' vegas solitaire 
        '
        modelBuilder.Configurations.Add(Of Game)(New GameConfiguration())
        modelBuilder.Configurations.Add(Of VegasSet)(New VegasSetConfiguration())
        modelBuilder.Configurations.Add(Of Dealer)(New DealerConfiguration())
        'modelBuilder.Configurations.Add(Of Deck)(New DeckConfiguration())
    End Sub

End Class
