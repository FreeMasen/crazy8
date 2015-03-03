Public Class frmCrazyEights
    'defines our deck of cards collection object
    Dim objdeckofCards As New DeckofCards
    'defines our face up card object
    Dim upCard As Card
    'holds who's turn it is
    Dim turncounter As Integer
    'counts how many times a player has clicked draw
    Dim drawCount As Integer
    'defines our player hands as an arraylist
    Dim aLPlayer1Hand As New ArrayList
    Dim aLPlayer2Hand As New ArrayList


    'this code modified from a stackoverflow page generates a random number
    'http://stackoverflow.com/questions/18676/random-int-in-vb-net
    Public Function GetRandom() As Integer
        Dim generator As System.Random = New System.Random()
        Return generator.Next(0, objdeckofCards.Count)

    End Function

    'defines the method for adding a card to our deck collection object
    Private Sub BuildDeck(cardValue As Integer, suit As String)
        Dim addedcard As Card

        addedcard.cardValue = cardValue
        addedcard.suit = suit

        objdeckofCards.Build(addedcard)

    End Sub

    'this method refreshes both lstboxes that show a players hand to keep them in line
    'with the arraylist of a player's hand
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

    'sets the visual aspect of a player1 turn
    Private Sub Player1Turn()
        lstP1Hand.Visible = True
        btnP1Draw.Visible = True
        btnP1Play.Visible = True
        btnStartPlayer.Visible = False
        lstSuits.Visible = False
        btnSetSuit.Visible = False
        RefreshPlayerHand()
    End Sub

    'sets the visual aspect of a player 2 turn
    Private Sub Player2Turn()
        lstP2Hand.Visible = True
        btnP2Draw.Visible = True
        btnP2Play.Visible = True
        btnStartPlayer.Visible = False
        lstSuits.Visible = False
        btnSetSuit.Visible = False
        RefreshPlayerHand()
    End Sub

    'sets the visual aspect of the form between player turns
    'this mehtod also check for if a player has won
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
        'if either player runs out of cards, call the win sub
        If aLPlayer1Hand.Count = 0 Or aLPlayer2Hand.Count = 0 Then
            Win()
        End If
    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'when the form loads generate an array of the 4 suits
        Dim suitsArray As Array = {"Clubs", "Spades", "Diamonds", "Hearts"}
        'loop over our card values 1 though 13
        For counter As Integer = 1 To 13
            'for each value loop over the array of suits
            For Each suit In suitsArray
                'add a card to the deck with the value and suit of the loops
                BuildDeck(counter, CStr(suit))
            Next
        Next

        'deal cards to each user, players get 7 cards each
        For i As Integer = 0 To 6
            'get a random integer based on the size of the deck
            Dim index As Integer = GetRandom()
            'add a card from a random location in the deck to player1's hand
            aLPlayer1Hand.Add(CType(objdeckofCards(index), Card))
            'remove the card from the deck
            objdeckofCards.RemoveAt(index)
            'get a new random number
            index = GetRandom()
            'add a card from a random location in the deck to player1's hand
            aLPlayer2Hand.Add(CType(objdeckofCards(index), Card))
            'remove that card from the deck
            objdeckofCards.RemoveAt(index)
        Next
        'after the cards have been delt, get another random number
        Dim secondIndex As Integer = GetRandom()
        'set the face up card to the card at the random position
        upCard = objdeckofCards(secondIndex)
        'remove that card from the deck
        objdeckofCards.RemoveAt(secondIndex)
        'set the txtbox that show what card is face up to display this card
        txtFaceUp.Text = upCard.ToString
        'set the turn counter to player 1's turn
        turncounter = 1
        'show the players the between turns screen
        BetweenTurns()
    End Sub
    'the next 4 properties are definitions of a card selected based on the index of 
    'the specific list box choosen.
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

    'when player 1 clicks his/her play button
    Private Sub btnP1Play_Click(sender As Object, e As EventArgs) Handles btnP1Play.Click
        'make sure the error lable is not seen
        lblError.Visible = False
        'if the index is not not selected
        If lstP1Hand.SelectedIndex <> -1 Then
            'if the card value is an 8
            If selectedCardP1.cardValue = 8 Then
                'set the upcard to the card this player played
                upCard = selectedCardP1
                'set the text box to match
                txtFaceUp.Text = upCard.ToString
                'remove the card from the player's hand
                aLPlayer1Hand.Remove(selectedCardP1)
                'if the player still has cards
                If aLPlayer1Hand.Count > 0 Then
                    'call the call suit method to define the suit for player2
                    callSuit()
                    'set the turn counter to player 2's turn
                    turncounter = 2
                Else
                    'otherwise show the between turns
                    BetweenTurns()
                End If
                'if the card suit or value match that of the upcard
            ElseIf upCard.suit = selectedCardP1.suit Or upCard.cardValue = selectedCardP1.cardValue Then
                'set the upcard to the card selected by player1
                upCard = selectedCardP1
                'set the textbox to match
                txtFaceUp.Text = upCard.ToString
                'remove the card from the player hand
                aLPlayer1Hand.Remove(selectedCardP1)
                'show the between turns screen
                BetweenTurns()
            Else
                'if the user is not playing a valid card show this error message
                lblError.Text = "Try another card or click draw card"
                lblError.Visible = True
            End If
        Else
            'if the player has not selected a card, show this error message
            lblError.Text = "Select a card to play"
            lblError.Visible = True
        End If
    End Sub

    'this method defines a wildcard item to replace the upcard when a player plays an 8
    Private Sub callSuit()
        Dim wildCard As Card
        'show the box for the user to select their suit
        lstSuits.Visible = True
        'show the button for that selection
        btnSetSuit.Visible = True
        'test the user selection agains the returned suit
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
        'update the upcard to the wildcard
        upCard = wildCard
    End Sub

    'when player 1 click the draw button
    Private Sub btnP1Draw_Click(sender As Object, e As EventArgs) Handles btnP1Draw.Click
        'set the draw card variable as a card
        Dim drawCard As Card
        'test if the user has reached the max draws (3)
        If drawCount < 2 Then
            'if not then get a random number
            Dim index As Integer = GetRandom()

            'select a card from that index in the deck
            drawCard = objdeckofCards(index)

            'add this card to the player's hand
            aLPlayer1Hand.Add(drawCard)
            'remove it from the deck of cards
            objdeckofCards.RemoveAt(index)
            'increase the draw count
            drawCount = drawCount + 1
        Else
            'if the user has reach the max
            'allow one more use of this button
            'get a random number
            Dim index As Integer = GetRandom()

            'select a card at that index
            drawCard = objdeckofCards(index)
            'add this item to the player's hand
            aLPlayer1Hand.Add(drawCard)
            'remove it from the deck
            objdeckofCards.RemoveAt(index)
            'remove the draw button from the screen
            btnP1Draw.Visible = False
            'repace it with the end turn button
            btnP1EndTurn.Visible = True
            'set the turncoutner to player 2's turn
            turncounter = 2
            'reset the draw count to 0
            drawCount = 0
        End If
        'refresh the player's hands
        RefreshPlayerHand()
    End Sub

    Private Sub btnStartPlayer_Click(sender As Object, e As EventArgs) Handles btnStartPlayer.Click
        'when the player clicks this test who's turn is next and show that screen
        If turncounter = 1 Then
            Player1Turn()
            turncounter = 2
        ElseIf turncounter = 2 Then
            Player2Turn()
            turncounter = 1
        End If
    End Sub

    'when the user clicks the end turn button set the playercount to player 2's turn
    Private Sub btnP1EndTurn_Click(sender As Object, e As EventArgs) Handles btnP1EndTurn.Click
        turncounter = 2
        BetweenTurns()
    End Sub

    'when player 2 clicks the draw button
    Private Sub btnP2Draw_Click(sender As Object, e As EventArgs) Handles btnP2Draw.Click
        'define a card to be drawn
        Dim drawCard As Card
        'test if the user has reached the max
        If drawCount < 2 Then
            'get a random number
            Dim index As Integer = GetRandom()
            'grab the card at that random number
            drawCard = objdeckofCards(index)
            'add it to the player's hand
            aLPlayer2Hand.Add(drawCard)
            'remove it from the deck
            objdeckofCards.RemoveAt(index)
            'add to the draw count
            drawCount = drawCount + 1
        Else
            'allow one last click of the draw card
            'get a random number
            Dim index As Integer = GetRandom()
            'select a crad to draw
            drawCard = objdeckofCards(index)
            'add this card to the player's hand
            aLPlayer2Hand.Add(drawCard)
            'remove the card from the deck
            objdeckofCards.RemoveAt(index)
            'remove the draw card from the screen
            btnP2Draw.Visible = False
            'add the end turn button to the screen
            btnP2EndTurn.Visible = True
            'set the turncoutner to player 1's turn
            turncounter = 1
            'reset the drawcounter
            drawCount = 0
        End If
        'refresh the player's hands
        RefreshPlayerHand()
    End Sub

    Private Sub btnP2Play_Click(sender As Object, e As EventArgs) Handles btnP2Play.Click
        'when the player clicks the player button, test for a non-selection
        If lstP2Hand.SelectedIndex <> -1 Then
            'set the error label to not visible
            lblError.Visible = False
            'test of the card is an 8
            If selectedCardP2.cardValue = 8 Then
                'set the up card to the 8 and remove it from the player's hand
                upCard = selectedCardP2
                txtFaceUp.Text = upCard.ToString
                aLPlayer2Hand.Remove(selectedCardP2)
                'if the player still has cards use the callsuit method for the user to select a new suit
                If aLPlayer1Hand.Count > 0 Then
                    callSuit()
                    turncounter = 1
                Else
                    'otherwise display the between turns screen
                    BetweenTurns()
                End If
                'if the player's card is not an 8 but is playable
            ElseIf upCard.suit = selectedCardP2.suit Or upCard.cardValue = selectedCardP2.cardValue Then
                'set the upcard to the played card and remove it from the screen and end the player's turn
                upCard = selectedCardP2
                txtFaceUp.Text = upCard.ToString
                aLPlayer2Hand.Remove(selectedCardP2)
                BetweenTurns()
            Else
                'if the card is not playble, show this error message
                lblError.Text = "Try another card or click draw card"
                lblError.Visible = True
            End If
        Else
            'if the user has nto selected a card, show this error message
            lblError.Text = "Select a card to play"
            lblError.Visible = True
        End If
        BetweenTurns()
    End Sub

    'when the user elects to end their turn set the turn counter to player 1's turn
    Private Sub btnP2EndTurn_Click(sender As Object, e As EventArgs) Handles btnP2EndTurn.Click
        turncounter = 1
        BetweenTurns()
    End Sub

    'if a player wins
    Private Sub Win()
        'show a winning message based on who's turn is just was
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

    'when a player clicks the button to set the suit, 
    Private Sub btnSetSuit_Click(sender As Object, e As EventArgs) Handles btnSetSuit.Click
        'call the callsuit method
        callSuit()
        'remove the lstbox of suits from the screen and the button
        lstSuits.Visible = False
        btnSetSuit.Visible = False
        BetweenTurns()
    End Sub
End Class
