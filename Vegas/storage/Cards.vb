Imports System.Collections.ObjectModel



Public Class Cards
    Inherits ObservableCollection(Of Card)

    Public Sub New()
        MyBase.Add(New Card() With {.Left = 50, .Top = 50, .Width = 200, .Height = 200, .Source = "images/3_of_clubs.png"})
        MyBase.Add(New Card() With {.Left = 150, .Top = 150, .Width = 150, .Height = 150, .Source = "images/4_of_clubs.png"})
        MyBase.Add(New Card() With {.Left = 250, .Top = 250, .Width = 100, .Height = 100, .Source = "images/5_of_clubs.png"})
        MyBase.Add(New Card() With {.Left = 350, .Top = 350, .Width = 75, .Height = 75, .Source = "images/6_of_clubs.png"})
    End Sub

End Class


