Public Class FBase

    'on créé une instance de gestion de fichier
    Public Gestion As New GestionFichier()

    Private Sub BOKLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOKLogin.Click
        Dim Test As Integer
        Test = Gestion.VerificationUtilisateur("Test", "Coucou")
        FAgenda.Show()
    End Sub

End Class
