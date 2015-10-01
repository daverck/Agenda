<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DErreur
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.LErreur = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.OK_Button.Location = New System.Drawing.Point(133, 102)
        Me.OK_Button.Margin = New System.Windows.Forms.Padding(4)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(89, 28)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'LErreur
        '
        Me.LErreur.AutoSize = True
        Me.LErreur.Location = New System.Drawing.Point(34, 52)
        Me.LErreur.Name = "LErreur"
        Me.LErreur.Size = New System.Drawing.Size(0, 17)
        Me.LErreur.TabIndex = 1
        Me.LErreur.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DErreur
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(348, 143)
        Me.ControlBox = False
        Me.Controls.Add(Me.LErreur)
        Me.Controls.Add(Me.OK_Button)
        Me.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DErreur"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DErreur"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents LErreur As System.Windows.Forms.Label

End Class
