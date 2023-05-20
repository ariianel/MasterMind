Module Module1

    Public nbJoueurs As Integer = 0 'nombres de joueurs
    Public tjoueurs() As JOUEURS 'Tableau qui stocks tous les joueurs
    Private cptJoueurs As Integer = 0 'Compteur
    Public newJoueurs As New List(Of String)()
    Private Const PAS_TAB = 1 'Le pas pour agrandir le tableau
    Public caracteresATrouver(4) As Char 'Tableau ou l'on stock les caractères à trouver
    Public caracteresChoisis(4) As Char 'Tableau ou l'on stock les caractères qui seront choisis

    'Structure qui définit un joueur
    Structure JOUEURS
        Dim nom As String
        Dim score As Integer
        Dim meilleurTemps As Integer
        Dim nbParties As Integer
        Dim tempsCombinaison As Integer
    End Structure


    Public Function getCaracteres() As Char()
        Return caracteresATrouver
    End Function

    'Fonction qui permet d'ajouter un joueur dans le tableau
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

    'Permet d'agrandir le tableau
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

        'Lance le premier Formulaire ACCUEIL
        Application.Run(Accueil)

    End Sub

    Public Function GetNomsJoueurs() As String()
        Dim noms As New List(Of String)()

        For i As Integer = 0 To cptJoueurs - 1
            noms.Add(tjoueurs(i).nom)
        Next

        Return noms.ToArray()
    End Function

    Public Function setCaracteresACHoisir(carac1 As String, carac2 As String, carac3 As String, carac4 As String, carac5 As String)
        caracteresChoisis(0) = carac1
        caracteresChoisis(1) = carac2
        caracteresChoisis(2) = carac3
        caracteresChoisis(3) = carac4
        caracteresChoisis(4) = carac5

    End Function

    Public Function getCaractereChoisis() As Char()
        Return caracteresChoisis
    End Function

    Public Function CaractereDevinable(txt As Char) As Boolean
        Return caracteresATrouver.Contains(txt)
    End Function

    Public Function CaractereBonnePosition(caractere As Char, position As Integer) As Boolean
        ' Vérif si la position est valide dans le tableau
        If position >= 0 AndAlso position < caracteresATrouver.Length Then
            ' Vérif si le caractère à la position correspond au caractère donné
            If caracteresATrouver(position) = caractere Then
                Return True
            End If
        End If

        Return False
    End Function




End Module
