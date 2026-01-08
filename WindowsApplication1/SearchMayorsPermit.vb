Imports System.Data.SqlClient
Public Class SearchMayorsPermit

    Private Sub SearchMayorsPermit_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BtnSearchRecord_Click(sender As Object, e As EventArgs) Handles BtnSearchRecord.Click
        Dim PendingMayorsPermit As PendingMayorsPermit = CType(Application.OpenForms("PendingMayorsPermit"), PendingMayorsPermit)
        Try
            PendingMayorsPermit.DataGrid.Rows.Clear()
            conn = "SELECT * " _
             & "FROM " _
             & "business_permit_status INNER JOIN business_record_hdr ON business_record_hdr.accountno =  business_permit_status.AccountNo " & _
            "where business_permit_status.AccountNo LIKE '%" & txt_accountno.Text & "' and business_record_hdr.b_name LIKE '%" & txt_businessName.Text & "' "

            Con = New SqlConnection(cs)
            Con.Open()
            cmd = New SqlCommand(conn, Con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Do While rdr.Read = True
                PendingMayorsPermit.DataGrid.Rows.Add(rdr("DatePending"), rdr("ApplicationID"), rdr("BusinessID"), rdr("AccountNo"), rdr("Status"), "VIEW", rdr("BusinessID"))

            Loop

            Con.Close()
            Dim aa As String
            aa = PendingMayorsPermit.DataGrid.RowCount
            If PendingMayorsPermit.DataGrid.RowCount = 0 Then
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
End Class