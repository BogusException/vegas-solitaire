Public Module Enums

    '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    '
    ' Enums
    '
    Public Enum CardSuit
        Clubs = 1 ' ODD
        Diamonds = 2 ' EVEN
        Hearts = 3 ' ODD
        Spades = 4 ' EVEN
    End Enum

    Public Enum CardColor
        Black ' ODD cardsuits are black
        Red ' EVEN card suits are red
    End Enum

    Public Enum CardValue
        Ace = 1
        Two = 2
        Three = 3
        Four = 4
        Five = 5
        Six = 6
        Seven = 7
        Eight = 8
        Nine = 9
        Ten = 10
        Jack = 11
        Queen = 12
        King = 13
    End Enum

    Public Enum CardStack
        Draw ' draw from
        Discard ' discard pile next to draw pile
        Foundation1 ' left
        Foundation2
        Foundation3
        Foundation4 'right
        Tableau1 ' left
        Tableau2
        Tableau3
        Tableau4
        Tableau5
        Tableau6
        Tableau7 ' right
    End Enum

    Public Enum CardStyle
        Simple
        Traditional
    End Enum

End Module
