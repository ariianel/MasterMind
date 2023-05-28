Public Class Accueil
    Private Sub Accueil_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Accueil"
        Dim nomsJoueurs As String() = Module1.GetNomsJoueurs() 'Récupère tous les joueurs 
        Dim nomsJ As String() = Module1.GetNomsJoueurs()

        'BOUTON REJOUER
        Button4.Visible = False

        'mets à jours les jours dans notres ComboBox
        ComboBox1.DataSource = nomsJoueurs
        ComboBox2.DataSource = nomsJ

        ComboBox1.SelectedIndex = -1 ' Désélectionne l'élément sélectionné
        ComboBox2.SelectedIndex = -1

        ' Timer1.Start()
        ' Timer1_Tick(sender, e)


    End Sub

    Public Sub VerifierNomsJoueurs()
        'Vérif si les joueurs ont les mêmes prénoms
        If ComboBox1.Text.Trim() = "" Or ComboBox2.Text.Trim() = "" Or ComboBox1.Text.Trim() = ComboBox2.Text.Trim() Then
            MessageBox.Show("Les deux joueurs ne peuvent pas avoir le même nom.")
            ComboBox1.Text = ""
        Else

            Dim firstName As String = ComboBox1.Text.Trim()
            Dim secondName As String = ComboBox2.Text.Trim()

            Module1.nom1 = firstName
            Module1.nom2 = secondName

            'On enregistre nos deux joueurs temporairement dans un tableau
            ajout(firstName, 0, 0, 0, 0, 0)
            ajout(secondName, 0, 0, 0, 0, 0)


            'On peut lancer le deuxième formulaire
            Pattern.Show()
            Me.Hide()

        End If
    End Sub

    'BOUTON QUITTER
    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        VerifierNomsJoueurs()
        Dim joueur1Index As Integer = Array.FindIndex(tjoueurs, Function(joueur) joueur.nom = nom1)
        Dim joueur2Index As Integer = Array.FindIndex(tjoueurs, Function(joueur) joueur.nom = nom2)
        tjoueurs(joueur2Index).nbPartiesJoueur2 += 1
        tjoueurs(joueur1Index).nbPartiesJoueur1 += 1
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim joueur1Index As Integer = Array.FindIndex(tjoueurs, Function(joueur) joueur.nom = nom1)
        Dim joueur2Index As Integer = Array.FindIndex(tjoueurs, Function(joueur) joueur.nom = nom2)
        tjoueurs(joueur2Index).nbPartiesJoueur2 += 1
        tjoueurs(joueur1Index).nbPartiesJoueur1 += 1
        'On peut lancer le deuxième formulaire
        Pattern.Show()
        Me.Hide()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Accueil_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub OptionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OptionsToolStripMenuItem.Click
        Me.Hide()
        Options.Show()
    End Sub

    Private Sub ScoreToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ScoreToolStripMenuItem.Click
        Me.Hide()
        Score.Show()
    End Sub

    Private Sub QuitterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitterToolStripMenuItem.Click
        Dim result As DialogResult = MessageBox.Show("Voulez-vous vraiment quitter ?", "Confirmation", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            ' Code pour quitter l'application
            Application.Exit()
        End If
    End Sub

    Private Sub RèglesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RèglesToolStripMenuItem.Click
        Me.Hide()
        Regles.Show()
    End Sub
End Class
