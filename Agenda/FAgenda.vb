Public Class FAgenda

    'on trouve l'indice du jour actuel
    Dim JourDeLAnnee As Integer

    Private Sub FAgenda_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = My.Computer.Screen.WorkingArea.Location
        Me.Size = My.Computer.Screen.WorkingArea.Size

        'Limitation de la plage du widget calendrier à l'année courante
        Me.Calendrier.MinDate = New DateTime(DateTime.Now.Year, 1, 1)
        Me.Calendrier.MaxDate = New DateTime(DateTime.Now.Year, 12, 31)
    End Sub

    Private Sub FAgenda_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'on trouve l'indice du jour actuel
        JourDeLAnnee = Me.Calendrier.SelectionRange.Start.DayOfYear

        'on enregistre les notes du jour avant la fermeture
        FBase.Gestion.EcritureAgenda(JourDeLAnnee, 0, TBHeureRdv0.Text)
        FBase.Gestion.EcritureAgenda(JourDeLAnnee, 1, TBHeureRdv1.Text)
        FBase.Gestion.EcritureAgenda(JourDeLAnnee, 2, TBHeureRdv2.Text)
        FBase.Gestion.EcritureAgenda(JourDeLAnnee, 3, TBHeureRdv3.Text)
        FBase.Gestion.EcritureAgenda(JourDeLAnnee, 4, TBHeureRdv4.Text)
        FBase.Gestion.EcritureAgenda(JourDeLAnnee, 5, TBHeureRdv5.Text)
        FBase.Gestion.EcritureAgenda(JourDeLAnnee, 6, TBHeureRdv6.Text)
        FBase.Gestion.EcritureAgenda(JourDeLAnnee, 7, TBHeureRdv7.Text)
        FBase.Gestion.EcritureAgenda(JourDeLAnnee, 8, TBHeureRdv8.Text)
        FBase.Gestion.EcritureAgenda(JourDeLAnnee, 9, TBHeureRdv9.Text)
        FBase.Gestion.EcritureAgenda(JourDeLAnnee, 10, TBHeureRdv10.Text)
        FBase.Gestion.EcritureAgenda(JourDeLAnnee, 11, TBHeureRdv11.Text)
        FBase.Gestion.EcritureAgenda(JourDeLAnnee, 12, TBHeureRdv12.Text)
        FBase.Gestion.EcritureAgenda(JourDeLAnnee, 13, TBHeureRdv13.Text)
        FBase.Gestion.EcritureAgenda(JourDeLAnnee, 14, TBHeureRdv14.Text)
        FBase.Gestion.EcritureAgenda(JourDeLAnnee, 15, TBHeureRdv15.Text)
        FBase.Gestion.EcritureAgenda(JourDeLAnnee, 16, TBHeureRdv16.Text)
        FBase.Gestion.EcritureAgenda(JourDeLAnnee, 17, TBHeureRdv17.Text)
        FBase.Gestion.EcritureAgenda(JourDeLAnnee, 18, TBHeureRdv18.Text)
        FBase.Gestion.EcritureAgenda(JourDeLAnnee, 19, TBHeureRdv19.Text)
        FBase.Gestion.EcritureAgenda(JourDeLAnnee, 20, TBHeureRdv20.Text)
        FBase.Gestion.EcritureAgenda(JourDeLAnnee, 21, TBHeureRdv21.Text)
        FBase.Gestion.EcritureAgenda(JourDeLAnnee, 22, TBHeureRdv22.Text)
        FBase.Gestion.EcritureAgenda(JourDeLAnnee, 23, TBHeureRdv23.Text)
    End Sub

    Private Sub Calendrier_DateSelected(ByVal sender As Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles Calendrier.DateSelected

        Static JustLoaded As Boolean = True

        'Si le formulaire vient juste d'être affiché
        If JustLoaded = True Then
            'on trouve l'indice du jour actuel
            JourDeLAnnee = Me.Calendrier.SelectionRange.Start.DayOfYear

            'on met à jour les textboxs avec les notes inscrites précédement
            TBHeureRdv0.Text = FBase.Gestion.LectureAgenda(JourDeLAnnee, 0)
            TBHeureRdv1.Text = FBase.Gestion.LectureAgenda(JourDeLAnnee, 1)
            TBHeureRdv2.Text = FBase.Gestion.LectureAgenda(JourDeLAnnee, 2)
            TBHeureRdv3.Text = FBase.Gestion.LectureAgenda(JourDeLAnnee, 3)
            TBHeureRdv4.Text = FBase.Gestion.LectureAgenda(JourDeLAnnee, 4)
            TBHeureRdv5.Text = FBase.Gestion.LectureAgenda(JourDeLAnnee, 5)
            TBHeureRdv6.Text = FBase.Gestion.LectureAgenda(JourDeLAnnee, 6)
            TBHeureRdv7.Text = FBase.Gestion.LectureAgenda(JourDeLAnnee, 7)
            TBHeureRdv8.Text = FBase.Gestion.LectureAgenda(JourDeLAnnee, 8)
            TBHeureRdv9.Text = FBase.Gestion.LectureAgenda(JourDeLAnnee, 9)
            TBHeureRdv10.Text = FBase.Gestion.LectureAgenda(JourDeLAnnee, 10)
            TBHeureRdv11.Text = FBase.Gestion.LectureAgenda(JourDeLAnnee, 11)
            TBHeureRdv12.Text = FBase.Gestion.LectureAgenda(JourDeLAnnee, 12)
            TBHeureRdv13.Text = FBase.Gestion.LectureAgenda(JourDeLAnnee, 13)
            TBHeureRdv14.Text = FBase.Gestion.LectureAgenda(JourDeLAnnee, 14)
            TBHeureRdv15.Text = FBase.Gestion.LectureAgenda(JourDeLAnnee, 15)
            TBHeureRdv16.Text = FBase.Gestion.LectureAgenda(JourDeLAnnee, 16)
            TBHeureRdv17.Text = FBase.Gestion.LectureAgenda(JourDeLAnnee, 17)
            TBHeureRdv18.Text = FBase.Gestion.LectureAgenda(JourDeLAnnee, 18)
            TBHeureRdv19.Text = FBase.Gestion.LectureAgenda(JourDeLAnnee, 19)
            TBHeureRdv20.Text = FBase.Gestion.LectureAgenda(JourDeLAnnee, 20)
            TBHeureRdv21.Text = FBase.Gestion.LectureAgenda(JourDeLAnnee, 21)
            TBHeureRdv22.Text = FBase.Gestion.LectureAgenda(JourDeLAnnee, 22)
            TBHeureRdv23.Text = FBase.Gestion.LectureAgenda(JourDeLAnnee, 23)

            JustLoaded = False
        ElseIf JustLoaded = False Then
            'on enregistre les notes du jour actuel
            FBase.Gestion.EcritureAgenda(JourDeLAnnee, 0, TBHeureRdv0.Text)
            FBase.Gestion.EcritureAgenda(JourDeLAnnee, 1, TBHeureRdv1.Text)
            FBase.Gestion.EcritureAgenda(JourDeLAnnee, 2, TBHeureRdv2.Text)
            FBase.Gestion.EcritureAgenda(JourDeLAnnee, 3, TBHeureRdv3.Text)
            FBase.Gestion.EcritureAgenda(JourDeLAnnee, 4, TBHeureRdv4.Text)
            FBase.Gestion.EcritureAgenda(JourDeLAnnee, 5, TBHeureRdv5.Text)
            FBase.Gestion.EcritureAgenda(JourDeLAnnee, 6, TBHeureRdv6.Text)
            FBase.Gestion.EcritureAgenda(JourDeLAnnee, 7, TBHeureRdv7.Text)
            FBase.Gestion.EcritureAgenda(JourDeLAnnee, 8, TBHeureRdv8.Text)
            FBase.Gestion.EcritureAgenda(JourDeLAnnee, 9, TBHeureRdv9.Text)
            FBase.Gestion.EcritureAgenda(JourDeLAnnee, 10, TBHeureRdv10.Text)
            FBase.Gestion.EcritureAgenda(JourDeLAnnee, 11, TBHeureRdv11.Text)
            FBase.Gestion.EcritureAgenda(JourDeLAnnee, 12, TBHeureRdv12.Text)
            FBase.Gestion.EcritureAgenda(JourDeLAnnee, 13, TBHeureRdv13.Text)
            FBase.Gestion.EcritureAgenda(JourDeLAnnee, 14, TBHeureRdv14.Text)
            FBase.Gestion.EcritureAgenda(JourDeLAnnee, 15, TBHeureRdv15.Text)
            FBase.Gestion.EcritureAgenda(JourDeLAnnee, 16, TBHeureRdv16.Text)
            FBase.Gestion.EcritureAgenda(JourDeLAnnee, 17, TBHeureRdv17.Text)
            FBase.Gestion.EcritureAgenda(JourDeLAnnee, 18, TBHeureRdv18.Text)
            FBase.Gestion.EcritureAgenda(JourDeLAnnee, 19, TBHeureRdv19.Text)
            FBase.Gestion.EcritureAgenda(JourDeLAnnee, 20, TBHeureRdv20.Text)
            FBase.Gestion.EcritureAgenda(JourDeLAnnee, 21, TBHeureRdv21.Text)
            FBase.Gestion.EcritureAgenda(JourDeLAnnee, 22, TBHeureRdv22.Text)
            FBase.Gestion.EcritureAgenda(JourDeLAnnee, 23, TBHeureRdv23.Text)

            'on récupère l'indice du jour sélectionné dans l'année en cours
            JourDeLAnnee = Me.Calendrier.SelectionRange.Start.DayOfYear

            'on met à jour les textboxs avec les notes inscrites précédement
            TBHeureRdv0.Text = FBase.Gestion.LectureAgenda(JourDeLAnnee, 0)
            TBHeureRdv1.Text = FBase.Gestion.LectureAgenda(JourDeLAnnee, 1)
            TBHeureRdv2.Text = FBase.Gestion.LectureAgenda(JourDeLAnnee, 2)
            TBHeureRdv3.Text = FBase.Gestion.LectureAgenda(JourDeLAnnee, 3)
            TBHeureRdv4.Text = FBase.Gestion.LectureAgenda(JourDeLAnnee, 4)
            TBHeureRdv5.Text = FBase.Gestion.LectureAgenda(JourDeLAnnee, 5)
            TBHeureRdv6.Text = FBase.Gestion.LectureAgenda(JourDeLAnnee, 6)
            TBHeureRdv7.Text = FBase.Gestion.LectureAgenda(JourDeLAnnee, 7)
            TBHeureRdv8.Text = FBase.Gestion.LectureAgenda(JourDeLAnnee, 8)
            TBHeureRdv9.Text = FBase.Gestion.LectureAgenda(JourDeLAnnee, 9)
            TBHeureRdv10.Text = FBase.Gestion.LectureAgenda(JourDeLAnnee, 10)
            TBHeureRdv11.Text = FBase.Gestion.LectureAgenda(JourDeLAnnee, 11)
            TBHeureRdv12.Text = FBase.Gestion.LectureAgenda(JourDeLAnnee, 12)
            TBHeureRdv13.Text = FBase.Gestion.LectureAgenda(JourDeLAnnee, 13)
            TBHeureRdv14.Text = FBase.Gestion.LectureAgenda(JourDeLAnnee, 14)
            TBHeureRdv15.Text = FBase.Gestion.LectureAgenda(JourDeLAnnee, 15)
            TBHeureRdv16.Text = FBase.Gestion.LectureAgenda(JourDeLAnnee, 16)
            TBHeureRdv17.Text = FBase.Gestion.LectureAgenda(JourDeLAnnee, 17)
            TBHeureRdv18.Text = FBase.Gestion.LectureAgenda(JourDeLAnnee, 18)
            TBHeureRdv19.Text = FBase.Gestion.LectureAgenda(JourDeLAnnee, 19)
            TBHeureRdv20.Text = FBase.Gestion.LectureAgenda(JourDeLAnnee, 20)
            TBHeureRdv21.Text = FBase.Gestion.LectureAgenda(JourDeLAnnee, 21)
            TBHeureRdv22.Text = FBase.Gestion.LectureAgenda(JourDeLAnnee, 22)
            TBHeureRdv23.Text = FBase.Gestion.LectureAgenda(JourDeLAnnee, 23)
        End If

    End Sub

    Private Sub LB_00_01h_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LB_00_01h.Click

    End Sub
End Class