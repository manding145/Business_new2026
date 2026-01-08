Imports System.Data.SqlClient
Imports System.IO


Public Class Payment

    Private Sub Payment_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BtnSearchRecord_Click(sender As Object, e As EventArgs) Handles BtnSearchRecord.Click
        Try
            BPLO.DataGrid.Rows.Clear()
            conn = "SELECT ONLINE.business_application_tbl.applicationID as applicationID , ONLINE.business_application_tbl.accountno AS act, ONLINE.business_record_hdr.b_name as bname, ONLINE.business_assessment_dtl.Total_amt as amt " _
            & "FROM " _
            & "ONLINE.business_application_tbl INNER JOIN ONLINE.business_assessment_dtl ON ONLINE.business_assessment_dtl.applicationID= ONLINE.business_application_tbl.applicationID INNER JOIN ONLINE.business_applicationstatus_dtl ON ONLINE.business_applicationstatus_dtl.ApplicationID = ONLINE.business_application_tbl.applicationID INNER JOIN ONLINE.business_record_hdr ON ONLINE.business_record_hdr.recordID =  ONLINE.business_application_tbl.recordID " & _
            "where ONLINE.business_application_tbl.accountno LIKE '%" & referencono.Text & "' and YEAR(ONLINE.business_application_tbl.application_date)='" & Date.Now.Year & "' AND ONLINE.business_applicationstatus_dtl.payment_status='P'"
            Con_ms = New SqlConnection(mcs)
            Con_ms.Open()
            cmd_ms = New SqlCommand(conn, Con_ms)
            rdr_ms = cmd_ms.ExecuteReader(CommandBehavior.CloseConnection)
            If rdr_ms.Read = True Then

                TxtAccountNo.Text = rdr_ms("act").ToString
                TxtBusinessName.Text = rdr_ms("bname").ToString
                TotalAssessmentAmount.Text = rdr_ms("amt").ToString
                TxtApplicationNo.Text = rdr_ms("applicationID").ToString

            Else

                MsgBox("Business Record Not Found!")
            End If


            Con_ms.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub UploadScannedReceipt_Click(sender As Object, e As EventArgs) Handles UploadScannedReceipt.Click
        Dim openFileDialog As New OpenFileDialog()

        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tiff"


        If openFileDialog.ShowDialog() = DialogResult.OK Then

            Try
                'PictureBox1.Image = Image.FromFile(openFileDialog.FileName)
            Catch ex As Exception

                MessageBox.Show("Error loading image: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub SaveNow_Click(sender As Object, e As EventArgs) Handles SaveNow.Click


        If TxtTransaction.Text = "" Then

            MsgBox("Transaction cannot be empty!")
            Exit Sub
        End If



        If TotalAssessmentAmount.Text <> totalpaid.Text Then

            MsgBox("Assessment Amount and Paid Amount dont mactch!")
            Exit Sub
        End If


        If assessment_file.Text = "" Then

            MsgBox(" no Business OR file uploaded")
            Exit Sub
        End If



        'MsgBox("Transaction cannot be empty!")
        'End If

        'If PictureBox1.Image Is Nothing Then
        '    MsgBox("Please complete necessary fields!")
        '    Exit Sub
        'End If


        'If TxtAccountNo.Text = "" Or TxtBusinessName.Text = "" Or TxtAmountPaid.Text = "" Or TxtTransaction.Text = "" Then
        '    MsgBox("Please complete neccessary fields!")
        '    Exit Sub




        'Else
        ''SaveNow
        Try

            ' Raw path from Acrobat ActiveX
            Dim rawPath As String = AxAcroPDF1.src

            Dim sourcePath As String = rawPath.Replace("file://", "").Trim()

            Dim rawPath2 As String = AxAcroPDF2.src

            Dim sourcePath2 As String = rawPath2.Replace("file://", "").Trim()

        


            sourcePath = sourcePath.Replace("/", "\")
            sourcePath2 = sourcePath2.Replace("/", "\")
         

            Dim folderPath As String = "\\10.0.27.194\FileAttachment\BUSINESS_APPLICATION\" + referencono.Text + "\"

            Dim fileName As String = referencono.Text + "_Tax_OR.pdf"
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


            Dim fileName2 As String = referencono.Text + "_CTC_OR.pdf"
            Dim filePath2 As String = Path.Combine(folderPath, fileName2)
            If String.IsNullOrWhiteSpace(sourcePath2) OrElse Not File.Exists(sourcePath2) Then

                filePath2 = ""
            Else

                ' Copy the file
                File.Copy(sourcePath2, filePath2, True)
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
            conn_ms1 = "UPDATE ONLINE.business_applicationstatus_dtl set IsPrinted ='P', payment_status = 'D', payment_dttime='" & dt_datepaid.Value.ToString("yyyy-MM-dd hh:mm:ss") & "' where ApplicationID='" & TxtApplicationNo.Text & "'"
            cmd_ms1 = New SqlCommand(conn_ms1, Con_ms1)
            cmd_ms1.ExecuteNonQuery()
            Con_ms1.Close()



            Con_ms1 = New SqlConnection(mcs)
            Con_ms1.Open()
            conn_ms1 = "UPDATE ONLINE.business_assessment_dtl set PaymentTransactionNo = '" & TxtTransaction.Text & "', OfficialReceipt='" & fileName & "' , CTC = '" & fileName2 & "' where ApplicationID='" & TxtApplicationNo.Text & "'"
            cmd_ms1 = New SqlCommand(conn_ms1, Con_ms1)
            cmd_ms1.ExecuteNonQuery()
            Con_ms1.Close()

            MsgBox("Payment Status Successfully Saved")



            Con_ms = New SqlConnection(mcs)
            Con_ms.Open()
            conn = "INSERT INTO ONLINE.email_outbox (userid, officialreceipt_path, CTC_path, accountno, email, Subject, fullname, referencecode, datesend) " _
               & "VALUES ('" + useraccountid.Text + "', '" & filePath & "', '" & filePath2 & "', '" & TxtAccountNo.Text & "', '" & email & "', 'Business Permit Payment' ,@BusinessName, '" & referencono.Text & "', @Date)"
            cmd_ms = New SqlCommand(conn, Con_ms)
            cmd_ms.Parameters.Add("@BusinessName", SqlDbType.VarChar).Value = TxtBusinessName.Text

            cmd_ms.Parameters.Add("@useraccountid", SqlDbType.Int).Value = useraccountid.Text

            cmd_ms.Parameters.Add("@Date", SqlDbType.VarChar).Value = DateAndTime.Now()
            cmd_ms.ExecuteNonQuery()
            Con_ms.Close()

            Me.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Con_ms.Close()
        End Try

        'End If
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles referencono.TextChanged

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub TxtAccountNo_TextChanged(sender As Object, e As EventArgs) Handles TxtAccountNo.TextChanged

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim openFileDialog As New OpenFileDialog()

        openFileDialog.Filter = "PDF Files|*.pdf"


        If openFileDialog.ShowDialog() = DialogResult.OK Then

            Try

                AxAcroPDF1.src = openFileDialog.FileName

                assessment_file.Text = openFileDialog.FileName
            Catch ex As Exception

                MessageBox.Show("Error loading files: " & ex.Message)
            End Try
        End If



    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim openFileDialog As New OpenFileDialog()

        openFileDialog.Filter = "PDF Files|*.pdf"


        If openFileDialog.ShowDialog() = DialogResult.OK Then

            Try
                AxAcroPDF2.src = openFileDialog.FileName
                ctc_file.Text = openFileDialog.FileName
            Catch ex As Exception

                MessageBox.Show("Error loading files: " & ex.Message)
            End Try
        End If


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        'Dim openFileDialog As New OpenFileDialog()

        'openFileDialog.Filter = "PDF Files|*.pdf"


        'If openFileDialog.ShowDialog() = DialogResult.OK Then

        '    Try
        '        AxAcroPDF3.src = openFileDialog.FileName
        '        fire_file.Text = openFileDialog.FileName
        '    Catch ex As Exception

        '        MessageBox.Show("Error loading files: " & ex.Message)
        '    End Try
        'End If
    End Sub
End Class