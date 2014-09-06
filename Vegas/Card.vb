Imports System.Collections.ObjectModel
Imports System.Data.Entity.ModelConfiguration
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Interface ICard
    Property Left As Double
    Property Top As Double
    Property Source As String
    Property SourceImage As Image
End Interface
Public Class Card
    Implements ICard

    <Key>
    Public Property CardID As Integer
    Public Property Value As Enums.CardValue ' 1 - 13
    Public Property Suit As Enums.CardSuit ' 
    Public ReadOnly Property SuitName As String
        Get
            Select Case Me.Suit
                Case CardSuit.Clubs
                    Return "Clubs"
                Case CardSuit.Diamonds
                    Return "Diamonds"
                Case CardSuit.Hearts
                    Return "Hearts"
                Case CardSuit.Spades
                    Return "Spades"
                Case Else
                    Return Nothing ' hopefully causes an error upstream...
            End Select
        End Get
    End Property
    Public ReadOnly Property Color As CardColor
        Get
            If Suit Mod 2 = 0 Then
                Return CardColor.Red
            Else
                Return CardColor.Black
            End If
        End Get
    End Property
    Public Property FaceUp As Boolean ' true = face up, false - face down
    Public Property FaceUpTop As Boolean ' true = top-most card in stack AND face up (playable)
    Public Property PositionIndexStack As Integer ' 0 to 20 (1 on bottom)
    Public Property LocationStack As Enums.CardStack

    Public Property LocationXY As Point ' top left of card
        Get
            Return New Point(Me._leftX, Me._topY)
        End Get
        Set(value As Point)
            Me._leftX = value.X
            Me._topY = value.Y
        End Set
    End Property
    Private _leftX As Double
    Public Property Left As Double Implements ICard.Left
        Get
            Return Me._leftX
        End Get
        Set(value As Double)
            Me._leftX = value
        End Set
    End Property
    Private _topY As Double
    Public Property Top As Double Implements ICard.Top
        Get
            Return Me._topY
        End Get
        Set(value As Double)
            Me._topY = value
        End Set
    End Property
    Public Property Width As Double ' of card in pixels
    Public Property Height As Double ' of card in pixels
    Public Property DeckNumber As Integer ' for using multiple decks
    Public Property Style As Enums.CardStyle
    Public Property Source As String Implements ICard.Source
    Public Property SourceImage As Image Implements ICard.SourceImage
    ' not used right now... XXX
    Public Property ImageLocationSimple As String
    Public Property ImageLocationTraditional As String
    Public Property ImageLocationBack As String ' might be better defined in Deck()? 

End Class
Public Class CardConfiguration
    Inherits EntityTypeConfiguration(Of Card)
    Sub New()
        With Me.Property(Function(g) g.CardID)
            .HasDatabaseGeneratedOption(Schema.DatabaseGeneratedOption.Identity)
        End With
        Me.Property(Function(g) g.Value).IsOptional()
        Me.Property(Function(g) g.Suit).IsOptional()
        Me.Property(Function(g) g.Color).IsOptional()
        Me.Property(Function(g) g.FaceUp).IsOptional()
        Me.Property(Function(g) g.FaceUpTop).IsOptional()
        Me.Property(Function(g) g.PositionIndexStack).IsOptional()
        Me.Property(Function(g) g.LocationStack).IsOptional()
        Me.Property(Function(g) g.Width).IsOptional()
        Me.Property(Function(g) g.Height).IsOptional()
        Me.Property(Function(g) g.DeckNumber).IsOptional()
        Me.Property(Function(g) g.Style).IsOptional()
    End Sub
End Class