<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UploadPermit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UploadPermit))
        Me.AxAcroPDF3 = New AxAcroPDFLib.AxAcroPDF()
        Me.AxAcroPDF2 = New AxAcroPDFLib.AxAcroPDF()
        Me.TxtApplicationNo = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.SaveNow = New System.Windows.Forms.Button()
        Me.TxtAmountPaid = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtBusinessName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.AxAcroPDF1 = New AxAcroPDFLib.AxAcroPDF()
        Me.UploadScannedReceipt = New System.Windows.Forms.Button()
        Me.TxtAccountNo = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.file1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.referencono = New System.Windows.Forms.TextBox()
        Me.BtnSearchRecord = New System.Windows.Forms.Button()
        Me.useraccountid = New System.Windows.Forms.TextBox()
        CType(Me.AxAcroPDF3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxAcroPDF2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxAcroPDF1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'AxAcroPDF3
        '
        Me.AxAcroPDF3.Enabled = True
        Me.AxAcroPDF3.Location = New System.Drawing.Point(1027, 212)
        Me.AxAcroPDF3.Name = "AxAcroPDF3"
        Me.AxAcroPDF3.OcxState = CType(resources.GetObject("AxAcroPDF3.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxAcroPDF3.Size = New System.Drawing.Size(192, 192)
        Me.AxAcroPDF3.TabIndex = 174
        Me.AxAcroPDF3.Visible = False
        '
        'AxAcroPDF2
        '
        Me.AxAcroPDF2.Enabled = True
        Me.AxAcroPDF2.Location = New System.Drawing.Point(891, 14)
        Me.AxAcroPDF2.Name = "AxAcroPDF2"
        Me.AxAcroPDF2.OcxState = CType(resources.GetObject("AxAcroPDF2.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxAcroPDF2.Size = New System.Drawing.Size(192, 192)
        Me.AxAcroPDF2.TabIndex = 173
        Me.AxAcroPDF2.Visible = False
        '
        'TxtApplicationNo
        '
        Me.TxtApplicationNo.BackColor = System.Drawing.Color.AliceBlue
        Me.TxtApplicationNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtApplicationNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtApplicationNo.Enabled = False
        Me.TxtApplicationNo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtApplicationNo.Location = New System.Drawing.Point(16, 32)
        Me.TxtApplicationNo.Multiline = True
        Me.TxtApplicationNo.Name = "TxtApplicationNo"
        Me.TxtApplicationNo.ReadOnly = True
        Me.TxtApplicationNo.Size = New System.Drawing.Size(242, 26)
        Me.TxtApplicationNo.TabIndex = 175
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(15, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(76, 13)
        Me.Label9.TabIndex = 174
        Me.Label9.Text = "Application No"
        '
        'SaveNow
        '
        Me.SaveNow.BackColor = System.Drawing.Color.FromArgb(CType(CType(6, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.SaveNow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SaveNow.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SaveNow.ForeColor = System.Drawing.Color.White
        Me.SaveNow.Location = New System.Drawing.Point(15, 186)
        Me.SaveNow.Name = "SaveNow"
        Me.SaveNow.Size = New System.Drawing.Size(194, 31)
        Me.SaveNow.TabIndex = 172
        Me.SaveNow.Text = "&Upload Permit Now"
        Me.SaveNow.UseVisualStyleBackColor = False
        '
        'TxtAmountPaid
        '
        Me.TxtAmountPaid.BackColor = System.Drawing.Color.AliceBlue
        Me.TxtAmountPaid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtAmountPaid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtAmountPaid.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAmountPaid.Location = New System.Drawing.Point(159, 553)
        Me.TxtAmountPaid.Multiline = True
        Me.TxtAmountPaid.Name = "TxtAmountPaid"
        Me.TxtAmountPaid.Size = New System.Drawing.Size(242, 26)
        Me.TxtAmountPaid.TabIndex = 166
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(137, 582)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 13)
        Me.Label5.TabIndex = 165
        Me.Label5.Text = "Amount Paid"
        '
        'TxtBusinessName
        '
        Me.TxtBusinessName.BackColor = System.Drawing.Color.AliceBlue
        Me.TxtBusinessName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtBusinessName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtBusinessName.Enabled = False
        Me.TxtBusinessName.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBusinessName.Location = New System.Drawing.Point(17, 85)
        Me.TxtBusinessName.Multiline = True
        Me.TxtBusinessName.Name = "TxtBusinessName"
        Me.TxtBusinessName.ReadOnly = True
        Me.TxtBusinessName.Size = New System.Drawing.Size(493, 26)
        Me.TxtBusinessName.TabIndex = 162
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 13)
        Me.Label3.TabIndex = 161
        Me.Label3.Text = "Business Name:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(265, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 159
        Me.Label2.Text = "Account No."
        '
        'AxAcroPDF1
        '
        Me.AxAcroPDF1.Enabled = True
        Me.AxAcroPDF1.Location = New System.Drawing.Point(1123, 11)
        Me.AxAcroPDF1.Name = "AxAcroPDF1"
        Me.AxAcroPDF1.OcxState = CType(resources.GetObject("AxAcroPDF1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxAcroPDF1.Size = New System.Drawing.Size(192, 192)
        Me.AxAcroPDF1.TabIndex = 178
        Me.AxAcroPDF1.Visible = False
        '
        'UploadScannedReceipt
        '
        Me.UploadScannedReceipt.BackColor = System.Drawing.Color.FromArgb(CType(CType(6, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.UploadScannedReceipt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.UploadScannedReceipt.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UploadScannedReceipt.ForeColor = System.Drawing.Color.White
        Me.UploadScannedReceipt.Location = New System.Drawing.Point(605, 8)
        Me.UploadScannedReceipt.Name = "UploadScannedReceipt"
        Me.UploadScannedReceipt.Size = New System.Drawing.Size(184, 31)
        Me.UploadScannedReceipt.TabIndex = 177
        Me.UploadScannedReceipt.Text = "&Upload Scanned Receipt"
        Me.UploadScannedReceipt.UseVisualStyleBackColor = False
        Me.UploadScannedReceipt.Visible = False
        '
        'TxtAccountNo
        '
        Me.TxtAccountNo.BackColor = System.Drawing.Color.AliceBlue
        Me.TxtAccountNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtAccountNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtAccountNo.Enabled = False
        Me.TxtAccountNo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAccountNo.Location = New System.Drawing.Point(268, 31)
        Me.TxtAccountNo.Multiline = True
        Me.TxtAccountNo.Name = "TxtAccountNo"
        Me.TxtAccountNo.ReadOnly = True
        Me.TxtAccountNo.Size = New System.Drawing.Size(242, 26)
        Me.TxtAccountNo.TabIndex = 160
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.AxAcroPDF3)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.AxAcroPDF2)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.file1)
        Me.Panel1.Controls.Add(Me.TxtApplicationNo)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.SaveNow)
        Me.Panel1.Controls.Add(Me.TxtAmountPaid)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.TxtBusinessName)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.TxtAccountNo)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(12, 91)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(524, 235)
        Me.Panel1.TabIndex = 176
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(431, 151)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(79, 26)
        Me.Button1.TabIndex = 182
        Me.Button1.Text = "Upload"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(15, 135)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(148, 13)
        Me.Label8.TabIndex = 176
        Me.Label8.Text = "Business Tax Assessment File"
        '
        'file1
        '
        Me.file1.BackColor = System.Drawing.Color.AliceBlue
        Me.file1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.file1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.file1.Enabled = False
        Me.file1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.file1.Location = New System.Drawing.Point(16, 151)
        Me.file1.Multiline = True
        Me.file1.Name = "file1"
        Me.file1.Size = New System.Drawing.Size(424, 26)
        Me.file1.TabIndex = 177
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 13)
        Me.Label1.TabIndex = 175
        Me.Label1.Text = "Reference No."
        '
        'referencono
        '
        Me.referencono.BackColor = System.Drawing.Color.AliceBlue
        Me.referencono.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.referencono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.referencono.Enabled = False
        Me.referencono.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.referencono.Location = New System.Drawing.Point(12, 45)
        Me.referencono.Multiline = True
        Me.referencono.Name = "referencono"
        Me.referencono.ReadOnly = True
        Me.referencono.Size = New System.Drawing.Size(511, 31)
        Me.referencono.TabIndex = 174
        '
        'BtnSearchRecord
        '
        Me.BtnSearchRecord.BackColor = System.Drawing.Color.FromArgb(CType(CType(6, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.BtnSearchRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSearchRecord.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSearchRecord.ForeColor = System.Drawing.Color.White
        Me.BtnSearchRecord.Location = New System.Drawing.Point(605, 45)
        Me.BtnSearchRecord.Name = "BtnSearchRecord"
        Me.BtnSearchRecord.Size = New System.Drawing.Size(184, 31)
        Me.BtnSearchRecord.TabIndex = 173
        Me.BtnSearchRecord.Text = "&Search Record"
        Me.BtnSearchRecord.UseVisualStyleBackColor = False
        Me.BtnSearchRecord.Visible = False
        '
        'useraccountid
        '
        Me.useraccountid.BackColor = System.Drawing.Color.AliceBlue
        Me.useraccountid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.useraccountid.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.useraccountid.Location = New System.Drawing.Point(176, 169)
        Me.useraccountid.Name = "useraccountid"
        Me.useraccountid.Size = New System.Drawing.Size(197, 22)
        Me.useraccountid.TabIndex = 188
        Me.useraccountid.Visible = False
        '
        'UploadPermit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(548, 360)
        Me.Controls.Add(Me.useraccountid)
        Me.Controls.Add(Me.AxAcroPDF1)
        Me.Controls.Add(Me.UploadScannedReceipt)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.referencono)
        Me.Controls.Add(Me.BtnSearchRecord)
        Me.Name = "UploadPermit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "UploadPermit"
        CType(Me.AxAcroPDF3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxAcroPDF2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxAcroPDF1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents AxAcroPDF3 As AxAcroPDFLib.AxAcroPDF
    Friend WithEvents AxAcroPDF2 As AxAcroPDFLib.AxAcroPDF
    Public WithEvents TxtApplicationNo As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Public WithEvents SaveNow As System.Windows.Forms.Button
    Public WithEvents TxtAmountPaid As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents TxtBusinessName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents AxAcroPDF1 As AxAcroPDFLib.AxAcroPDF
    Friend WithEvents UploadScannedReceipt As System.Windows.Forms.Button
    Public WithEvents TxtAccountNo As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Public WithEvents file1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents referencono As System.Windows.Forms.TextBox
    Friend WithEvents BtnSearchRecord As System.Windows.Forms.Button
    Friend WithEvents useraccountid As System.Windows.Forms.TextBox
End Class
