Imports System.CodeDom
Imports System.Runtime.Versioning

Public Class Options

    Public newNbCoups As Integer = 15
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
            CJ(i) = GroupBox1.Controls(i).Text
        Next
        setCaractereATrouver(CJ(0), CJ(1), CJ(2), CJ(3), CJ(4))
        MessageBox.Show("Les caractères autorisés ont été définie avec succès.")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim couleur As DialogResult
        couleur = ColorDialog1.ShowDialog
        If couleur = Windows.Forms.DialogResult.OK Then
            Button2.BackgroundImage = Nothing ' Supprimer l'image d'arrière-plan du bouton
            Button2.BackColor = ColorDialog1.Color ' Définir la couleur de fond du bouton
            setColorAbsent(ColorDialog1.Color) ' Appeler la fonction pour définir la couleur d'absence
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim couleur As DialogResult
        couleur = ColorDialog2.ShowDialog
        If couleur = Windows.Forms.DialogResult.OK Then
            Button3.BackgroundImage = Nothing
            Button3.BackColor = ColorDialog2.Color
            setColorPresent(ColorDialog2.Color)
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim couleur As DialogResult
        couleur = ColorDialog3.ShowDialog
        If couleur = Windows.Forms.DialogResult.OK Then
            Button4.BackgroundImage = Nothing
            Button4.BackColor = ColorDialog3.Color
            setColorBienPlace(ColorDialog3.Color)
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        setTempsBool(False)
        MessageBox.Show("Le temps a été retiré avec succès.")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        setTime(TextBox6.Text)

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim chance As Integer = 0
        Integer.TryParse(TextBox7.Text.Trim(), chance)
        setNBChance(chance)
    End Sub

    Private Sub setNBChance(chances As Integer)
        newNbCoups = chances
        MessageBox.Show("Le nombre de chance à été mis à jour avec succès.")
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
        setCheminFichier(TextBox8.Text)
    End Sub
    Private Sub setTime(ByVal time As String)
        setTempsBool(True)
        ' Enregistrer le temps dans une variable globale
        setTempsImparti(Integer.Parse(time))
        ' Afficher un message de confirmation
        MessageBox.Show("Le temps imparti a été défini avec succès.")
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs)
        Me.Hide()
        Accueil.Show()
    End Sub


    Private Sub LinkLabel1_Click(sender As Object, e As EventArgs) Handles LinkLabel1.Click
        Me.Hide()
        Accueil.Show()
    End Sub

End Class