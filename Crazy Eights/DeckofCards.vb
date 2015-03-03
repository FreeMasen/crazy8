Public Class DeckofCards
    Inherits CollectionBase

    Public Sub Build(NewCard As Card)
        Dim frontBack As Integer
        If frontBack = 0 Then
            Me.List.Insert(0, NewCard)
            frontBack = 1
        ElseIf frontBack = 1 Then
            Me.List.Insert(Me.List.Count, NewCard)
            frontBack = 0
        End If
    End Sub

    Public Sub deal(deltCard As Card)
        Me.List.Remove(deltCard)
    End Sub

    Default Public Property Item(index As Integer) As Card
        Get
            Return CType(Me.List.Item(index), Card)
        End Get
        Set(value As Card)
            Me.List.Item(index) = value
        End Set
    End Property

End Class
