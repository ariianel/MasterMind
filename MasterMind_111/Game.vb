Imports System.Drawing.Imaging

Public Class Game
    Dim valide As Integer = 0
    Private nbCoups As Integer = 15
    Private tmpRestant As Integer = 90 '1m30
    Private WithEvents timer As Timer
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If inputValide() Then
            'Enregistre dans un tableau les caractères choisis
            Module1.setCaracteresACHoisir(TextBox5.Text, TextBox4.Text, TextBox3.Text, TextBox2.Text, TextBox1.Text)

            Dim propositions As New List(Of String) ' Liste pour stocker les propositions du joueur 2
            Dim row As New DataGridViewRow

            For Each control As Control In PanelTextBox.Controls
                If TypeOf control Is TextBox Then
                    Dim txt As TextBox = control

                    'Vérif si le caractère existe et détermine le statut
                    If (Module1.CaractereDevinable(txt.Text)) Then
                        'Vérif si caractère bonne position
                        If (Module1.CaractereBonnePosition(txt.Text, txt.Tag)) Then

                            txt.BackColor = Color.Green ' Présent et bien placé
                        Else

                            txt.BackColor = Color.Blue ' Présent mais mal placé
                        End If
                    Else

                        txt.BackColor = Color.Black ' Caractère absent
                    End If

                End If
            Next

            For Each txt As TextBox In {TextBox1, TextBox2, TextBox3, TextBox4, TextBox5}
                Dim cell As New DataGridViewTextBoxCell()
                Dim carac As String = txt.Text
                cell.Style.ForeColor = txt.BackColor
                cell.Value = carac
                row.Cells.Add(cell)
            Next
            ' Ajouter la ligne à DataGridView
            DataGridView1.Rows.Add(row)

            Dim caracteresTrouves As Boolean = True
            For i As Integer = 0 To 4
                If Not Module1.CaractereDevinable(Module1.caracteresChoisis(i).ToString()) Then
                    caracteresTrouves = False
                    Exit For
                End If
            Next

            If caracteresTrouves Then
                MessageBox.Show("Félicitations, vous avez trouvé tous les caractères !")
            ElseIf DataGridView1.Rows.Count >= nbCoups Then
                MessageBox.Show("Vous avez épuisé tous les essais. Les caractères à trouver étaient : " & New String(Module1.caracteresATrouver))
            Else
                'Recommencer 
                'Réinitialiser les TextBox
                nbCoups -= 1
                For Each txtBox As TextBox In PanelTextBox.Controls.OfType(Of TextBox)()
                    txtBox.Text = ""
                    txtBox.BackColor = SystemColors.Control
                Next
            End If
        Else
            MsgBox("InputValide is false")
        End If

    End Sub

    Private Function inputValide() As Boolean
        'Réinitialiser le compteur valide
        valide = 0

        'Vérifier la validité des données
        For Each txtBox As TextBox In PanelTextBox.Controls.OfType(Of TextBox)()
            'Effectuer une action pour chaque TextBox
            If txtBox.Text <> "#" AndAlso txtBox.Text <> "$" AndAlso txtBox.Text <> "£" AndAlso txtBox.Text <> "%" AndAlso txtBox.Text <> "@" Then
                MessageBox.Show("Caractère invalide dans " & txtBox.Name)
                txtBox.Text = ""
            Else
                valide += 1
            End If
        Next

        'Vérifier que toutes les cases ont un caractère
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Then
            MsgBox("Il manque un caractère")
        End If

        If valide = 5 Then
            Return True
        Else
            Return False
        End If
    End Function



    Private Sub Game_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Interval = 1000
        Timer1.Start()
        Timer1_Tick(sender, e)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        tmpRestant -= 1
        Label10.Text = FormatTime(tmpRestant)
        Label11.Text = "Il vous reste " & nbCoups & " coup(s)..."
    End Sub

    Private Function FormatTime(seconds As Integer) As String
        Dim minutes As Integer = seconds \ 60
        Dim remainingSeconds As Integer = seconds Mod 60
        Return minutes.ToString("00") & ":" & remainingSeconds.ToString("00")
    End Function

End Class

