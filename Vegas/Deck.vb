Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.Data.Entity.Core.Mapping
Imports System.Data.Entity.ModelConfiguration

Interface IDeck
    Property Style As Enums.CardStyle
End Interface
Public Class Deck
    Inherits ObservableCollection(Of Card)
    '
#Region "Constructors"
    Public Sub New()
        Me.Style = CardStyle.Traditional
        Me.Setup()
    End Sub
    Public Sub New(Optional Style As CardStyle = CardStyle.Traditional)
        Me.Style = Style
        Me.Setup()
    End Sub
    Private Sub Setup()

    End Sub
#End Region
#Region "Properties"
    Public Property Style As Enums.CardStyle
#End Region
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
#Region "Using The Cards"
  
   

    Public Sub Deal1Card()

        MsgBox("in Deal1Card")

    End Sub
#End Region
End Class
'Public Class DeckConfiguration
'    Inherits EntityTypeConfiguration(Of Deck)
'    Sub New()
'        'Dim strategy As System.Data.Entity.IDatabaseInitializer(Of vASASysContext)
'        'strategy = New System.Data.Entity.NullDatabaseInitializer(Of vASASysContext)
'        'Database.SetInitializer(strategy)
'        '
'        With Me.Property(Function(a) a.DeckId)
'            .HasDatabaseGeneratedOption(Schema.DatabaseGeneratedOption.Identity)
'        End With
'        With Me.Property(Function(d) d.Style)
'            .IsOptional()
'        End With
'        With Me.Property(Function(d) d.Style)
'            .IsOptional()
'        End With
'        'With Me.Property(Function(a) a.LastUpdated)
'        '    '.HasDatabaseGeneratedOption(Schema.DatabaseGeneratedOption.Computed)
'        '    .HasColumnType("datetime2")
'        '    .HasPrecision(7)
'        '    .IsOptional()
'        'End With
'    End Sub
'End Class