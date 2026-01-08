Imports System.Data.SqlClient
Imports System.IO
Public Class PendingMayorsPermit

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

   
    End Sub

    Private Sub PendingMayorsPermit_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Label10.Visible = False

        'Try
        '    conn = "SELECT DISTINCT(BPLS.BusinessLedger.BusinessID), BPLS.BusinessLedger.ORNumber, BPLS.BusinessLedger.[Year], BPLS.BusinessLedger.ORDate FROM BPLS.BusinessLedger where Year = '" & Date.Now.Year & "' ORDER by ORDate ASC"
        '    Con1 = New SqlConnection(cs3)
        '    Con1.Open()
        '    cmd1 = New SqlCommand(conn, Con1)
        '    rdr1 = cmd1.ExecuteReader(CommandBehavior.CloseConnection)
        '    Do While rdr1.Read = True
        '        Dim pendingpermit, accountno As String
        '        pendingpermit = "PENDING"


        '        conn1 = "SELECT * from business_permit_status where BusinessID = '" & rdr1("BusinessID") & "'"
        '        Con = New SqlConnection(cs)
        '        Con.Open()
        '        cmd = New SqlCommand(conn1, Con)
        '        rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
        '        Do While rdr.Read = True
        '            pendingpermit = "VERIFIED"
        '        Loop
        '        Con.Close()



        '        conn3 = "SELECT * FROM BPLS.BusinessRecord_HDR WHERE BusinessID = '" & rdr1("BusinessID") & "'"
        '        Con3 = New SqlConnection(cs1)
        '        Con3.Open()
        '        cmd3 = New SqlCommand(conn3, Con3)
        '        rdr3 = cmd3.ExecuteReader(CommandBehavior.CloseConnection)
        '        If rdr3.Read = True Then

        '            accountno = rdr3("AccountNo")
        '        End If
        '        Con3.Close()






        '        DataGrid.Rows.Add(rdr1("ORDate"), rdr1("ORNumber"), accountno, pendingpermit)



        '    Loop
        '    Con1.Close()
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try











    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick


        Try

            conn_ms = "SELECT COUNT(*) as no_pending FROM ONLINE.business_applicationstatus_dtl " & _
           "WHERE payment_status ='D' and IsPrinted  = 'P'"
            Con_ms = New SqlConnection(mcs)
            Con_ms.Open()
            cmd_ms = New SqlCommand(conn_ms, Con_ms)
            rdr_ms = cmd_ms.ExecuteReader(CommandBehavior.CloseConnection)
            If rdr_ms.Read = True Then
                lbl_countpending.Text = rdr_ms("no_pending")
            End If
            Con_ms.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try




        Try
            conn = "SELECT " _
               & " COUNT(permitappid) as no_pending " _
               & " FROM business_permit_status where status ='D' and Year(DatePrinted) = '" & Date.Now.Year & "' and TypeApplication='ONLINE'"

            Con = New SqlConnection(cs)
            Con.Open()
            cmd = New SqlCommand(conn, Con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If rdr.Read = True Then

                lblcountissued.Text = rdr("no_pending")

            End If

            Con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try
            conn = "SELECT " _
               & " COUNT(permitappid) as no_pending " _
               & " FROM business_permit_status where status ='D' and Year(DatePrinted) = '" & Date.Now.Year & "' and (TypeApplication='WALKIN' OR TypeApplication is null)"

            Con = New SqlConnection(cs)
            Con.Open()
            cmd = New SqlCommand(conn, Con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If rdr.Read = True Then

                lblcountissued_W.Text = rdr("no_pending")

            End If

            Con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click


        Label10.Visible = True

        'Get Done Payment

        DataGrid.Rows.Clear()
        lblCount.Visible = False
        Try
            conn_ms = "SELECT bat.delivery_type , bat.businessname, bat.accountno, bsd.applicationID, bsd.IsPrinted, bsd.payment_dttime, bsd.IsPaid FROM ONLINE.business_applicationstatus_dtl bsd INNER JOIN ONLINE.business_application_tbl bat ON bat.applicationID = bsd.applicationID INNER JOIN ONLINE.business_assessment_dtl bad ON bad.applicationID = bsd.applicationID WHERE bsd.payment_status = 'D' AND bsd.IsPrinted = 'P' ORDER BY bsd.payment_dttime ASC;"

            Con_ms = New SqlConnection(mcs)
            Con_ms.Open()
            cmd_ms = New SqlCommand(conn_ms, Con_ms)
            rdr_ms = cmd_ms.ExecuteReader(CommandBehavior.CloseConnection)
            Do While rdr_ms.Read = True
                Dim STATUS = "PENDING"
                Dim action = "GENERATE"
                If rdr_ms("IsPrinted").ToString = "" Then
                    STATUS = "PENDING"
                    action = "GENERATE"
                Else
                    STATUS = "DONE"
                    action = "VIEW"
                End If

                'Con2 = New SqlConnection(cs)
                'Con2.Open()
                'Dim permitappid As Integer
                'conn = "SELECT * FROM business_permit_status WHERE BusinessID='" & rdr_ms("businessid") & "' and ApplicationID='" & rdr_ms("applicationID") & "' "
                'cmd2 = New SqlCommand(conn, Con2)
                'rdr2 = cmd2.ExecuteReader(CommandBehavior.CloseConnection)
                'If rdr2.Read = True Then

                '    permitappid = rdr2("permitappid")

                'End If
                'Con2.Close()



                DataGrid.Rows.Add(rdr_ms("payment_dttime"), rdr_ms("applicationID"), "", rdr_ms("accountno"), "Pending", "Upload", "", rdr_ms("applicationID"), rdr_ms("delivery_type"))

            Loop

            Con_ms.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Con_ms.Close()
        End Try














        'DataGrid.Rows.Clear()
        'lblCount.Visible = False
        'Try
        '    conn = "SELECT * FROM business_permit_status WHERE Status ='P' ORDER BY DatePending ASC"

        '    Con = New SqlConnection(cs)
        '    Con.Open()
        '    cmd = New SqlCommand(conn, Con)
        '    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
        '    Do While rdr.Read = True

        '        DataGrid.Rows.Add(rdr("DatePending"), rdr("ApplicationID"), rdr("BusinessID"), rdr("AccountNo"), rdr("Status"), "VIEW", "VIEW", rdr("permitappid"))

        '    Loop

        '    Con.Close()

        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        FormStatus = False
        Me.Close()
    End Sub

    Private Sub DataGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGrid.CellContentClick
        If e.RowIndex = -1 Then

            Exit Sub
        End If


        If e.ColumnIndex = 5 Then


            If DataGrid.Item(5, DataGrid.CurrentRow.Index).Value = "Upload" Then


                conn_ms = "SELECT bat.user_id, bad.MayorsPermit, bad.OfficialReceipt, bad.CTC, bad.FireOR, bsd.IsPrinted,bat.RefCode, bat.applicationID, bat.accountno, bat.businessname, bad.tax_amt, bad.cedula_amt, bad.fire_local_amount, bad.Total_amt " & _
                       "FROM ONLINE.business_applicationstatus_dtl bsd " & _
                       "INNER JOIN ONLINE.business_application_tbl bat " & _
                       "ON bsd.applicationID = bat.applicationID " & _
                       "INNER JOIN ONLINE.business_assessment_dtl bad " & _
                       "ON bad.applicationID = bsd.applicationID " & _
                       "WHERE bsd.applicationID = '" + DataGrid.Item(1, DataGrid.CurrentRow.Index).Value.ToString() + "'"

                Con_ms = New SqlConnection(mcs)
                Con_ms.Open()
                cmd_ms = New SqlCommand(conn_ms, Con_ms)
                rdr_ms = cmd_ms.ExecuteReader(CommandBehavior.CloseConnection)
                If rdr_ms.Read = True Then




                    Dim NewMDIChild As New UploadPermit()
                    NewMDIChild.Show()


                    Dim UploadPermit As UploadPermit = CType(Application.OpenForms("UploadPermit"), UploadPermit)
                    With UploadPermit



                        UploadPermit.referencono.Text = ""
                        UploadPermit.referencono.Text = rdr_ms("RefCode").ToString
                        UploadPermit.TxtApplicationNo.Text = rdr_ms("applicationID").ToString
                        UploadPermit.TxtAccountNo.Text = rdr_ms("accountno").ToString
                        UploadPermit.TxtBusinessName.Text = rdr_ms("businessname").ToString
                        UploadPermit.useraccountid.Text = rdr_ms("user_id").ToString


                        If (rdr_ms("IsPrinted").ToString = "P") Then

                        Else
                            UploadPermit.SaveNow.Enabled = False

                            UploadPermit.file1.Text = rdr_ms("CTC").ToString



                        End If


                    End With
                End If

                Con_ms.Close()





            Else


                Dim NewMDIChild As New MayorsPermitControl()
                NewMDIChild.MdiParent = MainMenu
                NewMDIChild.Show()
                'applicationID_search = DataGrid.Item(1, DataGrid.CurrentRow.Index).Value.ToString

                Dim MayorsPermitControl As MayorsPermitControl = CType(Application.OpenForms("MayorsPermitControl"), MayorsPermitControl)
                With MayorsPermitControl


                    .temp_applicationid = DataGrid.Item(7, DataGrid.CurrentRow.Index).Value

                    If DataGrid.Item(1, DataGrid.CurrentRow.Index).Value.ToString = "" Then
                    Else
                        .applicationID_search = DataGrid.Item(1, DataGrid.CurrentRow.Index).Value.ToString = ""
                    End If
                    Try






                        'CHECK IF THIS BUSINESSID APPLY FOR PERMIT

                        conn = "SELECT * from BPLS.PermitApplication WHERE BPLS.PermitApplication.BusinessID = '" & DataGrid.Item(2, DataGrid.CurrentRow.Index).Value & "'  AND BPLS.PermitApplication.Year ='" & Date.Now.Year & "'"
                        Con4 = New SqlConnection(cs1)
                        Con4.Open()
                        cmd4 = New SqlCommand(conn, Con4)
                        rdr4 = cmd4.ExecuteReader(CommandBehavior.CloseConnection)
                        If rdr4.Read = True Then

                            If DataGrid.Item(1, DataGrid.CurrentRow.Index).Value.ToString = "" Then





                                'email address from BPLS if walkin
                                conn = "SELECT BPLS.aOwner.EMail as EMail FROM BPLS.BusinessRecord_HDR INNER JOIN BPLS.aOwner ON BPLS.BusinessRecord_HDR.OwnerId = BPLS.aOwner.OwnerId WHERE BPLS.BusinessRecord_HDR.AccountNo =  '" & DataGrid.Item(3, DataGrid.CurrentRow.Index).Value & "' "
                                Con1 = New SqlConnection(cs1)
                                Con1.Open()
                                cmd1 = New SqlCommand(conn, Con1)
                                rdr1 = cmd1.ExecuteReader(CommandBehavior.CloseConnection)
                                If rdr1.Read = True Then

                                    .txt_email.Text = rdr1("EMail").ToString
                                Else
                                    .txt_email.Text = ""
                                End If
                                Con1.Close()





                                'conn = "SELECT business_record_hdr.email_add FROM business_record_hdr WHERE business_record_hdr.accountno ='" & DataGrid.Item(3, DataGrid.CurrentRow.Index).Value & "'"
                                'Con = New SqlConnection(cs)
                                'Con.Open()
                                'cmd = New SqlCommand(conn, Con)
                                'rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                                'If rdr.Read = True Then

                                '    .txt_email.Text = rdr("email_add").ToString

                                'End If
                                'Con.Close()


                            Else

                                conn_ms = "SELECT ONLINE.business_application_tbl.applicationID, ONLINE.business_record_hdr.email_add, ONLINE.business_record_hdr.b_contactno,  ONLINE.business_record_hdr.folder_directory FROM ONLINE.business_application_tbl INNER JOIN ONLINE.business_record_hdr ON ONLINE.business_application_tbl.recordID = ONLINE.business_record_hdr.recordID WHERE ONLINE.business_application_tbl.applicationID ='" & DataGrid.Item(1, DataGrid.CurrentRow.Index).Value & "'"
                                Con_ms = New SqlConnection(mcs)
                                Con_ms.Open()
                                cmd_ms = New SqlCommand(conn_ms, Con_ms)
                                rdr_ms = cmd_ms.ExecuteReader(CommandBehavior.CloseConnection)
                                If rdr_ms.Read = True Then

                                    .txt_email.Text = rdr_ms("email_add").ToString
                                    .mPhone = rdr_ms("b_contactno").ToString

                                    folder_directory = rdr_ms("folder_directory").ToString
                                    .applicationID_search = rdr_ms("applicationID")
                                End If
                                Con_ms.Close()
                            End If

                            .permit_stat = "Online"
                            .txt_applicationnumber.Text = rdr4("ApplicationNumber").ToString
                            .txt_applicationdate.Text = rdr4("ApplicationDate").ToString





                            conn = "SELECT * from BPLS.Permit WHERE BPLS.Permit.BusinessID = '" & DataGrid.Item(2, DataGrid.CurrentRow.Index).Value & "'  AND BPLS.Permit.Year ='" & Date.Now.Year & "'"
                            Con1 = New SqlConnection(cs1)
                            Con1.Open()
                            cmd1 = New SqlCommand(conn, Con1)
                            rdr1 = cmd1.ExecuteReader(CommandBehavior.CloseConnection)
                            If rdr1.Read = True Then


                                .txt_permitNumber.Text = rdr1("PermitNumber")
                                .mpermitno = rdr1("PermitNumber")

                            End If
                            Con1.Close()


                            conn = "SELECT " _
                            & "BPLS.BusinessRecord_HDR.BusinessID, " _
                                  & "BPLS.BusinessRecord_HDR.BusinessName, " _
                                  & "BPLS.BusinessRecord_HDR.AccountNo, " _
                                  & "BPLS.BusinessRecord_HDR.BarangayID, " _
                                  & "BPLS.BusinessRecord_HDR.Phone, " _
                                  & "BPLS.BusinessRecord_HDR.BusinessAddress, " _
                                    & "BPLS.BusinessRecord_HDR.BIN, " _
                                  & "BPLS.aBusinessLine.BusinessLineDescription, " _
                                  & "BPLS.BusinessDetail.Year, " _
                                  & "BPLS.BusinessDetail.MainLine, " _
                                  & "BPLS.BusinessRecord_HDR.Employees, " _
                                  & "BPLS.aOwner.OwnerName, " _
                                    & "BPLS.aOwner.OwnerAddress, " _
                                  & "BPLS.aBusinessNature.BusinessNatureDescription, " _
                                  & "BPLS.ABarangay.BarangayName " _
                                  & "FROM " _
                                  & "BPLS.BusinessRecord_HDR " _
                          & "INNER JOIN BPLS.BusinessDetail ON BPLS.BusinessRecord_HDR.BusinessID = BPLS.BusinessDetail.BusinessID " _
                          & "INNER JOIN BPLS.aBusinessLine ON BPLS.BusinessDetail.BusinessLineID = BPLS.aBusinessLine.BusinessLineID " _
                          & "INNER JOIN BPLS.aOwner ON BPLS.aOwner.OwnerID = BPLS.BusinessRecord_HDR.OwnerID " _
                          & "INNER JOIN BPLS.aBusinessNature ON BPLS.aBusinessLine.BusinessNatureID = BPLS.aBusinessNature.BusinessNatureID " _
                          & "INNER JOIN BPLS.ABarangay ON BPLS.BusinessRecord_HDR.BarangayID = BPLS.ABarangay.BarangayID " _
                            & "WHERE " _
                          & "BPLS.BusinessDetail.Year = '" & Date.Now.Year & "' " _
                          & "AND BPLS.BusinessDetail.MainLine = '1' " _
                          & "AND BPLS.BusinessRecord_HDR.AccountNo = '" & DataGrid.Item(3, DataGrid.CurrentRow.Index).Value & "' "
                            Con1 = New SqlConnection(cs1)
                            Con1.Open()
                            cmd1 = New SqlCommand(conn, Con1)
                            rdr1 = cmd1.ExecuteReader(CommandBehavior.CloseConnection)
                            If rdr1.Read = True Then
                                conn3 = "SELECT sum(BPLS.BusinessLedger.AmountPaid) as AmountPaid1 FROM BPLS.BusinessLedger WHERE BPLS.BusinessLedger.BusinessID = '" & rdr1("BusinessID") & "' and BPLS.BusinessLedger.[Year] ='" & Date.Now.Year & "'"
                                Con3 = New SqlConnection(cs3)
                                Con3.Open()
                                cmd3 = New SqlCommand(conn3, Con3)
                                rdr3 = cmd3.ExecuteReader(CommandBehavior.CloseConnection)
                                If rdr3.Read = True Then

                                    .txt_AccountNo.Text = rdr1("AccountNo")
                                    .TxtRegisteredOwner.Text = rdr1("OwnerName")
                                    .txt_tradename.Text = rdr1("BusinessName")
                                    .mowneraddress = rdr1("OwnerAddress")
                                    .mBIN = rdr1("BIN")
                                    .txt_AmountPaid.Text = (Format(rdr3("AmountPaid1"), "0.00"))
                                    .txt_numberofEmployees.Text = rdr1("Employees")
                                    .mbusinessID = rdr1("BusinessID")
                                    .mBusinessname = rdr1("BusinessName")
                                    .mAccountNo = rdr1("AccountNo")
                                    '.mPhone = rdr1("Phone")
                                    .mBusinessAddress = rdr1("BusinessAddress")
                                    .mBusinessLineDescription = rdr1("BusinessLineDescription")
                                    .myear = rdr1("Year")
                                    .mEmployees = rdr1("Employees")
                                    .mOwnerName = rdr1("OwnerName")
                                    .mBusinessNatureDescription = rdr1("BusinessNatureDescription")
                                    .mBarangayName = rdr1("BarangayName")
                                    .mAmount = (Format(rdr3("AmountPaid1"), "0.00"))


                                End If
                                Con3.Close()
                                conn3 = "SELECT BusinessLedger.ORNumber, BusinessLedger.ORDate FROM BPLS.BusinessLedger WHERE BPLS.BusinessLedger.BusinessID = '" & rdr1("BusinessID") & "' and BPLS.BusinessLedger.[Year] ='" & Date.Now.Year & "'   order by BPLS.BusinessLedger.ORDate DESC"
                                Con3 = New SqlConnection(cs3)
                                Con3.Open()
                                cmd3 = New SqlCommand(conn3, Con3)
                                rdr3 = cmd3.ExecuteReader(CommandBehavior.CloseConnection)
                                If rdr3.Read = True Then

                                    .mORNumber = rdr3("ORNumber")
                                    .mDatePaid = rdr3("ORDate")

                                    .txt_datepayment.Text = rdr3("ORDate")
                                    .txt_ORNumber.Text = rdr3("ORNumber")

                                End If
                                Con3.Close()





                            End If
                            Con1.Close()
                        Else

                            MsgBox("This business is not yet applied for Business Permit!", vbOKOnly & vbCritical, "BPLO")

                            NewMDIChild.Close()

                        End If
                        Con4.Close()

                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try



                End With
            End If
        ElseIf e.ColumnIndex = 6 Then



            Dim NewMDIChild As New BarangayClearanceControl()
            NewMDIChild.MdiParent = MainMenu
            NewMDIChild.Show()

            Dim BarangayClearanceControl As BarangayClearanceControl = CType(Application.OpenForms("BarangayClearanceControl"), BarangayClearanceControl)
            With BarangayClearanceControl
                .temp_applicationid = DataGrid.Item(7, DataGrid.CurrentRow.Index).Value

                If DataGrid.Item(1, DataGrid.CurrentRow.Index).Value.ToString = "" Then
                Else
                    .applicationID_search = DataGrid.Item(1, DataGrid.CurrentRow.Index).Value.ToString = ""
                End If
                Try


                    If DataGrid.Item(1, DataGrid.CurrentRow.Index).Value.ToString = "" Then
                        'email address from BPLS if walkin
                        conn = "SELECT BPLS.aOwner.EMail as EMail FROM BPLS.BusinessRecord_HDR INNER JOIN BPLS.aOwner ON BPLS.BusinessRecord_HDR.OwnerId = BPLS.aOwner.OwnerId WHERE BPLS.BusinessRecord_HDR.AccountNo =  '" & DataGrid.Item(3, DataGrid.CurrentRow.Index).Value & "' "
                        Con1 = New SqlConnection(cs1)
                        Con1.Open()
                        cmd1 = New SqlCommand(conn, Con1)
                        rdr1 = cmd1.ExecuteReader(CommandBehavior.CloseConnection)
                        If rdr1.Read = True Then

                            .txt_email.Text = rdr1("EMail").ToString
                        Else
                            .txt_email.Text = ""
                        End If
                        Con1.Close()


                        'conn = "SELECT business_record_hdr.email_add FROM business_record_hdr WHERE business_record_hdr.accountno ='" & DataGrid.Item(3, DataGrid.CurrentRow.Index).Value & "'"
                        'Con = New SqlConnection(cs)
                        'Con.Open()
                        'cmd = New SqlCommand(conn, Con)
                        'rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                        'If rdr.Read = True Then

                        '    .txt_email.Text = rdr("email_add").ToString

                        'End If
                        'Con.Close()


                    Else

                        conn_ms = "SELECT business_application_tbl.applicationID, business_record_hdr.b_contactno, business_record_hdr.email_add, business_record_hdr.folder_directory FROM business_application_tbl INNER JOIN business_record_hdr ON business_application_tbl.recordID = business_record_hdr.recordID WHERE business_application_tbl.applicationID ='" & DataGrid.Item(1, DataGrid.CurrentRow.Index).Value & "'"
                        Con_ms = New SqlConnection(mcs)
                        Con_ms.Open()
                        cmd_ms = New SqlCommand(conn_ms, Con_ms)
                        rdr_ms = cmd_ms.ExecuteReader(CommandBehavior.CloseConnection)
                        If rdr_ms.Read = True Then

                            .txt_email.Text = rdr_ms("email_add").ToString
                            folder_directory = rdr_ms("folder_directory").ToString
                            .applicationID_search = rdr_ms("applicationID")
                            .mPhone = rdr_ms("b_contactno").ToString



                        End If
                        Con_ms.Close()
                    End If

                    .permit_stat = "Online"
                    '.txt_applicationnumber.Text = rdr4("ApplicationNumber").ToString
                    '.txt_applicationdate.Text = rdr4("ApplicationDate").ToString

                    Con2 = New SqlConnection(cs)
                    Con2.Open()
                    conn = "SELECT * FROM business_brgyclearance_status where BusinessID ='" & DataGrid.Item(2, DataGrid.CurrentRow.Index).Value & "' and Year='" & Date.Now.Year & "'"
                    cmd2 = New SqlCommand(conn, Con2)
                    rdr2 = cmd2.ExecuteReader(CommandBehavior.CloseConnection)
                    If rdr2.Read = True Then
                        .BtnPreview1.Visible = True
                        .BtnPreview.Visible = False
                        .txt_permitNumber.Text = rdr2("PermitNo")
                        .temp_applicationid = rdr2("permitappid")

                    Else

                        .BtnPreview1.Visible = False
                        .BtnPreview.Visible = True
                    End If
                    Con2.Close()



                    conn = "SELECT " _
                    & "BPLS.BusinessRecord_HDR.BusinessID, " _
                          & "BPLS.BusinessRecord_HDR.BusinessName, " _
                          & "BPLS.BusinessRecord_HDR.AccountNo, " _
                          & "BPLS.BusinessRecord_HDR.BarangayID, " _
                          & "BPLS.BusinessRecord_HDR.Phone, " _
                          & "BPLS.BusinessRecord_HDR.BusinessAddress, " _
                            & "BPLS.BusinessRecord_HDR.BIN, " _
                          & "BPLS.aBusinessLine.BusinessLineDescription, " _
                          & "BPLS.BusinessDetail.Year, " _
                          & "BPLS.BusinessDetail.MainLine, " _
                          & "BPLS.BusinessRecord_HDR.Employees, " _
                          & "BPLS.aOwner.OwnerName, " _
                            & "BPLS.aOwner.OwnerAddress, " _
                            & "BPLS.aOwner.EMail, " _
                          & "BPLS.aBusinessNature.BusinessNatureDescription, " _
                            & "BPLS.ABarangay.BarangayID, " _
                          & "BPLS.ABarangay.BarangayName " _
                          & "FROM " _
                          & "BPLS.BusinessRecord_HDR " _
                  & "INNER JOIN BPLS.BusinessDetail ON BPLS.BusinessRecord_HDR.BusinessID = BPLS.BusinessDetail.BusinessID " _
                  & "INNER JOIN BPLS.aBusinessLine ON BPLS.BusinessDetail.BusinessLineID = BPLS.aBusinessLine.BusinessLineID " _
                  & "INNER JOIN BPLS.aOwner ON BPLS.aOwner.OwnerID = BPLS.BusinessRecord_HDR.OwnerID " _
                  & "INNER JOIN BPLS.aBusinessNature ON BPLS.aBusinessLine.BusinessNatureID = BPLS.aBusinessNature.BusinessNatureID " _
                  & "INNER JOIN BPLS.ABarangay ON BPLS.BusinessRecord_HDR.BarangayID = BPLS.ABarangay.BarangayID " _
                    & "WHERE " _
                  & "BPLS.BusinessDetail.Year = '" & Date.Now.Year & "' " _
                  & "AND BPLS.BusinessDetail.MainLine = '1' " _
                  & "AND BPLS.BusinessRecord_HDR.AccountNo = '" & DataGrid.Item(3, DataGrid.CurrentRow.Index).Value.ToString & "' "
                    Con1 = New SqlConnection(cs1)
                    Con1.Open()
                    cmd1 = New SqlCommand(conn, Con1)
                    rdr1 = cmd1.ExecuteReader(CommandBehavior.CloseConnection)
                    If rdr1.Read = True Then
                        conn3 = "SELECT sum(BPLS.BusinessLedger.AmountPaid) as AmountPaid1 FROM BPLS.BusinessLedger WHERE BPLS.BusinessLedger.BusinessID = '" & rdr1("BusinessID") & "' and BPLS.BusinessLedger.[Year] ='" & Date.Now.Year & "' and (BPLS.BusinessLedger.Cancelled is null or BPLS.BusinessLedger.Cancelled =0)"
                        Con3 = New SqlConnection(cs3)
                        Con3.Open()
                        cmd3 = New SqlCommand(conn3, Con3)
                        rdr3 = cmd3.ExecuteReader(CommandBehavior.CloseConnection)
                        If rdr3.Read = True Then

                            .txt_AccountNo.Text = rdr1("AccountNo")
                            .TxtRegisteredOwner.Text = rdr1("OwnerName")
                            .txt_tradename.Text = rdr1("BusinessName")
                            .mowneraddress = rdr1("OwnerAddress")
                            .mBIN = rdr1("BIN")
                            .txt_AmountPaid.Text = (Format(rdr3("AmountPaid1").ToString, "0.00"))
                            .mbusinessID = rdr1("BusinessID")
                            .mBusinessname = rdr1("BusinessName")
                            .mAccountNo = rdr1("AccountNo")
                            '.mPhone = rdr1("Phone")
                            .mBusinessAddress = rdr1("BusinessAddress")
                            .txtBusinessAddress.Text = rdr1("BusinessAddress")
                            .mBusinessLineDescription = rdr1("BusinessLineDescription")
                            .myear = rdr1("Year")
                            .mEmployees = rdr1("Employees")
                            .mOwnerName = rdr1("OwnerName")
                            .mBusinessNatureDescription = rdr1("BusinessNatureDescription")
                            .mBarangayName = rdr1("BarangayName")
                            .mAmount = (Format(rdr3("AmountPaid1"), "0.00"))
                            .txt_email.Text = rdr1("EMail").ToString
                            .mBarangayID = rdr1("BarangayID")

                            Try


                                conn = "SELECT * from business_barangay WHERE BarangayId='" & rdr1("BarangayID") & "'"
                                Con = New SqlConnection(cs)
                                Con.Open()
                                cmd = New SqlCommand(conn, Con)
                                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                                Do While rdr.Read = True
                                    .cmb_signatories.Text = rdr("PunongBarangay").ToString
                                    .cmb_signatories.Items.Add(rdr("PunongBarangay")).ToString()


                                    If rdr("Signatories").ToString = "" Then

                                    Else

                                        Dim bytes = CType(rdr("Signatories"), Byte())
                                        Using ms As New MemoryStream(bytes)
                                            .PictureBox1.Image = Image.FromStream(ms)
                                        End Using

                                    End If


                                Loop
                                Con.Close()


                            Catch ex As Exception
                                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End Try



                        End If
                        Con3.Close()
                        conn3 = "SELECT BusinessLedger.ORNumber, BusinessLedger.ORDate FROM BPLS.BusinessLedger WHERE BPLS.BusinessLedger.BusinessID = '" & rdr1("BusinessID") & "' and BPLS.BusinessLedger.[Year] ='" & Date.Now.Year & "' and (BPLS.BusinessLedger.[Cancelled] = 0 OR BPLS.BusinessLedger.[Cancelled] IS NULL)    order by BPLS.BusinessLedger.ORDate DESC"
                        Con3 = New SqlConnection(cs3)
                        Con3.Open()
                        cmd3 = New SqlCommand(conn3, Con3)
                        rdr3 = cmd3.ExecuteReader(CommandBehavior.CloseConnection)
                        If rdr3.Read = True Then

                            .mORNumber = rdr3("ORNumber")
                            .mDatePaid = rdr3("ORDate")

                            .txt_datepayment.Text = rdr3("ORDate")
                            .txt_ORNumber.Text = rdr3("ORNumber")
                        Else

                            MsgBox("This business is not yet paid!", vbOKOnly & vbCritical, "BPLO")
                            Me.Close()
                        End If
                        Con3.Close()

                    End If
                    Con1.Close()
                    Con4.Close()
                    Me.Close()


                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try



            End With


        End If





    End Sub

    Private Sub BtnSearchRecord_Click(sender As Object, e As EventArgs) Handles BtnSearchRecord.Click
        SearchMayorsPermit.ShowDialog()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

        If cmb_appointmentstatus.Text = "PENDING" Then
            DataGrid.Rows.Clear()
            lblCount.Visible = False
           
            Try
                conn_ms = "SELECT " & _
                "ONLINE.business_record_hdr.businessid, " & _
                "ONLINE.business_record_hdr.accountno, " & _
                "ONLINE.business_applicationstatus_dtl.applicationID, " & _
                "ONLINE.business_applicationstatus_dtl.IsPrinted, " & _
                "ONLINE.business_applicationstatus_dtl.paid_dttime, " & _
                "ONLINE.business_applicationstatus_dtl.IsPaid FROM " & _
                "ONLINE.business_applicationstatus_dtl 	INNER JOIN ONLINE.business_application_tbl ON business_applicationstatus_dtl.ApplicationID = business_application_tbl.applicationID INNER Join ONLINE.business_record_hdr ON business_application_tbl.recordID = business_record_hdr.recordID  " & _
                "WHERE business_applicationstatus_dtl.payment_status ='D' AND business_applicationstatus_dtl.IsPrinted IS NULL and business_applicationstatus_dtl.paid_dttime ='" & Format((dt_Appoinment.Value), "yyyy-MM-dd") & "' ORDER BY business_applicationstatus_dtl.paid_dttime ASC"
                Con_ms = New SqlConnection(mcs)
                Con_ms.Open()
                cmd_ms = New SqlCommand(conn_ms, Con_ms)
                rdr_ms = cmd_ms.ExecuteReader(CommandBehavior.CloseConnection)
                Do While rdr_ms.Read = True

                    DataGrid.Rows.Add(rdr_ms("paid_dttime"), rdr_ms("businessid"), rdr_ms("applicationID"), rdr_ms("accountno"), rdr_ms("IsPrinted"), "GENERATE", "GENERATE")

                Loop

                Con_ms.Close()

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Con_ms.Close()
            End Try

        ElseIf cmb_appointmentstatus.Text = "PRINTED" Then
            DataGrid.Rows.Clear()
            lblCount.Visible = False
            Try
                conn = "SELECT * FROM business_permit_status WHERE Status ='D' and DatePrinted  = '" & Format((dt_Appoinment.Value), "yyyy-MM-dd") & "' ORDER BY DatePending ASC"

                Con = New SqlConnection(cs)
                Con.Open()
                cmd = New SqlCommand(conn, Con)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                Do While rdr.Read = True

                    DataGrid.Rows.Add(rdr("DatePending"), rdr("ApplicationID"), rdr("BusinessID"), rdr("AccountNo"), rdr("Status"), "VIEW", "VIEW", rdr("permitappid"))

                Loop

                Con.Close()

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        Label10.Visible = False

        DataGrid.Rows.Clear()
        lblCount.Visible = False
        Try
            conn = "SELECT * FROM business_permit_status WHERE status ='D' and Year(DatePrinted) = '" & Date.Now.Year & "' and TypeApplication='ONLINE' ORDER BY DatePrinted ASC"

            Con = New SqlConnection(cs)
            Con.Open()
            cmd = New SqlCommand(conn, Con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Do While rdr.Read = True

                DataGrid.Rows.Add(rdr("DatePrinted"), rdr("ApplicationID"), rdr("BusinessID"), rdr("AccountNo"), rdr("Status"), "VIEW", "VIEW", rdr("permitappid"))

            Loop

            Con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub lbl_countpending_Click(sender As Object, e As EventArgs) Handles lbl_countpending.Click

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Label10.Visible = False

        SearchWalkInBussinessPermit.ShowDialog()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub PictureBox9_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        SearchWalkIn_BrgyClearance.ShowDialog()
    End Sub

    Private Sub cmb_appointmentstatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_appointmentstatus.SelectedIndexChanged

    End Sub

    Private Sub PanelAppoinment_Paint(sender As Object, e As PaintEventArgs) Handles PanelAppoinment.Paint

    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Label10.Visible = False

        DataGrid.Rows.Clear()
        lblCount.Visible = False
        Try
            conn = "SELECT * FROM business_permit_status WHERE status ='D' and Year(DatePrinted) = '" & Date.Now.Year & "' and (TypeApplication='WALKIN' OR TypeApplication is null) ORDER BY DatePrinted ASC"

            Con = New SqlConnection(cs)
            Con.Open()
            cmd = New SqlCommand(conn, Con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Do While rdr.Read = True

                DataGrid.Rows.Add(rdr("DatePrinted"), rdr("ApplicationID"), rdr("BusinessID"), rdr("AccountNo"), rdr("Status"), "VIEW", "VIEW", rdr("permitappid"))

            Loop

            Con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txt_name_TextChanged(sender As Object, e As EventArgs) Handles txt_name.TextChanged
        Dim searchText As String = txt_name.Text.ToLower() ' Convert to lowercase for case-insensitive search

        ' Iterate through each row in the DataGridView
        For Each row As DataGridViewRow In DataGrid.Rows
            ' Check if the cell in column 3 (index 3) contains the search text
            If row.Cells(3).Value IsNot Nothing AndAlso row.Cells(3).Value.ToString().ToLower().Contains(searchText) Then
                ' If a match is found, make the row visible
                row.Visible = True
            Else
                ' If no match is found, hide the row
                row.Visible = False
            End If
        Next
    End Sub
End Class