Public Class Accueil
    Private Sub Accueil_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim nomsJoueurs As String() = Module1.GetNomsJoueurs() 'Récupère tous les joueurs 

        'BOUTON REJOUER
        Button4.Visible = False

        'mets à jours les jours dans notres ComboBox
        ComboBox1.DataSource = nomsJoueurs
        ComboBox2.DataSource = nomsJoueurs

        ComboBox1.SelectedIndex = -1 ' Désélectionne l'élément sélectionné
        ComboBox2.SelectedIndex = -1

        Timer1.Start()
        Timer1_Tick(sender, e)


    End Sub

    Private Sub VerifierNomsJoueurs()
        'Vérif si les joueurs ont les mêmes prénoms
        If ComboBox1.Text.Trim() <> "" AndAlso ComboBox2.Text.Trim() <> "" AndAlso ComboBox1.Text.Trim() = ComboBox2.Text.Trim() Then
            MessageBox.Show("Les deux joueurs ne peuvent pas avoir le même nom.")
            ComboBox1.Text = ""
        Else
            'Si les deux prénoms sont différents
            Dim firstName As String = ComboBox2.Text.Trim()
            Dim secondName As String = ComboBox1.Text.Trim()

            'On enregistre nos deux joueurs temporairement dans deux variables et un tableau
            Module1.nom1 = firstName
            Module1.nom2 = secondName
            Module1.ajout_ephemere(firstName, 0, 0, 0, 0, 0, secondName, 0, 0, 0, 0, 0)

            'On peut lancer le deuxième formulaire
            Pattern.Show()
            Me.Hide()

        End If
    End Sub

    'BOUTON QUITTER
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim result As DialogResult = MessageBox.Show("Voulez-vous vraiment quitter ?", "Confirmation", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            ' Code pour quitter l'application
            Application.Exit()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        VerifierNomsJoueurs()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'On peut lancer le deuxième formulaire
        Pattern.Show()
        Me.Hide()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Hide()
        Options.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Score.Show()
    End Sub
End Class
