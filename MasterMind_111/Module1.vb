Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MasterMind_111.Module1

Module Module1

    Private nbJoueurs As Integer = 0 'nombres de joueurs
    Private rejouerButton As Boolean = False
    Private cptJoueurs As Integer = 0 'Compteur
    Private Const PAS_TAB = 1 'Le pas pour agrandir le tableau
    Private tempsBool As Boolean = True
    Private cheminFichier As String = "Joueurs.txt"
    Private tempsImparti As Integer = 90 '1min30
    Private caracteresAutorise() As Char = {"#", "$", "£", "%", "@"} 'Par défaut

    Public tjoueurs() As JOUEURS 'Tableau qui stocks tous les joueurs
    Public caracteresATrouver() As Char = {"#", "$", "£", "%", "@"} 'Tableau ou l'on stock les caractères à trouver
    Public caracteresChoisis(4) As Char 'Tableau ou l'on stock les caractères qui seront choisis
    Public colorAbsent = Color.Black, colorPresent = Color.Blue, colorBienPlace = Color.Green
    Public nom1 As String
    Public nom2 As String


    'Structure qui définit un joueur
    Structure JOUEURS
        Dim nom As String
        Dim score As Integer
        Dim meilleurTemps As Integer
        Dim nbPartiesJoueur1 As Integer
        Dim nbPartiesJoueur2 As Integer
        Dim tempsCombinaison As Integer
    End Structure


    Public Function getCaracteres() As Char()
        Return caracteresATrouver
    End Function

    Public Function setCheminFichier(nom As String)
        cheminFichier = nom
    End Function

    'Fonction qui permet d'ajouter un joueur dans le tableau
    Public Function ajout(nom As String, score As Integer, meilleurTemps As Integer, nbParties As Integer, nbParties2 As Integer, TempsCombinaison As Integer)

        If Not String.IsNullOrEmpty(nom) Then
            ' Vérifier si le joueur existe déjà dans le tableau
            Dim joueurExistant As JOUEURS = tjoueurs.FirstOrDefault(Function(joueur) joueur.nom = nom)

            If joueurExistant.nom IsNot Nothing Then
                ' Le joueur existe déjà, mettre à jour ses statistiques
                joueurExistant.score = score
                joueurExistant.meilleurTemps = meilleurTemps
                joueurExistant.nbPartiesJoueur1 = nbParties
                joueurExistant.nbPartiesJoueur2 = nbParties2
                joueurExistant.tempsCombinaison = TempsCombinaison
            Else
                ' Le joueur n'existe pas, l'ajouter au tableau
                Dim pers As JOUEURS
                pers.nom = nom
                pers.score = score
                pers.meilleurTemps = meilleurTemps
                pers.nbPartiesJoueur1 = nbParties
                pers.nbPartiesJoueur2 = nbParties2
                pers.tempsCombinaison = TempsCombinaison

                If tjoueurs.Length > nbJoueurs Then
                    agrandir(tjoueurs, PAS_TAB, tjoueurs.Length)
                End If

                tjoueurs(nbJoueurs) = pers
                nbJoueurs += 1
            End If
        End If

    End Function

    ' Fonction qui vérifie si un joueur existe déjà dans le tableau
    Public Function joueurExiste(nom As String) As Boolean
        For i As Integer = 0 To cptJoueurs - 1
            If tjoueurs(i).nom = nom Then
                Return True
            End If
        Next
        Return False
    End Function

    'Permet d'agrandir le tableau
    Private Sub agrandir(ByRef tab() As JOUEURS, pas As Integer, tailleTableau As Integer)
        ReDim Preserve tab(tailleTableau + pas)
    End Sub


    Public Sub Main()
        ' Réinitialiser le tableau tjoueurs à Nothing
        tjoueurs = Nothing

        ''''' Récupère les données depuis le fichier ''''''''
        Dim nom As String
        Dim score, meilleurTemps, nbParties, nbParties2, TempsCombinaison As Integer
        Dim num As Integer = FreeFile()
        ReDim Preserve tjoueurs(nbJoueurs)


        FileOpen(num, cheminFichier, OpenMode.Input)

        Do Until EOF(num)
            Input(num, nom) 'titre d'une personne
            Input(num, score) 'score
            Input(num, meilleurTemps)
            Input(num, nbParties)
            Input(num, nbParties2)
            Input(num, TempsCombinaison)
            'on ajoute cette personne au tableau tjoueurs
            ajout(nom, score, meilleurTemps, nbParties, nbParties2, TempsCombinaison)
        Loop

        FileClose(num)

        'Lance le premier Formulaire ACCUEIL
        Application.Run(Accueil)

        EnregistrerJoueursDansFichier()

    End Sub

    Public Sub EnregistrerJoueursDansFichier()
        Dim num As Integer = FreeFile()
        FileOpen(num, cheminFichier, OpenMode.Output)

        For i As Integer = 0 To nbJoueurs - 1
            PrintLine(num, tjoueurs(i).nom)
            PrintLine(num, tjoueurs(i).score)
            PrintLine(num, tjoueurs(i).meilleurTemps)
            PrintLine(num, tjoueurs(i).nbPartiesJoueur1)
            PrintLine(num, tjoueurs(i).nbPartiesJoueur2)
            PrintLine(num, tjoueurs(i).tempsCombinaison)
        Next

        FileClose(num)
    End Sub


    Public Function GetNomsJoueurs() As String()
        Dim noms As New List(Of String)()

        For i As Integer = 0 To nbJoueurs - 1
            noms.Add(tjoueurs(i).nom)
        Next

        Return noms.ToArray()
    End Function

    Public Function setCaracteresAutorise(carac1 As Char, carac2 As Char, carac3 As Char, carac4 As Char, carac5 As Char)
        caracteresAutorise(0) = carac1
        caracteresAutorise(1) = carac2
        caracteresAutorise(2) = carac3
        caracteresAutorise(3) = carac4
        caracteresAutorise(4) = carac5

    End Function

    Public Function getCaracteresAutorise()
        Return caracteresAutorise
    End Function

    Public Function getCaractereAutoriseAtIndex(index As Integer) As Char
        If index >= 0 AndAlso index < 5 Then
            Return caracteresAutorise(index)
        Else
            Throw New IndexOutOfRangeException("L'index spécifié est invalide.")
        End If
    End Function

    Public Function setCaracteresCHoisis(carac1 As Char, carac2 As Char, carac3 As Char, carac4 As Char, carac5 As Char)
        caracteresChoisis(0) = carac1
        caracteresChoisis(1) = carac2
        caracteresChoisis(2) = carac3
        caracteresChoisis(3) = carac4
        caracteresChoisis(4) = carac5

    End Function

    Public Function setCaractereATrouver(carac1 As Char, carac2 As Char, carac3 As Char, carac4 As Char, carac5 As Char)
        caracteresATrouver(0) = carac1
        caracteresATrouver(1) = carac2
        caracteresATrouver(2) = carac3
        caracteresATrouver(3) = carac4
        caracteresATrouver(4) = carac5
    End Function

    Public Function getCaractereChoisis() As Char()
        Return Module1.caracteresChoisis
    End Function

    Public Function getCaractereATrouver() As Char()
        Return Module1.caracteresATrouver
    End Function

    Public Function CaractereDevinable(txt As Char) As Boolean
        Return Module1.caracteresATrouver.Contains(txt)
    End Function

    Public Function CaractereBonnePosition(caractere As Char, position As Integer) As Boolean
        ' Vérif si la position est valide dans le tableau
        If position >= 0 AndAlso position < caracteresATrouver.Length Then
            ' Vérif si le caractère à la position correspond au caractère donné
            If Module1.caracteresATrouver(position) = caractere Then
                Return True
            End If
        End If

        Return False
    End Function

    Public Sub setColorAbsent(ByVal color As Color)
        'Enregistrer la couleur dans une variable
        colorAbsent = color
        ' Afficher un message de confirmation
        MessageBox.Show("La couleur d'absence a été définie avec succès.")
    End Sub

    Public Sub setColorPresent(ByVal color As Color)
        'Enregistrer la couleur dans une variable
        colorPresent = color
        ' Afficher un message de confirmation
        MessageBox.Show("La couleur présent a été définie avec succès.")
    End Sub

    Public Sub setColorBienPlace(ByVal color As Color)
        'Enregistrer la couleur dans une variable
        colorBienPlace = color
        ' Afficher un message de confirmation
        MessageBox.Show("La couleur présent et bien placé a été définie avec succès.")
    End Sub

    Public Function getnbJoueurs() As Integer
        Return nbJoueurs
    End Function

    Public Function getRejouerButton() As Boolean
        Return rejouerButton
    End Function

    Public Sub setRejouerButton(bool As Boolean)
        rejouerButton = bool
    End Sub

    Public Function getTempsBool() As Boolean
        Return tempsBool
    End Function

    Public Sub setTempsBool(bool As Boolean)
        tempsBool = bool
    End Sub

    Public Function getTempsImparti() As Integer
        Return tempsImparti
    End Function

    Public Sub setTempsImparti(time As Integer)
        tempsImparti = time
    End Sub






End Module
