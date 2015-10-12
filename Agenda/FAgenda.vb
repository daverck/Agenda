Imports System.Drawing

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
        Static Dim Heure As Integer
        Static Dim Page As Integer
        Dim Position As System.Drawing.PointF
        Dim Rectangle As RectangleF
        Dim RectangleTitre As RectangleF
        Dim RectangleHeure As RectangleF
        Dim Police As Font
        Dim PoliceBold As Font
        Dim PoliceTitre As Font
        Dim HauteurLigne As Single
        Dim HauteurLigneTitre As Single
        Dim NbrLignesParPage As Integer
        Dim NumLigne As Integer = 1
        Dim stringSize As New SizeF

        ' Dans cet exemple, toutes les lignes utilisent la même police
        Police = New Font("Courier New", 10, FontStyle.Regular)
        PoliceBold = New Font("Courier New", 10, FontStyle.Bold)
        PoliceTitre = New Font("Courier New", 15, FontStyle.Bold)
        HauteurLigne = Police.GetHeight(e.Graphics)
        HauteurLigneTitre = PoliceTitre.GetHeight(e.Graphics)
        Rectangle.Width = e.MarginBounds.Width - 80
        Rectangle.Height = HauteurLigne
        RectangleTitre.Width = e.MarginBounds.Width
        RectangleTitre.Height = HauteurLigneTitre
        RectangleHeure.Width = 80
        RectangleHeure.Height = HauteurLigne

        ' Le Nombre de lignes par page est la hauteur de la zone imprimable ( - taille du titre) divisée par la hauteur d'une ligne
        NbrLignesParPage = (e.MarginBounds.Height - HauteurLigneTitre * 2) / HauteurLigne

        'Titre sur la première page
        If Page = 0 Then
            ' Mise en page du Titre
            Ligne = "Calendrier de " & FBase.TBNomUtil.Text & " : Notes du " & Calendrier.SelectionRange.Start.Day.ToString & "/" & Calendrier.SelectionRange.Start.Month.ToString & " au " & Calendrier.SelectionRange.End.Day & "/" & Calendrier.SelectionRange.End.Month & "/" & Calendrier.SelectionRange.Start.Year.ToString
            Position = New PointF(e.MarginBounds.Left, e.MarginBounds.Top)
            RectangleTitre.Location = Position
            e.Graphics.DrawString(Ligne, PoliceTitre, Brushes.Black, RectangleTitre)

            'ont saute une ligne sous le titre
            Ligne = ""
            Position = New PointF(e.MarginBounds.Left, e.MarginBounds.Top + HauteurLigneTitre)
            RectangleTitre.Location = Position
            e.Graphics.DrawString(Ligne, PoliceTitre, Brushes.Black, RectangleTitre)
        End If

        ' Mise en page des horaires et des notes
        Do
            Ligne = TBHeures(Heure).Text
            stringSize = e.Graphics.MeasureString(Ligne, Police)
            Rectangle.Height = HauteurLigne + HauteurLigne * (stringSize.Width \ Rectangle.Width)
            Position = New PointF(e.MarginBounds.Left + 80, e.MarginBounds.Top + HauteurLigneTitre * 2 + (NumLigne * HauteurLigne))
            'si il y a assez de place sur la page
            If (Position.Y + Rectangle.Height) <= (e.PageBounds.Height - e.PageSettings.HardMarginY) Then
                'rectangle pour note
                Rectangle.Location = Position
                e.Graphics.DrawString(Ligne, Police, Brushes.Black, Rectangle)
                'rectangle pour heure
                Ligne = Heure.ToString("D2") & "h-" & (Heure + 1).ToString("D2") & "h"
                Position = New PointF(e.MarginBounds.Left, e.MarginBounds.Top + HauteurLigneTitre * 2 + (NumLigne * HauteurLigne))
                RectangleHeure.Location = Position
                e.Graphics.DrawString(Ligne, PoliceBold, Brushes.Black, RectangleHeure)
                ' Comptage des lignes imprimées
                NumLigne += (stringSize.Width \ Rectangle.Width) + 1
                Heure += 1
            ElseIf (stringSize.Width \ Rectangle.Width) + 1 > NbrLignesParPage Then
                MessageBox.Show("texte trop long pour être mis en page correctement !")
                PrintPreviewDialogJour.Close()
                Exit Sub
            Else
                e.HasMorePages = True
                Exit Do
            End If
        Loop Until Heure > 23 Or (Position.Y + Rectangle.Height) > (e.PageBounds.Height - e.PageSettings.HardMarginY)

        'après la dernière page imprimée on remet les compteurs à 0
        If Heure = 24 Then
            Heure = 0
            Page = 0
            e.HasMorePages = False
        End If

    End Sub

    Private Sub BImprimer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BImprimer.Click
        PageSetupDialogJour.Document = PrintDocumentJour
        If PageSetupDialogJour.ShowDialog() = DialogResult.OK Then
            PrintPreviewDialogJour.Document = PrintDocumentJour
            PrintPreviewDialogJour.ShowDialog()
        End If
    End Sub

    Private Sub BCreerNouvUtil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCreerNouvUtil.Click

        Dim Utilisateur As New ListViewItem
        Dim Admin As Integer

        Utilisateur.Text = TBNouvUtil.Text
        Utilisateur.SubItems.Add(TBNouvMotPasse.Text)

        If CBAdmin.Checked = True Then
            Admin = 1
        End If

        LVUtil.Items.Add(Utilisateur)

        FBase.Gestion.GestionUtilisateurs(TBNouvUtil.Text, TBNouvMotPasse.Text, 1, Admin)

        TBNouvUtil.Text = ""
        TBNouvMotPasse.Text = ""

    End Sub

    Private Sub BSupprimUtil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSupprimUtil.Click

        If LVUtil.SelectedItems.Count > 0 Then
            LVUtil.Items.Remove(LVUtil.SelectedItems(0))

            FBase.Gestion.GestionUtilisateurs(TBNouvUtil.Text, TBNouvMotPasse.Text, 2)

            TBNouvUtil.Text = ""
            TBNouvMotPasse.Text = ""

        End If

    End Sub

    Private Sub BModiF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BModiF.Click
        If LVUtil.SelectedItems.Count > 0 Then
            Dim Admin As Integer
            
            If CBAdmin.Checked = True Then
                Admin = 1
            End If

            FBase.Gestion.ModifUtilisateur(LVUtil.SelectedItems(0).Text, TBNouvUtil.Text, TBNouvMotPasse.Text, Admin)

            LVUtil.SelectedItems(0).Text = TBNouvUtil.Text
            LVUtil.SelectedItems(0).SubItems(1).Text = TBNouvMotPasse.Text

            TBNouvUtil.Text = ""
            TBNouvMotPasse.Text = ""
        End If
    End Sub

    Private Sub LVUtil_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LVUtil.SelectedIndexChanged
        TBNouvUtil.Text = LVUtil.SelectedItems(0).Text
        TBNouvMotPasse.Text = LVUtil.SelectedItems(0).SubItems(1).Text
    End Sub

End Class