Public Class frmCrazyEights
    Dim objdeckofCards As New DeckofCards
    Dim upCard As Card
    Dim turncounter As Integer
    Dim drawCount As Integer
    Dim aLPlayer1Hand As New ArrayList
    Dim aLPlayer2Hand As New ArrayList


    'this code modified from a stackoverflow page
    'http://stackoverflow.com/questions/18676/random-int-in-vb-net
    Public Function GetRandom() As Integer
        Dim generator As System.Random = New System.Random()
        Return generator.Next(0, objdeckofCards.Count)

    End Function

    Private Sub BuildDeck(cardValue As Integer, suit As String)
        Dim addedcard As Card

        addedcard.cardValue = cardValue
        addedcard.suit = suit

        objdeckofCards.Build(addedcard)

    End Sub
    Public Sub RefreshPlayerHand()
        lstP1Hand.Items.Clear()
        lstP2Hand.Items.Clear()
        For Each item In aLPlayer1Hand
            lstP1Hand.Items.Add(item)
        Next
        For Each item In aLPlayer2Hand
            lstP2Hand.Items.Add(item)
        Next

    End Sub

    Private Sub Player1Turn()
        lstP1Hand.Visible = True
        btnP1Draw.Visible = True
        btnP1Play.Visible = True
        btnStartPlayer.Visible = False
        lstSuits.Visible = False
        btnSetSuit.Visible = False
        RefreshPlayerHand()
    End Sub

    Private Sub Player2Turn()
        lstP2Hand.Visible = True
        btnP2Draw.Visible = True
        btnP2Play.Visible = True
        btnStartPlayer.Visible = False
        lstSuits.Visible = False
        btnSetSuit.Visible = False
        RefreshPlayerHand()
    End Sub

    Private Sub BetweenTurns()
        lstP1Hand.Visible = False
        lstP2Hand.Visible = False
        btnP1Draw.Visible = False
        btnP1Play.Visible = False
        btnP2Draw.Visible = False
        btnP2Play.Visible = False
        btnP1EndTurn.Visible = False
        btnP2EndTurn.Visible = False
        btnStartPlayer.Text = "Start player" & turncounter & "'s turn"
        btnStartPlayer.Visible = True
        RefreshPlayerHand()
        If aLPlayer1Hand.Count = 0 Or aLPlayer2Hand.Count = 0 Then
            Win()
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim suitsArray As Array = {"Clubs", "Spades", "Diamonds", "Hearts"}
        for counter as integer = 1 to 13
            For Each suit In suitsArray
                BuildDeck(counter, CStr(suit))
            Next
        Next


        'deal cards to each user
        For i As Integer = 0 To 6
            Dim index As Integer = GetRandom()
            aLPlayer1Hand.Add(CType(objdeckofCards(index), Card))
            objdeckofCards.RemoveAt(index)
            index = GetRandom()
            aLPlayer2Hand.Add(CType(objdeckofCards(index), Card))
            objdeckofCards.RemoveAt(index)
        Next

        Dim secondIndex As Integer = GetRandom()
        upCard = objdeckofCards(secondIndex)
        objdeckofCards.RemoveAt(secondIndex)
        txtFaceUp.Text = upCard.ToString
        turncounter = 1
        BetweenTurns()
    End Sub

    Public ReadOnly Property selectedCardP1() As Card
        Get
            If lstP1Hand.SelectedIndex <> -1 Then
                Return CType(aLPlayer1Hand(lstP1Hand.SelectedIndex), Card)
            End If
        End Get
    End Property

    Public ReadOnly Property selectedCardP2() As Card
        Get
            If lstP2Hand.SelectedIndex <> -1 Then
                Return CType(aLPlayer2Hand(lstP2Hand.SelectedIndex), Card)
            End If
        End Get
    End Property

    Public ReadOnly Property selectedSuit() As Card
        Get
            If lstP2Hand.SelectedIndex <> -1 Then
                Return CType(lstP2Hand.Items(lstP2Hand.SelectedIndex), Card)
            End If
        End Get
    End Property

    Private Sub btnP1Play_Click(sender As Object, e As EventArgs) Handles btnP1Play.Click
        lblError.Visible = False
        If lstP1Hand.SelectedIndex <> -1 Then
            If selectedCardP1.cardValue = 8 Then
                upCard = selectedCardP1
                txtFaceUp.Text = upCard.ToString
                aLPlayer1Hand.Remove(selectedCardP1)
                If aLPlayer1Hand.Count > 0 Then
                    callSuit()
                    turncounter = 2
                Else
                    BetweenTurns()
                End If
            ElseIf upCard.suit = selectedCardP1.suit Or upCard.cardValue = selectedCardP1.cardValue Then
                upCard = selectedCardP1
                txtFaceUp.Text = upCard.ToString
                aLPlayer1Hand.Remove(selectedCardP1)
                BetweenTurns()
            Else
                lblError.Text = "Try another card or click draw card"
                lblError.Visible = True
            End If
        Else
            lblError.Text = "Select a card to play"
            lblError.Visible = True
        End If
    End Sub

    Private Sub callSuit()
        Dim wildCard As Card
        If lstSuits.SelectedIndex = 0 Then
            wildCard.suit = "Clubs"
            wildCard.cardValue = 8
            txtFaceUp.Text = CType(wildCard, Card).ToString
        ElseIf lstSuits.SelectedIndex = 1 Then
            wildCard.suit = "Spades"
            wildCard.cardValue = 8
            txtFaceUp.Text = CType(wildCard, Card).ToString
        ElseIf lstSuits.SelectedIndex = 2 Then
            wildCard.suit = "Diamonds"
            wildCard.cardValue = 8
            txtFaceUp.Text = CType(wildCard, Card).ToString
        ElseIf lstSuits.SelectedIndex = 3 Then
            wildCard.suit = "Hearts"
            wildCard.cardValue = 8
            txtFaceUp.Text = CType(wildCard, Card).ToString
        End If
        upCard = wildCard
        lstSuits.Visible = True
        btnSetSuit.Visible = True
    End Sub

    Private Sub btnP1Draw_Click(sender As Object, e As EventArgs) Handles btnP1Draw.Click
        Dim drawCard As Card
        If drawCount < 2 Then
            Dim index As Integer = GetRandom()

            drawCard = objdeckofCards(index)

            aLPlayer1Hand.Add(drawCard)
            objdeckofCards.RemoveAt(index)
            drawCount = drawCount + 1
        Else
            Dim index As Integer = GetRandom()

            drawCard = objdeckofCards(index)
            aLPlayer1Hand.Add(drawCard)
            objdeckofCards.RemoveAt(index)
            btnP1Draw.Visible = False
            btnP1EndTurn.Visible = True
            turncounter = 2
            drawCount = 0
        End If
        RefreshPlayerHand()
    End Sub

    Private Sub btnStartPlayer_Click(sender As Object, e As EventArgs) Handles btnStartPlayer.Click
        If turncounter = 1 Then
            Player1Turn()
            turncounter = 2
        ElseIf turncounter = 2 Then
            Player2Turn()
            turncounter = 1
        End If
    End Sub

    Private Sub btnP1EndTurn_Click(sender As Object, e As EventArgs) Handles btnP1EndTurn.Click
        turncounter = 2
        BetweenTurns()
    End Sub

    Private Sub btnP2Draw_Click(sender As Object, e As EventArgs) Handles btnP2Draw.Click
        Dim drawCard As Card
        If drawCount < 2 Then
            Dim index As Integer = GetRandom()

            drawCard = objdeckofCards(index)
            aLPlayer2Hand.Add(drawCard)
            objdeckofCards.RemoveAt(index)
            drawCount = drawCount + 1
        Else
            Dim index As Integer = GetRandom()

            drawCard = objdeckofCards(index)
            aLPlayer2Hand.Add(drawCard)
            objdeckofCards.RemoveAt(index)
            btnP2Draw.Visible = False
            btnP2EndTurn.Visible = True
            turncounter = 1
            drawCount = 0
        End If
        RefreshPlayerHand()
    End Sub

    Private Sub btnP2Play_Click(sender As Object, e As EventArgs) Handles btnP2Play.Click
        If lstP2Hand.SelectedIndex <> -1 Then
            lblError.Visible = False
            If selectedCardP2.cardValue = 8 Then
                upCard = selectedCardP2
                txtFaceUp.Text = upCard.ToString
                aLPlayer2Hand.Remove(selectedCardP2)
                If aLPlayer1Hand.Count > 0 Then
                    callSuit()
                    turncounter = 1
                Else
                    BetweenTurns()
                End If
            ElseIf upCard.suit = selectedCardP2.suit Or upCard.cardValue = selectedCardP2.cardValue Then
                upCard = selectedCardP2
                txtFaceUp.Text = upCard.ToString
                aLPlayer2Hand.Remove(selectedCardP2)
                BetweenTurns()
            Else
                lblError.Text = "Try another card or click draw card"
                lblError.Visible = True
            End If
        Else
            lblError.Text = "Select a card to play"
            lblError.Visible = True
        End If
        BetweenTurns()
    End Sub

    Private Sub btnP2EndTurn_Click(sender As Object, e As EventArgs) Handles btnP2EndTurn.Click
        turncounter = 1
        BetweenTurns()
    End Sub

    Private Sub Win()
        lstWin.Visible = True
        If turncounter = 1 Then
            For i As Integer = 0 To 25
                lstWin.Items.Add("Player 2 wins!")
            Next
        End If
        If turncounter = 2 Then
            For i As Integer = 0 To 25
                lstWin.Items.Add("player 1 wins!")
            Next
        End If
    End Sub

    Private Sub btnSetSuit_Click(sender As Object, e As EventArgs) Handles btnSetSuit.Click
        callSuit()
    End Sub
End Class
