Public Class FBase

    'on créé une instance de gestion de fichier puis on vérifie si l'utilisateur existe et sous quel niveau d'administration
    Public Gestion As New GestionFichier()
    Private Sub BOKLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOKLogin.Click

        'on créé une instance de gestion de fichier puis on vérifie si l'utilisateur existe et sous quel niveau d'administration
        Dim Gestion As New GestionFichier()
        Dim Verification As Integer

        Verification = Gestion.VerificationUtilisateur(TBMotPasse.Text, TBNomUtil.Text)

        If Verification = -1 Then
            MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect !")
            TBMotPasse.Text = ""
            TBNomUtil.Text = ""
        ElseIf Verification = 0 Then
            FAgenda.Show()
            Me.Visible = False
        Else
            FAgenda.Show()
            Me.Visible = False
        End If
    End Sub

End Class
