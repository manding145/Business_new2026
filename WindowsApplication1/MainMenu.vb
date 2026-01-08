Imports Tulpep.NotificationWindow
Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Public Class MainMenu

    Private Sub BtnSearchRecord_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If FormStatus = False Then
            FormStatus = True
            SettingsMenuStrip1.Visible = False
            ReportMenuStrip.Visible = False
            Dim NewMDIChild As New PendingMayorsPermit()
            NewMDIChild.MdiParent = Me
            NewMDIChild.Show()
            'Panel3.Visible = False
        Else

            MsgBox("Please close your current form to continue.", vbOKOnly & vbExclamation, "BPLO Online")
        End If
    End Sub

    Private Sub MainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each ctl As Control In Me.Controls
            If TypeOf ctl Is MdiClient Then
                ctl.BackColor = Me.BackColor
            End If
        Next ctl
        lblfname.Text = lblfname1
        lbluserrole.Text = lbluserrole1






        Dim sql_update As String =
                "UPDATE bsd " & vbCrLf &
                "SET bsd.payment_status = 'E' " & vbCrLf &
                "FROM ONLINE.business_applicationstatus_dtl AS bsd " & vbCrLf &
                "INNER JOIN ONLINE.business_assessment_dtl AS bad " & vbCrLf &
                "  ON bad.ApplicationID = bsd.ApplicationID " & vbCrLf &
                "WHERE bad.payment_status = 'P' " & vbCrLf &
                "  AND CONVERT(date, bsd.Validity) < CONVERT(date, GETDATE());"

        Dim Con_ms As SqlConnection = Nothing
        Dim cmd_ms As SqlCommand = Nothing

        Try
            Con_ms = New SqlConnection(mcs)
            Con_ms.Open()

            cmd_ms = New SqlCommand(sql_update, Con_ms)
            Dim rowsAffected As Integer = cmd_ms.ExecuteNonQuery()
            ' (Optional) You can log rowsAffected if you want
        Catch ex As Exception
            ' handle/log error
        Finally
            If Con_ms IsNot Nothing Then Con_ms.Close()
        End Try





        Try
            conn_ms = "SELECT " _
            & " COUNT(applicationID) as no_pending " _
            & " FROM ONLINE.business_applicationstatus_dtl  where verify_status ='P' and IsReupload ='0' "

            Con_ms = New SqlConnection(mcs)
            Con_ms.Open()
            cmd_ms = New SqlCommand(conn_ms, Con_ms)
            rdr_ms = cmd_ms.ExecuteReader(CommandBehavior.CloseConnection)
            If rdr_ms.Read = True Then
                If rdr_ms("no_pending").ToString = "0" Then
                Else
                    Dim popup = New PopupNotifier
                    popup.TitleColor = Color.Blue
                    popup.TitleFont = New Font("Segoe UI", 14, FontStyle.Bold)
                    popup.TitleText = "Online Business Renewal"
                    popup.Image = My.Resources.blogo
                    popup.ContentFont = New Font("Segoe UI", 11, FontStyle.Bold)
                    popup.ContentText = "Hello " & lblfname.Text & "," & vbCrLf & "You have " & rdr_ms("no_pending") & " pending application!"
                    popup.Popup()
                End If
            Else
                'lbl_countpending.Text = "0"
            End If
            Con_ms.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Con_ms.Close()
        End Try




    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If FormStatus = False Then
            FormStatus = True
            SettingsMenuStrip1.Visible = False
            ReportMenuStrip.Visible = False
            Dim NewMDIChild As New BPLO()
            NewMDIChild.MdiParent = Me
            NewMDIChild.Show()
            'Panel3.Visible = False
        Else

            MsgBox("Please close your current form to continue.", vbOKOnly & vbExclamation, "BPLO Online")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Appointment.ShowDialog()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        FormStatus = False
        Me.Close()
        LogIn.Show()
    End Sub

    Private Sub RecordsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecordsToolStripMenuItem.Click

    End Sub

    Private Sub msBusinessRecord_Click(sender As Object, e As EventArgs) Handles msBusinessRecord.Click

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        If FormStatus = False Then
            FormStatus = True
            SettingsMenuStrip1.Visible = False
            ReportMenuStrip.Visible = True
            'Panel3.Visible = False
        Else

            MsgBox("Please close your current form to continue.", vbOKOnly & vbExclamation, "BPLO Online")
        End If

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Try
            conn_ms = "SELECT " _
            & " COUNT(applicationID) as no_pending " _
            & " FROM ONLINE.business_applicationstatus_dtl  where verify_status ='P' and IsReupload ='0' "

            Con_ms = New SqlConnection(mcs)
            Con_ms.Open()
            cmd_ms = New SqlCommand(conn_ms, Con_ms)
            rdr_ms = cmd_ms.ExecuteReader(CommandBehavior.CloseConnection)
            If rdr_ms.Read = True Then
                If rdr_ms("no_pending").ToString = "0" Then
                Else

                    Dim popup = New PopupNotifier
                    popup.TitleColor = Color.Blue
                    popup.TitleFont = New Font("Segoe UI", 14, FontStyle.Bold)
                    popup.TitleText = "Online Business Renewal"
                    popup.Image = My.Resources.blogo
                    popup.ContentFont = New Font("Segoe UI", 11, FontStyle.Bold)
                    popup.ContentText = "Hello " & lblfname.Text & "," & vbCrLf & "You have " & rdr_ms("no_pending") & " pending application!"
                    popup.Popup()
                End If
            Else
                'lbl_countpending.Text = "0"
            End If
            Con_ms.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Con_ms.Close()
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ReportMenuStrip.Visible = False
        SettingsMenuStrip1.Visible = True
    End Sub

    Private Sub NotificationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NotificationToolStripMenuItem.Click
        FrmNotificationControl.ShowDialog()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        'Payment.ShowDialog()


        If FormStatus = False Then
            FormStatus = True
            SettingsMenuStrip1.Visible = False
            ReportMenuStrip.Visible = False
            Dim NewMDIChild As New PaymentDashboard()
            NewMDIChild.MdiParent = Me
            NewMDIChild.Show()
            'Panel3.Visible = False
        Else

            MsgBox("Please close your current form to continue.", vbOKOnly & vbExclamation, "BPLO Online")
        End If



    End Sub

    Private Sub B2NoOfAssessedPaidBusinessesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles B2NoOfAssessedPaidBusinessesToolStripMenuItem.Click
        b2report.ShowDialog()
    End Sub
End Class