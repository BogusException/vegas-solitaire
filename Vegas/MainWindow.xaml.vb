Imports System.Collections.ObjectModel

Class MainWindow
    Public Property TheDealer As Dealer
    Public Property TheDeck As Deck
    Public Property DesiredWidth As Double
    Public Property DesiredHeight As Double
    '
    Public Property Foundation1Pile As New ObservableCollection(Of Card)
    Public Property Foundation2Pile As New ObservableCollection(Of Card)
    Public Property Foundation3Pile As New ObservableCollection(Of Card)
    Public Property Foundation4Pile As New ObservableCollection(Of Card)
    Public Property DiscardPile As New ObservableCollection(Of Card)
    Public Property DrawPile As New ObservableCollection(Of Card)
    Public Property Tableau1Pile As New ObservableCollection(Of Card)
    Public Property Tableau2Pile As New ObservableCollection(Of Card)
    Public Property Tableau3Pile As New ObservableCollection(Of Card)
    Public Property Tableau4Pile As New ObservableCollection(Of Card)
    Public Property Tableau5Pile As New ObservableCollection(Of Card)
    Public Property Tableau6Pile As New ObservableCollection(Of Card)
    Public Property Tableau7Pile As New ObservableCollection(Of Card)
    ' in cases of multiple decks, etc.
    Public Property UnplayedCardsPile As New ObservableCollection(Of Card)
    '
    Private OneSecondTimer As Timers.Timer
    Private cardNumber As Integer
    '
    '====================================================================
    '
#Region "Constructors"
    Public Sub New()
        Try

            ' This call is required by the designer.
            InitializeComponent()

            Me.DesiredHeight = 500
            Me.DesiredWidth = 600

            '
            ' create the dealer
            '
            Me.TheDealer = New Dealer(Me, Me.DesiredWidth)
            'TheDealer.ScreenWidthX = CardTable.ActualWidth
            'TheDealer.ScreenWidthX = Me.DesiredWidth
            'Me.TheDealer.AllCards.CreateDeck()
            'Me.TheDealer.AllCards.ShuffleCards(1)
            Me.TheDealer.DealNewGame()
            ' Add any initialization after the InitializeComponent() call.
            Me.Measure(New Size(Double.PositiveInfinity, Double.PositiveInfinity))
            Me.Arrange(New Rect(0, 0, Me.DesiredWidth, Me.DesiredHeight))
            '
            ' create pile structures
            '
            Me.AddChild(Foundation1Pile)
            MyBase.AddChild(Foundation1Pile)
            MyBase.AddChild(Foundation2Pile)
            MyBase.AddChild(Foundation3Pile)
            MyBase.AddChild(Foundation4Pile)
            MyBase.AddChild(DiscardPile)
            MyBase.AddChild(DrawPile)
            MyBase.AddChild(Tableau1Pile)
            MyBase.AddChild(Tableau2Pile)
            MyBase.AddChild(Tableau3Pile)
            MyBase.AddChild(Tableau4Pile)
            MyBase.AddChild(Tableau5Pile)
            MyBase.AddChild(Tableau6Pile)
            MyBase.AddChild(Tableau7Pile)
            MyBase.AddChild(UnplayedCardsPile)
            '
            '
            '

            '
            Me.Setup()
            '
        Catch ex As Exception
            Dim methodName As String = "New"
            Debug.WriteLine(methodName & "() exception.Message: " & ex.Message)
            Debug.WriteLine(methodName & "() exception.ToString: " & ex.ToString)
            Debug.WriteLine(methodName & "() exception.StackTrace: " & ex.StackTrace)
        End Try
    End Sub
    Private Sub Setup()
        Debug.WriteLine("in Setup()")
        Try

            '
            ' create the deck
            '
            Me.TheDeck = New Deck(CardStyle.Traditional)
            '
            ' create the dealer
            '
            Me.TheDealer = New Dealer(Me, Me.DesiredWidth)
            'TheDealer.ScreenWidthX = CardTable.ActualWidth
            'TheDealer.ScreenWidthX = Me.DesiredWidth
            'Me.TheDealer.AllCards.CreateDeck()
            'Me.TheDealer.AllCards.ShuffleCards(1)
            Me.TheDealer.DealNewGame()


            '
            '=========================================================================
            ' Me.cardNumber = 2
            Me.OneSecondTimer = New Timers.Timer(1000.0)
            AddHandler Me.OneSecondTimer.Elapsed, AddressOf Me.SecondTimer
            '=========================================================================
            '
            Debug.WriteLine("end Setup()")
            '
        Catch ex As Exception
            Dim methodName As String = "Setup"
            Debug.WriteLine(methodName & "() exception.Message: " & ex.Message)
            Debug.WriteLine(methodName & "() exception.ToString: " & ex.ToString)
            Debug.WriteLine(methodName & "() exception.StackTrace: " & ex.StackTrace)
        End Try
    End Sub
#End Region
#Region "Timers"
    Public Sub SecondTimer(e As Object, eArgs As System.Timers.ElapsedEventArgs)
        '
        If Me.cardNumber = 11 Then
            Me.cardNumber = 2
        End If

        Dim c As New Card
        c.Left = 100
        c.Top = 150
        c.Height = 300
        c.Width = 300
        c.Source = String.Format("images/{0}_of_diamnds.png")
        Me.TheDeck.Add(c)

        Me.cardNumber += 1
    End Sub
#End Region
#Region "Events"
    Private Sub CardTable_SizeChanged(sender As Object, e As SizeChangedEventArgs) Handles MainWindow.SizeChanged
        Try

            '
            ' need to reposition the cards, and resize
            '
            Me.TheDealer.ScreenWidthX = CInt(MainWindow.ActualWidth)
            Me.TheDealer.RefreshLayout()

        Catch ex As Exception
            Dim methodName As String = "CardTable_SizeChanged"
            Debug.WriteLine(methodName & "() exception.Message: " & ex.Message)
            Debug.WriteLine(methodName & "() exception.ToString: " & ex.ToString)
            Debug.WriteLine(methodName & "() exception.StackTrace: " & ex.StackTrace)
        End Try
    End Sub

    Private Sub MenuItem_Click(sender As Object, e As RoutedEventArgs)
        Try




        Catch ex As Exception
            Dim methodName As String = "MenuItem_Click"
            Debug.WriteLine(methodName & "() exception.Message: " & ex.Message)
            Debug.WriteLine(methodName & "() exception.ToString: " & ex.ToString)
            Debug.WriteLine(methodName & "() exception.StackTrace: " & ex.StackTrace)
        End Try
    End Sub
#End Region
End Class
