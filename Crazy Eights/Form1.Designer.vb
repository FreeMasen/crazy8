<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCrazyEights
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lstP1Hand = New System.Windows.Forms.ListBox()
        Me.lstP2Hand = New System.Windows.Forms.ListBox()
        Me.btnP1Play = New System.Windows.Forms.Button()
        Me.btnP1Draw = New System.Windows.Forms.Button()
        Me.btnP2Draw = New System.Windows.Forms.Button()
        Me.btnP2Play = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFaceUp = New System.Windows.Forms.TextBox()
        Me.lblError = New System.Windows.Forms.Label()
        Me.btnStartPlayer = New System.Windows.Forms.Button()
        Me.btnP1EndTurn = New System.Windows.Forms.Button()
        Me.btnP2EndTurn = New System.Windows.Forms.Button()
        Me.lstSuits = New System.Windows.Forms.ListBox()
        Me.btnSetSuit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lstP1Hand
        '
        Me.lstP1Hand.FormattingEnabled = True
        Me.lstP1Hand.ItemHeight = 20
        Me.lstP1Hand.Location = New System.Drawing.Point(12, 12)
        Me.lstP1Hand.Name = "lstP1Hand"
        Me.lstP1Hand.Size = New System.Drawing.Size(255, 384)
        Me.lstP1Hand.TabIndex = 0
        '
        'lstP2Hand
        '
        Me.lstP2Hand.FormattingEnabled = True
        Me.lstP2Hand.ItemHeight = 20
        Me.lstP2Hand.Location = New System.Drawing.Point(617, 12)
        Me.lstP2Hand.Name = "lstP2Hand"
        Me.lstP2Hand.Size = New System.Drawing.Size(286, 384)
        Me.lstP2Hand.TabIndex = 2
        Me.lstP2Hand.Visible = False
        '
        'btnP1Play
        '
        Me.btnP1Play.Location = New System.Drawing.Point(12, 402)
        Me.btnP1Play.Name = "btnP1Play"
        Me.btnP1Play.Size = New System.Drawing.Size(101, 31)
        Me.btnP1Play.TabIndex = 3
        Me.btnP1Play.Text = "Play Card"
        Me.btnP1Play.UseVisualStyleBackColor = True
        '
        'btnP1Draw
        '
        Me.btnP1Draw.Location = New System.Drawing.Point(166, 402)
        Me.btnP1Draw.Name = "btnP1Draw"
        Me.btnP1Draw.Size = New System.Drawing.Size(101, 31)
        Me.btnP1Draw.TabIndex = 4
        Me.btnP1Draw.Text = "Draw Card"
        Me.btnP1Draw.UseVisualStyleBackColor = True
        '
        'btnP2Draw
        '
        Me.btnP2Draw.Location = New System.Drawing.Point(802, 402)
        Me.btnP2Draw.Name = "btnP2Draw"
        Me.btnP2Draw.Size = New System.Drawing.Size(101, 31)
        Me.btnP2Draw.TabIndex = 7
        Me.btnP2Draw.Text = "Draw Card"
        Me.btnP2Draw.UseVisualStyleBackColor = True
        Me.btnP2Draw.Visible = False
        '
        'btnP2Play
        '
        Me.btnP2Play.Location = New System.Drawing.Point(623, 402)
        Me.btnP2Play.Name = "btnP2Play"
        Me.btnP2Play.Size = New System.Drawing.Size(101, 31)
        Me.btnP2Play.TabIndex = 6
        Me.btnP2Play.Text = "Play Card"
        Me.btnP2Play.UseVisualStyleBackColor = True
        Me.btnP2Play.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 483)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 20)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Player 1 Score"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(613, 483)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(111, 20)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Player 2 Score"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(129, 483)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 20)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Label3"
        Me.Label3.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(730, 483)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 20)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Label4"
        Me.Label4.Visible = False
        '
        'txtFaceUp
        '
        Me.txtFaceUp.Location = New System.Drawing.Point(298, 12)
        Me.txtFaceUp.Name = "txtFaceUp"
        Me.txtFaceUp.Size = New System.Drawing.Size(286, 26)
        Me.txtFaceUp.TabIndex = 15
        '
        'lblError
        '
        Me.lblError.AutoSize = True
        Me.lblError.Location = New System.Drawing.Point(294, 58)
        Me.lblError.Name = "lblError"
        Me.lblError.Size = New System.Drawing.Size(57, 20)
        Me.lblError.TabIndex = 16
        Me.lblError.Text = "Label5"
        Me.lblError.Visible = False
        '
        'btnStartPlayer
        '
        Me.btnStartPlayer.Location = New System.Drawing.Point(298, 373)
        Me.btnStartPlayer.Name = "btnStartPlayer"
        Me.btnStartPlayer.Size = New System.Drawing.Size(286, 60)
        Me.btnStartPlayer.TabIndex = 17
        Me.btnStartPlayer.Text = "Start next Player's turn"
        Me.btnStartPlayer.UseVisualStyleBackColor = True
        '
        'btnP1EndTurn
        '
        Me.btnP1EndTurn.Location = New System.Drawing.Point(166, 402)
        Me.btnP1EndTurn.Name = "btnP1EndTurn"
        Me.btnP1EndTurn.Size = New System.Drawing.Size(101, 31)
        Me.btnP1EndTurn.TabIndex = 18
        Me.btnP1EndTurn.Text = "End Turn"
        Me.btnP1EndTurn.UseVisualStyleBackColor = True
        '
        'btnP2EndTurn
        '
        Me.btnP2EndTurn.Location = New System.Drawing.Point(802, 402)
        Me.btnP2EndTurn.Name = "btnP2EndTurn"
        Me.btnP2EndTurn.Size = New System.Drawing.Size(101, 31)
        Me.btnP2EndTurn.TabIndex = 19
        Me.btnP2EndTurn.Text = "End Turn"
        Me.btnP2EndTurn.UseVisualStyleBackColor = True
        Me.btnP2EndTurn.Visible = False
        '
        'lstSuits
        '
        Me.lstSuits.FormattingEnabled = True
        Me.lstSuits.ItemHeight = 20
        Me.lstSuits.Items.AddRange(New Object() {"Clubs", "Spades", "Diamonds", "Hearts"})
        Me.lstSuits.Location = New System.Drawing.Point(298, 81)
        Me.lstSuits.Name = "lstSuits"
        Me.lstSuits.Size = New System.Drawing.Size(286, 104)
        Me.lstSuits.TabIndex = 20
        Me.lstSuits.Visible = False
        '
        'btnSetSuit
        '
        Me.btnSetSuit.Location = New System.Drawing.Point(298, 191)
        Me.btnSetSuit.Name = "btnSetSuit"
        Me.btnSetSuit.Size = New System.Drawing.Size(286, 35)
        Me.btnSetSuit.TabIndex = 21
        Me.btnSetSuit.Text = "Set Suit"
        Me.btnSetSuit.UseVisualStyleBackColor = True
        Me.btnSetSuit.Visible = False
        '
        'frmCrazyEights
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1013, 553)
        Me.Controls.Add(Me.btnSetSuit)
        Me.Controls.Add(Me.lstSuits)
        Me.Controls.Add(Me.btnStartPlayer)
        Me.Controls.Add(Me.lblError)
        Me.Controls.Add(Me.txtFaceUp)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnP2Draw)
        Me.Controls.Add(Me.btnP2Play)
        Me.Controls.Add(Me.btnP1Draw)
        Me.Controls.Add(Me.btnP1Play)
        Me.Controls.Add(Me.lstP2Hand)
        Me.Controls.Add(Me.lstP1Hand)
        Me.Controls.Add(Me.btnP2EndTurn)
        Me.Controls.Add(Me.btnP1EndTurn)
        Me.Name = "frmCrazyEights"
        Me.Text = "Crazy Eights"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstP1Hand As System.Windows.Forms.ListBox
    Friend WithEvents lstP2Hand As System.Windows.Forms.ListBox
    Friend WithEvents btnP1Play As System.Windows.Forms.Button
    Friend WithEvents btnP1Draw As System.Windows.Forms.Button
    Friend WithEvents btnP2Draw As System.Windows.Forms.Button
    Friend WithEvents btnP2Play As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFaceUp As System.Windows.Forms.TextBox
    Friend WithEvents lblError As System.Windows.Forms.Label
    Friend WithEvents btnStartPlayer As System.Windows.Forms.Button
    Friend WithEvents btnP1EndTurn As System.Windows.Forms.Button
    Friend WithEvents btnP2EndTurn As System.Windows.Forms.Button
    Friend WithEvents lstSuits As System.Windows.Forms.ListBox
    Friend WithEvents btnSetSuit As System.Windows.Forms.Button

End Class
