<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Payment
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Payment))
        Me.BtnSearchRecord = New System.Windows.Forms.Button()
        Me.referencono = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.useraccountid = New System.Windows.Forms.TextBox()
        Me.AxAcroPDF3 = New AxAcroPDFLib.AxAcroPDF()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.fire_file = New System.Windows.Forms.TextBox()
        Me.assessment_file = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ctc_file = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.totalpaid = New System.Windows.Forms.TextBox()
        Me.AxAcroPDF2 = New AxAcroPDFLib.AxAcroPDF()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ctc_fire = New System.Windows.Forms.TextBox()
        Me.tax_amount = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ctc_amount = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TotalAssessmentAmount = New System.Windows.Forms.TextBox()
        Me.TxtApplicationNo = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.SaveNow = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dt_datepaid = New System.Windows.Forms.DateTimePicker()
        Me.TxtTransaction = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtAmountPaid = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtBusinessName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtAccountNo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.UploadScannedReceipt = New System.Windows.Forms.Button()
        Me.AxAcroPDF1 = New AxAcroPDFLib.AxAcroPDF()
        Me.Panel1.SuspendLayout()
        CType(Me.AxAcroPDF3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.AxAcroPDF2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.AxAcroPDF1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnSearchRecord
        '
        Me.BtnSearchRecord.BackColor = System.Drawing.Color.FromArgb(CType(CType(6, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.BtnSearchRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSearchRecord.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSearchRecord.ForeColor = System.Drawing.Color.White
        Me.BtnSearchRecord.Location = New System.Drawing.Point(615, 37)
        Me.BtnSearchRecord.Name = "BtnSearchRecord"
        Me.BtnSearchRecord.Size = New System.Drawing.Size(184, 31)
        Me.BtnSearchRecord.TabIndex = 156
        Me.BtnSearchRecord.Text = "&Search Record"
        Me.BtnSearchRecord.UseVisualStyleBackColor = False
        Me.BtnSearchRecord.Visible = False
        '
        'referencono
        '
        Me.referencono.BackColor = System.Drawing.Color.AliceBlue
        Me.referencono.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.referencono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.referencono.Enabled = False
        Me.referencono.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.referencono.Location = New System.Drawing.Point(22, 37)
        Me.referencono.Multiline = True
        Me.referencono.Name = "referencono"
        Me.referencono.ReadOnly = True
        Me.referencono.Size = New System.Drawing.Size(511, 31)
        Me.referencono.TabIndex = 157
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(22, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 13)
        Me.Label1.TabIndex = 158
        Me.Label1.Text = "Reference No."
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.useraccountid)
        Me.Panel1.Controls.Add(Me.AxAcroPDF3)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.AxAcroPDF2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.TxtApplicationNo)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.SaveNow)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.dt_datepaid)
        Me.Panel1.Controls.Add(Me.TxtTransaction)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.TxtAmountPaid)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.TxtBusinessName)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.TxtAccountNo)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(22, 83)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1084, 430)
        Me.Panel1.TabIndex = 159
        '
        'useraccountid
        '
        Me.useraccountid.BackColor = System.Drawing.Color.AliceBlue
        Me.useraccountid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.useraccountid.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.useraccountid.Location = New System.Drawing.Point(617, 18)
        Me.useraccountid.Name = "useraccountid"
        Me.useraccountid.Size = New System.Drawing.Size(197, 22)
        Me.useraccountid.TabIndex = 187
        Me.useraccountid.Visible = False
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
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button3)
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.fire_file)
        Me.GroupBox2.Controls.Add(Me.assessment_file)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.ctc_file)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.totalpaid)
        Me.GroupBox2.Location = New System.Drawing.Point(291, 117)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(523, 287)
        Me.GroupBox2.TabIndex = 183
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Payment Details"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(413, 171)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(57, 26)
        Me.Button3.TabIndex = 184
        Me.Button3.Text = "Upload"
        Me.Button3.UseVisualStyleBackColor = True
        Me.Button3.Visible = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(413, 117)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(57, 26)
        Me.Button2.TabIndex = 183
        Me.Button2.Text = "Upload"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(413, 59)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(57, 26)
        Me.Button1.TabIndex = 182
        Me.Button1.Text = "Upload"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 43)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(148, 13)
        Me.Label8.TabIndex = 176
        Me.Label8.Text = "Business Tax Assessment File"
        '
        'fire_file
        '
        Me.fire_file.BackColor = System.Drawing.Color.AliceBlue
        Me.fire_file.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.fire_file.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.fire_file.Enabled = False
        Me.fire_file.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fire_file.Location = New System.Drawing.Point(10, 171)
        Me.fire_file.Multiline = True
        Me.fire_file.Name = "fire_file"
        Me.fire_file.Size = New System.Drawing.Size(409, 26)
        Me.fire_file.TabIndex = 181
        Me.fire_file.Visible = False
        '
        'assessment_file
        '
        Me.assessment_file.BackColor = System.Drawing.Color.AliceBlue
        Me.assessment_file.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.assessment_file.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.assessment_file.Enabled = False
        Me.assessment_file.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.assessment_file.Location = New System.Drawing.Point(9, 59)
        Me.assessment_file.Multiline = True
        Me.assessment_file.Name = "assessment_file"
        Me.assessment_file.Size = New System.Drawing.Size(410, 26)
        Me.assessment_file.TabIndex = 177
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(7, 155)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(53, 13)
        Me.Label13.TabIndex = 180
        Me.Label13.Text = "Fire Local"
        Me.Label13.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(7, 101)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(67, 13)
        Me.Label14.TabIndex = 178
        Me.Label14.Text = "CTC Amount"
        '
        'ctc_file
        '
        Me.ctc_file.BackColor = System.Drawing.Color.AliceBlue
        Me.ctc_file.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ctc_file.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ctc_file.Enabled = False
        Me.ctc_file.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ctc_file.Location = New System.Drawing.Point(10, 117)
        Me.ctc_file.Multiline = True
        Me.ctc_file.Name = "ctc_file"
        Me.ctc_file.Size = New System.Drawing.Size(409, 26)
        Me.ctc_file.TabIndex = 179
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(7, 215)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(142, 13)
        Me.Label15.TabIndex = 163
        Me.Label15.Text = "Total Assessment Amount"
        '
        'totalpaid
        '
        Me.totalpaid.BackColor = System.Drawing.Color.AliceBlue
        Me.totalpaid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.totalpaid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.totalpaid.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.totalpaid.Location = New System.Drawing.Point(10, 231)
        Me.totalpaid.Multiline = True
        Me.totalpaid.Name = "totalpaid"
        Me.totalpaid.Size = New System.Drawing.Size(235, 26)
        Me.totalpaid.TabIndex = 164
        Me.totalpaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'AxAcroPDF2
        '
        Me.AxAcroPDF2.Enabled = True
        Me.AxAcroPDF2.Location = New System.Drawing.Point(1027, 39)
        Me.AxAcroPDF2.Name = "AxAcroPDF2"
        Me.AxAcroPDF2.OcxState = CType(resources.GetObject("AxAcroPDF2.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxAcroPDF2.Size = New System.Drawing.Size(192, 192)
        Me.AxAcroPDF2.TabIndex = 173
        Me.AxAcroPDF2.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.ctc_fire)
        Me.GroupBox1.Controls.Add(Me.tax_amount)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.ctc_amount)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TotalAssessmentAmount)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 117)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(259, 287)
        Me.GroupBox1.TabIndex = 182
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Assessment Details"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 43)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(168, 13)
        Me.Label10.TabIndex = 176
        Me.Label10.Text = "Business Tax Assessment Amount"
        '
        'ctc_fire
        '
        Me.ctc_fire.BackColor = System.Drawing.Color.AliceBlue
        Me.ctc_fire.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ctc_fire.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ctc_fire.Enabled = False
        Me.ctc_fire.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ctc_fire.Location = New System.Drawing.Point(10, 171)
        Me.ctc_fire.Multiline = True
        Me.ctc_fire.Name = "ctc_fire"
        Me.ctc_fire.ReadOnly = True
        Me.ctc_fire.Size = New System.Drawing.Size(242, 26)
        Me.ctc_fire.TabIndex = 181
        Me.ctc_fire.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ctc_fire.Visible = False
        '
        'tax_amount
        '
        Me.tax_amount.BackColor = System.Drawing.Color.AliceBlue
        Me.tax_amount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tax_amount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tax_amount.Enabled = False
        Me.tax_amount.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tax_amount.Location = New System.Drawing.Point(9, 59)
        Me.tax_amount.Multiline = True
        Me.tax_amount.Name = "tax_amount"
        Me.tax_amount.ReadOnly = True
        Me.tax_amount.Size = New System.Drawing.Size(242, 26)
        Me.tax_amount.TabIndex = 177
        Me.tax_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(7, 155)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(53, 13)
        Me.Label12.TabIndex = 180
        Me.Label12.Text = "Fire Local"
        Me.Label12.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(7, 101)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(67, 13)
        Me.Label11.TabIndex = 178
        Me.Label11.Text = "CTC Amount"
        '
        'ctc_amount
        '
        Me.ctc_amount.BackColor = System.Drawing.Color.AliceBlue
        Me.ctc_amount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ctc_amount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ctc_amount.Enabled = False
        Me.ctc_amount.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ctc_amount.Location = New System.Drawing.Point(10, 117)
        Me.ctc_amount.Multiline = True
        Me.ctc_amount.Name = "ctc_amount"
        Me.ctc_amount.ReadOnly = True
        Me.ctc_amount.Size = New System.Drawing.Size(242, 26)
        Me.ctc_amount.TabIndex = 179
        Me.ctc_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(7, 215)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(142, 13)
        Me.Label4.TabIndex = 163
        Me.Label4.Text = "Total Assessment Amount"
        '
        'TotalAssessmentAmount
        '
        Me.TotalAssessmentAmount.BackColor = System.Drawing.Color.AliceBlue
        Me.TotalAssessmentAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TotalAssessmentAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TotalAssessmentAmount.Enabled = False
        Me.TotalAssessmentAmount.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalAssessmentAmount.Location = New System.Drawing.Point(10, 231)
        Me.TotalAssessmentAmount.Multiline = True
        Me.TotalAssessmentAmount.Name = "TotalAssessmentAmount"
        Me.TotalAssessmentAmount.ReadOnly = True
        Me.TotalAssessmentAmount.Size = New System.Drawing.Size(242, 26)
        Me.TotalAssessmentAmount.TabIndex = 164
        Me.TotalAssessmentAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.SaveNow.Location = New System.Drawing.Point(862, 346)
        Me.SaveNow.Name = "SaveNow"
        Me.SaveNow.Size = New System.Drawing.Size(194, 31)
        Me.SaveNow.TabIndex = 172
        Me.SaveNow.Text = "&Record Payment Now"
        Me.SaveNow.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(859, 292)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 13)
        Me.Label7.TabIndex = 170
        Me.Label7.Text = "TransactionNo"
        '
        'dt_datepaid
        '
        Me.dt_datepaid.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt_datepaid.Location = New System.Drawing.Point(862, 247)
        Me.dt_datepaid.Name = "dt_datepaid"
        Me.dt_datepaid.Size = New System.Drawing.Size(194, 20)
        Me.dt_datepaid.TabIndex = 169
        '
        'TxtTransaction
        '
        Me.TxtTransaction.BackColor = System.Drawing.Color.AliceBlue
        Me.TxtTransaction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTransaction.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtTransaction.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTransaction.Location = New System.Drawing.Point(862, 308)
        Me.TxtTransaction.Multiline = True
        Me.TxtTransaction.Name = "TxtTransaction"
        Me.TxtTransaction.Size = New System.Drawing.Size(194, 26)
        Me.TxtTransaction.TabIndex = 168
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(859, 218)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 13)
        Me.Label6.TabIndex = 167
        Me.Label6.Text = "Date Paid"
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(265, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 159
        Me.Label2.Text = "Account No."
        '
        'UploadScannedReceipt
        '
        Me.UploadScannedReceipt.BackColor = System.Drawing.Color.FromArgb(CType(CType(6, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.UploadScannedReceipt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.UploadScannedReceipt.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UploadScannedReceipt.ForeColor = System.Drawing.Color.White
        Me.UploadScannedReceipt.Location = New System.Drawing.Point(615, 0)
        Me.UploadScannedReceipt.Name = "UploadScannedReceipt"
        Me.UploadScannedReceipt.Size = New System.Drawing.Size(184, 31)
        Me.UploadScannedReceipt.TabIndex = 171
        Me.UploadScannedReceipt.Text = "&Upload Scanned Receipt"
        Me.UploadScannedReceipt.UseVisualStyleBackColor = False
        Me.UploadScannedReceipt.Visible = False
        '
        'AxAcroPDF1
        '
        Me.AxAcroPDF1.Enabled = True
        Me.AxAcroPDF1.Location = New System.Drawing.Point(1133, 3)
        Me.AxAcroPDF1.Name = "AxAcroPDF1"
        Me.AxAcroPDF1.OcxState = CType(resources.GetObject("AxAcroPDF1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxAcroPDF1.Size = New System.Drawing.Size(192, 192)
        Me.AxAcroPDF1.TabIndex = 172
        Me.AxAcroPDF1.Visible = False
        '
        'Payment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1113, 520)
        Me.Controls.Add(Me.AxAcroPDF1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.referencono)
        Me.Controls.Add(Me.BtnSearchRecord)
        Me.Controls.Add(Me.UploadScannedReceipt)
        Me.Name = "Payment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Record Online Payment"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.AxAcroPDF3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.AxAcroPDF2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.AxAcroPDF1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnSearchRecord As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents UploadScannedReceipt As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Public WithEvents referencono As System.Windows.Forms.TextBox
    Public WithEvents dt_datepaid As System.Windows.Forms.DateTimePicker
    Public WithEvents TxtTransaction As System.Windows.Forms.TextBox
    Public WithEvents TxtAmountPaid As System.Windows.Forms.TextBox
    Public WithEvents TotalAssessmentAmount As System.Windows.Forms.TextBox
    Public WithEvents TxtBusinessName As System.Windows.Forms.TextBox
    Public WithEvents TxtAccountNo As System.Windows.Forms.TextBox
    Public WithEvents TxtApplicationNo As System.Windows.Forms.TextBox
    Public WithEvents ctc_amount As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Public WithEvents tax_amount As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Public WithEvents ctc_fire As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Public WithEvents fire_file As System.Windows.Forms.TextBox
    Public WithEvents assessment_file As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Public WithEvents ctc_file As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Public WithEvents totalpaid As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents AxAcroPDF1 As AxAcroPDFLib.AxAcroPDF
    Friend WithEvents AxAcroPDF2 As AxAcroPDFLib.AxAcroPDF
    Friend WithEvents AxAcroPDF3 As AxAcroPDFLib.AxAcroPDF
    Public WithEvents SaveNow As System.Windows.Forms.Button
    Friend WithEvents useraccountid As System.Windows.Forms.TextBox
End Class
