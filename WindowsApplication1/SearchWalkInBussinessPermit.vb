Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Public Class SearchWalkInBussinessPermit
    Dim SearchAccountNo As String
    Dim SearchBusinessID As String

    Private Sub BtnSearchRecord_Click(sender As Object, e As EventArgs) Handles BtnSearchRecord.Click
        SearchAccountNo = TxtLetter.Text & "-" & TxtNumber.Text


        conn = "SELECT * from BPLS.BusinessRecord_HDR WHERE BPLS.BusinessRecord_HDR.AccountNo = '" & SearchAccountNo & "'"
        Con4 = New SqlConnection(cs1)
        Con4.Open()
        cmd4 = New SqlCommand(conn, Con4)
        rdr4 = cmd4.ExecuteReader(CommandBehavior.CloseConnection)
        If rdr4.Read = True Then
            SearchBusinessID = rdr4("BusinessID")
        Else
            MsgBox("No Record found!")
            Con4.Close()
            Exit Sub
        End If

        Con4.Close()



        Dim NewMDIChild As New MayorsPermitControl()
        NewMDIChild.MdiParent = MainMenu
        NewMDIChild.Show()

        Dim MayorsPermitControl As MayorsPermitControl = CType(Application.OpenForms("MayorsPermitControl"), MayorsPermitControl)
        With MayorsPermitControl


            Try

                'CHECK IF THIS BUSINESSID APPLY FOR PERMIT

                conn = "SELECT * from BPLS.PermitApplication WHERE BPLS.PermitApplication.BusinessID = '" & SearchBusinessID & "'  AND BPLS.PermitApplication.Year ='" & Date.Now.Year & "'"
                Con4 = New SqlConnection(cs1)
                Con4.Open()
                cmd4 = New SqlCommand(conn, Con4)
                rdr4 = cmd4.ExecuteReader(CommandBehavior.CloseConnection)
                If rdr4.Read = True Then


                    .txt_applicationnumber.Text = rdr4("ApplicationNumber")
                    .txt_applicationdate.Text = rdr4("ApplicationDate").ToString





                    conn = "SELECT * from BPLS.Permit WHERE BPLS.Permit.BusinessID = '" & SearchBusinessID & "'  AND BPLS.Permit.Year ='" & Date.Now.Year & "'"
                    Con1 = New SqlConnection(cs1)
                    Con1.Open()
                    cmd1 = New SqlCommand(conn, Con1)
                    rdr1 = cmd1.ExecuteReader(CommandBehavior.CloseConnection)
                    If rdr1.Read = True Then


                        .txt_permitNumber.Text = rdr1("PermitNumber")
                        .mpermitno = rdr1("PermitNumber")

                    End If
                    Con1.Close()


                    .permit_stat = "WalkIn"

                    Con2 = New SqlConnection(cs)
                    Con2.Open()
                    conn = "SELECT * FROM ONLINE.business_permit_status WHERE AccountNo='" & SearchAccountNo & "' and Year ='" & Date.Now.Year & "'"
                    cmd2 = New SqlCommand(conn, Con2)
                    rdr2 = cmd2.ExecuteReader(CommandBehavior.CloseConnection)
                    If rdr2.Read = True Then

                        MayorsPermitControl.temp_applicationid = rdr2("permitappid")

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
                  & "AND BPLS.BusinessRecord_HDR.AccountNo = '" & SearchAccountNo & "' "
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
                            .txt_AmountPaid.Text = Format(Math.Round(Convert.ToDecimal(rdr3("AmountPaid1")), 1), "0.00")

                            .txt_numberofEmployees.Text = rdr1("Employees")
                            .mbusinessID = rdr1("BusinessID")
                            .mBusinessname = rdr1("BusinessName")
                            .mAccountNo = rdr1("AccountNo")
                            .mPhone = rdr1("Phone")
                            .mBusinessAddress = rdr1("BusinessAddress")

                            .mBusinessLineDescription = rdr1("BusinessLineDescription")
                            .myear = rdr1("Year")
                            .mEmployees = rdr1("Employees")
                            .mOwnerName = rdr1("OwnerName")
                            .mBusinessNatureDescription = rdr1("BusinessNatureDescription")
                            .mBarangayName = rdr1("BarangayName")
                            .mAmount = (Format(rdr3("AmountPaid1"), "0.00"))
                            .txt_email.Text = rdr1("EMail").ToString

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
                Else

                    MsgBox("This business is not yet applied for Business Permit!", vbOKOnly & vbCritical, "BPLO")
                    Con4.Close()
                    Me.Close()

                End If
                Con4.Close()

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try



        End With

    End Sub

    Private Sub TxtLetter_TextChanged(sender As Object, e As EventArgs) Handles TxtLetter.TextChanged
        If TxtLetter.Text.Length > 0 Then
            TxtNumber.Focus()
        Else

        End If
    End Sub

    Private Sub TxtNumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtNumber.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SearchAccountNo = TxtLetter.Text & "-" & TxtNumber.Text


            conn = "SELECT * from BPLS.BusinessRecord_HDR WHERE BPLS.BusinessRecord_HDR.AccountNo = '" & SearchAccountNo & "'"
            Con4 = New SqlConnection(cs1)
            Con4.Open()
            cmd4 = New SqlCommand(conn, Con4)
            rdr4 = cmd4.ExecuteReader(CommandBehavior.CloseConnection)
            If rdr4.Read = True Then
                SearchBusinessID = rdr4("BusinessID")
            Else
                MsgBox("No Record found!")
                Con4.Close()
                Exit Sub
            End If

            Con4.Close()



            Dim NewMDIChild As New MayorsPermitControl()
            NewMDIChild.MdiParent = MainMenu
            NewMDIChild.Show()

            Dim MayorsPermitControl As MayorsPermitControl = CType(Application.OpenForms("MayorsPermitControl"), MayorsPermitControl)
            With MayorsPermitControl


                Try






                    'CHECK IF THIS BUSINESSID APPLY FOR PERMIT

                    conn = "SELECT * from BPLS.PermitApplication WHERE BPLS.PermitApplication.BusinessID = '" & SearchBusinessID & "'  AND BPLS.PermitApplication.Year ='" & Date.Now.Year & "'"
                    Con4 = New SqlConnection(cs1)
                    Con4.Open()
                    cmd4 = New SqlCommand(conn, Con4)
                    rdr4 = cmd4.ExecuteReader(CommandBehavior.CloseConnection)
                    If rdr4.Read = True Then


                        .txt_applicationnumber.Text = rdr4("ApplicationNumber")
                        .txt_applicationdate.Text = rdr4("ApplicationDate").ToString





                        conn = "SELECT * from BPLS.Permit WHERE BPLS.Permit.BusinessID = '" & SearchBusinessID & "'  AND BPLS.Permit.Year ='" & Date.Now.Year & "'"
                        Con1 = New SqlConnection(cs1)
                        Con1.Open()
                        cmd1 = New SqlCommand(conn, Con1)
                        rdr1 = cmd1.ExecuteReader(CommandBehavior.CloseConnection)
                        If rdr1.Read = True Then


                            .txt_permitNumber.Text = rdr1("PermitNumber")
                            .mpermitno = rdr1("PermitNumber")

                        End If
                        Con1.Close()


                        .permit_stat = "WalkIn"

                        Con2 = New SqlConnection(cs)
                        Con2.Open()
                        conn = "SELECT * FROM business_permit_status WHERE AccountNo='" & SearchAccountNo & "' and Year ='" & Date.Now.Year & "'"
                        cmd2 = New SqlCommand(conn, Con2)
                        rdr2 = cmd2.ExecuteReader(CommandBehavior.CloseConnection)
                        If rdr2.Read = True Then

                            MayorsPermitControl.temp_applicationid = rdr2("permitappid")

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
                      & "AND BPLS.BusinessRecord_HDR.AccountNo = '" & SearchAccountNo & "' "
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
                                .mPhone = rdr1("Phone")
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
                            Else

                                MsgBox("This business is not yet paid!", vbOKOnly & vbCritical, "BPLO")
                                Me.Close()
                            End If
                            Con3.Close()





                        End If
                        Con1.Close()
                        Con4.Close()
                        Me.Close()
                    Else

                        MsgBox("This business is not yet applied for Business Permit!", vbOKOnly & vbCritical, "BPLO")
                        Con4.Close()
                        Me.Close()

                    End If
                    Con4.Close()

                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try



            End With
        Else

        End If
    End Sub

    Private Sub TxtNumber_TextChanged(sender As Object, e As EventArgs) Handles TxtNumber.TextChanged
        If TxtNumber.Text.Length > 4 Then

            BtnSearchRecord.Focus()
        Else

        End If
    End Sub

    Private Sub SearchWalkInBussinessPermit_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class