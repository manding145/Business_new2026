Imports System.Data.SqlClient
Public Class SearchApplicationRecord

    Private Sub BtnSearchRecord_Click(sender As Object, e As EventArgs) Handles BtnSearchRecord.Click
        Dim BPLO As BPLO = CType(Application.OpenForms("BPLO"), BPLO)
        Try
            BPLO.DataGrid.Rows.Clear()
            conn = "SELECT * " _
             & "FROM " _
             & "business_application_tbl INNER JOIN business_record_hdr ON business_record_hdr.recordID =  business_application_tbl.recordID INNER JOIN business_applicationstatus_dtl ON business_application_tbl.applicationID = business_applicationstatus_dtl.applicationID " & _
            "where business_application_tbl.accountno LIKE '%" & txt_accountno.Text & "' and business_record_hdr.b_name LIKE '%" & txt_businessName.Text & "' ORDER BY application_date, application_time ASC "

            Con = New SqlConnection(cs)
            Con.Open()
            cmd = New SqlCommand(conn, Con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Do While rdr.Read = True
                BPLO.DataGrid.Rows.Add(rdr("ApplicationID"), rdr("RecordID"), rdr("application_date"), rdr("application_time"), rdr("accountno"), rdr("b_name"), rdr("verify_status"), "VIEW")


            Loop

            Con.Close()
            Dim aa As String
            aa = BPLO.DataGrid.RowCount
            If BPLO.DataGrid.RowCount = 0 Then
                MsgBox("No Record Found!", vbOKOnly & vbCritical, "Tacloban Health Office Management System")
                Me.Close()
            Else
                MsgBox(aa + " Record Found!", vbOKOnly & vbInformation, "Tacloban Health Office Management System")

                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txt_seachfirstname_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub check_lastaname_CheckedChanged(sender As Object, e As EventArgs) Handles check_lastaname.CheckedChanged

    End Sub

    Private Sub check_controlno_CheckedChanged(sender As Object, e As EventArgs) Handles check_controlno.CheckedChanged
        If check_controlno.Checked = False Then
            txt_businessName.Enabled = False
            txt_businessName.Text = ""
        Else
            txt_businessName.Enabled = True
            txt_businessName.Text = ""
        End If
    End Sub

    Private Sub txt_accountno_TextChanged(sender As Object, e As EventArgs) Handles txt_accountno.TextChanged

    End Sub
End Class