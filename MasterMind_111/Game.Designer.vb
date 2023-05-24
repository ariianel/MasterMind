<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Game
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
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.text = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.text2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.text3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.text4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.text5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PanelTextBox = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Button2 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelTextBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Goudy Stout", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(64, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(363, 37)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "MASTERMIND"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(280, 130)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Code Couleur"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(279, 249)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Caractères jouables"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(88, 127)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 15)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Precedents essais"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.DarkGreen
        Me.Button1.Location = New System.Drawing.Point(421, 80)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 20)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Guess"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(338, 7)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(60, 20)
        Me.TextBox5.TabIndex = 6
        Me.TextBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(258, 7)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(60, 20)
        Me.TextBox4.TabIndex = 7
        Me.TextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(173, 8)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(60, 20)
        Me.TextBox3.TabIndex = 8
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(94, 8)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(60, 20)
        Me.TextBox2.TabIndex = 9
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(12, 8)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(60, 20)
        Me.TextBox1.TabIndex = 10
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(289, 151)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Absent"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(289, 173)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Présent"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Green
        Me.Label7.Location = New System.Drawing.Point(289, 196)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(109, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Présent et Bien Placé"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Teal
        Me.Label8.Location = New System.Drawing.Point(289, 271)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 15)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "# $ £ % @"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(279, 336)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(79, 13)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "Temps restant"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(289, 361)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(45, 13)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "Label10"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.ColumnHeadersVisible = False
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.text, Me.text2, Me.text3, Me.text4, Me.text5})
        Me.DataGridView1.Location = New System.Drawing.Point(45, 151)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(197, 365)
        Me.DataGridView1.TabIndex = 17
        '
        'text
        '
        Me.text.HeaderText = "1"
        Me.text.Name = "text"
        '
        'text2
        '
        Me.text2.HeaderText = "2"
        Me.text2.Name = "text2"
        '
        'text3
        '
        Me.text3.HeaderText = "3"
        Me.text3.Name = "text3"
        '
        'text4
        '
        Me.text4.HeaderText = "4"
        Me.text4.Name = "text4"
        '
        'text5
        '
        Me.text5.HeaderText = "5"
        Me.text5.Name = "text5"
        '
        'PanelTextBox
        '
        Me.PanelTextBox.Controls.Add(Me.TextBox1)
        Me.PanelTextBox.Controls.Add(Me.TextBox2)
        Me.PanelTextBox.Controls.Add(Me.TextBox3)
        Me.PanelTextBox.Controls.Add(Me.TextBox4)
        Me.PanelTextBox.Controls.Add(Me.TextBox5)
        Me.PanelTextBox.Location = New System.Drawing.Point(9, 71)
        Me.PanelTextBox.Name = "PanelTextBox"
        Me.PanelTextBox.Size = New System.Drawing.Size(406, 39)
        Me.PanelTextBox.TabIndex = 18
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Brown
        Me.Label11.Location = New System.Drawing.Point(289, 428)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(50, 15)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "Label11"
        '
        'Timer1
        '
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.DarkRed
        Me.Button2.Location = New System.Drawing.Point(408, 488)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(87, 27)
        Me.Button2.TabIndex = 20
        Me.Button2.Text = "Bye"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Game
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(508, 528)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.PanelTextBox)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Game"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelTextBox.ResumeLayout(False)
        Me.PanelTextBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents text As DataGridViewTextBoxColumn
    Friend WithEvents text2 As DataGridViewTextBoxColumn
    Friend WithEvents text3 As DataGridViewTextBoxColumn
    Friend WithEvents text4 As DataGridViewTextBoxColumn
    Friend WithEvents text5 As DataGridViewTextBoxColumn
    Friend WithEvents PanelTextBox As Panel
    Friend WithEvents Label11 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Button2 As Button
End Class
