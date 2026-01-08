<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Print_mayorsbusinesspermit
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SampleMayorsPermit6 = New WindowsApplication1.SampleMayorsPermit()
        Me.SampleMayorsPermit5 = New WindowsApplication1.SampleMayorsPermit()
        Me.SampleMayorsPermit4 = New WindowsApplication1.SampleMayorsPermit()
        Me.SampleMayorsPermit3 = New WindowsApplication1.SampleMayorsPermit()
        Me.SampleMayorsPermit2 = New WindowsApplication1.SampleMayorsPermit()
        Me.SampleMayorsPermit1 = New WindowsApplication1.SampleMayorsPermit()
        Me.RptMayorsPermit1 = New WindowsApplication1.RptMayorsPermit()
        Me.RptMayorsPermit2 = New WindowsApplication1.RptMayorsPermit()
        Me.RptMayorsPermit3 = New WindowsApplication1.RptMayorsPermit()
        Me.RptMayorsPermit4 = New WindowsApplication1.RptMayorsPermit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 30)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(287, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "&SEND EMAIL NOW (FOR ONLINE APPLICANTS ONLY)"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(303, 30)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(99, 23)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "CLOSE"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(941, 531)
        Me.CrystalReportViewer1.TabIndex = 1
        Me.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'SampleMayorsPermit6
        '
        '
        'SampleMayorsPermit5
        '
        '
        'SampleMayorsPermit4
        '
        '
        'SampleMayorsPermit3
        '
        '
        'SampleMayorsPermit2
        '
        '
        'SampleMayorsPermit1
        '
        '
        'RptMayorsPermit1
        '
        '
        'RptMayorsPermit2
        '
        '
        'RptMayorsPermit3
        '
        '
        'RptMayorsPermit4
        '
        '
        'Print_mayorsbusinesspermit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(941, 531)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Print_mayorsbusinesspermit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Rpt_mayorsbusinesspermit"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents RptMayorsPermit1 As WindowsApplication1.RptMayorsPermit
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents SampleMayorsPermit1 As WindowsApplication1.SampleMayorsPermit
    Friend WithEvents RptMayorsPermit2 As WindowsApplication1.RptMayorsPermit
    Friend WithEvents SampleMayorsPermit2 As WindowsApplication1.SampleMayorsPermit
    Friend WithEvents SampleMayorsPermit3 As WindowsApplication1.SampleMayorsPermit
    Friend WithEvents SampleMayorsPermit4 As WindowsApplication1.SampleMayorsPermit
    Friend WithEvents RptMayorsPermit3 As WindowsApplication1.RptMayorsPermit
    Friend WithEvents SampleMayorsPermit5 As WindowsApplication1.SampleMayorsPermit
    Friend WithEvents RptMayorsPermit4 As WindowsApplication1.RptMayorsPermit
    Friend WithEvents SampleMayorsPermit6 As WindowsApplication1.SampleMayorsPermit
End Class
