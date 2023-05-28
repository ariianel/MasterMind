Public Class Regles
    Private Sub Regles_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = "Le jeu du Mastermind se joue avec deux joueurs : le codeur et le décodeur. Le codeur crée une " & vbCrLf & "combinaison secrète de caractères et le décodeur doit deviner cette combinaison en proposant des combinaisons." & vbCrLf &
      "La combinaison secrète est composée de 5 différents caractères. Le type de caractères et leur ordrr" & vbCrLf & "peuvent être choisi par l'utilisateur." &
      "Le décodeur propose une première combinaison en sélectionnant" & vbCrLf & " un ensemble de caractères. Le jeu fournit alors des indications pour aider" & vbCrLf & "le décodeur à trouver la bonne combinaison." & vbCrLf &
      "Les indications fournies par le jeu sont généralement sous la " & vbCrLf & "forme de couleur. Ces indiques indiquent les caractères correctement placés" & vbCrLf & " et les caractères corrects mais mal placés dans la proposition du décodeur." & vbCrLf &
      "Le décodeur utilise les indications fournies par le jeu pour" & vbCrLf & " affiner ses propositions suivantes. Il ajuste les caractères et leur position" & vbCrLf & " en fonction des indications reçues." & vbCrLf &
      "Le jeu se poursuit par des allers-retours entre le jeu et l" & vbCrLf & " décodeur jusqu'à ce que le décodeur trouve la combinaison secrète ou atteigne" & vbCrLf & " le nombre maximum de tentatives autorisées dans un temps imparti." & vbCrLf &
      "Le jeu peut avoir différentes variantes, telles que l'utilisation de" & vbCrLf & " d'autres types de caractères, la modification du temps et/ou du " & vbCrLf & "nombres de chances. Le décodeur gagne s'il parvient à trouver la combinaison secrète dans les" & vbCrLf & "limites de tentatives autorisées. Le codeur gagne s'il parvient à rendre" & vbCrLf & " la combinaison secrète suffisamment difficile à trouver."
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.Hide()
        Accueil.Show()
    End Sub
End Class