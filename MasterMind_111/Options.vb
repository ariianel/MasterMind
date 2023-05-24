Public Class Options
    Private Sub Options_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Name = "Options"

        Dim a As String = ""
        Dim t As Char() = getCaracteres()

        For i As Integer = 0 To 4
            a &= t(4 - i)
        Next


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim CJ(5) As String
        For i As Integer = 0 To GroupBox1.Controls.Count - 1
            'CJ.Append(GroupBox1.Controls(i).Text)
            CJ(i) = GroupBox1.Controls(i).Text
        Next
        setCaractereATrouver(CJ(0), CJ(1), CJ(2), CJ(3), CJ(4))
        MessageBox.Show("Les caractères autorisés ont été définie avec succès.")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim couleur As DialogResult
        couleur = ColorDialog1.ShowDialog
        If couleur = Windows.Forms.DialogResult.OK Then
            Button2.BackColor = ColorDialog1.Color
            setcolorAbsent(ColorDialog1.Color)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim couleur As DialogResult
        couleur = ColorDialog2.ShowDialog
        If couleur = Windows.Forms.DialogResult.OK Then
            Button3.BackColor = ColorDialog2.Color
            setColorPresent(ColorDialog1.Color)
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim couleur As DialogResult
        couleur = ColorDialog3.ShowDialog
        If couleur = Windows.Forms.DialogResult.OK Then
            Button4.BackColor = ColorDialog3.Color
            setColorBienPlace(ColorDialog1.Color)
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        'stopChrono()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        setTime(TextBox6.Text)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        'setNBChance()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim fBrowser As New FolderBrowserDialog

        fBrowser.RootFolder = Environment.SpecialFolder.Desktop
        fBrowser.Description = "Sélectionnez un répertoire SVP"
        fBrowser.ShowDialog()

        If fBrowser.SelectedPath = String.Empty Then
            TextBox8.Text = "Pas de sélection"
        Else
            TextBox8.Text = fBrowser.SelectedPath
        End If
        fBrowser.Dispose()
        'setCheminFichier(textbox8.text)
    End Sub
    Private Sub setTime(ByVal time As String)

        ' Exemple : Enregistrer le temps dans une variable globale
        tempsImparti = Integer.Parse(time)
        ' Afficher un message de confirmation
        MessageBox.Show("Le temps imparti a été défini avec succès.")
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs)
        Me.Hide()
        Accueil.Show()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub LinkLabel1_Click(sender As Object, e As EventArgs) Handles LinkLabel1.Click
        Me.Hide()
        Accueil.Show()
    End Sub
End Class