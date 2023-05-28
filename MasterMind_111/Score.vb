Imports System.ComponentModel
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar

Public Class Score
    Private Structure Joueur
        Public nom As String
        Public score As Integer
        Public meilleurTemps As Integer
        Public nbParties As Integer
        Public nbParties2 As Integer
        Public tempsCombinaison As Integer
    End Structure

    Private joueurs As New List(Of Joueur)
    Private Sub Score_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim nomsJ As String() = Module1.GetNomsJoueurs()

        'mets à jours les jours dans notres ComboBox
        ComboBoxRechercheJoueur.DataSource = nomsJ
        ComboBoxRechercheJoueur.SelectedIndex = -1
        ' Charger les données
        LoadData()

    End Sub

    Private Sub LoadData()
        ' Récupérer les données depuis le fichier
        Dim num As Integer = FreeFile()
        Dim nom As String
        Dim score, meilleurTemps, nbParties, nbParties2, tempsCombinaison As Integer
        Dim joueurs As New List(Of Joueur)


        FileOpen(num, "Joueurs.txt", OpenMode.Input)

        Do Until EOF(num)
            Input(num, nom)
            Input(num, score)
            Input(num, meilleurTemps)
            Input(num, nbParties)
            Input(num, nbParties2)
            Input(num, tempsCombinaison)

            ' Vérifier si le joueur avec le même nom existe déjà dans la liste
            Dim joueurExistant As Joueur = joueurs.Find(Function(joueur) joueur.nom = nom)
            If joueurExistant.nom = "" Then
                ' Le joueur n'existe pas, vous pouvez l'ajouter à la liste
                Dim joueur As Joueur
                joueur.nom = nom
                joueur.score = score
                joueur.meilleurTemps = meilleurTemps
                joueur.nbParties = nbParties
                joueur.nbParties2 = nbParties2
                joueur.tempsCombinaison = tempsCombinaison
                joueurs.Add(joueur)
            Else
                ' Le joueur existe déjà, vous pouvez choisir de mettre à jour ses informations ici si nécessaire
            End If
        Loop



        FileClose(num)


        ' Créer un DataTable pour stocker les données des joueurs
        Dim dataTable As New DataTable()

        ' Définir les colonnes du DataTable
        dataTable.Columns.Add("Nom")
        dataTable.Columns.Add("Score", GetType(Integer))
        dataTable.Columns.Add("Meilleur Temps", GetType(Integer))
        dataTable.Columns.Add("Nombre de Parties J1", GetType(Integer))
        dataTable.Columns.Add("Nombre de Parties J2", GetType(Integer))
        dataTable.Columns.Add("Temps Combinaison", GetType(Integer))

        ' Ajouter les joueurs au DataTable
        For Each joueur In joueurs
            dataTable.Rows.Add(joueur.nom, joueur.score, joueur.meilleurTemps, joueur.nbParties, joueur.nbParties2, joueur.tempsCombinaison)
        Next

        ' Afficher les données du DataTable dans la DataGridView
        DataGridView1.DataSource = dataTable

    End Sub

    Private Sub SortByNom()
        ' Trier les joueurs par nom
        DataGridView1.Sort(DataGridView1.Columns("Nom"), ListSortDirection.Ascending)

    End Sub

    Private Sub SortByScore()
        ' Trier les joueurs par score
        DataGridView1.Sort(DataGridView1.Columns("Score"), ListSortDirection.Descending)
    End Sub
    Private Sub SortByMeilleurTemps()
        ' Trier les joueurs par meilleur temps
        DataGridView1.Sort(DataGridView1.Columns("Meilleur Temps"), ListSortDirection.Ascending)

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
        Dim joueurNom As String = ComboBoxRechercheJoueur.SelectedItem

        ' Variable pour indiquer si le joueur a été trouvé
        Dim joueurTrouve As Boolean = False

        ' Rechercher le joueur correspondant dans la liste des joueurs
        For Each joueur As JOUEURS In tjoueurs
            If joueur.nom = joueurNom Then
                joueurTrouve = True

                ' Afficher les statistiques du joueur dans une MessageBox
                Dim message As String = $"Statistiques pour le joueur : {joueur.nom}" & vbCrLf &
                            $"Score : {joueur.score}" & vbCrLf &
                            $"Meilleur Temps : {joueur.meilleurTemps}" & vbCrLf &
                            $"Nombre de Parties J1 : {joueur.nbPartiesJoueur1}" & vbCrLf &
                            $"Nombre de Parties J2 : {joueur.nbPartiesJoueur2}" & vbCrLf &
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