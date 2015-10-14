Public Class FBase

    'on créé une instance de gestion de fichier puis on vérifie si l'utilisateur existe et sous quel niveau d'administration
    Public Gestion As New GestionFichier()

    Private Sub BOKLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOKLogin.Click

        Dim Verification As Integer
        Verification = Gestion.VerificationUtilisateur(TBMotPasse.Text, TBNomUtil.Text)

        If Verification = -1 Then
            MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect !")
        ElseIf Verification = 0 Then
            FAgenda.TCCalendrier.TabPages.Remove(FAgenda.TPUtilisateur)
            FAgenda.Show()
            Me.Visible = False
        Else
            FAgenda.Show()
            Me.Visible = False
        End If

        TBMotPasse.Text = ""
        TBNomUtil.Text = ""
    End Sub

End Class
