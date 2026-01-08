<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SearchWalkIn_BrgyClearance
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
        Me.BtnSearchRecord = New System.Windows.Forms.Button()
        Me.TxtNumber = New System.Windows.Forms.TextBox()
        Me.TxtLetter = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'BtnSearchRecord
        '
        Me.BtnSearchRecord.BackColor = System.Drawing.Color.FromArgb(CType(CType(6, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.BtnSearchRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSearchRecord.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSearchRecord.ForeColor = System.Drawing.Color.White
        Me.BtnSearchRecord.Location = New System.Drawing.Point(187, 29)
        Me.BtnSearchRecord.Name = "BtnSearchRecord"
        Me.BtnSearchRecord.Size = New System.Drawing.Size(123, 31)
        Me.BtnSearchRecord.TabIndex = 159
        Me.BtnSearchRecord.Text = "&Search"
        Me.BtnSearchRecord.UseVisualStyleBackColor = False
        '
        'TxtNumber
        '
        Me.TxtNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNumber.Location = New System.Drawing.Point(63, 29)
        Me.TxtNumber.Name = "TxtNumber"
        Me.TxtNumber.Size = New System.Drawing.Size(118, 32)
        Me.TxtNumber.TabIndex = 158
        '
        'TxtLetter
        '
        Me.TxtLetter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtLetter.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLetter.Location = New System.Drawing.Point(22, 29)
        Me.TxtLetter.Name = "TxtLetter"
        Me.TxtLetter.Size = New System.Drawing.Size(35, 32)
        Me.TxtLetter.TabIndex = 157
        '
        'SearchWalkIn_BrgyClearance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(333, 91)
        Me.Controls.Add(Me.BtnSearchRecord)
        Me.Controls.Add(Me.TxtNumber)
        Me.Controls.Add(Me.TxtLetter)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "SearchWalkIn_BrgyClearance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Search Account No :"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnSearchRecord As System.Windows.Forms.Button
    Friend WithEvents TxtNumber As System.Windows.Forms.TextBox
    Friend WithEvents TxtLetter As System.Windows.Forms.TextBox
End Class
