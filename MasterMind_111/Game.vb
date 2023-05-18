Public Class Game

    Dim valide As Integer = 0
    Public caracteresChoisis As New List(Of String)()
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        inputValide()
        If valide = 5 Then
            For i = 0 To 4
                'On traite les caractères entrées
                For Each txtBox As TextBox In Me.Controls.OfType(Of TextBox)()
                    'On enregistre la textBox dans la liste caracteres choisis
                    caracteresChoisis.Add(txtBox.Text)
                Next
            Next

            'Ensuite on compare ses caractères choisis avec ceux du joueur 1



        End If

    End Sub

    Private Sub inputValide()
        For Each txtBox As TextBox In Me.Controls.OfType(Of TextBox)()
            ' Effectuer une action pour chaque TextBox
            If txtBox.Text <> "#" AndAlso txtBox.Text <> "$" AndAlso txtBox.Text <> "£" AndAlso txtBox.Text <> "%" AndAlso txtBox.Text <> "@" Then
                MessageBox.Show("Caractère invalide dans la " & txtBox.Name)
                txtBox.Text = ""
            Else
                valide += 1
            End If

        Next
    End Sub
End Class

