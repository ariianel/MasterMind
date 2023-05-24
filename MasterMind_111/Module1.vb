Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Module Module1

    Public nbJoueurs As Integer = 0 'nombres de joueurs
    Public tjoueurs() As JOUEURS 'Tableau qui stocks tous les joueurs
    Public ejoueurs(1) As JOUEURS 'Tableau éphémère qui permet de stocker les joueurs avant leurs enregistrement
    Public rejouerButton As Boolean = False
    Private cptJoueurs As Integer = 0 'Compteur
    Public newJoueurs As New List(Of String)()
    Public nom1 As String
    Public Dim nom2 As String
    Private Const PAS_TAB = 1 'Le pas pour agrandir le tableau
    Public caracteresATrouver() As Char = {"#", "$", "£", "%", "@"} 'Tableau ou l'on stock les caractères à trouver
    Public caracteresChoisis(4) As Char 'Tableau ou l'on stock les caractères qui seront choisis
    Public colorAbsent, colorPresent, colorBienPlace As Color
    Public tempsImparti As Integer

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

    'Fonction qui permet d'ajouter un joueur dans le tableau
    Public Function ajout(nom As String, ByRef score As String, ByRef meilleurTemps As Integer, nbParties As Integer, nbParties2 As Integer, TempsCombinaison As Integer)
        Dim pers As JOUEURS
        'On init la personne dans notre struct
        pers.nom = nom
        pers.score = score
        pers.meilleurTemps = meilleurTemps
        pers.nbPartiesJoueur1 = nbParties
        pers.nbPartiesJoueur2 = nbParties2
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

    Public Function ajout_ephemere(nom As String, ByRef score As String, ByRef meilleurTemps As Integer, ByRef nbParties As Integer, nbPartiesJ1 As Integer, ByRef TempsCombinaison As Integer, nom2 As String, ByRef score2 As String, ByRef meilleurTemps2 As Integer, ByRef nbParties2 As Integer, ByRef nbPartiesJ2 As Integer, ByRef TempsCombinaison2 As Integer)

        Dim pers As JOUEURS
        Dim pers2 As JOUEURS

        'On init joueur 1
        pers.nom = nom
        pers.score = score
        pers.meilleurTemps = meilleurTemps
        pers.nbPartiesJoueur1 = nbParties
        pers.nbPartiesJoueur2 = nbPartiesJ1
        pers.tempsCombinaison = TempsCombinaison
        ejoueurs(0) = pers

        'On init joueur 2
        pers2.nom = nom2
        pers2.score = score2
        pers2.meilleurTemps = meilleurTemps2
        pers2.nbPartiesJoueur1 = nbParties2
        pers2.nbPartiesJoueur2 = nbPartiesJ2
        pers2.tempsCombinaison = TempsCombinaison2
        ejoueurs(1) = pers2

    End Function

    'Permet d'agrandir le tableau
    Private Sub agrandir(ByRef tab() As JOUEURS, pas As Integer, tailleTableau As Integer)
        ReDim Preserve tab(tailleTableau + pas)
    End Sub


    Public Sub Main()
        ''''' Récupère les données depuis le fichier ''''''''
        Dim nom As String
        Dim score, meilleurTemps, nbParties, nbParties2, TempsCombinaison As Integer
        Dim num As Integer = FreeFile()
        ReDim tjoueurs(nbJoueurs)


        FileOpen(num, "Joueurs.txt", OpenMode.Input)

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



    End Sub

    Public Function GetNomsJoueurs() As String()
        Dim noms As New List(Of String)()

        For i As Integer = 0 To cptJoueurs - 1
            noms.Add(tjoueurs(i).nom)
        Next

        Return noms.ToArray()
    End Function

    Public Function setCaracteresCHoisis(carac1 As String, carac2 As String, carac3 As String, carac4 As String, carac5 As String)
        caracteresChoisis(0) = carac1
        caracteresChoisis(1) = carac2
        caracteresChoisis(2) = carac3
        caracteresChoisis(3) = carac4
        caracteresChoisis(4) = carac5

    End Function

    Public Function setCaractereATrouver(carac1 As String, carac2 As String, carac3 As String, carac4 As String, carac5 As String)
        caracteresATrouver(0) = carac1
        caracteresATrouver(1) = carac2
        caracteresATrouver(2) = carac3
        caracteresATrouver(3) = carac4
        caracteresATrouver(4) = carac5
    End Function

    Public Function getCaractereChoisis() As Char()
        Return caracteresChoisis
    End Function

    Public Function getCaractereATrouver() As Char()
        Return caracteresATrouver
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

    ' Fonction qui enregistre un joueur dans un fichier texte
    Public Sub EnregistrerJoueur(Joueur As JOUEURS)
        Dim cheminFichier As String = "Joueurs.txt"
        Dim lignes As New List(Of String)
        Dim joueurExistant As Boolean = False

        ' Lecture du fichier pour vérifier si le joueur existe déjà
        Using sr As New StreamReader(cheminFichier)
            While Not sr.EndOfStream
                Dim ligne As String = sr.ReadLine()
                If ligne = Joueur.nom Then
                    joueurExistant = True
                    lignes.Add(ligne) ' Ajoute le nom du joueur existant à la liste des lignes
                    Dim score As String = sr.ReadLine() ' Lecture de la ligne du score
                    Dim meilleurTemps As String = sr.ReadLine() ' Lecture de la ligne du meilleur temps
                    Dim nbPartiesJoueur1 As String = sr.ReadLine() ' Lecture de la ligne du nombre de parties en tant que joueur 1
                    Dim nbPartiesJoueur2 As String = sr.ReadLine() ' Lecture de la ligne du nombre de parties en tant que joueur 2
                    Dim tempsCombinaison As String = sr.ReadLine() ' Lecture de la ligne du temps de combinaison

                    If Joueur.meilleurTemps < Integer.Parse(meilleurTemps) Then
                        lignes.Add(score) ' Ajoute l'ancien score à la liste des lignes
                        lignes.Add(Joueur.meilleurTemps.ToString()) ' Ajoute le nouveau meilleur temps à la liste des lignes
                    Else
                        lignes.Add(score) ' Ajoute l'ancien score à la liste des lignes
                        lignes.Add(meilleurTemps) ' Ajoute l'ancien meilleur temps à la liste des lignes
                    End If

                    lignes.Add(nbPartiesJoueur1) ' Ajoute l'ancien nombre de parties en tant que joueur 1 à la liste des lignes
                    lignes.Add(nbPartiesJoueur2) ' Ajoute l'ancien nombre de parties en tant que joueur 2 à la liste des lignes
                    lignes.Add(tempsCombinaison) ' Ajoute l'ancien temps de combinaison à la liste des lignes
                Else
                    lignes.Add(ligne) ' Ajoute la ligne non concernée par le joueur existant à la liste des lignes
                End If
            End While
        End Using

        ' Écriture des informations mises à jour dans le fichier
        Using sw As New StreamWriter(cheminFichier)
            For Each ligne As String In lignes
                sw.WriteLine(ligne)
            Next

            ' Si le joueur n'existe pas dans le fichier, ajoute ses informations à la fin
            If Not joueurExistant Then
                sw.WriteLine(Joueur.nom)
                sw.WriteLine(Joueur.score)
                sw.WriteLine(Joueur.meilleurTemps)
                sw.WriteLine(Joueur.nbPartiesJoueur1)
                sw.WriteLine(Joueur.nbPartiesJoueur2)
                sw.WriteLine(Joueur.tempsCombinaison)
            End If
        End Using
    End Sub

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

End Module
