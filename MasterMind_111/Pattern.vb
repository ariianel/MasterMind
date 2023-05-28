Public Class Pattern
    Private random As New Random()
    Private Sub Pattern_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Pattern à deviner" 'titre fenêtre
        Label3.Text = getCaracteresAutorise()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim valide As Integer = 0
        For Each txtBox As TextBox In Panel1.Controls.OfType(Of TextBox)()
            ' Effectuer une action pour chaque TextBox
            If txtBox.Text <> getCaractereAutoriseAtIndex(0) AndAlso txtBox.Text <> getCaractereAutoriseAtIndex(1) AndAlso txtBox.Text <> getCaractereAutoriseAtIndex(2) AndAlso txtBox.Text <> getCaractereAutoriseAtIndex(3) AndAlso txtBox.Text <> getCaractereAutoriseAtIndex(4) Then
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
                For Each txtBox As TextBox In Panel1.Controls.OfType(Of TextBox)()
                    ' On enregistre la TextBox dans le tableau caracteresATrouver à la position i
                    If j = i Then
                        Module1.caracteresATrouver(i) = txtBox.Text
                        MsgBox(caracteresATrouver)

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
        For Each txtBox As TextBox In Panel1.Controls.OfType(Of TextBox)()
            txtBox.Text = ""
        Next

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Générer un caractère aléatoire pour chaque TextBox
        For Each txtBox As TextBox In Panel1.Controls.OfType(Of TextBox)()
            Dim index As Integer = random.Next(0, 4)
            txtBox.Text = getCaractereAutoriseAtIndex(index)
        Next
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class