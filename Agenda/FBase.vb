Public Class FBase

    'On instancie l'objet GestionFichier.
    Public Gestion As New GestionFichier()

    'Cette procédure évènementielle vérifie que le mot de passe et le nom de l'utilisateur sont bel et bien existant dans les svgdes du programme.
    Private Sub BOKLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOKLogin.Click

        Dim Verification As Integer
        Verification = Gestion.VerificationUtilisateur(TBMotPasse.Text, TBNomUtil.Text)

        'En fonction de la valeur renvoyée par "VerificationUtilisateur" on accepte ou non l'accès à l'agenda (-1 : refus/0 ou 1 : accepter). 
        If Verification = -1 Then
            MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect !")
        ElseIf Verification = 0 Then

            'Si la valeur renvoyée par "VerificationUtilisateur" est 0, on empêche l'accès au panel d'administration.
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
