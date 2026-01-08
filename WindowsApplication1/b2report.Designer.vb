<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class b2report
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmb_year = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_assessed = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_paid = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(30, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 21)
        Me.Label4.TabIndex = 88
        Me.Label4.Text = "Year"
        '
        'cmb_year
        '
        Me.cmb_year.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_year.FormattingEnabled = True
        Me.cmb_year.Location = New System.Drawing.Point(117, 21)
        Me.cmb_year.Name = "cmb_year"
        Me.cmb_year.Size = New System.Drawing.Size(176, 28)
        Me.cmb_year.TabIndex = 90
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(30, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 21)
        Me.Label1.TabIndex = 91
        Me.Label1.Text = "Assessed:"
        '
        'txt_assessed
        '
        Me.txt_assessed.BackColor = System.Drawing.Color.AliceBlue
        Me.txt_assessed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_assessed.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_assessed.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txt_assessed.ForeColor = System.Drawing.Color.Red
        Me.txt_assessed.Location = New System.Drawing.Point(117, 60)
        Me.txt_assessed.Multiline = True
        Me.txt_assessed.Name = "txt_assessed"
        Me.txt_assessed.Size = New System.Drawing.Size(176, 34)
        Me.txt_assessed.TabIndex = 92
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(36, 110)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 21)
        Me.Label2.TabIndex = 93
        Me.Label2.Text = "Paid:"
        '
        'txt_paid
        '
        Me.txt_paid.BackColor = System.Drawing.Color.AliceBlue
        Me.txt_paid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_paid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_paid.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txt_paid.ForeColor = System.Drawing.Color.Red
        Me.txt_paid.Location = New System.Drawing.Point(117, 105)
        Me.txt_paid.Multiline = True
        Me.txt_paid.Name = "txt_paid"
        Me.txt_paid.Size = New System.Drawing.Size(176, 34)
        Me.txt_paid.TabIndex = 94
        '
        'b2report
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(350, 157)
        Me.Controls.Add(Me.txt_paid)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_assessed)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmb_year)
        Me.Controls.Add(Me.Label4)
        Me.Name = "b2report"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "No. of Assessed and Paid Businesses"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmb_year As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_assessed As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_paid As System.Windows.Forms.TextBox
End Class
