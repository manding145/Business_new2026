Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Public Class MayorsPermitControl
    Public applicationID_search, mBIN, mowneraddress, mbusinessID, mBusinessname, mAccountNo, mPhone, mBusinessAddress, mBusinessLineDescription, myear, mEmployees, mOwnerName, mBusinessNatureDescription, mBarangayName, mAmount, mORNumber, mDatePaid As String
    Public mpermitno As Integer
    Public permit_stat As String
    Public temp_applicationid As String


    Private Sub Label22_Click(sender As Object, e As EventArgs) Handles Label22.Click

    End Sub

    Private Sub MayorsPermitControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load







       



        DateTimePicker1.Value = Date.Now
        cmb_signatories.Text = "GEMAFIEL R. GASPAY"
        txt_position.Text = "LICENSING OFFICER IV"
        dt_issued.Text = Format(Date.Now, "MM-dd-yyyy")
        'Call LoadMe()
        Try

            conn = "SELECT * from business_signatory"
            Con = New MySqlConnection(cs)
            Con.Open()
            cmd = New MySqlCommand(conn, Con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Do While rdr.Read = True
                cmb_signatories.Items.Add(rdr("SignatoryName")).ToString()
            Loop
            Con.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub txt_AccountNo_TextChanged(sender As Object, e As EventArgs) Handles txt_AccountNo.TextChanged

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
    Private Sub LoadMe()
        Try
            conn = "SELECT " _
            & "BPLS.BusinessRecord_HDR.BusinessID, " _
                  & "BPLS.BusinessRecord_HDR.BusinessName, " _
                  & "BPLS.BusinessRecord_HDR.AccountNo, " _
                  & "BPLS.BusinessRecord_HDR.BarangayID, " _
                  & "BPLS.BusinessRecord_HDR.Phone, " _
                  & "BPLS.BusinessRecord_HDR.BusinessAddress, " _
                  & "BPLS.aBusinessLine.BusinessLineDescription, " _
                  & "BPLS.BusinessDetail.Year, " _
                  & "BPLS.BusinessDetail.MainLine, " _
                  & "BPLS.BusinessRecord_HDR.Employees, " _
                  & "BPLS.aOwner.OwnerName, " _
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
          & "AND BPLS.BusinessRecord_HDR.AccountNo = '" & txt_AccountNo.Text & "' "
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
                    mbusinessID = rdr1("BusinessID")
                    mBusinessname = rdr1("BusinessName")
                    mAccountNo = rdr1("AccountNo")
                    mPhone = rdr1("Phone")
                    mBusinessAddress = rdr1("BusinessAddress")
                    mBusinessLineDescription = rdr1("BusinessLineDescription")
                    myear = rdr1("Year")
                    mEmployees = rdr1("Employees")
                    mOwnerName = rdr1("OwnerName")
                    mBusinessNatureDescription = rdr1("BusinessNatureDescription")
                    mBarangayName = rdr1("BarangayName")
                    mAmount = rdr3("AmountPaid1")

                End If
                Con3.Close()
                conn3 = "SELECT BusinessLedger.ORNumber, BusinessLedger.ORDate FROM BPLS.BusinessLedger WHERE BPLS.BusinessLedger.BusinessID = '" & rdr1("BusinessID") & "' and BPLS.BusinessLedger.[Year] ='" & Date.Now.Year & "' order by BPLS.BusinessLedger.ORDate DESC"
                Con3 = New SqlConnection(cs3)
                Con3.Open()
                cmd3 = New SqlCommand(conn3, Con3)
                rdr3 = cmd3.ExecuteReader(CommandBehavior.CloseConnection)
                If rdr3.Read = True Then
                    
                    mORNumber = rdr3("ORNumber")
                    mDatePaid = rdr3("ORDate")
                End If
                Con3.Close()
            End If
            Con1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnPreview_Click(sender As Object, e As EventArgs) Handles BtnPreview.Click
        'Call LoadMe()
        'Dim NewMDIChild As New Print_mayorsbusinesspermit()
        'NewMDIChild.MdiParent = MainMenu
        'NewMDIChild.Show()
        Print_mayorsbusinesspermit.ShowDialog()

    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub cmb_signatories_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_signatories.SelectedIndexChanged
        Try

            conn = "SELECT * from business_signatory where SignatoryName = '" & cmb_signatories.Text & "'"
            Con = New MySqlConnection(cs)
            Con.Open()
            cmd = New MySqlCommand(conn, Con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If rdr.Read = True Then
                txt_position.Text = rdr("Position")
            End If
            Con.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            If permit_stat = "WalkIn" Then

                Dim mytimestamp = DateTime.Now.ToString("yyyy-MM-dd")
                'SAVE TO BPLS DATABASE FOR BACK UP
                'get this year last permit no
                Dim permit_no As String

                '//check current year
                conn = "Select * from BPLS.Permit where BPLS.Permit.Year = '" & Date.Now.Year & "' order by  BPLS.Permit.Year DESC, BPLS.Permit.PermitNumber DESC"
                Con1 = New SqlConnection(cs1)
                Con1.Open()
                cmd1 = New SqlCommand(conn, Con1)
                rdr1 = cmd1.ExecuteReader(CommandBehavior.CloseConnection)
                If rdr1.Read = True Then


                    conn = "Select * from BPLS.Permit where BPLS.Permit.Year = '" & Date.Now.Year & "' and BusinessID= '" & mbusinessID & "' "
                    Con4 = New SqlConnection(cs1)
                    Con4.Open()
                    cmd4 = New SqlCommand(conn, Con4)
                    rdr4 = cmd4.ExecuteReader(CommandBehavior.CloseConnection)
                    If rdr4.Read = True Then

                        MsgBox("This application has already assigned for business permit number!")
                        Con4.Close()
                        Con1.Close()
                        Exit Sub
                      



                      
                    Else
                        'increment 1
                        ''MsgBox(rdr1("Year") & rdr1("PermitNumber"))
                        'insert to bpls

                        permit_no = rdr1("PermitNumber") + 1



                        'check if existing permit in BPLS
                        conn3 = "Select * from BPLS.Permit where BPLS.Permit.Year = '" & Date.Now.Year & "' and BPLS.Permit.PermitNumber='" & permit_no & "'"
                        Con3 = New SqlConnection(cs1)
                        Con3.Open()
                        cmd3 = New SqlCommand(conn3, Con3)
                        rdr3 = cmd3.ExecuteReader(CommandBehavior.CloseConnection)
                        If rdr3.Read = True Then

                            MsgBox("This application has already taken in BPLS Database!, Contact your system administrator.")

                            Con4.Close()
                            Con1.Close()
                            Con3.Close()
                            Exit Sub
                          
                        End If
                        Con3.Close()


                      
                        'check if existing permit in Business Portal
                        conn2 = "Select * from  business_permit_status where Year= '" & Date.Now.Year & "' and PermitNo='" & permit_no & "'"
                        Con2 = New MySqlConnection(cs)
                        Con2.Open()
                        cmd2 = New MySqlCommand(conn2, Con2)
                        rdr2 = cmd2.ExecuteReader(CommandBehavior.CloseConnection)
                        If rdr2.Read = True Then
                            MsgBox("This application has already taken in Business Portal Database!, Contact your system administrator.")
                            Con4.Close()
                            Con1.Close()
                            Con2.Close()
                            Exit Sub
                        End If
                        Con2.Close()









                        Con3 = New SqlConnection(cs1)
                        Con3.Open()
                        conn = "INSERT INTO BPLS.Permit (Year, PermitNumber, DateIssued, UserID, BusinessID, AmountPaid, Remarks ) " _
                           & "VALUES ('" & Date.Now.Year & "', '" & permit_no & "', '" & mytimestamp & "', '" & userid & "', '" & mbusinessID & "' , '" & txt_AmountPaid.Text & "', '" & txt_remarks.Text & "')"
                        cmd3 = New SqlCommand(conn, Con3)
                        cmd3.ExecuteNonQuery()
                        Con3.Close()


                        'insert to business_permit_status as new

                        Con2 = New MySqlConnection(cs)
                        Con2.Open()


                        conn = "INSERT INTO business_permit_status (AccountNo, BusinessID, DatePending, Status, DatePrinted, PermitNo, UserID, Remarks, Year) " _
                         & "VALUES ('" & txt_AccountNo.Text & "', '" & mbusinessID & "', '" & mytimestamp & "', 'D' , '" & mytimestamp & "', '" & permit_no & "', '" & userid & "', '" & txt_remarks.Text & "', '" & Date.Now.Year & "')"
                        cmd2 = New MySqlCommand(conn, Con2)
                        cmd2.ExecuteNonQuery()
                        Con2.Close()
                        txt_permitNumber.Text = permit_no


                        'MsgBox("Confirmed!", vbOKOnly & vbInformation, "Business Renewal")


                        'get lasst applicationid
                        Con2 = New MySqlConnection(cs)
                        Con2.Open()

                        conn = "SELECT * FROM business_permit_status ORDER BY permitappid DESC LIMIT 1"
                        cmd2 = New MySqlCommand(conn, Con2)
                        rdr2 = cmd2.ExecuteReader(CommandBehavior.CloseConnection)
                        If rdr2.Read = True Then

                            temp_applicationid = rdr2("permitappid")

                        End If
                        Con2.Close()

                        'Con2 = New MySqlConnection(cs)
                        'Con2.Open()
                        'conn = "UPDATE business_applicationstatus_dtl set IsPrinted = '1', Printed_dttime = '" & mytimestamp & "' WHERE applicationID='" & applicationID_search & "'"
                        'cmd2 = New MySqlCommand(conn, Con2)
                        'cmd2.ExecuteNonQuery()
                        'Con2.Close()


                        txt_permitNumber.Text = permit_no
                        MsgBox("Confirmed!", vbOKOnly & vbInformation, "Business Renewal")



                        Dim mydate As String
                        mydate = "12-31-" & Now.Year
                        Con2.Open()
                        Dim qrcodestr As String
                        qrcodestr = mydate & " " & mAccountNo & " TC "
                        conn = "INSERT INTO cho_qrcode_dummy (descriptiontext, forwardedID, Type) " _
                          & "VALUES ('" & qrcodestr & "', '" & temp_applicationid & "', 'MP_WALKIN')"
                        cmd2 = New MySqlCommand(conn, Con2)
                        cmd2.ExecuteNonQuery()
                        'MsgBox("Health Certificate Record Successfully Saved", vbOKOnly & vbInformation, "Tacloban Health Office Management System")
                        Con2.Close()
                    End If

                Else
                    'if not exist then reset to 1

                    permit_no = "1"

                    Con3 = New SqlConnection(cs1)
                    Con3.Open()
                    conn = "INSERT INTO BPLS.Permit (Year, PermitNumber, DateIssued, UserID, BusinessID, AmountPaid, Remarks ) " _
                       & "VALUES ('" & Date.Now.Year & "', '" & permit_no & "', '" & mytimestamp & "', '" & userid & "', '" & mbusinessID & "' , '" & txt_AmountPaid.Text & "', '" & txt_remarks.Text & "')"
                    cmd3 = New SqlCommand(conn, Con3)
                    cmd3.ExecuteNonQuery()
                    Con3.Close()


                    MsgBox("Confirmed!", vbOKOnly & vbInformation, "Business Renewal")
                    txt_permitNumber.Text = permit_no


                    'insert to business_permit_status as new

                    Con2 = New MySqlConnection(cs)
                    Con2.Open()


                    conn = "INSERT INTO business_permit_status (AccountNo, BusinessID, DatePending, Status, DatePrinted, PermitNo, UserID, Remarks, Year) " _
                     & "VALUES ('" & txt_AccountNo.Text & "', '" & mbusinessID & "', '" & mytimestamp & "', 'D' , '" & mytimestamp & "', '" & permit_no & "', '" & userid & "', '" & txt_remarks.Text & "', '" & Date.Now.Year & "')"
                    cmd2 = New MySqlCommand(conn, Con2)
                    cmd2.ExecuteNonQuery()
                    Con2.Close()
                    txt_permitNumber.Text = permit_no
                    'MsgBox("Confirmed!", vbOKOnly & vbInformation, "Business Renewal")


                    'get lasst applicationid
                    Con2 = New MySqlConnection(cs)
                    Con2.Open()





                    conn = "SELECT * FROM business_permit_status ORDER BY permitappid DESC LIMIT 1"
                    cmd2 = New MySqlCommand(conn, Con2)
                    rdr2 = cmd2.ExecuteReader(CommandBehavior.CloseConnection)
                    If rdr2.Read = True Then

                        temp_applicationid = rdr2("permitappid")

                    End If
                    Con2.Close()


                    Dim mydate As String
                    mydate = "12-31-" & Now.Year
                    Con2.Open()
                    Dim qrcodestr As String
                    qrcodestr = mydate & " " & mAccountNo & " TC "
                    conn = "INSERT INTO cho_qrcode_dummy (descriptiontext, forwardedID, Type) " _
                      & "VALUES ('" & qrcodestr & "', '" & temp_applicationid & "', 'MP_WALKIN')"
                    cmd2 = New MySqlCommand(conn, Con2)
                    cmd2.ExecuteNonQuery()
                    'MsgBox("Health Certificate Record Successfully Saved", vbOKOnly & vbInformation, "Tacloban Health Office Management System")
                    Con2.Close()


                End If





















                ElseIf permit_stat = "Online" Then




                    Dim mytimestamp = DateTime.Now.ToString("yyyy-MM-dd")
                    'SAVE TO BPLS DATABASE FOR BACK UP
                    'get this year last permit no
                    Dim permit_no As String

                conn = "Select * from BPLS.Permit where BPLS.Permit.Year = '" & Date.Now.Year & "' order by BPLS.Permit.PermitNumber DESC"
                    Con1 = New SqlConnection(cs1)
                    Con1.Open()
                    cmd1 = New SqlCommand(conn, Con1)
                    rdr1 = cmd1.ExecuteReader(CommandBehavior.CloseConnection)
                    If rdr1.Read = True Then
                    '


                    conn = "Select * from BPLS.Permit where BPLS.Permit.Year = '" & Date.Now.Year & "' and BusinessID= '" & mbusinessID & "' "
                    Con4 = New SqlConnection(cs1)
                    Con4.Open()
                    cmd4 = New SqlCommand(conn, Con4)
                    rdr4 = cmd4.ExecuteReader(CommandBehavior.CloseConnection)
                    If rdr4.Read = True Then

                        MsgBox("This application has already assigned for business permit number!")





                    Else


                        'increment 1
                        'MsgBox(rdr1("Year") & rdr1("PermitNumber"))

                        permit_no = rdr1("PermitNumber") + 1

                        Con3 = New SqlConnection(cs1)
                        Con3.Open()
                        conn = "INSERT INTO BPLS.Permit (Year, PermitNumber, DateIssued, UserID, BusinessID, AmountPaid, Remarks ) " _
                           & "VALUES ('" & Date.Now.Year & "', '" & permit_no & "', '" & mytimestamp & "', '" & userid & "', '" & mbusinessID & "' , '" & txt_AmountPaid.Text & "', '" & txt_remarks.Text & "')"
                        cmd3 = New SqlCommand(conn, Con3)
                        cmd3.ExecuteNonQuery()
                        Con3.Close()









                        Con2 = New MySqlConnection(cs)
                        Con2.Open()


                        conn = "INSERT INTO business_permit_status (TypeApplication, ApplicationID, AccountNo, BusinessID, DatePending, Status, DatePrinted, PermitNo, UserID, Remarks, Year) " _
                         & "VALUES ('ONLINE', '" & applicationID_search & "', '" & txt_AccountNo.Text & "', '" & mbusinessID & "', '" & mytimestamp & "', 'D' , '" & mytimestamp & "', '" & permit_no & "', '" & userid & "', '" & txt_remarks.Text & "', '" & Date.Now.Year & "')"
                        cmd2 = New MySqlCommand(conn, Con2)
                        cmd2.ExecuteNonQuery()
                        Con2.Close()
                        txt_permitNumber.Text = permit_no
                        'MsgBox("Confirmed!", vbOKOnly & vbInformation, "Business Renewal")



                        Con2 = New MySqlConnection(cs)
                        Con2.Open()
                        conn = "SELECT * FROM business_permit_status ORDER BY permitappid DESC LIMIT 1"
                        cmd2 = New MySqlCommand(conn, Con2)
                        rdr2 = cmd2.ExecuteReader(CommandBehavior.CloseConnection)
                        If rdr2.Read = True Then

                            temp_applicationid = rdr2("permitappid")

                        End If
                        Con2.Close()

                        'get lasst applicationid
                        'Con2 = New MySqlConnection(cs)
                        'Con2.Open()





                        'Con2 = New MySqlConnection(cs)
                        'Con2.Open()
                        'conn = "UPDATE business_permit_status set Status = 'D', DatePrinted = '" & mytimestamp & "', PermitNo = '" & permit_no & "', UserID ='" & userid & "', Remarks = '" & txt_remarks.Text & "', Year ='" & Date.Now.Year & "' WHERE applicationID='" & applicationID_search & "'"
                        'cmd2 = New MySqlCommand(conn, Con2)
                        'cmd2.ExecuteNonQuery()
                        'Con2.Close()
                        'txt_permitNumber.Text = permit_no
                        'MsgBox("Confirmed!", vbOKOnly & vbInformation, "Business Renewal")



                        Con_ms = New SqlConnection(mcs)
                        Con_ms.Open()
                        conn_ms = "UPDATE ONLINE.business_applicationstatus_dtl set IsPrinted = '1', Printed_dttime = '" & mytimestamp & "' WHERE applicationID='" & applicationID_search & "'"
                        cmd_ms = New SqlCommand(conn_ms, Con_ms)
                        cmd_ms.ExecuteNonQuery()
                        Con_ms.Close()


                        txt_permitNumber.Text = permit_no

                        MsgBox("Confirmed!", vbOKOnly & vbInformation, "Business Renewal")



                        Dim MAYORSPERMIT As String = txt_AccountNo.Text & "_MP.pdf"

                        Con_ms = New SqlConnection(mcs)
                        Con_ms.Open()
                        conn_ms = "UPDATE ONLINE.business_assessment_dtl set MayorsPermit ='" & MAYORSPERMIT & "' WHERE applicationID='" & applicationID_search & "'"
                        cmd_ms = New SqlCommand(conn_ms, Con_ms)
                        cmd_ms.ExecuteNonQuery()
                        Con_ms.Close()





                        Dim mydate As String
                        mydate = "12-31-" & Now.Year
                        Con2.Open()
                        Dim qrcodestr As String
                        qrcodestr = mydate & " " & mAccountNo & " TC "
                        conn = "INSERT INTO cho_qrcode_dummy (descriptiontext, forwardedID, Type) " _
                          & "VALUES ('" & qrcodestr & "', '" & temp_applicationid & "', 'MP_ONLINE')"
                        cmd2 = New MySqlCommand(conn, Con2)
                        cmd2.ExecuteNonQuery()
                        'MsgBox("Health Certificate Record Successfully Saved", vbOKOnly & vbInformation, "Tacloban Health Office Management System")
                        Con2.Close()
                    End If

                Else
                    'if not exist then reset to 1

                    permit_no = "1"


                    Con3 = New SqlConnection(cs1)
                    Con3.Open()
                    conn = "INSERT INTO BPLS.Permit (Year, PermitNumber, DateIssued, UserID, BusinessID, AmountPaid, Remarks ) " _
                       & "VALUES ('" & Date.Now.Year & "', '" & permit_no & "', '" & mytimestamp & "', '" & userid & "', '" & mbusinessID & "' , '" & txt_AmountPaid.Text & "', '" & txt_remarks.Text & "')"
                    cmd3 = New SqlCommand(conn, Con3)
                    cmd3.ExecuteNonQuery()
                    Con3.Close()
                    MsgBox("Confirmed!", vbOKOnly & vbInformation, "Business Renewal")
                    txt_permitNumber.Text = permit_no


                    Con2 = New MySqlConnection(cs)
                    Con2.Open()


                    conn = "INSERT INTO business_permit_status (TypeApplication, ApplicationID, AccountNo, BusinessID, DatePending, Status, DatePrinted, PermitNo, UserID, Remarks, Year) " _
                     & "VALUES ('ONLINE, ''" & applicationID_search & "', '" & txt_AccountNo.Text & "', '" & mbusinessID & "', '" & mytimestamp & "', 'D' , '" & mytimestamp & "', '" & permit_no & "', '" & userid & "', '" & txt_remarks.Text & "', '" & Date.Now.Year & "')"
                    cmd2 = New MySqlCommand(conn, Con2)
                    cmd2.ExecuteNonQuery()
                    Con2.Close()
                    txt_permitNumber.Text = permit_no
                    'MsgBox("Confirmed!", vbOKOnly & vbInformation, "Business Renewal")



                    Con2 = New MySqlConnection(cs)
                    Con2.Open()
                    conn = "SELECT * FROM business_permit_status ORDER BY permitappid DESC LIMIT 1"
                    cmd2 = New MySqlCommand(conn, Con2)
                    rdr2 = cmd2.ExecuteReader(CommandBehavior.CloseConnection)
                    If rdr2.Read = True Then

                        temp_applicationid = rdr2("permitappid")

                    End If
                    Con2.Close()

                    'get lasst applicationid
                    'Con2 = New MySqlConnection(cs)
                    'Con2.Open()





                    'Con2 = New MySqlConnection(cs)
                    'Con2.Open()
                    'conn = "UPDATE business_permit_status set Status = 'D', DatePrinted = '" & mytimestamp & "', PermitNo = '" & permit_no & "', UserID ='" & userid & "', Remarks = '" & txt_remarks.Text & "', Year ='" & Date.Now.Year & "' WHERE applicationID='" & applicationID_search & "'"
                    'cmd2 = New MySqlCommand(conn, Con2)
                    'cmd2.ExecuteNonQuery()
                    'Con2.Close()
                    'txt_permitNumber.Text = permit_no
                    'MsgBox("Confirmed!", vbOKOnly & vbInformation, "Business Renewal")



                    Con_ms = New SqlConnection(mcs)
                    Con_ms.Open()
                    conn_ms = "UPDATE ONLINE.business_applicationstatus_dtl set IsPrinted = '1', Printed_dttime = '" & mytimestamp & "' WHERE applicationID='" & applicationID_search & "'"
                    cmd_ms = New SqlCommand(conn_ms, Con_ms)
                    cmd_ms.ExecuteNonQuery()
                    Con_ms.Close()


                    txt_permitNumber.Text = permit_no

                    MsgBox("Confirmed!", vbOKOnly & vbInformation, "Business Renewal")


                    Dim MAYORSPERMIT As String = txt_AccountNo.Text & "_MP.pdf"

                    Con_ms = New SqlConnection(mcs)
                    Con_ms.Open()
                    conn_ms = "UPDATE ONLINE.business_assessment_dtl set MayorsPermit ='" & MAYORSPERMIT & "' WHERE applicationID='" & applicationID_search & "'"
                    cmd_ms = New SqlCommand(conn_ms, Con_ms)
                    cmd_ms.ExecuteNonQuery()
                    Con_ms.Close()




                    Dim mydate As String
                    mydate = "12-31-" & Now.Year
                    Con2.Open()
                    Dim qrcodestr As String
                    qrcodestr = mydate & " " & mAccountNo & " TC "
                    conn = "INSERT INTO cho_qrcode_dummy (descriptiontext, forwardedID, Type) " _
                      & "VALUES ('" & qrcodestr & "', '" & temp_applicationid & "', 'MP_ONLINE')"
                    cmd2 = New MySqlCommand(conn, Con2)
                    cmd2.ExecuteNonQuery()
                    'MsgBox("Health Certificate Record Successfully Saved", vbOKOnly & vbInformation, "Tacloban Health Office Management System")
                    Con2.Close()


                End If





                End If



        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try





    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        temp_applicationid = "4917"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim permit_no As Integer
        permit_no = txt_permitNumber.Text

        conn = "Select * from BPLS.Permit where BPLS.Permit.Year = '" & Date.Now.Year & "' and PermitNumber= '" & permit_no & "' "
        Con4 = New SqlConnection(cs1)
        Con4.Open()
        cmd4 = New SqlCommand(conn, Con4)
        rdr4 = cmd4.ExecuteReader(CommandBehavior.CloseConnection)
        If rdr4.Read = True Then

            MsgBox("permit number taken!")

        Else
            Dim mytimestamp = DateTimePicker1.Value.ToString("yyyy-MM-dd")

            Con3 = New SqlConnection(cs1)
            Con3.Open()
            conn = "INSERT INTO BPLS.Permit (Year, PermitNumber, DateIssued, UserID, BusinessID, AmountPaid, Remarks ) " _
               & "VALUES ('" & Date.Now.Year & "', '" & permit_no & "', '" & mytimestamp & "', '" & userid & "', '" & mbusinessID & "' , '" & txt_AmountPaid.Text & "', '" & txt_remarks.Text & "')"
            cmd3 = New SqlCommand(conn, Con3)
            cmd3.ExecuteNonQuery()
            Con3.Close()


            'insert to business_permit_status as new

            Con2 = New MySqlConnection(cs)
            Con2.Open()


            conn = "INSERT INTO business_permit_status (AccountNo, BusinessID, DatePending, Status, DatePrinted, PermitNo, UserID, Remarks, Year) " _
             & "VALUES ('" & txt_AccountNo.Text & "', '" & mbusinessID & "', '" & mytimestamp & "', 'D' , '" & mytimestamp & "', '" & permit_no & "', '" & userid & "', '" & txt_remarks.Text & "', '" & Date.Now.Year & "')"
            cmd2 = New MySqlCommand(conn, Con2)
            cmd2.ExecuteNonQuery()
            Con2.Close()
            txt_permitNumber.Text = permit_no
            'MsgBox("Confirmed!", vbOKOnly & vbInformation, "Business Renewal")


            'get lasst applicationid
            Con2 = New MySqlConnection(cs)
            Con2.Open()


            conn = "SELECT * FROM business_permit_status ORDER BY permitappid DESC LIMIT 1"
            cmd2 = New MySqlCommand(conn, Con2)
            rdr2 = cmd2.ExecuteReader(CommandBehavior.CloseConnection)
            If rdr2.Read = True Then

                temp_applicationid = rdr2("permitappid")

            End If
            Con2.Close()

            'Con2 = New MySqlConnection(cs)
            'Con2.Open()
            'conn = "UPDATE business_applicationstatus_dtl set IsPrinted = '1', Printed_dttime = '" & mytimestamp & "' WHERE applicationID='" & applicationID_search & "'"
            'cmd2 = New MySqlCommand(conn, Con2)
            'cmd2.ExecuteNonQuery()
            'Con2.Close()


            txt_permitNumber.Text = permit_no
            MsgBox("Confirmed!", vbOKOnly & vbInformation, "Business Renewal")



            Dim mydate As String
            mydate = "12-31-" & Now.Year
            Con2.Open()
            Dim qrcodestr As String
            qrcodestr = mydate & " " & mAccountNo & " TC "
            conn = "INSERT INTO cho_qrcode_dummy (descriptiontext, forwardedID, Type) " _
              & "VALUES ('" & qrcodestr & "', '" & temp_applicationid & "', 'MP_WALKIN')"
            cmd2 = New MySqlCommand(conn, Con2)
            cmd2.ExecuteNonQuery()
            'MsgBox("Health Certificate Record Successfully Saved", vbOKOnly & vbInformation, "Tacloban Health Office Management System")
            Con2.Close()
        End If
        Con4.Close()

    End Sub
End Class