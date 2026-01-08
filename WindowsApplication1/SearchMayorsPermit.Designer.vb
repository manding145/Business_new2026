<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SearchMayorsPermit
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
        Me.Label16 = New System.Windows.Forms.Label()
        Me.check_controlno = New System.Windows.Forms.CheckBox()
        Me.check_lastaname = New System.Windows.Forms.CheckBox()
        Me.txt_businessName = New System.Windows.Forms.TextBox()
        Me.txt_accountno = New System.Windows.Forms.TextBox()
        Me.BtnSearchRecord = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(12, 9)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(73, 15)
        Me.Label16.TabIndex = 194
        Me.Label16.Text = "SEARCH BY:"
        '
        'check_controlno
        '
        Me.check_controlno.AutoSize = True
        Me.check_controlno.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.check_controlno.Location = New System.Drawing.Point(37, 57)
        Me.check_controlno.Name = "check_controlno"
        Me.check_controlno.Size = New System.Drawing.Size(106, 19)
        Me.check_controlno.TabIndex = 193
        Me.check_controlno.Text = "Business Name"
        Me.check_controlno.UseVisualStyleBackColor = True
        '
        'check_lastaname
        '
        Me.check_lastaname.AutoSize = True
        Me.check_lastaname.Checked = True
        Me.check_lastaname.CheckState = System.Windows.Forms.CheckState.Checked
        Me.check_lastaname.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.check_lastaname.Location = New System.Drawing.Point(37, 32)
        Me.check_lastaname.Name = "check_lastaname"
        Me.check_lastaname.Size = New System.Drawing.Size(90, 19)
        Me.check_lastaname.TabIndex = 192
        Me.check_lastaname.Text = "Account No"
        Me.check_lastaname.UseVisualStyleBackColor = True
        '
        'txt_businessName
        '
        Me.txt_businessName.BackColor = System.Drawing.Color.AliceBlue
        Me.txt_businessName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_businessName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_businessName.Enabled = False
        Me.txt_businessName.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_businessName.Location = New System.Drawing.Point(149, 57)
        Me.txt_businessName.Name = "txt_businessName"
        Me.txt_businessName.Size = New System.Drawing.Size(184, 23)
        Me.txt_businessName.TabIndex = 191
        '
        'txt_accountno
        '
        Me.txt_accountno.BackColor = System.Drawing.Color.AliceBlue
        Me.txt_accountno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_accountno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_accountno.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_accountno.Location = New System.Drawing.Point(149, 28)
        Me.txt_accountno.Name = "txt_accountno"
        Me.txt_accountno.Size = New System.Drawing.Size(184, 23)
        Me.txt_accountno.TabIndex = 190
        '
        'BtnSearchRecord
        '
        Me.BtnSearchRecord.BackColor = System.Drawing.Color.FromArgb(CType(CType(6, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.BtnSearchRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSearchRecord.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSearchRecord.ForeColor = System.Drawing.Color.White
        Me.BtnSearchRecord.Location = New System.Drawing.Point(149, 95)
        Me.BtnSearchRecord.Name = "BtnSearchRecord"
        Me.BtnSearchRecord.Size = New System.Drawing.Size(184, 31)
        Me.BtnSearchRecord.TabIndex = 189
        Me.BtnSearchRecord.Text = "&Search"
        Me.BtnSearchRecord.UseVisualStyleBackColor = False
        '
        'SearchMayorsPermit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(370, 154)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.check_controlno)
        Me.Controls.Add(Me.check_lastaname)
        Me.Controls.Add(Me.txt_businessName)
        Me.Controls.Add(Me.txt_accountno)
        Me.Controls.Add(Me.BtnSearchRecord)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "SearchMayorsPermit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Search Mayors Permit"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents check_controlno As System.Windows.Forms.CheckBox
    Friend WithEvents check_lastaname As System.Windows.Forms.CheckBox
    Friend WithEvents txt_businessName As System.Windows.Forms.TextBox
    Friend WithEvents txt_accountno As System.Windows.Forms.TextBox
    Friend WithEvents BtnSearchRecord As System.Windows.Forms.Button
End Class
