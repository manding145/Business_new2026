Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Public Class BPLO
    Dim im_userid, takngaran As String

   

    Private Sub DataGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGrid.CellContentClick
      
        If e.RowIndex = -1 Then

            Exit Sub
        End If


        If e.ColumnIndex = 8 Then
            Try

                conn_ms1 = "SELECT * FROM ONLINE.business_application_tbl " _
               & "WHERE " _
               & "applicationID= '" & DataGrid.Item(0, DataGrid.CurrentRow.Index).Value & "' and process_status ='1'"

                Con_ms1 = New SqlConnection(mcs)
                Con_ms1.Open()
                cmd_ms1 = New SqlCommand(conn_ms1, Con_ms1)
                rdr_ms1 = cmd_ms1.ExecuteReader(CommandBehavior.CloseConnection)
                If rdr_ms1.Read = True Then

                    MsgBox("This Application is currently handle by other user")
                Else
                    FormStatus = True
                    'if not, update process_status
                    Con_ms = New SqlConnection(mcs)
                    Con_ms.Open()
                    conn_ms = "UPDATE ONLINE.business_application_tbl set process_status = '1' " _
                        & "WHERE applicationID='" & DataGrid.Item(0, DataGrid.CurrentRow.Index).Value & "'"
                    cmd_ms = New SqlCommand(conn_ms, Con_ms)
                    cmd_ms.ExecuteNonQuery()
                    Con_ms.Close()



                    'load data to record form
                    conn_ms = "SELECT * FROM ONLINE.business_application_tbl INNER JOIN ONLINE.SysMngr ON ONLINE.SysMngr.UserID = ONLINE.business_application_tbl.user_id WHERE business_application_tbl.applicationID= '" & DataGrid.Item(0, DataGrid.CurrentRow.Index).Value & "' "
                    Con_ms = New SqlConnection(mcs)
                    Con_ms.Open()
                    cmd_ms = New SqlCommand(conn_ms, Con_ms)
                    rdr_ms = cmd_ms.ExecuteReader(CommandBehavior.CloseConnection)
                    If rdr_ms.Read = True Then

                        Dim NewMDIChild As New BPLOApplicationRecord()
                        NewMDIChild.MdiParent = MainMenu
                        NewMDIChild.Show()

                        Dim BPLOApplicationRecord As BPLOApplicationRecord = CType(Application.OpenForms("BPLOApplicationRecord"), BPLOApplicationRecord)

                        With BPLOApplicationRecord
                            .txt_grossdeclared.Text = rdr_ms("gross_dec").ToString
                            .TxtRefenceNo.Text = rdr_ms("RefCode").ToString
                            applicationID_search = rdr_ms("applicationID").ToString
                            .lbl_accountno.Text = rdr_ms("accountno").ToString
                            .lbl_businessname.Text = rdr_ms("businessname").ToString
                            .txt_accountno.Text = rdr_ms("accountno").ToString
                            .txt_businessname.Text = rdr_ms("businessname").ToString
                            .txt_applicationno.Text = rdr_ms("applicationID").ToString
                            '.txt_businessaddress.Text = rdr_ms("address").ToString
                            .txt_businessline.Text = rdr_ms("businessline").ToString
                            .txt_email.Text = rdr_ms("Email").ToString
                            .txt_contactno.Text = rdr_ms("ContactNo").ToString
                            folder_directory = "BUSINESS_APPLICATION\" + rdr_ms("RefCode").ToString + "\"
                            '.txt_username.Text = rdr_ms("b_username").ToString
                            '.txt_password.Text = rdr_ms("b_password").ToString
                            .txt_itr4.Text = rdr_ms("b_itr4").ToString

                            .fullname.Text = rdr_ms("Firstname").ToString() + " " + rdr_ms("Middlename").ToString() + " " + rdr_ms("Lastname").ToString()
                            .typeofapplication.Text = rdr_ms("applicationtype").ToString()
                            .useraccountid.Text = rdr_ms("user_id").ToString()


                            .Grid_attachments.Rows.Clear()


                            'attachments
                            conn_ms2 = "SELECT * FROM ONLINE.business_attachment_m where IsActive = '1'"
                            Con_ms2 = New SqlConnection(mcs)
                            Con_ms2.Open()
                            cmd_ms2 = New SqlCommand(conn_ms2, Con_ms2)
                            rdr_ms2 = cmd_ms2.ExecuteReader(CommandBehavior.CloseConnection)
                            Do While rdr_ms2.Read = True

                                Dim attach_code_temp As String
                                attach_code_temp = rdr_ms2("attachmentcode")
                                If rdr_ms(attach_code_temp).ToString = "" Then
                                    'do nothing
                                Else
                                    .Grid_attachments.Rows.Add(rdr_ms(attach_code_temp), rdr_ms2("AttachmentDescription"), "VIEW")
                                End If
                            Loop
                            Con_ms2.Close()

                        End With

                    End If
                    Con_ms.Close()



                    'track application_Status
                    conn_ms = "SELECT * FROM ONLINE.business_applicationstatus_dtl where business_applicationstatus_dtl.applicationID= '" & DataGrid.Item(0, DataGrid.CurrentRow.Index).Value & "' "
                    Con_ms = New SqlConnection(mcs)
                    Con_ms.Open()
                    cmd_ms = New SqlCommand(conn_ms, Con_ms)
                    rdr_ms = cmd_ms.ExecuteReader(CommandBehavior.CloseConnection)
                    If rdr_ms.Read = True Then

                        Dim BPLOApplicationRecord As BPLOApplicationRecord = CType(Application.OpenForms("BPLOApplicationRecord"), BPLOApplicationRecord)
                        With BPLOApplicationRecord

                            If rdr_ms("verify_status") = "P" Then
                                .Panel_pending.Visible = True
                                .panel_verified.Visible = False
                                .panel_denied.Visible = False
                            ElseIf rdr_ms("verify_status") = "V" Then
                                .Panel_pending.Visible = False
                                .panel_verified.Visible = True
                                .panel_denied.Visible = False
                                .BtnAddNewRecord.Enabled = False
                                .btnDeny.Visible = False
                            ElseIf rdr_ms("verify_status") = "D" Then
                                .Panel_pending.Visible = False
                                .panel_verified.Visible = False
                                .panel_denied.Visible = True
                                .BtnAddNewRecord.Enabled = False
                                .btnDeny.Visible = False
                            End If
                            .txt_deniedremarks.Text = rdr_ms("Denied_remarks").ToString






                            'Verification Status
                            If rdr_ms("verify_status").ToString = "P" Then
                                .panel_track_verification.Visible = True
                                .txt_veririfacation_date.Text = "NOT AVAILABLE"
                                .txt_verification_user.Text = "NOT AVAILABLE"
                                .txt_verification_remarks.Text = "Pending Application"
                            ElseIf rdr_ms("verify_status").ToString = "V" Then
                                im_userid = rdr_ms("user_verified").ToString
                                Call whoisthisuser()
                                .txt_veririfacation_date.Text = rdr_ms("verified_timedt")
                                .txt_verification_user.Text = takngaran
                                .txt_verification_remarks.Text = "This Application was verified by:"
                                .panel_track_verification.Visible = True

                            ElseIf rdr_ms("verify_status").ToString = "D" Then
                                .panel_track_verification.Visible = True
                                im_userid = rdr_ms("user_deny").ToString
                                Call whoisthisuser()
                                .txt_veririfacation_date.Text = rdr_ms("verify_deny_dttime")
                                .txt_verification_user.Text = takngaran
                                .txt_verification_remarks.Text = "This Application was Denied by:"
                            Else
                                .panel_track_verification.Visible = False
                            End If



                            'Evaluation
                            If rdr_ms("eval_status").ToString = "P" Then
                                .panel_track_evaluation.Visible = True
                                .txt_evaluation_date.Text = "NOT AVAILABLE"
                                .txt_evaluation_user.Text = "NOT AVAILABLE"
                                .txt_evaluation_remarks.Text = "Pending Application"

                            ElseIf rdr_ms("eval_status").ToString = "V" Then
                                im_userid = rdr_ms("user_eval").ToString
                                Call whoisthisuser()
                                .txt_evaluation_date.Text = rdr_ms("eval_timedt").ToString
                                .txt_evaluation_user.Text = takngaran
                                .txt_evaluation_remarks.Text = "This Application was evaluated by:"
                                .panel_track_evaluation.Visible = True

                            ElseIf rdr_ms("eval_status").ToString = "D" Then
                                .panel_track_verification.Visible = True
                                im_userid = rdr_ms("user_deny").ToString
                                Call whoisthisuser()
                                .txt_veririfacation_date.Text = rdr_ms("eval_deny_dttime")
                                .txt_verification_user.Text = takngaran
                                .txt_verification_remarks.Text = "This Application was Denied by:"

                            Else
                                .panel_track_evaluation.Visible = False
                            End If


                            'Assessment

                            If rdr_ms("assess_status").ToString = "P" Then
                                .panel_track_assessment.Visible = True
                                .txt_asses_date.Text = "NOT AVAILABLE"
                                .txt_asses_user.Text = "NOT AVAILABLE"
                                .txt_asses_remarks.Text = "Pending Application"

                            ElseIf rdr_ms("assess_status").ToString = "V" Then
                                im_userid = rdr_ms("user_assess").ToString
                                Call whoisthisuser()
                                .txt_asses_date.Text = rdr_ms("assess_timedt")
                                .txt_asses_user.Text = takngaran
                                .txt_asses_remarks.Text = "This Application was assessed by:"
                                .panel_track_assessment.Visible = True

                            ElseIf rdr_ms("assess_status").ToString = "D" Then
                                .panel_track_assessment.Visible = True
                                im_userid = rdr_ms("user_deny").ToString
                                Call whoisthisuser()
                                .txt_veririfacation_date.Text = rdr_ms("assess_deny_dttime")
                                .txt_verification_user.Text = takngaran
                                .txt_verification_remarks.Text = "This Application was Denied by:"

                            Else
                                .panel_track_assessment.Visible = False
                            End If



                            If rdr_ms("fire_assess_status").ToString = "V" Then
                                .panel_track_pay.Visible = True
                                .txt_veririfacation_date_fire.Text = rdr_ms("fire_assess_timedt")
                                .txt_verification_user_fire.Text = rdr_ms("fire_user_assess")
                                .txt_verification_remarks_fire.Text = "This Application was assessed by:"

                            Else
                                .panel_track_pay.Visible = False
                            End If

                            .DataGrid_remarks.Rows.Clear()
                            If rdr_ms("verify_remarks").ToString = "" Then

                            Else
                                .DataGrid_remarks.Rows.Add("Verification", rdr_ms("verify_remarks"))
                            End If

                            If rdr_ms("eval_remarks").ToString = "" Then

                            Else
                                .DataGrid_remarks.Rows.Add("Evaluation", rdr_ms("eval_remarks"))
                            End If

                            If rdr_ms("assess_remarks").ToString = "" Then

                            Else
                                .DataGrid_remarks.Rows.Add("Assessment", rdr_ms("assess_remarks"))
                            End If



                            If rdr_ms("fire_assess_status").ToString = "" Then

                            Else
                                .DataGrid_remarks.Rows.Add("Fire Assessment", "-")
                            End If




                            If rdr_ms("printed_remarks").ToString = "" Then

                            Else
                                .DataGrid_remarks.Rows.Add("Printed", rdr_ms("printed_remarks"))
                            End If



                        End With
                    End If

                    Con_ms.Close()
                End If
                rdr_ms1.Close()

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try



        End If




    End Sub
    Private Sub whoisthisuser()
        conn_ms2 = "SELECT * FROM ONLINE.business_users where system_userid= '" & im_userid & "' "

        Con_ms2 = New SqlConnection(mcs)
        Con_ms2.Open()
        cmd_ms2 = New SqlCommand(conn_ms2, Con_ms2)
        rdr_ms2 = cmd_ms2.ExecuteReader(CommandBehavior.CloseConnection)
        If rdr_ms2.Read = True Then

            takngaran = rdr_ms2("Firstname").ToString & " " & rdr_ms2("MiddleName").ToString & " " & rdr_ms2("LastName").ToString

        End If
        Con_ms2.Close()
    End Sub
    Private Sub BtnSearchRecord_Click(sender As Object, e As EventArgs) Handles BtnSearchRecord.Click
        SearchApplicationRecord.ShowDialog()
        'Dim FrmHealthCertificate As MayorsPermitControl = CType(Application.OpenForms("MayorsPermitControl"), MayorsPermitControl)
        'MayorsPermitControl.txt_AccountNo.Text = "T-01289"
        'MayorsPermitControl.ShowDialog()
    End Sub




    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Try

            conn_ms = "SELECT " _
            & " COUNT(applicationID) as no_pending " _
            & " FROM ONLINE.business_applicationstatus_dtl  where verify_status ='P'"

            Con_ms = New SqlConnection(mcs)
            Con_ms.Open()
            cmd_ms = New SqlCommand(conn_ms, Con_ms)
            rdr_ms = cmd_ms.ExecuteReader(CommandBehavior.CloseConnection)
            If rdr_ms.Read = True Then

                lbl_countpending.Text = rdr_ms("no_pending")
            Else
                lbl_countpending.Text = "0"

            End If

            Con_ms.Close()



            conn_ms = "SELECT " _
           & " COUNT(applicationID) as no_pending " _
           & " FROM ONLINE.business_applicationstatus_dtl  where verify_status ='V' and verified_timedt like '%" & Format((dt_Appoinment.Value), "yyyy-MM-dd") & "%'"

            Con_ms = New SqlConnection(mcs)
            Con_ms.Open()
            cmd_ms = New SqlCommand(conn_ms, Con_ms)
            rdr_ms = cmd_ms.ExecuteReader(CommandBehavior.CloseConnection)
            If rdr_ms.Read = True Then

                lblcountissued.Text = rdr_ms("no_pending")
            Else
                lblcountissued.Text = "0"
            End If

            Con_ms.Close()




            conn_ms = "SELECT " _
               & " COUNT(applicationID) as no_pending " _
               & " FROM ONLINE.business_applicationstatus_dtl  where IsReupload ='1'  and verify_status = 'P'"
            Con_ms = New SqlConnection(mcs)
            Con_ms.Open()
            cmd_ms = New SqlCommand(conn_ms, Con_ms)
            rdr_ms = cmd_ms.ExecuteReader(CommandBehavior.CloseConnection)
            If rdr_ms.Read = True Then

                lbl_countreuploaded.Text = rdr_ms("no_pending")

            End If

            Con_ms.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Con_ms.Close()
        End Try
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        DataGrid.Rows.Clear()
        lblCount.Visible = False
        Try
            conn_ms = "SELECT " & _
            "business_application_tbl.applicationid, " & _
            "business_application_tbl.RefCode, " & _
            "business_application_tbl.recordID, " & _
            "business_application_tbl.accountno, " & _
             "business_application_tbl.businessname, " & _
            "business_application_tbl.application_date, " & _
            "business_application_tbl.application_time, " & _
            "business_applicationstatus_dtl.verify_status FROM " & _
            "ONLINE.business_application_tbl  " & _
            "INNER JOIN ONLINE.business_applicationstatus_dtl ON ONLINE.business_application_tbl.applicationID = ONLINE.business_applicationstatus_dtl.applicationID " & _
            "WHERE ONLINE.business_applicationstatus_dtl.verify_status='P' order by application_date ASC, application_time ASC"

            Con_ms = New SqlConnection(mcs)
            Con_ms.Open()
            cmd_ms = New SqlCommand(conn_ms, Con_ms)
            rdr_ms = cmd_ms.ExecuteReader(CommandBehavior.CloseConnection)
            Do While rdr_ms.Read = True

                DataGrid.Rows.Add(rdr_ms("applicationid"), rdr_ms("RefCode"), rdr_ms("RecordID"), rdr_ms("application_date"), Convert.ToDateTime(rdr_ms("application_date")).ToString("hh:mm tt"), rdr_ms("accountno"), rdr_ms("businessname"), rdr_ms("verify_status"), "VIEW")

            Loop

            Con_ms.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Con_ms.Close()
        End Try

    End Sub

    Private Sub dt_Appoinment_ValueChanged(sender As Object, e As EventArgs) Handles dt_Appoinment.ValueChanged
        DataGrid.Rows.Clear()

        Try
            conn_ms = "SELECT " & _
            "business_application_tbl.applicationID, " & _
            "business_application_tbl.recordID, " & _
            "business_application_tbl.accountno, " & _
            "business_record_hdr.b_name, " & _
            "business_application_tbl.application_date, " & _
            "business_application_tbl.application_time, " & _
            "business_application_tbl.application_status, " & _
            "business_applicationstatus_dtl.verify_status " & _
            "FROM " & _
            "ONLINE.business_application_tbl " & _
            "INNER JOIN ONLINE.business_applicationstatus_dtl ON ONLINE.business_application_tbl.applicationID = ONLINE.business_applicationstatus_dtl.applicationID " & _
            "INNER JOIN ONLINE.business_record_hdr ON ONLINE.business_application_tbl.recordID = ONLINE.business_record_hdr.recordID WHERE business_applicationstatus_dtl.verify_status ='P' and Isreupload='0' and application_date = '" & Format((dt_Appoinment.Value), "yyyy-MM-dd") & "' ORDER BY application_date ASC"
            Con_ms = New SqlConnection(mcs)
            Con_ms.Open()
            cmd_ms = New SqlCommand(conn_ms, Con_ms)
            rdr_ms = cmd_ms.ExecuteReader(CommandBehavior.CloseConnection)
            Do While rdr_ms.Read = True

                DataGrid.Rows.Add(rdr_ms("ApplicationID"), rdr_ms("RecordID"), rdr_ms("application_date"), rdr_ms("application_time"), rdr_ms("accountno"), rdr_ms("b_name"), rdr_ms("verify_status"), "VIEW")

            Loop

            Con_ms.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Con_ms.Close()
        End Try
        lblCount.Text = DataGrid.RowCount
    End Sub

    Private Sub Button8_Click_1(sender As Object, e As EventArgs) Handles Button8.Click
        DataGrid.Rows.Clear()

        Try
            If cmb_appointmentstatus.Text = "ALL" Then
                conn_ms = "SELECT " & _
            "business_application_tbl.applicationID, " & _
            "business_application_tbl.recordID, " & _
            "business_application_tbl.accountno, " & _
            "business_record_hdr.b_name, " & _
            "business_application_tbl.application_date, " & _
            "business_application_tbl.application_time, " & _
            "business_applicationstatus_dtl.verify_status " & _
            "FROM " & _
            "ONLINE.business_application_tbl " & _
            "INNER JOIN ONLINE.business_applicationstatus_dtl ON ONLINE.business_application_tbl.applicationID = ONLINE.business_applicationstatus_dtl.applicationID " & _
            "INNER ONLINE.JOIN business_record_hdr ON ONLINE.business_application_tbl.recordID = ONLINE.business_record_hdr.recordID WHERE (application_date between '" & Format((dt_Appoinment.Value), "yyyy-MM-dd") & "' and '" & Format((dt_Appoinment1.Value), "yyyy-MM-dd") & "') and Isreupload='0' ORDER BY application_date ASC"
                Con_ms = New SqlConnection(mcs)
                Con_ms.Open()
                cmd_ms = New SqlCommand(conn_ms, Con_ms)
                rdr_ms = cmd_ms.ExecuteReader(CommandBehavior.CloseConnection)
                Do While rdr_ms.Read = True
                    DataGrid.Rows.Add(rdr_ms("ApplicationID"), rdr_ms("RecordID"), rdr_ms("application_date"), rdr_ms("application_time"), rdr_ms("accountno"), rdr_ms("b_name"), rdr_ms("verify_status"), "VIEW")
                Loop
                Con_ms.Close()

            ElseIf cmb_appointmentstatus.Text = "PENDING" Then
                conn_ms = "SELECT " & _
               "business_application_tbl.applicationID, " & _
               "business_application_tbl.recordID, " & _
               "business_application_tbl.accountno, " & _
               "business_record_hdr.b_name, " & _
               "business_application_tbl.application_date, " & _
               "business_application_tbl.application_time, " & _
                "business_applicationstatus_dtl.verify_status " & _
                "FROM " & _
                "ONLINE.business_application_tbl " & _
                "INNER JOIN ONLINE.business_applicationstatus_dtl ON ONLINE.business_application_tbl.applicationID = ONLINE.business_applicationstatus_dtl.applicationID " & _
                "INNER JOIN ONLINE.business_record_hdr ON ONLINE.business_application_tbl.recordID = ONLINE.business_record_hdr.recordID WHERE business_applicationstatus_dtl.verify_status ='P'  and Isreupload='0' and application_date between '" & Format((dt_Appoinment.Value), "yyyy-MM-dd") & "' and '" & Format((dt_Appoinment1.Value), "yyyy-MM-dd") & "' ORDER BY application_date ASC, application_date ASC"
                Con_ms = New SqlConnection(cs)
                Con_ms.Open()
                cmd_ms = New SqlCommand(conn_ms, Con_ms)
                rdr_ms = cmd_ms.ExecuteReader(CommandBehavior.CloseConnection)
                Do While rdr_ms.Read = True
                    DataGrid.Rows.Add(rdr_ms("ApplicationID"), rdr_ms("RecordID"), rdr_ms("application_date"), rdr_ms("application_time"), rdr_ms("accountno"), rdr_ms("b_name"), rdr_ms("verify_status"), "VIEW")
                Loop

                Con_ms.Close()
            ElseIf cmb_appointmentstatus.Text = "DENIED" Then

                Dim mytimestampfrom = dt_Appoinment.Value.ToString("yyyy-MM-dd") & " 00:00:00"
                Dim mytimestampto = dt_Appoinment1.Value.ToString("yyyy-MM-dd") & " 23:59:00"
                conn = "SELECT " & _
               "business_application_tbl.applicationID, " & _
               "business_application_tbl.recordID, " & _
               "business_application_tbl.accountno, " & _
               "business_record_hdr.b_name, " & _
               "business_application_tbl.application_date, " & _
               "business_application_tbl.application_time, " & _
                "business_applicationstatus_dtl.verify_status " & _
                "FROM " & _
                "ONLINE.business_application_tbl " & _
                "INNER JOIN ONLINE.business_applicationstatus_dtl ON ONLINE.business_application_tbl.applicationID = ONLINE.business_applicationstatus_dtl.applicationID " & _
                "INNER JOIN ONLINE.business_record_hdr ON ONLINE.business_application_tbl.recordID = ONLINE.business_record_hdr.recordID WHERE business_applicationstatus_dtl.verify_status='D' and Isreupload='0' and verify_deny_dttime between '" & mytimestampfrom & "' and '" & mytimestampto & "' ORDER BY application_date ASC"
                Con_ms = New SqlConnection(mcs)
                Con_ms.Open()
                cmd_ms = New SqlCommand(conn, Con_ms)
                rdr_ms = cmd_ms.ExecuteReader(CommandBehavior.CloseConnection)
                Do While rdr_ms.Read = True

                    DataGrid.Rows.Add(rdr_ms("ApplicationID"), rdr_ms("RecordID"), rdr_ms("application_date"), rdr_ms("application_time"), rdr_ms("accountno"), rdr_ms("b_name"), rdr_ms("verify_status"), "VIEW")

                Loop

                Con_ms.Close()

                

            ElseIf cmb_appointmentstatus.Text = "VERIFIED" Then

                Dim mytimestampfrom = dt_Appoinment.Value.ToString("yyyy-MM-dd") & " 00:00:00"
                Dim mytimestampto = dt_Appoinment1.Value.ToString("yyyy-MM-dd") & " 23:59:00"
                conn = "SELECT " & _
               "business_application_tbl.applicationID, " & _
               "business_application_tbl.recordID, " & _
               "business_application_tbl.accountno, " & _
               "business_record_hdr.b_name, " & _
               "business_application_tbl.application_date, " & _
               "business_application_tbl.application_time, " & _
                "business_applicationstatus_dtl.verify_status " & _
                "FROM " & _
                "ONLINE.business_application_tbl " & _
                    "INNER JOIN ONLINE.business_applicationstatus_dtl ON ONLINE.business_application_tbl.applicationID = ONLINE.business_applicationstatus_dtl.applicationID " & _
                "INNER JOIN ONLINE.business_record_hdr ON ONLINE.business_application_tbl.recordID = ONLINE.business_record_hdr.recordID WHERE business_applicationstatus_dtl.verify_status='V' and Isreupload='0' and verified_timedt between '" & mytimestampfrom & "' and '" & mytimestampto & "'  ORDER BY application_date ASC"
                Con_ms = New SqlConnection(mcs)
                Con_ms.Open()
                cmd_ms = New SqlCommand(conn, Con_ms)
                rdr_ms = cmd_ms.ExecuteReader(CommandBehavior.CloseConnection)
                Do While rdr_ms.Read = True

                    DataGrid.Rows.Add(rdr_ms("ApplicationID"), rdr_ms("RecordID"), rdr_ms("application_date"), rdr_ms("application_time"), rdr_ms("accountno"), rdr_ms("b_name"), rdr_ms("verify_status"), "VIEW")

                Loop

                Con_ms.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        lblCount.Text = DataGrid.RowCount
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Con_ms = New SqlConnection(mcs)
        Con_ms.Open()
        conn_ms = "UPDATE ONLINE.business_application_tbl set process_status = '0' WHERE ApplicationID='" & DataGrid.Item(0, DataGrid.CurrentRow.Index).Value & "'"
        cmd_ms = New SqlCommand(conn_ms, Con_ms)
        cmd_ms.ExecuteNonQuery()
        Con_ms.Close()
        MsgBox("This application record is sucessfully unlock!")
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        FormStatus = False
        Me.Close()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub lbl_countpending_Click(sender As Object, e As EventArgs) Handles lbl_countpending.Click

    End Sub

    Private Sub PictureBox9_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click

    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint

    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        DataGrid.Rows.Clear()
        lblCount.Visible = False
        Try
            conn_ms = "SELECT " & _
            "business_application_tbl.applicationID, " & _
            "business_application_tbl.recordID, " & _
            "business_application_tbl.accountno, " & _
            "business_record_hdr.b_name, " & _
            "business_application_tbl.application_date, " & _
            "business_application_tbl.application_time, " & _
            "business_applicationstatus_dtl.verify_status FROM " & _
            "ONLINE.business_application_tbl  " & _
            "INNER JOIN ONLINE.business_record_hdr ON ONLINE.business_application_tbl.recordID = ONLINE.business_record_hdr.recordID  " & _
            "INNER JOIN ONLINE.business_applicationstatus_dtl ON ONLINE.business_application_tbl.applicationID = ONLINE.business_applicationstatus_dtl.applicationID " & _
            "WHERE business_applicationstatus_dtl.verify_status='P' and Isreupload='1' order by Reupload_time ASC"
            Con_ms = New SqlConnection(mcs)
            Con_ms.Open()
            cmd_ms = New SqlCommand(conn_ms, Con_ms)
            rdr_ms = cmd_ms.ExecuteReader(CommandBehavior.CloseConnection)
            Do While rdr_ms.Read = True

                DataGrid.Rows.Add(rdr_ms("ApplicationID"), rdr_ms("RecordID"), rdr_ms("application_date"), rdr_ms("application_time"), rdr_ms("accountno"), rdr_ms("b_name"), rdr_ms("verify_status"), "VIEW")

            Loop

            Con_ms.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub lblcountissued_Click(sender As Object, e As EventArgs) Handles lblcountissued.Click

    End Sub

    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs) Handles Panel5.Paint

    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        DataGrid.Rows.Clear()
        lblCount.Visible = False
        Try
            conn_ms = "SELECT " & _
            "business_application_tbl.applicationID, " & _
            "business_application_tbl.RefCode, " & _
            "business_application_tbl.recordID, " & _
            "business_application_tbl.accountno, " & _
            "business_application_tbl.businessname, " & _
            "business_application_tbl.application_date, " & _
            "business_application_tbl.application_time, " & _
            "business_applicationstatus_dtl.verify_status FROM " & _
            "ONLINE.business_application_tbl  " & _
            "INNER JOIN ONLINE.business_applicationstatus_dtl ON ONLINE.business_application_tbl.applicationID = ONLINE.business_applicationstatus_dtl.applicationID " & _
            "WHERE business_applicationstatus_dtl.verify_status ='V' and business_applicationstatus_dtl.verified_timedt like '%" & Format((dt_Appoinment.Value), "yyyy-MM-dd") & "%' order by application_date ASC, application_time ASC"
            Con_ms = New SqlConnection(mcs)
            Con_ms.Open()
            cmd_ms = New SqlCommand(conn_ms, Con_ms)
            rdr_ms = cmd_ms.ExecuteReader(CommandBehavior.CloseConnection)
            Do While rdr_ms.Read = True

                DataGrid.Rows.Add(rdr_ms("applicationid"), rdr_ms("RefCode"), rdr_ms("RecordID"), rdr_ms("application_date"), Convert.ToDateTime(rdr_ms("application_date")).ToString("hh:mm tt"), rdr_ms("accountno"), rdr_ms("businessname"), rdr_ms("verify_status"), "VIEW")

            Loop
            Con_ms.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

  



    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Con_ms = New SqlConnection(mcs)
        Con_ms.Open()
        conn_ms = "DELETE from ONLINE.business_application_tbl WHERE ApplicationID='" & DataGrid.Item(0, DataGrid.CurrentRow.Index).Value & "'"
        cmd_ms = New SqlCommand(conn_ms, Con_ms)
        cmd_ms.ExecuteNonQuery()
        MsgBox("This application record is sucessfully deleted!")
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub
End Class