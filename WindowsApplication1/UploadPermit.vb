Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports System.IO

Public Class UploadPermit

    Private Sub SaveNow_Click(sender As Object, e As EventArgs) Handles SaveNow.Click

        If file1.Text = "" Then

            MsgBox("Upload Permit")
            Exit Sub
        End If


        Try

            ' Raw path from Acrobat ActiveX
            Dim rawPath As String = AxAcroPDF1.src

            Dim sourcePath As String = rawPath.Replace("file://", "").Trim()



            sourcePath = sourcePath.Replace("/", "\")



            Dim folderPath As String = "\\10.0.27.194\FileAttachment\BUSINESS_APPLICATION\" + referencono.Text + "\"

            Dim fileName As String = referencono.Text + "_MayorsPermit.pdf"
            Dim filePath As String = Path.Combine(folderPath, fileName)


            If Not Directory.Exists(folderPath) Then
                Directory.CreateDirectory(folderPath)
            End If




            If String.IsNullOrWhiteSpace(sourcePath) OrElse Not File.Exists(sourcePath) Then

                filePath = ""
            Else

                ' Copy the file
                File.Copy(sourcePath, filePath, True)
            End If




            ''get email
            Dim email As String = ""

            conn = "SELECT SysMngr.email from ONLINE.business_application_tbl INNER JOIN ONLINE.SysMngr ON ONLINE.SysMngr.UserID= ONLINE.business_application_tbl.user_id WHERE business_application_tbl.ApplicationID = '" & TxtApplicationNo.Text & "'"
            Con_ms = New SqlConnection(mcs)
            Con_ms.Open()
            cmd_ms = New SqlCommand(conn, Con_ms)
            rdr_ms = cmd_ms.ExecuteReader(CommandBehavior.CloseConnection)
            If rdr_ms.Read = True Then
                email = rdr_ms("email").ToString


            Else

                MsgBox("No Email Found for this application contact your admin")
                Exit Sub
            End If

            Con_ms.Close()



            Con_ms1 = New SqlConnection(mcs)
            Con_ms1.Open()
            conn_ms1 = "UPDATE ONLINE.business_applicationstatus_dtl set IsPrinted ='D',  Printed_dttime='" & DateTime.Now() & "' where ApplicationID='" & TxtApplicationNo.Text & "'"
            cmd_ms1 = New SqlCommand(conn_ms1, Con_ms1)
            cmd_ms1.ExecuteNonQuery()
            Con_ms1.Close()



            Con_ms1 = New SqlConnection(mcs)
            Con_ms1.Open()
            conn_ms1 = "UPDATE ONLINE.business_assessment_dtl set  MayorsPermit='" & fileName & "'  where ApplicationID='" & TxtApplicationNo.Text & "'"
            cmd_ms1 = New SqlCommand(conn_ms1, Con_ms1)
            cmd_ms1.ExecuteNonQuery()
            Con_ms1.Close()

            MsgBox("Permit uploaded Successfully ")












            Con_ms = New SqlConnection(mcs)
            Con_ms.Open()
            conn = "INSERT INTO ONLINE.email_outbox (userid, assessment_path,accountno, email, Subject, fullname, referencecode, datesend) " _
               & "VALUES ('" & useraccountid.Text & "','" & filePath & "', '" & TxtAccountNo.Text & "', '" & email & "', 'Business Permit Issuance' ,@BusinessName, '" & referencono.Text & "', @Date)"
            cmd_ms = New SqlCommand(conn, Con_ms)
            cmd_ms.Parameters.Add("@BusinessName", SqlDbType.VarChar).Value = TxtBusinessName.Text
            cmd_ms.Parameters.Add("@Date", SqlDbType.VarChar).Value = DateAndTime.Now()
            cmd_ms.ExecuteNonQuery()
            Con_ms.Close()

            Me.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Con_ms.Close()
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim openFileDialog As New OpenFileDialog()

        openFileDialog.Filter = "PDF Files|*.pdf"


        If openFileDialog.ShowDialog() = DialogResult.OK Then

            Try

                AxAcroPDF1.src = openFileDialog.FileName

                file1.Text = openFileDialog.FileName
            Catch ex As Exception

                MessageBox.Show("Error loading files: " & ex.Message)
            End Try
        End If
    End Sub
End Class