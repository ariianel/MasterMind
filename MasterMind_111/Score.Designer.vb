<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Score
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
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.ListBox3 = New System.Windows.Forms.ListBox()
        Me.ListBox4 = New System.Windows.Forms.ListBox()
        Me.ListBox5 = New System.Windows.Forms.ListBox()
        Me.ListBox6 = New System.Windows.Forms.ListBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.ComboBoxRechercheJoueur = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(12, 85)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(112, 355)
        Me.ListBox1.TabIndex = 0
        '
        'ListBox2
        '
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.Location = New System.Drawing.Point(130, 85)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(112, 355)
        Me.ListBox2.TabIndex = 2
        '
        'ListBox3
        '
        Me.ListBox3.FormattingEnabled = True
        Me.ListBox3.Location = New System.Drawing.Point(248, 85)
        Me.ListBox3.Name = "ListBox3"
        Me.ListBox3.Size = New System.Drawing.Size(141, 355)
        Me.ListBox3.TabIndex = 3
        '
        'ListBox4
        '
        Me.ListBox4.FormattingEnabled = True
        Me.ListBox4.Location = New System.Drawing.Point(395, 85)
        Me.ListBox4.Name = "ListBox4"
        Me.ListBox4.Size = New System.Drawing.Size(120, 355)
        Me.ListBox4.TabIndex = 4
        '
        'ListBox5
        '
        Me.ListBox5.FormattingEnabled = True
        Me.ListBox5.Location = New System.Drawing.Point(521, 85)
        Me.ListBox5.Name = "ListBox5"
        Me.ListBox5.Size = New System.Drawing.Size(120, 355)
        Me.ListBox5.TabIndex = 5
        '
        'ListBox6
        '
        Me.ListBox6.FormattingEnabled = True
        Me.ListBox6.Location = New System.Drawing.Point(647, 85)
        Me.ListBox6.Name = "ListBox6"
        Me.ListBox6.Size = New System.Drawing.Size(122, 355)
        Me.ListBox6.TabIndex = 6
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(395, 36)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(116, 31)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Ordre Alphabétique"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(538, 36)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(86, 31)
        Me.Button2.TabIndex = 8
        Me.Button2.Text = "Meilleur Score"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(660, 36)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(86, 31)
        Me.Button3.TabIndex = 9
        Me.Button3.Text = "Meilleur Temps"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'ComboBoxRechercheJoueur
        '
        Me.ComboBoxRechercheJoueur.FormattingEnabled = True
        Me.ComboBoxRechercheJoueur.Location = New System.Drawing.Point(158, 42)
        Me.ComboBoxRechercheJoueur.Name = "ComboBoxRechercheJoueur"
        Me.ComboBoxRechercheJoueur.Size = New System.Drawing.Size(206, 21)
        Me.ComboBoxRechercheJoueur.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(485, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(198, 15)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Appuyez sur un bouton pour trier :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(210, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 15)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Recherche par nom:"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.Location = New System.Drawing.Point(12, 11)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(59, 15)
        Me.LinkLabel1.TabIndex = 14
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "⬅️ Retour"
        '
        'Score
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBoxRechercheJoueur)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ListBox6)
        Me.Controls.Add(Me.ListBox5)
        Me.Controls.Add(Me.ListBox4)
        Me.Controls.Add(Me.ListBox3)
        Me.Controls.Add(Me.ListBox2)
        Me.Controls.Add(Me.ListBox1)
        Me.Name = "Score"
        Me.Text = "Score"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents ListBox2 As ListBox
    Friend WithEvents ListBox3 As ListBox
    Friend WithEvents ListBox4 As ListBox
    Friend WithEvents ListBox5 As ListBox
    Friend WithEvents ListBox6 As ListBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents ComboBoxRechercheJoueur As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents LinkLabel1 As LinkLabel
End Class
