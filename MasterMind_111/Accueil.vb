Public Class Accueil
    Private Sub Accueil_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim nomsJoueurs As String() = Module1.GetNomsJoueurs() 'Récupère tous les joueurs 

        'mets à jours les jours dans notres ComboBox
        ComboBox1.DataSource = nomsJoueurs
        ComboBox2.DataSource = nomsJoueurs

        ComboBox1.SelectedIndex = -1 ' Désélectionne l'élément sélectionné
        ComboBox2.SelectedIndex = -1
    End Sub

    Private Sub VerifierNomsJoueurs()
        'Vérif si les joueurs ont les mêmes prénoms
        If ComboBox1.Text.Trim() <> "" AndAlso ComboBox2.Text.Trim() <> "" AndAlso ComboBox1.Text.Trim() = ComboBox2.Text.Trim() Then
            MessageBox.Show("Les deux joueurs ne peuvent pas avoir le même nom.")
            ComboBox1.Text = ""
        Else
            'Si les deux prénoms sont différents
            Dim nom1 As String = ComboBox2.Text.Trim()
            Dim nom2 As String = ComboBox1.Text.Trim()

            'On enregistre le Prenom temporairement dans une liste
            For i = 0 To Module1.nbJoueurs
                Module1.newJoueurs.Add(nom1)
                Module1.newJoueurs.Add(nom2)

            Next

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
End Class
