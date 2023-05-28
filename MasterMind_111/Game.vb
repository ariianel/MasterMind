Imports System.Drawing.Imaging
Imports MasterMind_111.Module1

Public Class Game
    Dim valide As Integer = 0
    Public nbCoups As Integer = Options.newNbCoups 'newNbCoups init à 15 coups par défaut
    Private tmpRestant As Integer = getTempsImparti() '1m30

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If inputValide() Then
            'Enregistre dans un tableau les caractères choisis
            Module1.setCaracteresCHoisis(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text)
            nbCoups -= 1
            Label11.Text = "Il vous reste " & nbCoups & " coup(s)..."
            Dim propositions As New List(Of String) ' Liste pour stocker les propositions du joueur 2
            Dim row As New DataGridViewRow

            For Each control As Control In PanelTextBox.Controls
                If TypeOf control Is TextBox Then
                    Dim txt As TextBox = control

                    'Vérif si le caractère existe et détermine le statut
                    If (Module1.CaractereDevinable(txt.Text)) Then
                        'Vérif si caractère bonne position
                        If (Module1.CaractereBonnePosition(txt.Text, txt.Tag)) Then
                            txt.BackColor = colorBienPlace ' Présent et bien placé
                        Else
                            txt.BackColor = colorPresent ' Présent mais mal placé
                        End If
                    Else
                        txt.BackColor = colorAbsent ' Caractère absent
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
                If Not Module1.CaractereBonnePosition(Module1.caracteresChoisis(i).ToString(), i) Then
                    caracteresTrouves = False
                    Exit For
                End If
            Next

            Dim joueur1Index As Integer = Array.FindIndex(tjoueurs, Function(joueur) joueur.nom = nom1)
            Dim joueur2Index As Integer = Array.FindIndex(tjoueurs, Function(joueur) joueur.nom = nom2)

            If caracteresTrouves Then
                Timer1.Stop()
                PictureBox2.Visible = True
                Label12.Visible = True
                Label12.Text = "Félicitations" & vbCrLf & "vous avez trouvé tous" & vbCrLf & " les caractères !"
                tjoueurs(joueur2Index).score += 1
                tjoueurs(joueur1Index).score -= 1
                Button2.Visible = True
                setRejouerButton(True)

                MettreAJourMeilleurTemps(nom2, tmpRestant)
                tjoueurs(joueur2Index).tempsCombinaison += tmpRestant

            ElseIf DataGridView1.Rows.Count >= nbCoups Then
                ' GAME OVER !!!!!!!!!
                ' Mettre le fond du formulaire en noir
                Me.BackColor = Color.Black
                PictureBox1.SizeMode = PictureBoxSizeMode.CenterImage
                PictureBox1.Visible = True
                Timer1.Stop()
                MessageBox.Show("Vous avez épuisé tous les essais. Les caractères à trouver étaient : " & New String(Module1.caracteresATrouver))

                tjoueurs(joueur2Index).score -= 1
                tjoueurs(joueur1Index).score += 1

                Button2.Visible = True
                setRejouerButton(True)

                MettreAJourMeilleurTemps(nom2, tmpRestant)
                tjoueurs(joueur2Index).tempsCombinaison += tmpRestant

            Else
                'Recommencer 
                'Réinitialiser les TextBox
                'nbCoups -= 1
                For Each txtBox As TextBox In PanelTextBox.Controls.OfType(Of TextBox)()
                    If txtBox.BackColor <> colorBienPlace Then
                        txtBox.Text = ""
                        txtBox.BackColor = SystemColors.Control
                    End If
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
        Label5.ForeColor = Module1.colorAbsent
        Label6.ForeColor = Module1.colorPresent
        Label7.ForeColor = Module1.colorBienPlace
        PictureBox1.Visible = False

        Label10.Text = ""
        Label11.Text = "Il vous reste " & nbCoups & " coup(s)..."

        If (getTempsBool() = True) Then
            Timer1.Interval = 1000
            Timer1.Start()
            Timer1_Tick(sender, e)
        End If

        'Bouton BYE
        Button2.Visible = False

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        tmpRestant -= 1
        Label10.Text = FormatTime(tmpRestant)


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


            Dim joueur1Index As Integer = Array.FindIndex(tjoueurs, Function(joueur) joueur.nom = nom1)
            Dim joueur2Index As Integer = Array.FindIndex(tjoueurs, Function(joueur) joueur.nom = nom2)

            If caracteresTrouves Then
                MessageBox.Show("Temps écoulé, mais le joueur 2 a trouvé la combinaison !")
                setRejouerButton(True)

                ' Mettre en œuvre les actions pour que le joueur 2 perde un point et le joueur 1 en gagne un
                tjoueurs(joueur2Index).score += 1
                tjoueurs(joueur1Index).score -= 1
                Button2.Visible = True


                MettreAJourMeilleurTemps(nom2, tmpRestant)
                tjoueurs(joueur2Index).tempsCombinaison += tmpRestant
            Else
                ' GAME OVER !!!!!!!!!
                PictureBox1.SizeMode = PictureBoxSizeMode.CenterImage
                PictureBox1.Visible = True

                MessageBox.Show("Temps écoulé ! Le joueur 2 n'a pas trouvé la combinaison.")
                setRejouerButton(True)
                ' Mettre en œuvre les actions pour que le joueur 2 perde un point et le joueur 1 en gagne un
                tjoueurs(joueur2Index).score -= 1
                tjoueurs(joueur1Index).score += 1
                Button2.Visible = True

                MettreAJourMeilleurTemps(nom2, tmpRestant)
                tjoueurs(joueur2Index).tempsCombinaison += tmpRestant
            End If

            ' Effectuer ici d'autres actions pour terminer la partie
        End If
    End Sub

    Private Sub MettreAJourMeilleurTemps(nom As String, temps As Integer)
        For i As Integer = 0 To getnbJoueurs() - 1
            If tjoueurs(i).nom = nom Then
                If tjoueurs(i).meilleurTemps = 0 OrElse temps < tjoueurs(i).meilleurTemps Then
                    tjoueurs(i).meilleurTemps = temps
                End If
                Exit For
            End If
        Next
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

        If getRejouerButton() OrElse DataGridView1.Rows.Count >= nbCoups Then
            EnregistrerJoueursDansFichier()
            MessageBox.Show("La partie est terminée. Cliquez sur le bouton 'Rejouer' pour continuer.")

            ' Inverser les rôles des joueurs pour la partie suivante
            Dim firstName As String = Accueil.ComboBox2.Text.Trim()
            Dim secondName As String = Accueil.ComboBox1.Text.Trim()

            ' Remplacer les noms des joueurs dans les ComboBox du formulaire Accueil et les variables noms
            Accueil.ComboBox1.Text = firstName
            Accueil.ComboBox2.Text = secondName
            Module1.nom1 = nom2
            Module1.nom2 = nom1
            'Afficher le bouton REJOUER
            Accueil.Button4.Visible = True


        End If


    End Sub

End Class

