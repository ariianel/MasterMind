Imports System.Drawing.Imaging
Imports MasterMind_111.Module1

Public Class Game
    Dim valide As Integer = 0
    Public nbCoups As Integer = 15
    Private tmpRestant As Integer = tempsImparti '1m30
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If inputValide() Then
            'Enregistre dans un tableau les caractères choisis
            Module1.setCaracteresCHoisis(TextBox5.Text, TextBox4.Text, TextBox3.Text, TextBox2.Text, TextBox1.Text)

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

            Dim joueur1 As JOUEURS = ejoueurs(0)
            Dim joueur2 As JOUEURS = ejoueurs(1)

            If caracteresTrouves Then
                Timer1.Stop()
                MessageBox.Show("Félicitations, vous avez trouvé tous les caractères !")
                joueur2.score += 1
                joueur1.score -= 1
                Button2.Visible = True
                rejouerButton = True

                ' Ajouter le temps au joueur 1
                joueur2.tempsCombinaison += tmpRestant

            ElseIf DataGridView1.Rows.Count >= nbCoups Then
                Timer1.Stop()
                MessageBox.Show("Vous avez épuisé tous les essais. Les caractères à trouver étaient : " & New String(Module1.caracteresATrouver))

                joueur2.score -= 1
                joueur1.score += 1
                Button2.Visible = True
                rejouerButton = True

                ' Ajouter le temps au joueur 1
                joueur1.tempsCombinaison += tmpRestant
            Else
                'Recommencer 
                'Réinitialiser les TextBox
                'nbCoups -= 1
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

        'Bouton BYE
        Button2.Visible = False

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        tmpRestant -= 1
        Label10.Text = FormatTime(tmpRestant)
        Label11.Text = "Il vous reste " & nbCoups & " coup(s)..."

        'Si le temps est écoulé
        If tmpRestant <= 0 Then
            Timer1.Stop()

            ' Vérifier si le joueur 2 a trouvé la combinaison
            Dim caracteresTrouves As Boolean = True
            For i As Integer = 0 To 4
                If Not Module1.CaractereDevinable(Module1.caracteresChoisis(i).ToString()) Then
                    caracteresTrouves = False
                    Exit For
                End If
            Next

            Dim joueur1 As JOUEURS = ejoueurs(0)
            Dim joueur2 As JOUEURS = ejoueurs(1)

            If caracteresTrouves Then
                MessageBox.Show("Temps écoulé, mais le joueur 2 a trouvé la combinaison !")
                rejouerButton = True
                ' Mettre en œuvre les actions pour que le joueur 2 perde un point et le joueur 1 en gagne un
                joueur2.score += 1
                joueur1.score -= 1
                Button2.Visible = True

                ' Ajouter le temps au joueur 2
                joueur2.tempsCombinaison += tmpRestant
            Else
                MessageBox.Show("Temps écoulé ! Le joueur 2 n'a pas trouvé la combinaison.")
                rejouerButton = True
                ' Mettre en œuvre les actions pour que le joueur 2 perde un point et le joueur 1 en gagne un
                joueur2.score -= 1
                joueur1.score += 1
                Button2.Visible = True
                ' Ajouter le temps au joueur 1
                joueur1.tempsCombinaison += tmpRestant
            End If

            ' Effectuer ici d'autres actions pour terminer la partie
        End If
    End Sub

    Private Function FormatTime(seconds As Integer) As String
        Dim minutes As Integer = seconds \ 60
        Dim remainingSeconds As Integer = seconds Mod 60
        Return minutes.ToString("00") & ":" & remainingSeconds.ToString("00")
    End Function

    'BOUTON BYE
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        Accueil.Show()

        'Mise à jour des données
        Dim joueur1 As JOUEURS = ejoueurs(0)
        Dim joueur2 As JOUEURS = ejoueurs(1)

        If rejouerButton OrElse DataGridView1.Rows.Count >= nbCoups Then
            MessageBox.Show("La partie est terminée. Cliquez sur le bouton 'Rejouer' pour continuer.")

            ' Inverser les rôles des joueurs pour la partie suivante
            Dim firstName As String = Accueil.ComboBox2.Text.Trim()
            Dim secondName As String = Accueil.ComboBox1.Text.Trim()

            ' Remplacer les noms des joueurs dans les ComboBox du formulaire Accueil
            Accueil.ComboBox1.Text = firstName
            Accueil.ComboBox2.Text = secondName
            'Afficher le bouton REJOUER
            Accueil.Button4.Visible = True

            joueur2.nbPartiesJoueur2 += 1
            joueur1.nbPartiesJoueur1 += 1

            ' Ajouter le temps au joueur 2
            'joueur2.tempsCombinaison += tmpRestant

            ' Vérifier et mettre à jour le meilleur temps du joueur 2
            If joueur2.meilleurTemps = 0 OrElse tmpRestant < joueur2.meilleurTemps Then
                joueur2.meilleurTemps = tmpRestant
            End If

            ' Ajouter le temps au joueur 1
            'joueur1.tempsCombinaison += tmpRestant

            ' Vérifier et mettre à jour le meilleur temps du joueur 1
            If joueur1.meilleurTemps = 0 OrElse tmpRestant < joueur1.meilleurTemps Then
                joueur1.meilleurTemps = tmpRestant
            End If

        End If

        'ENREGISTRER FICHIERR LES NOUVEAUX JOUEURS
        Module1.EnregistrerJoueur(ejoueurs(0))
        Module1.EnregistrerJoueur(ejoueurs(1))

        'On échange les joueurs dans le tableau ephemère
        ejoueurs(0) = joueur2
        ejoueurs(1) = joueur1


    End Sub
End Class

