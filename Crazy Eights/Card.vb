Public Structure Card
    Dim cardValue As Integer

    Dim suit As String

    Public ReadOnly Property Name() As String
        Get
            Return cardValue & " " & suit
        End Get
    End Property

    Public Overrides Function ToString() As String
        If cardValue = 11 Then
            Return "Jack of " & suit
        ElseIf cardValue = 12 Then
            Return "Queen of " & suit
        ElseIf cardValue = 13 Then
            Return "King of " & suit
        ElseIf cardValue = 1 Then
            Return "Ace of " & suit
        Else
            Return cardValue & " " & suit
        End If
    End Function

End Structure
