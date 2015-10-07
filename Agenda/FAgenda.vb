Public Class FAgenda

    Dim JourDeLAnnee As Integer
    Dim Imprimante As New Impression()
    Dim TBHeures(23) As TextBox

    Private Sub FAgenda_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = My.Computer.Screen.WorkingArea.Location
        Me.Size = My.Computer.Screen.WorkingArea.Size

        'Limitation de la plage du widget calendrier à l'année courante
        Me.Calendrier.MinDate = New DateTime(DateTime.Now.Year, 1, 1)
        Me.Calendrier.MaxDate = New DateTime(DateTime.Now.Year, 12, 31)

        'inscription des textbox dans un tableau
        TBHeures(0) = TBHeureRdv0
        TBHeures(1) = TBHeureRdv1
        TBHeures(2) = TBHeureRdv2
        TBHeures(3) = TBHeureRdv3
        TBHeures(4) = TBHeureRdv4
        TBHeures(5) = TBHeureRdv5
        TBHeures(6) = TBHeureRdv6
        TBHeures(7) = TBHeureRdv7
        TBHeures(8) = TBHeureRdv8
        TBHeures(9) = TBHeureRdv9
        TBHeures(10) = TBHeureRdv10
        TBHeures(11) = TBHeureRdv11
        TBHeures(12) = TBHeureRdv12
        TBHeures(13) = TBHeureRdv13
        TBHeures(14) = TBHeureRdv14
        TBHeures(15) = TBHeureRdv15
        TBHeures(16) = TBHeureRdv16
        TBHeures(17) = TBHeureRdv17
        TBHeures(18) = TBHeureRdv18
        TBHeures(19) = TBHeureRdv19
        TBHeures(20) = TBHeureRdv20
        TBHeures(21) = TBHeureRdv21
        TBHeures(22) = TBHeureRdv22
        TBHeures(23) = TBHeureRdv23

        'on trouve l'indice du jour actuel
        JourDeLAnnee = Me.Calendrier.SelectionRange.Start.DayOfYear

        'on met à jour les textboxs avec les notes inscrites précédement
        For i As Integer = 0 To 23 Step 1
            TBHeures(i).Text = FBase.Gestion.LectureAgenda(JourDeLAnnee, i)
        Next i

        'selection de la premiere textbox
        TBHeureRdv0.Select()
    End Sub

    Private Sub FAgenda_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'on trouve l'indice du jour actuel
        JourDeLAnnee = Me.Calendrier.SelectionRange.Start.DayOfYear

        'on enregistre les notes du jour avant la fermeture
        For i As Integer = 0 To 23 Step 1
            FBase.Gestion.EcritureAgenda(JourDeLAnnee, i, TBHeures(i).Text)
        Next i
        'on affiche une erreur si un problème survient à l'écriture du fichier
        If Not FBase.Gestion.EcritureFichierAgenda() Then
            MessageBox.Show("Erreur à l'enregistrement des données !")
        End If

        'Fermeture de FBase
        FBase.Dispose()
    End Sub

    Private Sub Calendrier_DateSelected(ByVal sender As Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles Calendrier.DateSelected

        'on enregistre les notes du jour actuel
        For i As Integer = 0 To 23 Step 1
            FBase.Gestion.EcritureAgenda(JourDeLAnnee, i, TBHeures(i).Text)
        Next i

        'on récupère l'indice du jour sélectionné dans l'année en cours
        JourDeLAnnee = Me.Calendrier.SelectionRange.Start.DayOfYear

        'on met à jour les textboxs avec les notes inscrites précédement
        For i As Integer = 0 To 23 Step 1
            TBHeures(i).Text = FBase.Gestion.LectureAgenda(JourDeLAnnee, i)
        Next i
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
        Dim NumLigne As Integer

        ' Dans cet exemple, toutes les lignes utilisent la même police
        Police = New Font("Courier New", 10, FontStyle.Regular)
        PoliceBold = New Font("Courier New", 10, FontStyle.Bold)
        PoliceTitre = New Font("Courier New", 15, FontStyle.Bold)
        HauteurLigne = Police.GetHeight(e.Graphics)
        HauteurLigneTitre = PoliceTitre.GetHeight(e.Graphics)
        Rectangle.Width = e.MarginBounds.Width
        Rectangle.Height = HauteurLigne
        RectangleTitre.Width = e.MarginBounds.Width
        RectangleTitre.Height = HauteurLigneTitre

        ' Le Nombre de lignes par page est la hauteur de la zone imprimable ( - taille du titre) divisée par la hauteur d'une ligne
        NbrLignesParPage = (e.MarginBounds.Height - HauteurLigneTitre * 2) / HauteurLigne

        ' Mise en page du Titre
        Ligne = "Calendrier de " & FBase.TBNomUtil.Text & " : Notes du " & Calendrier.SelectionRange.Start.DayOfWeek.ToString & " " & Calendrier.SelectionRange.Start.Day.ToString & " " & Calendrier.SelectionRange.Start.Month.ToString & " " & Calendrier.SelectionRange.Start.Year.ToString
        Position = New PointF(e.MarginBounds.Left, e.MarginBounds.Top)
        RectangleTitre.Location = Position
        e.Graphics.DrawString(Ligne, PoliceTitre, Brushes.Black, RectangleTitre)

        'ont saute une ligne sous le titre
        Ligne = ""
        Position = New PointF(e.MarginBounds.Left, e.MarginBounds.Top)
        RectangleTitre.Location = Position
        e.Graphics.DrawString(Ligne, PoliceTitre, Brushes.Black, RectangleTitre)

        ' Mise en page des horaires et des notes
        'on met à jour les textboxs avec les notes inscrites précédement
        For i As Integer = 0 To 23 Step 1
            'heure
            Ligne = i.ToString("D2") & "h-" & (i + 1).ToString("D2") & "h"
            Position = New PointF(e.MarginBounds.Left, e.MarginBounds.Top + HauteurLigneTitre * 2 + (NumLigne * HauteurLigne))
            Rectangle.Location = Position
            e.Graphics.DrawString(Ligne, PoliceBold, Brushes.Black, Rectangle)
            'note
            Ligne = TBHeures(i).Text
            Position = New PointF(e.MarginBounds.Left + 80, e.MarginBounds.Top + HauteurLigneTitre * 2 + (NumLigne * HauteurLigne))
            Rectangle.Location = Position
            e.Graphics.DrawString(Ligne, Police, Brushes.Black, Rectangle)
            ' Comptage des lignes imprimées
            NumLigne += 1
        Next i
    End Sub

    Private Sub BImprimer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BImprimer.Click
        PageSetupDialogJour.Document = PrintDocumentJour
        If PageSetupDialogJour.ShowDialog() = DialogResult.OK Then
            PrintPreviewDialogJour.Document = PrintDocumentJour
            PrintPreviewDialogJour.ShowDialog()
        End If
    End Sub

End Class