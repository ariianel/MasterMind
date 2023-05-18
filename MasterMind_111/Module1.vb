Module Module1

    Public nbJoueurs As Integer = 0
    Public tjoueurs() As JOUEURS
    Private cptJoueurs As Integer = 0
    Public newJoueurs As New List(Of String)()
    Private Const PAS_TAB = 1
    Public caracteres() As Char = {"$", "@", "<", ">", "!", "?"}


    Structure JOUEURS
        Dim nom As String
        Dim score As Integer
        Dim meilleurTemps As Integer
        Dim nbParties As Integer
        Dim tempsCombinaison As Integer
    End Structure

    Public Function getCaracteres() As Char()
        Return caracteres
    End Function


    Public Function ajout(nom As String, ByRef score As String, ByRef meilleurTemps As Integer, ByRef nbParties As Integer, ByRef TempsCombinaison As Integer)
        Dim pers As JOUEURS
        'On init la personne dans notre struct
        pers.nom = nom
        pers.score = score
        pers.meilleurTemps = meilleurTemps
        pers.nbParties = nbParties
        pers.tempsCombinaison = TempsCombinaison

        'Agrandit le tableau
        If tjoueurs.Length > nbJoueurs Then
            agrandir(tjoueurs, PAS_TAB, tjoueurs.Length)
        End If

        'Vérif que la personne n'existe pas si oui on l'ajt
        If Not tjoueurs.Contains(pers) Then
            tjoueurs(cptJoueurs) = pers
            cptJoueurs += 1
        Else
            'Si elle existe déjà
            MsgBox("La personne existe déjà, impossible d'enregistrer")
        End If

    End Function

    Private Sub agrandir(ByRef tab() As JOUEURS, pas As Integer, tailleTableau As Integer)
        ReDim Preserve tab(tailleTableau + pas)
    End Sub

    Public Sub Main()
        ''''' Récupère les données depuis le fichier ''''''''
        Dim nom As String
        Dim score, meilleurTemps, nbParties, TempsCombinaison As Integer
        Dim num As Integer = FreeFile()
        ReDim tjoueurs(nbJoueurs)


        FileOpen(num, "Joueurs.txt", OpenMode.Input)

        Do Until EOF(num)
            Input(num, nom) 'titre d'une personne
            Input(num, score) 'score
            Input(num, meilleurTemps)
            Input(num, nbParties)
            Input(num, TempsCombinaison)
            'on ajoute cette personne au tableau tjoueurs
            ajout(nom, score, meilleurTemps, nbParties, TempsCombinaison)
        Loop

        Application.Run(Accueil)

    End Sub

    Public Function GetNomsJoueurs() As String()
        Dim noms As New List(Of String)()

        For i As Integer = 0 To cptJoueurs - 1
            noms.Add(tjoueurs(i).nom)
        Next

        Return noms.ToArray()
    End Function



End Module
