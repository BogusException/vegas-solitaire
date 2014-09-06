Imports System.Collections.ObjectModel
Imports System.Data.Entity.ModelConfiguration
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Collections.Specialized
Imports System.ComponentModel

Interface IDealer
    Property Style As Enums.CardStyle
End Interface
Public Class Dealer
    Inherits ObservableCollection(Of ObservableCollection(Of Card))
    Implements IDealer

#Region "Other Classes"
    <NotMapped>
    Public Property GameDeck As Deck
    Public Property CardTable As MainWindow
#End Region
#Region "Properties"
    Public Property DealerID As Integer
    '         ^ +Y
    '         |
    ' -X  <------> +X
    '         |
    '         v -Y
    '
    ' topmost point, where all other card positions are measured from...
    <NotMapped>
    Public Property OriginPointXY As Point ' top left, where Foundation1XY is located
    ' foundation piles
    <NotMapped>
    Public Property Foundation1XY As Point ' left
    <NotMapped>
    Public Property Foundation2XY As Point
    <NotMapped>
    Public Property Foundation3XY As Point
    <NotMapped>
    Public Property Foundation4XY As Point ' right
    ' tableau piles
    <NotMapped>
    Public Property Tableau1XY As Point ' left
    <NotMapped>
    Public Property Tableau2XY As Point
    <NotMapped>
    Public Property Tableau3XY As Point
    <NotMapped>
    Public Property Tableau4XY As Point
    <NotMapped>
    Public Property Tableau5XY As Point
    <NotMapped>
    Public Property Tableau6XY As Point
    <NotMapped>
    Public Property Tableau7XY As Point ' right
    '
    '=============================================================
    ' discard & draw piles
    <NotMapped>
    Public Property DiscardPileXY As Point
    <NotMapped>
    Public Property DrawPileXY As Point
    ' offsets
    <NotMapped>
    Public Property ColumnsXOffset As Double ' # of pixels between XY poins for each column (F1-4, T1-7, Disc, Draw)
    <NotMapped>
    Public Property TableauRowYOffset As Double ' distance from F, D, D's XY points and T's Y point (top left of cards)
    <NotMapped>
    Public Property TableauYStackOffset As Double ' Distance in Y between cards in piles (so value can show)
    ' minimums
    <NotMapped>
    Public Property ColumnsXOffsetMin As Double
    <NotMapped>
    Public Property TableauRowYOffsetMin As Double
    <NotMapped>
    Public Property TableauYStackOffsetMin As Double
    ' card sizes
    <NotMapped>
    Public Property CardWidthX As Double
    <NotMapped>
    Public Property CardHeightY As Double
    <NotMapped>
    Public Property CardHeightRatio As Double
    <NotMapped>
    Public Property CardSpacingPctOfWidth As Double ' ex: 0.2 = 20% of width, etc.
    '
    <NotMapped>
    Public Property ScreenWidthX As Double ' determined at run time
    '
    Public Property Style As Enums.CardStyle Implements IDealer.Style
#End Region
#Region "Internal Class Variables"

#End Region
#Region "Constructors"
    ' CONSTants
    Private Const IMAGE_DIRECTORY As String = "images/"
    '
    Public Sub New(ByRef windowMain As MainWindow, ByVal screenWidth As Double)
        Me.CardTable = windowMain ' gives us access to the piles & drawing suyrface
        Me.ScreenWidthX = screenWidth
        Me.Setup()
        Me.SetupDeckAndTable()

    End Sub
    Private Sub Setup()
        Try
            ' Me.CardTable
            '
            ' create all the cards & decks
            '
            ' assign/create each card in the deck(s)
            Me.GameDeck = Me.CreateDeck(1)
            ' take that deck & shuffle X times...
            '  Me.ShuffleCards(3)
            ' with .PNG, not really needed, it seems...
            Me.CardHeightRatio = 1.452 ' width times this # is the height 
            Me.CardSpacingPctOfWidth = 0.2 ' X% ow acrd width between cards in X-axis
            '
            ' origin point...
            '
            Me.OriginPointXY = New Point(20, 20)
            '
            ' Minimums 9not used right now...)
            '
            Me.ColumnsXOffsetMin = 0
            Me.TableauRowYOffsetMin = 0
            Me.TableauYStackOffsetMin = 0
            '
        Catch ex As Exception

        End Try
    End Sub
    Public Sub SetupDeckAndTable()
        '
        ' calculate offsets & positions of stacks, not cards
        ' note: there are 7 columns of cards, and 8 spaces (includes left & right margins)
        '
        ' these values (height & width) will be the same for all cards in deck
        Me.CardWidthX = CInt(Math.Round(0.1064 * Me.ScreenWidthX, MidpointRounding.AwayFromZero))
        Me.CardHeightY = CInt(Math.Round(Me.CardHeightRatio * Me.CardWidthX))
        ' each row's X value is a multiple of:
        Me.ColumnsXOffset = CInt(Me.CardWidthX + (Me.CardWidthX * Me.CardSpacingPctOfWidth))
        '
        ' Top Row foundations, discard & draw
        '
        Me.Foundation1XY = New Point(Me.OriginPointXY.X, Me.OriginPointXY.Y)
        Me.Foundation2XY = New Point(Me.OriginPointXY.X + (1 * Me.ColumnsXOffset), Me.OriginPointXY.Y)
        Me.Foundation3XY = New Point(Me.OriginPointXY.X + (2 * Me.ColumnsXOffset), Me.OriginPointXY.Y)
        Me.Foundation4XY = New Point(Me.OriginPointXY.X + (3 * Me.ColumnsXOffset), Me.OriginPointXY.Y)
        ' space between foundation 4 and discard pile
        Me.DiscardPileXY = New Point(Me.OriginPointXY.X + (5 * Me.ColumnsXOffset), Me.OriginPointXY.Y)
        Me.DrawPileXY = New Point(Me.OriginPointXY.X + (6 * Me.ColumnsXOffset), Me.OriginPointXY.Y)
        '
        ' Top row tableau
        '   This only positions the first row:
        Me.TableauRowYOffset = CInt(Me.CardHeightY + (CardSpacingPctOfWidth * 0.01 * CardHeightY))
        '
        '=======================================
        '
        ' this is the offset between cards in the same tableau:
        '
        Me.TableauYStackOffset = 0.25 * Me.CardHeightY
        '
        '=======================================
        Me.Tableau1XY = New Point(OriginPointXY.X, Me.TableauRowYOffset)
        Me.Tableau2XY = New Point(OriginPointXY.X + (1 * Me.ColumnsXOffset), Me.TableauRowYOffset)
        Me.Tableau3XY = New Point(OriginPointXY.X + (2 * Me.ColumnsXOffset), Me.TableauRowYOffset)
        Me.Tableau4XY = New Point(OriginPointXY.X + (3 * Me.ColumnsXOffset), Me.TableauRowYOffset)
        Me.Tableau5XY = New Point(OriginPointXY.X + (4 * Me.ColumnsXOffset), Me.TableauRowYOffset)
        Me.Tableau6XY = New Point(OriginPointXY.X + (5 * Me.ColumnsXOffset), Me.TableauRowYOffset)
        Me.Tableau7XY = New Point(OriginPointXY.X + (6 * Me.ColumnsXOffset), Me.TableauRowYOffset)
        '
        ' now for the individual positions in each tableau
        '   note: the List() is zero-based
        '
        ' top card in each pile (or bottom/first, depending on your perspective!)
        '
        Me.CardTable.Tableau1Pile.Add(New Card With {.LocationXY = Me.Tableau1XY})
        Me.CardTable.Tableau2Pile.Add(New Card With {.LocationXY = Me.Tableau2XY})
        Me.CardTable.Tableau3Pile.Add(New Card With {.LocationXY = Me.Tableau3XY})
        Me.CardTable.Tableau4Pile.Add(New Card With {.LocationXY = Me.Tableau4XY})
        Me.CardTable.Tableau5Pile.Add(New Card With {.LocationXY = Me.Tableau5XY})
        Me.CardTable.Tableau6Pile.Add(New Card With {.LocationXY = Me.Tableau6XY})
        Me.CardTable.Tableau7Pile.Add(New Card With {.LocationXY = Me.Tableau7XY})
        '
        For idx = 1 To 21
            Me.CardTable.Tableau1Pile.Add(New Card() With {.LocationXY = New Point(Tableau1XY.X, idx * Me.TableauYStackOffset)})
            Me.CardTable.Tableau2Pile.Add(New Card() With {.LocationXY = New Point(Tableau2XY.X, idx * Me.TableauYStackOffset)})
            Me.CardTable.Tableau3Pile.Add(New Card() With {.LocationXY = New Point(Tableau3XY.X, idx * Me.TableauYStackOffset)})
            Me.CardTable.Tableau4Pile.Add(New Card() With {.LocationXY = New Point(Tableau4XY.X, idx * Me.TableauYStackOffset)})
            Me.CardTable.Tableau5Pile.Add(New Card() With {.LocationXY = New Point(Tableau5XY.X, idx * Me.TableauYStackOffset)})
            Me.CardTable.Tableau6Pile.Add(New Card() With {.LocationXY = New Point(Tableau6XY.X, idx * Me.TableauYStackOffset)})
            Me.CardTable.Tableau7Pile.Add(New Card() With {.LocationXY = New Point(Tableau7XY.X, idx * Me.TableauYStackOffset)})
        Next
    End Sub
#End Region
#Region "Dealing/ReDealing"
    Public Sub DealNewGame()
        Me.SetupDeckAndTable()
        '
        ' [...]
        '
        Try
            Me.GameDeck.Item(0).LocationStack = CardStack.Foundation1

        Catch ex As Exception
            Debug.WriteLine("DealNewGame() exception.Message: " & ex.Message)
            Debug.WriteLine("DealNewGame() exception.ToString: " & ex.ToString)
            Debug.WriteLine("DealNewGame() exception.StackTrace: " & ex.StackTrace)
        End Try



    End Sub
    Public Sub Deal()
        ' 24 in draw, 28 in the tableaus...
        ' actually, the draw pile can be a card back, or empty.
        ' the discard pile can be the latest 3 cards, face up (3 positions)
        ' foundations only have one card (face up) at a time
        '

    End Sub
    Public Sub RefreshLayout()
        '
        ' called usually when the CardTable has been resized... (ScreenWidthX is updated automatically when CardTable resized)
        '
        Me.SetupDeckAndTable()

        ' clear table
        Me.Deal()

    End Sub
#End Region
    Public Function CreateDeck(Optional NumberOfDecks As Integer = 1) As Deck
        Dim newDeck As Deck = New Deck()
        Try
            For d As Integer = 1 To NumberOfDecks
                For s As CardSuit = CType(1, CardSuit) To CType(4, CardSuit)
                    For v As CardValue = CType(1, CardValue) To CType(13, CardValue)
                        Dim newCard As Card = New Card
                        With newCard
                            .DeckNumber = d
                            .FaceUp = False
                            .Suit = s
                            .Style = Me.Style
                            .Value = v
                            Select Case .Value
                                ' note: IMAGE_DIRECTORY ends in a "/"
                                Case CardValue.Ace
                                    .Source = IMAGE_DIRECTORY & "ace_of_" & .SuitName.ToLower & ".png"
                                Case CardValue.Jack
                                    .Source = IMAGE_DIRECTORY & "jack_of_" & .SuitName.ToLower & ".png"
                                Case CardValue.King
                                    .Source = IMAGE_DIRECTORY & "king_of_" & .SuitName.ToLower & ".png"
                                Case CardValue.Queen
                                    .Source = IMAGE_DIRECTORY & "queen_of_" & .SuitName.ToLower & ".png"
                                Case Else
                                    .Source = IMAGE_DIRECTORY & v & "_of_" & .SuitName.ToLower & ".png"
                            End Select ' .Value
                        End With
                        newDeck.Add(newCard)
                    Next
                Next
            Next
        Catch ex As Exception
            Dim methodName As String = "CreateDeck"
            Debug.WriteLine(methodName & "() exception.Message: " & ex.Message)
            Debug.WriteLine(methodName & "() exception.ToString: " & ex.ToString)
            Debug.WriteLine(methodName & "() exception.StackTrace: " & ex.StackTrace)
        End Try
        Return newDeck
    End Function
    Public Sub ShuffleCards(NumberOfShuffles As Integer)
        Dim shuffledDeck As New ObservableCollection(Of Card)
        Try

        Catch ex As Exception
            Dim methodName As String = "ShuffleDeck"
            Debug.WriteLine(methodName & "() exception.Message: " & ex.Message)
            Debug.WriteLine(methodName & "() exception.ToString: " & ex.ToString)
            Debug.WriteLine(methodName & "() exception.StackTrace: " & ex.StackTrace)
        End Try
        '  Me.TheCards = shuffledDeck
    End Sub
#Region "Events"
    'Protected Overrides Sub OnCollectionChanged(ByVal e As NotifyCollectionChangedEventArgs)
    '    If e.Action = NotifyCollectionChangedAction.Add Then
    '        RegisterPropertyChanged(e.NewItems)
    '    ElseIf e.Action = NotifyCollectionChangedAction.Remove Then
    '        UnRegisterPropertyChanged(e.OldItems)
    '    ElseIf e.Action = NotifyCollectionChangedAction.Replace Then
    '        UnRegisterPropertyChanged(e.OldItems)
    '        RegisterPropertyChanged(e.NewItems)
    '    End If
    '    MyBase.OnCollectionChanged(e)
    'End Sub
    'Protected Overrides Sub ClearItems()
    '    UnRegisterPropertyChanged(Me)
    '    MyBase.ClearItems()
    'End Sub
    'Private Sub RegisterPropertyChanged(ByVal items As IList)
    '    For Each item As INotifyPropertyChanged In items
    '        If item IsNot Nothing Then
    '            AddHandler item.PropertyChanged, AddressOf item_PropertyChanged
    '        End If
    '    Next item
    'End Sub
    'Private Sub UnRegisterPropertyChanged(ByVal items As IList)
    '    For Each item As INotifyPropertyChanged In items
    '        If item IsNot Nothing Then
    '            RemoveHandler item.PropertyChanged, AddressOf item_PropertyChanged
    '        End If
    '    Next item
    'End Sub
    'Private Sub item_PropertyChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
    '    MyBase.OnCollectionChanged(New NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset))
    'End Sub
#End Region

End Class
Public Class DealerConfiguration
    Inherits EntityTypeConfiguration(Of Dealer)
    Sub New()
        'Dim strategy As System.Data.Entity.IDatabaseInitializer(Of vASASysContext)
        'strategy = New System.Data.Entity.NullDatabaseInitializer(Of vASASysContext)
        'Database.SetInitializer(strategy)
        '
        With Me.Property(Function(d) d.DealerID)
            .HasDatabaseGeneratedOption(Schema.DatabaseGeneratedOption.Identity)
        End With
        'With Me.Property(Function(a) a.LastUpdated)
        '    '.HasDatabaseGeneratedOption(Schema.DatabaseGeneratedOption.Computed)
        '    .HasColumnType("datetime2")
        '    .HasPrecision(7)
        '    .IsOptional()
        'End With
    End Sub
End Class
