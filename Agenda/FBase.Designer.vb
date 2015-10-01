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
        Me.Label1.Location = New System.Drawing.Point(55, 86)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nom d'utilisateur :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(70, 131)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Mot de passe :"
        '
        'BOKLogin
        '
        Me.BOKLogin.Location = New System.Drawing.Point(183, 188)
        Me.BOKLogin.Name = "BOKLogin"
        Me.BOKLogin.Size = New System.Drawing.Size(99, 23)
        Me.BOKLogin.TabIndex = 2
        Me.BOKLogin.Text = "OK"
        Me.BOKLogin.UseVisualStyleBackColor = True
        '
        'TBNomUtil
        '
        Me.TBNomUtil.Location = New System.Drawing.Point(183, 78)
        Me.TBNomUtil.Name = "TBNomUtil"
        Me.TBNomUtil.Size = New System.Drawing.Size(100, 20)
        Me.TBNomUtil.TabIndex = 3
        '
        'TBMotPasse
        '
        Me.TBMotPasse.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TBMotPasse.Location = New System.Drawing.Point(183, 131)
        Me.TBMotPasse.Name = "TBMotPasse"
        Me.TBMotPasse.Size = New System.Drawing.Size(100, 20)
        Me.TBMotPasse.TabIndex = 4
        Me.TBMotPasse.UseSystemPasswordChar = True
        '
        'FBase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(392, 293)
        Me.Controls.Add(Me.TBMotPasse)
        Me.Controls.Add(Me.TBNomUtil)
        Me.Controls.Add(Me.BOKLogin)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
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
