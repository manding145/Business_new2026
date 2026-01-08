Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Public Class BPLOApplicationRecord

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Me.Close()
        FormStatus = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click


        Con_ms = New SqlConnection(mcs)
        Con_ms.Open()
        conn_ms = "UPDATE ONLINE.business_application_tbl set process_status = '0' " _
            & "WHERE applicationID='" & applicationID_search & "'"
        cmd_ms = New SqlCommand(conn_ms, Con_ms)
        cmd_ms.ExecuteNonQuery()
        Con_ms.Close()
        Me.Close()
        FormStatus = False

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click



        Con_ms = New SqlConnection(mcs)
        Con_ms.Open()
        conn_ms = "UPDATE ONLINE.business_application_tbl set process_status = '0' " _
            & "WHERE applicationID='" & applicationID_search & "'"
        cmd_ms = New SqlCommand(conn_ms, Con_ms)
        cmd_ms.ExecuteNonQuery()
        Con_ms.Close()
        Me.Close()
        FormStatus = False


    End Sub

    Private Sub btnDeny_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BtnPrintHealthCard_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BtnAddNewRecord_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Grid_attachments_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid_attachments.CellContentClick
        Dim link_string As String
        link_string = link_prefix & folder_directory & Grid_attachments.Item(0, Grid_attachments.CurrentRow.Index).Value
        Dim extension = System.IO.Path.GetExtension(link_string)

        If (extension = ".pdf") Then
            ViewAttachments_webcontrol.Text = Grid_attachments.Item(1, Grid_attachments.CurrentRow.Index).Value + " Attachments of " + txt_accountno.Text
            ViewAttachments_webcontrol.AxAcroPDF1.src = link_string
            ViewAttachments_webcontrol.ShowDialog()
        Else
            ViewAttachmentsPictureBox.Text = Grid_attachments.Item(1, Grid_attachments.CurrentRow.Index).Value + " Attachments of " + txt_accountno.Text
            ViewAttachmentsPictureBox.PictureBox1.Image = Image.FromFile(link_string)
            ViewAttachmentsPictureBox.ShowDialog()

            ' MsgBox("Invalid Attachment, please contact your system administrator", vbOKOnly & vbInformation, "BPLO")
        End If


        'If e.ColumnIndex = 2 Then

        '    If Grid_attachments.Item(1, Grid_attachments.CurrentRow.Index).Value = "Unified Form" Then
        '        Dim link_string As String
        '        link_string = link_prefix & folder_directory & Grid_attachments.Item(0, Grid_attachments.CurrentRow.Index).Value
        '        'ViewAttachments_webcontrol.WebKitBrowser1.Navigate("www.google.com")
        '        ViewAttachments_webcontrol.AxAcroPDF1.src = link_string
        '        ViewAttachments_webcontrol.ShowDialog()



        '    Else
        '        Dim link_string As String
        '        link_string = link_prefix & folder_directory & Grid_attachments.Item(0, Grid_attachments.CurrentRow.Index).Value
        '        ViewAttachmentsPictureBox.PictureBox1.Image = Image.FromFile(link_string)
        '        'ViewAttachmentsPictureBox.Text = "Deworming Result Attachment of " + TxtFirstName.Text + "  " + TxtMiddleName.Text + " " + TxtLastName.Text
        '        ViewAttachmentsPictureBox.ShowDialog()

        '    End If


        'End If
    End Sub

    Private Sub BtnAddNewRecord_Click_1(sender As Object, e As EventArgs) Handles BtnAddNewRecord.Click
        'insert data to applicationstat table

        Dim BPLOApplicationRecord As BPLOApplicationRecord = CType(Application.OpenForms("BPLOApplicationRecord"), BPLOApplicationRecord)
        Dim mytimestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

        Con_ms = New SqlConnection(mcs)
        Con_ms.Open()
        conn_ms = "UPDATE ONLINE.business_applicationstatus_dtl set  verify_remarks='" & TxtRemarks.Text & "' , verify_status = 'V', admin_status = 'P', verified_timedt = '" & mytimestamp & "', user_verified ='" & userid & "', IsReupload = '0' WHERE applicationID='" & BPLOApplicationRecord.txt_applicationno.Text & "'"
        Try

            cmd_ms = New SqlCommand(conn_ms, Con_ms)
            cmd_ms.ExecuteNonQuery()
            Con_ms.Close()

            MsgBox("Business application successfully verified", vbOKOnly & vbInformation, "BPLO")

            Con_ms1 = New SqlConnection(mcs)
            Con_ms1.Open()
            conn_ms1 = "UPDATE ONLINE.business_application_tbl set accountno ='" & txt_accountno.Text & "', process_status = '0' " _
                & "WHERE applicationID='" & applicationID_search & "'"
            cmd_ms1 = New SqlCommand(conn_ms1, Con_ms1)
            cmd_ms1.ExecuteNonQuery()
            Con_ms1.Close()


            FormStatus = False


            Me.Close()




        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Con_ms.Close()
        End Try

    End Sub

    Private Sub btnDeny_Click_1(sender As Object, e As EventArgs) Handles btnDeny.Click
        Deny.Show()
    End Sub

    Private Sub panel_track_verification_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub BPLOApplicationRecord_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub

    Private Sub txt_asses_date_Click(sender As Object, e As EventArgs) Handles txt_asses_date.Click

    End Sub

    Private Sub lblPotential_Click(sender As Object, e As EventArgs) Handles lblPotential.Click

    End Sub
End Class