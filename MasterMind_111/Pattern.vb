Public Class Pattern
    Private Sub Pattern_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Pattern à deviner" 'titre fenêtre
        Label3.Text = getCaractereATrouver()
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim valide As Integer = 0
        For Each txtBox As TextBox In Me.Controls.OfType(Of TextBox)()
            ' Effectuer une action pour chaque TextBox
            If txtBox.Text <> "#" AndAlso txtBox.Text <> "$" AndAlso txtBox.Text <> "£" AndAlso txtBox.Text <> "%" AndAlso txtBox.Text <> "@" Then
                MessageBox.Show("Caractère invalide dans la " & txtBox.Name)
                txtBox.Text = ""
            Else
                valide += 1
            End If

        Next

        If valide = 5 Then
            For i = 0 To 4
                ' On traite les caractères entrés
                Dim j As Integer = 0 ' Indice pour parcourir les TextBox
                For Each txtBox As TextBox In Me.Controls.OfType(Of TextBox)()
                    ' On enregistre la TextBox dans le tableau caracteresATrouver à la position i
                    If j = i Then
                        Module1.caracteresATrouver(i) = txtBox.Text
                        Exit For ' Sortir de la boucle après avoir trouvé la TextBox correspondante
                    End If
                    j += 1
                Next
            Next
            'On exécute le troisième formulaire 
            Me.Hide()
            Game.Show()
        End If

        ' Réinitialise le contenu des TextBox
        For Each txtBox As TextBox In Me.Controls.OfType(Of TextBox)()
            txtBox.Text = ""
        Next

    End Sub
End Class