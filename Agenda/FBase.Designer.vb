<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FBase
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BOKLogin = New System.Windows.Forms.Button()
        Me.TBNomUtil = New System.Windows.Forms.TextBox()
        Me.TBMotPasse = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(73, 106)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nom d'utilisateur :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(93, 161)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Mot de passe :"
        '
        'BOKLogin
        '
        Me.BOKLogin.Location = New System.Drawing.Point(244, 231)
        Me.BOKLogin.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BOKLogin.Name = "BOKLogin"
        Me.BOKLogin.Size = New System.Drawing.Size(132, 28)
        Me.BOKLogin.TabIndex = 2
        Me.BOKLogin.Text = "OK"
        Me.BOKLogin.UseVisualStyleBackColor = True
        '
        'TBNomUtil
        '
        Me.TBNomUtil.Location = New System.Drawing.Point(244, 96)
        Me.TBNomUtil.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TBNomUtil.Name = "TBNomUtil"
        Me.TBNomUtil.Size = New System.Drawing.Size(132, 22)
        Me.TBNomUtil.TabIndex = 3
        '
        'TBMotPasse
        '
        Me.TBMotPasse.Location = New System.Drawing.Point(244, 161)
        Me.TBMotPasse.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TBMotPasse.Name = "TBMotPasse"
        Me.TBMotPasse.Size = New System.Drawing.Size(132, 22)
        Me.TBMotPasse.TabIndex = 4
        '
        'FBase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(523, 361)
        Me.Controls.Add(Me.TBMotPasse)
        Me.Controls.Add(Me.TBNomUtil)
        Me.Controls.Add(Me.BOKLogin)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FBase"
        Me.Text = "Agenda"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BOKLogin As System.Windows.Forms.Button
    Friend WithEvents TBNomUtil As System.Windows.Forms.TextBox
    Friend WithEvents TBMotPasse As System.Windows.Forms.TextBox

End Class
