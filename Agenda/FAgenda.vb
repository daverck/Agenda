Public Class FAgenda

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
        If Not FBase.Gestion.EcritureFichierAgenda() Then
            DErreur.LErreur.Text = "Erreur à l'enregistrement des données !"
            DErreur.ShowDialog()
        End If
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
            If Not FBase.Gestion.EcritureFichierAgenda() Then
                DErreur.LErreur.Text = "Erreur à l'enregistrement des données !"
                DErreur.ShowDialog()
            End If

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

    Private Sub PrintDocumentJour_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocumentJour.PrintPage
        Dim Ligne As String
        Dim Position As System.Drawing.PointF
        Dim Rectangle As RectangleF
        Dim RectangleTitre As RectangleF
        Dim Police As Font
        Dim PoliceBold As Font
        Dim PoliceTitre As Font
        Dim HauteurLigne As Single
        Dim HauteurLigneTitre As Single
        Dim NbrLignesParPage As Integer
        Dim NumLigne As Integer = 0 ' Comptage des lignes imprimées

        ' Dans cet exemple, toutes les lignes utilisent la même police
        Police = New Font("Courier New", 10, FontStyle.Regular)
        'PoliceBold = New Font("Courier New", 10, FontStyle.Bold)
        PoliceTitre = New Font("Courier New", 20, FontStyle.Bold)
        HauteurLigne = Police.GetHeight(e.Graphics)
        HauteurLigneTitre = PoliceTitre.GetHeight(e.Graphics)
        Rectangle.Width = e.MarginBounds.Width
        Rectangle.Height = HauteurLigne
        RectangleTitre.Width = e.MarginBounds.Width
        RectangleTitre.Height = HauteurLigneTitre

        ' Le Nombre de lignes par page est la hauteur de la zone imprimable ( - taille du titre) divisée par la hauteur d'une ligne
        NbrLignesParPage = (e.MarginBounds.Height - HauteurLigneTitre) / HauteurLigne

        ' Mise en page du Titre
        Ligne = "Notes du " & Calendrier.SelectionRange.Start.DayOfWeek.ToString & " " & Calendrier.SelectionRange.Start.Day.ToString & " " & Calendrier.SelectionRange.Start.Month.ToString & " " & Calendrier.SelectionRange.Start.Year.ToString
        Position = New PointF(e.MarginBounds.Left, e.MarginBounds.Top)
        RectangleTitre.Location = Position
        e.Graphics.DrawString(Ligne, PoliceTitre, Brushes.Black, RectangleTitre)

        ' Mise en page des horaires et des notes
        ' 00h
        Ligne = "00h-01h    " & TBHeureRdv0.Text
        Position = New PointF(e.MarginBounds.Left, e.MarginBounds.Top + HauteurLigneTitre + (NumLigne * HauteurLigne))
        Rectangle.Location = Position
        e.Graphics.DrawString(Ligne, Police, Brushes.Black, Rectangle)
        NumLigne += 1

        ' 01h
        Ligne = "01h-02h    " & TBHeureRdv1.Text
        Position = New PointF(e.MarginBounds.Left, e.MarginBounds.Top + HauteurLigneTitre + (NumLigne * HauteurLigne))
        Rectangle.Location = Position
        e.Graphics.DrawString(Ligne, Police, Brushes.Black, Rectangle)
        NumLigne += 1

        ' 02h
        Ligne = "02h-03h    " & TBHeureRdv2.Text
        Position = New PointF(e.MarginBounds.Left, e.MarginBounds.Top + HauteurLigneTitre + (NumLigne * HauteurLigne))
        Rectangle.Location = Position
        e.Graphics.DrawString(Ligne, Police, Brushes.Black, Rectangle)
        NumLigne += 1

        ' 03h
        Ligne = "03h-04h    " & TBHeureRdv3.Text
        Position = New PointF(e.MarginBounds.Left, e.MarginBounds.Top + HauteurLigneTitre + (NumLigne * HauteurLigne))
        Rectangle.Location = Position
        e.Graphics.DrawString(Ligne, Police, Brushes.Black, Rectangle)
        NumLigne += 1

        ' 04h
        Ligne = "04h-05h    " & TBHeureRdv4.Text
        Position = New PointF(e.MarginBounds.Left, e.MarginBounds.Top + HauteurLigneTitre + (NumLigne * HauteurLigne))
        Rectangle.Location = Position
        e.Graphics.DrawString(Ligne, Police, Brushes.Black, Rectangle)
        NumLigne += 1

        ' 05h
        Ligne = "05h-06h    " & TBHeureRdv5.Text
        Position = New PointF(e.MarginBounds.Left, e.MarginBounds.Top + HauteurLigneTitre + (NumLigne * HauteurLigne))
        Rectangle.Location = Position
        e.Graphics.DrawString(Ligne, Police, Brushes.Black, Rectangle)
        NumLigne += 1

        ' 06h
        Ligne = "06h-07h    " & TBHeureRdv6.Text
        Position = New PointF(e.MarginBounds.Left, e.MarginBounds.Top + HauteurLigneTitre + (NumLigne * HauteurLigne))
        Rectangle.Location = Position
        e.Graphics.DrawString(Ligne, Police, Brushes.Black, Rectangle)
        NumLigne += 1

        ' 07h
        Ligne = "07h-08h    " & TBHeureRdv7.Text
        Position = New PointF(e.MarginBounds.Left, e.MarginBounds.Top + HauteurLigneTitre + (NumLigne * HauteurLigne))
        Rectangle.Location = Position
        e.Graphics.DrawString(Ligne, Police, Brushes.Black, Rectangle)
        NumLigne += 1

        ' 08h
        Ligne = "08h-09h    " & TBHeureRdv8.Text
        Position = New PointF(e.MarginBounds.Left, e.MarginBounds.Top + HauteurLigneTitre + (NumLigne * HauteurLigne))
        Rectangle.Location = Position
        e.Graphics.DrawString(Ligne, Police, Brushes.Black, Rectangle)
        NumLigne += 1

        ' 09h
        Ligne = "09h-10h    " & TBHeureRdv9.Text
        Position = New PointF(e.MarginBounds.Left, e.MarginBounds.Top + HauteurLigneTitre + (NumLigne * HauteurLigne))
        Rectangle.Location = Position
        e.Graphics.DrawString(Ligne, Police, Brushes.Black, Rectangle)
        NumLigne += 1

        ' 10h
        Ligne = "10h-11h    " & TBHeureRdv10.Text
        Position = New PointF(e.MarginBounds.Left, e.MarginBounds.Top + HauteurLigneTitre + (NumLigne * HauteurLigne))
        Rectangle.Location = Position
        e.Graphics.DrawString(Ligne, Police, Brushes.Black, Rectangle)
        NumLigne += 1

        ' 11h
        Ligne = "11h-12h    " & TBHeureRdv11.Text
        Position = New PointF(e.MarginBounds.Left, e.MarginBounds.Top + HauteurLigneTitre + (NumLigne * HauteurLigne))
        Rectangle.Location = Position
        e.Graphics.DrawString(Ligne, Police, Brushes.Black, Rectangle)
        NumLigne += 1

        ' 12h
        Ligne = "12h-13h    " & TBHeureRdv12.Text
        Position = New PointF(e.MarginBounds.Left, e.MarginBounds.Top + HauteurLigneTitre + (NumLigne * HauteurLigne))
        Rectangle.Location = Position
        e.Graphics.DrawString(Ligne, Police, Brushes.Black, Rectangle)
        NumLigne += 1

        ' 13h
        Ligne = "13h-14h    " & TBHeureRdv13.Text
        Position = New PointF(e.MarginBounds.Left, e.MarginBounds.Top + HauteurLigneTitre + (NumLigne * HauteurLigne))
        Rectangle.Location = Position
        e.Graphics.DrawString(Ligne, Police, Brushes.Black, Rectangle)
        NumLigne += 1

        ' 14h
        Ligne = "14h-15h    " & TBHeureRdv14.Text
        Position = New PointF(e.MarginBounds.Left, e.MarginBounds.Top + HauteurLigneTitre + (NumLigne * HauteurLigne))
        Rectangle.Location = Position
        e.Graphics.DrawString(Ligne, Police, Brushes.Black, Rectangle)
        NumLigne += 1

        ' 15h
        Ligne = "15h-16h    " & TBHeureRdv15.Text
        Position = New PointF(e.MarginBounds.Left, e.MarginBounds.Top + HauteurLigneTitre + (NumLigne * HauteurLigne))
        Rectangle.Location = Position
        e.Graphics.DrawString(Ligne, Police, Brushes.Black, Rectangle)
        NumLigne += 1

        ' 16h
        Ligne = "16h-17h    " & TBHeureRdv16.Text
        Position = New PointF(e.MarginBounds.Left, e.MarginBounds.Top + HauteurLigneTitre + (NumLigne * HauteurLigne))
        Rectangle.Location = Position
        e.Graphics.DrawString(Ligne, Police, Brushes.Black, Rectangle)
        NumLigne += 1

        ' 17h
        Ligne = "17h-18h    " & TBHeureRdv17.Text
        Position = New PointF(e.MarginBounds.Left, e.MarginBounds.Top + HauteurLigneTitre + (NumLigne * HauteurLigne))
        Rectangle.Location = Position
        e.Graphics.DrawString(Ligne, Police, Brushes.Black, Rectangle)
        NumLigne += 1

        ' 18h
        Ligne = "18h-19h    " & TBHeureRdv18.Text
        Position = New PointF(e.MarginBounds.Left, e.MarginBounds.Top + HauteurLigneTitre + (NumLigne * HauteurLigne))
        Rectangle.Location = Position
        e.Graphics.DrawString(Ligne, Police, Brushes.Black, Rectangle)
        NumLigne += 1

        ' 19h
        Ligne = "19h-20h    " & TBHeureRdv19.Text
        Position = New PointF(e.MarginBounds.Left, e.MarginBounds.Top + HauteurLigneTitre + (NumLigne * HauteurLigne))
        Rectangle.Location = Position
        e.Graphics.DrawString(Ligne, Police, Brushes.Black, Rectangle)
        NumLigne += 1

        ' 20h
        Ligne = "20h-21h    " & TBHeureRdv20.Text
        Position = New PointF(e.MarginBounds.Left, e.MarginBounds.Top + HauteurLigneTitre + (NumLigne * HauteurLigne))
        Rectangle.Location = Position
        e.Graphics.DrawString(Ligne, Police, Brushes.Black, Rectangle)
        NumLigne += 1

        ' 21h
        Ligne = "21h-22h    " & TBHeureRdv21.Text
        Position = New PointF(e.MarginBounds.Left, e.MarginBounds.Top + HauteurLigneTitre + (NumLigne * HauteurLigne))
        Rectangle.Location = Position
        e.Graphics.DrawString(Ligne, Police, Brushes.Black, Rectangle)
        NumLigne += 1

        ' 22h
        Ligne = "22h-23h    " & TBHeureRdv22.Text
        Position = New PointF(e.MarginBounds.Left, e.MarginBounds.Top + HauteurLigneTitre + (NumLigne * HauteurLigne))
        Rectangle.Location = Position
        e.Graphics.DrawString(Ligne, Police, Brushes.Black, Rectangle)
        NumLigne += 1

        ' 23h
        Ligne = "23h-00h    " & TBHeureRdv23.Text
        Position = New PointF(e.MarginBounds.Left, e.MarginBounds.Top + HauteurLigneTitre + (NumLigne * HauteurLigne))
        Rectangle.Location = Position
        e.Graphics.DrawString(Ligne, Police, Brushes.Black, Rectangle)
        NumLigne += 1
    End Sub

    Private Sub BImprimer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BImprimer.Click
        PageSetupDialogJour.Document = PrintDocumentJour
        If PageSetupDialogJour.ShowDialog() = DialogResult.OK Then
            PrintPreviewDialogJour.Document = PrintDocumentJour
            PrintPreviewDialogJour.ShowDialog()
        End If
    End Sub

End Class