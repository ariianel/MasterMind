Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Score
    Private Structure Joueur
        Public nom As String
        Public score As Integer
        Public meilleurTemps As Integer
        Public nbParties As Integer
        Public nbParties2 As Integer
        Public tempsCombinaison As Integer
    End Structure

    ' Liste pour stocker les joueurs
    Private joueurs As New List(Of Joueur)
    Private Sub Score_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Ajouter les colonnes dans chaque ListBox
        ListBox1.Items.Add("Nom")
        ListBox2.Items.Add("Score")
        ListBox3.Items.Add("meilleur Temps")
        ListBox4.Items.Add("Nb Parties J1")
        ListBox5.Items.Add("Nb Parties J2")
        ListBox6.Items.Add("temps Combinaison")


        ' Ajouter les ListBox au formulaire
        Controls.Add(ListBox1)
        Controls.Add(ListBox2)
        Controls.Add(ListBox3)
        Controls.Add(ListBox4)
        Controls.Add(ListBox5)
        Controls.Add(ListBox6)


        ' Charger les données
        LoadData()



    End Sub

    Private Sub LoadData()
        ' Récupérer les données depuis le fichier
        Dim num As Integer = FreeFile()
        Dim nom As String
        Dim score, meilleurTemps, nbParties, nbParties2, tempsCombinaison As Integer

        FileOpen(num, "Joueurs.txt", OpenMode.Input)

        Do Until EOF(num)
            Input(num, nom)
            Input(num, score)
            Input(num, meilleurTemps)
            Input(num, nbParties)
            Input(num, nbParties2)
            Input(num, tempsCombinaison)

            'Ajouter les données aux ListBox
            'ListBox1.Items.Add(nom)
            'ListBox2.Items.Add(score.ToString())
            'ListBox3.Items.Add(meilleurTemps.ToString())
            'ListBox4.Items.Add(nbParties.ToString())
            'ListBox5.Items.Add(nbParties2.ToString())
            'ListBox6.Items.Add(tempsCombinaison.ToString())

            ' Ajouter le nom du joueur à la ComboBox de recherche
            ComboBoxRechercheJoueur.Items.Add(nom)

            ' Ajouter le joueur à la liste
            Dim joueur As Joueur
            joueur.nom = nom
            joueur.score = score
            joueur.meilleurTemps = meilleurTemps
            joueur.nbParties = nbParties
            joueur.nbParties2 = nbParties2
            joueur.tempsCombinaison = tempsCombinaison
            joueurs.Add(joueur)
        Loop

        FileClose(num)

        FileClose(num)

        ' Mettre à jour les ListBox avec les données
        UpdateListBoxes()

    End Sub

    Private Sub UpdateListBoxes()
        ' Effacer les données actuelles des ListBox
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        ListBox3.Items.Clear()
        ListBox4.Items.Clear()
        ListBox5.Items.Clear()
        ListBox6.Items.Clear()

        ' Ajouter les données aux ListBox
        For Each joueur In joueurs
            ListBox1.Items.Add(joueur.nom)
            ListBox2.Items.Add(joueur.score.ToString())
            ListBox3.Items.Add(joueur.meilleurTemps.ToString())
            ListBox4.Items.Add(joueur.nbParties.ToString())
            ListBox5.Items.Add(joueur.nbParties2.ToString())
            ListBox6.Items.Add(joueur.tempsCombinaison.ToString())
        Next
    End Sub
    Private Sub SortByNom()
        ' Trier les joueurs par nom
        joueurs.Sort(Function(joueur1, joueur2) joueur1.nom.CompareTo(joueur2.nom))
        UpdateListBoxes()
    End Sub

    Private Sub SortByScore()
        ' Trier les joueurs par score
        joueurs.Sort(Function(joueur1, joueur2) joueur2.score.CompareTo(joueur1.score))
        UpdateListBoxes()
    End Sub
    Private Sub SortByMeilleurTemps()
        ' Trier les joueurs par meilleur temps
        joueurs.Sort(Function(joueur1, joueur2) joueur1.meilleurTemps.CompareTo(joueur2.meilleurTemps))
        UpdateListBoxes()
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SortByNom()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SortByScore()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        SortByMeilleurTemps()
    End Sub

    Private Sub ComboBoxRechercheJoueur_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxRechercheJoueur.SelectedIndexChanged
        ' Récupérer le nom du joueur sélectionné dans la ComboBox
        Dim joueurNom As String = ComboBoxRechercheJoueur.SelectedItem.ToString()
        Dim test As Boolean = False
        ' Rechercher le joueur correspondant dans la liste des joueurs
        Dim joueurRecherche As Joueur = joueurs.Find(Function(joueur) joueur.nom = joueurNom)
        ' Variable pour indiquer si le joueur a été trouvé
        Dim joueurTrouve As Boolean = False

        ' Rechercher le joueur correspondant dans la liste des joueurs
        For Each joueur As Joueur In joueurs
            If joueur.nom = joueurNom Then
                joueurTrouve = True

                ' Afficher les statistiques du joueur dans une MessageBox
                Dim message As String = $"Statistiques pour le joueur : {joueur.nom}" & vbCrLf &
                                $"Score : {joueur.score}" & vbCrLf &
                                $"Meilleur Temps : {joueur.meilleurTemps}" & vbCrLf &
                                $"Nombre de Parties J1 : {joueur.nbParties}" & vbCrLf &
                                $"Nombre de Parties J2 : {joueur.nbParties2}" & vbCrLf &
                                $"Temps Combinaison : {joueur.tempsCombinaison}"

                MessageBox.Show(message, "Statistiques du joueur")

                ' Sortir de la boucle une fois que le joueur a été trouvé
                Exit For
            End If
        Next

        ' Vérifier si le joueur n'a pas été trouvé
        If Not joueurTrouve Then
            Dim message As String = "Joueur introuvable."
            MessageBox.Show(message, "Erreur de recherche")
        End If
    End Sub

    Private Sub LinkLabel1_Click(sender As Object, e As EventArgs) Handles LinkLabel1.Click
        Me.Hide()
        Accueil.Show()
    End Sub
End Class