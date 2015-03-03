Public Class DeckofCards
    Inherits CollectionBase

    Public Sub Build(NewCard As Card)
        'adds a new card to the collection
        Me.List.Add(NewCard)
    End Sub

    Public Sub deal(deltCard As Card)
        'removes a card from the collection
        Me.List.Remove(deltCard)
    End Sub

    'defines how to get and set an item based on an index number
    Default Public Property Item(index As Integer) As Card
        Get
            Return CType(Me.List.Item(index), Card)
        End Get
        Set(value As Card)
            Me.List.Item(index) = value
        End Set
    End Property

End Class
