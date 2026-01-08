Imports System.Data.SqlClient
Public Class PendingDeny
    Dim lack_itr1, lack_itr2, lack_itr3, lack_itr4, lack_gross, lack_firearms, lack_waterpotability, lack_francisetooperate, lack_bsp, lack_slaughter, lack_cityvet, lack_peso, lack_dole, lack_dot, lack_citytourism, lack_licensetooperate, lack_agriculture, lack_pcab, lack_psa, lack_enro, lack_brgyresolution, lack_spa, lack_contractlease, lack_validid, lack_cda, lack_coop, lack_ctc, lack_bfad, lack_unf, lack_brgyclearance, lack_oldpermit, lack_oldplate, lack_oldfire, lack_itr, lack_market_clearance As Integer
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim userMsg As String
        userMsg = Microsoft.VisualBasic.InputBox("REMARKS", "CANCEL DENY REQUEST", "Input your remarks here")
        If userMsg <> "" Then
            Try
                Con_ms = New SqlConnection(mcs)
                Con_ms.Open()
                conn_ms = "UPDATE ONLINE.business_applicationstatus_dtl set IsPendingTemp = '0' , IsPendingRemarks='" & userMsg & "' " _
                    & "WHERE applicationID='" & txt_applicationno.Text & "'"
                cmd_ms = New SqlCommand(conn_ms, Con_ms)
                cmd_ms.ExecuteNonQuery()
                Con_ms.Close()

                Con_ms = New SqlConnection(mcs)
                Con_ms.Open()
                conn_ms = "UPDATE ONLINE.business_denytemp set deny_status = 'C'" _
                    & "WHERE applicationID='" & txt_applicationno.Text & "'"
                cmd_ms = New SqlCommand(conn_ms, Con_ms)
                cmd_ms.ExecuteNonQuery()
                Con_ms.Close()

                MsgBox("Request has been cancelled!")
                FormStatus = False

                Me.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        Else
            MsgBox("Please input reamrks!")
        End If


    End Sub
    Private Sub Clearme()
        txt_applicationno.Text = ""
        txt_accountno.Text = ""
        txt_businessname.Text = ""
        txt_email.Text = ""
        txt_remarks.Text = ""
        txt_userdeny.Text = ""
        txt_businessline.Text = ""

        ck_spa.Checked = False
        ck_contractlease.Checked = False
        ck_unf.Checked = False
        ck_oldpermit.Checked = False
        ck_oldfire.Checked = False
        ck_itr.Checked = False
        ck_brgyclearance.Checked = False
        ck_marketclearance.Checked = False
        ck_oldplate.Checked = False


        ck_validID.Checked = False
        ck_cda.Checked = False
        ck_coop.Checked = False
        ck_ctc.Checked = False
        ck_bfad.Checked = False
        ck_brgyresolution.Checked = False
        ck_enro.Checked = False
        ck_psa.Checked = False
        ck_pcab.Checked = False
        ck_agriculture.Checked = False
        ck_licensetooperate.Checked = False
        ck_citytourism.Checked = False
        ck_dot.Checked = False
        ck_dole.Checked = False
        ck_peso.Checked = False
        ck_cityvet.Checked = False
        ck_slaughter.Checked = False
        ck_bsp.Checked = False
        ck_francisetooperate.Checked = False
        ck_waterpotability.Checked = False
        ck_firearms.Checked = False






    End Sub
    Private Sub load_grid()
        DataGrid.Rows.Clear()

        Try
            conn = "SELECT " & _
            "business_application_tbl.applicationid, " & _
            "business_record_hdr.accountno, " & _
            "business_record_hdr.b_name, " & _
            "business_record_hdr.b_username, " & _
            "business_record_hdr.b_password, " & _
            "business_denytemp.applicationid, " & _
            "business_denytemp.deny_status, " & _
            "business_denytemp.deny_dt, " & _
            "business_denytemp.brgy_clearance_IsLacking, " & _
            "business_denytemp.unifiedform_islacking, " & _
            "business_denytemp.old_permit_IsLacking, " & _
            "business_denytemp.old_plate_IsLacking, " & _
            "business_denytemp.old_fire_IsLacking, " & _
            "business_denytemp.itr_islacking, " & _
            "business_denytemp.marketclr_islacking, " & _
            "business_users.Full_name " & _
            "FROM " & _
            "ONLINE.business_denytemp " & _
            "INNER JOIN ONLINE.business_application_tbl ON ONLINE.business_denytemp.applicationid = business_application_tbl.applicationID " & _
            "INNER JOIN ONLINE.business_record_hdr ON ONLINE.business_application_tbl.recordID = business_record_hdr.recordID " & _
            "INNER JOIN ONLINE.business_users ON ONLINE.business_denytemp.user_id = business_users.system_userid WHERE business_denytemp.deny_status = 'P' ORDER BY business_denytemp.deny_dt DESC "


            Con_ms = New SqlConnection(mcs)
            Con_ms.Open()
            cmd_ms = New SqlCommand(conn_ms, Con_ms)
            rdr_ms = cmd_ms.ExecuteReader(CommandBehavior.CloseConnection)
            Do While rdr_ms.Read = True

                DataGrid.Rows.Add(rdr_ms("deny_dt"), rdr_ms("accountno"), rdr_ms("applicationID"), rdr_ms("b_name"), rdr_ms("deny_status"), "VIEW")
            Loop
            Con_ms.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub PendingDeny_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call load_grid()

    End Sub

    Private Sub txt_applicationno_TextChanged(sender As Object, e As EventArgs) Handles txt_applicationno.TextChanged

    End Sub

    Private Sub DataGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGrid.CellContentClick
        If e.RowIndex = -1 Then

            Exit Sub
        End If


        If e.ColumnIndex = 5 Then
            Try
                Call Clearme()


                conn = "SELECT " & _
           "business_application_tbl.applicationid, " & _
           "business_record_hdr.accountno, " & _
            "business_denytemp.remarks, " & _
            "business_record_hdr.email_add, " & _
           "business_record_hdr.b_name, " & _
           "business_record_hdr.b_username, " & _
           "business_record_hdr.b_password, " & _
           "business_denytemp.type_deny, " & _
           "business_denytemp.applicationid, " & _
           "business_denytemp.deny_status, " & _
           "business_denytemp.deny_dt, " & _
           "business_denytemp.brgy_clearance_IsLacking, " & _
           "business_denytemp.unifiedform_islacking, " & _
           "business_denytemp.old_permit_IsLacking, " & _
           "business_denytemp.old_plate_IsLacking, " & _
           "business_denytemp.old_fire_IsLacking, " & _
           "business_denytemp.itr_islacking, " & _
            "business_denytemp.itr_islacking, " & _
           "business_denytemp.marketclr_islacking, " & _
             "business_denytemp.remarks, " & _
           "business_users.Full_name, " & _
                "business_denytemp.ValidID_isLacking, " & _
                "business_denytemp.CDAcert_isLacking, " & _
                   "business_denytemp.SPA_isLacking, " & _
                "business_denytemp.ContractLease_isLacking, " & _
                "business_denytemp.Citycoopcert_isLacking, " & _
                "business_denytemp.CTC_isLacking, " & _
                "business_denytemp.BFADcert_isLacking, " & _
                "business_denytemp.brgyreso_isLacking, " & _
                "business_denytemp.enrocert_isLacking, " & _
                "business_denytemp.PCA_isLacking, " & _
                "business_denytemp.PCAB_isLacking, " & _
                "business_denytemp.CAC_isLacking, " & _
                "business_denytemp.PNPlicense_isLacking, " & _
                "business_denytemp.Tourism_isLacking, " & _
                "business_denytemp.DOT_isLacking, " & _
                "business_denytemp.DOLE_isLacking, " & _
                "business_denytemp.PESO_isLacking, " & _
                "business_denytemp.Cityvet_isLacking, " & _
                "business_denytemp.Slaughter_isLacking, " & _
                "business_denytemp.BSP_isLacking, " & _
                "business_denytemp.Franchise_isLacking, " & _
                "business_denytemp.waterport_isLacking, " & _
                "business_record_hdr.b_line, " & _
                        "business_record_hdr.b_contactno, " & _
                "business_denytemp.gross_islacking, " & _
                 "business_denytemp.firearmslic_isLacking, " & _
                 "business_denytemp.itr1_isLacking, " & _
                 "business_denytemp.itr2_isLacking, " & _
                 "business_denytemp.itr3_isLacking, " & _
                 "business_denytemp.itr4_isLacking, " & _
            "business_users.system_userid " & _
           "FROM " & _
           "ONLINE.business_denytemp " & _
           "INNER JOIN ONLINE.business_application_tbl ON business_denytemp.applicationid = business_application_tbl.applicationID " & _
           "INNER JOIN ONLINE.business_record_hdr ON business_application_tbl.recordID = business_record_hdr.recordID " & _
           "INNER JOIN ONLINE.business_users ON business_denytemp.user_id = business_users.system_userid WHERE business_denytemp.deny_status = 'P' AND business_application_tbl.applicationid ='" & DataGrid.Item(2, DataGrid.CurrentRow.Index).Value & "'"


                Con_ms = New SqlConnection(mcs)
                Con_ms.Open()
                cmd_ms = New SqlCommand(conn_ms, Con_ms)
                rdr_ms = cmd_ms.ExecuteReader(CommandBehavior.CloseConnection)

                If rdr.Read = True Then
                    TxtContactNo.Text = rdr_ms("b_contactno").ToString
                    txt_businessline.Text = rdr_ms("b_line").ToString
                    txt_applicationno.Text = rdr_ms("applicationid").ToString
                    txt_accountno.Text = rdr_ms("accountno").ToString
                    txt_businessname.Text = rdr_ms("b_name").ToString
                    txt_email.Text = rdr_ms("email_add").ToString
                    txt_remarks.Text = rdr_ms("remarks").ToString
                    txt_userdeny.Text = rdr_ms("Full_name").ToString

                    ck_itr1.Checked = rdr_ms("itr1_isLacking")
                    ck_itr2.Checked = rdr_ms("itr2_isLacking")
                    ck_itr3.Checked = rdr_ms("itr3_isLacking")
                    ck_itr4.Checked = rdr_ms("itr4_isLacking")

                    ck_spa.Checked = rdr_ms("SPA_isLacking")
                    ck_contractlease.Checked = rdr_ms("ContractLease_isLacking")
                    ck_unf.Checked = rdr_ms("unifiedform_islacking")
                    ck_oldpermit.Checked = rdr_ms("old_plate_IsLacking")
                    ck_oldfire.Checked = rdr_ms("old_fire_IsLacking")
                    ck_itr.Checked = rdr_ms("itr_islacking")
                    ck_brgyclearance.Checked = rdr_ms("brgy_clearance_IsLacking")
                    ck_marketclearance.Checked = rdr_ms("marketclr_islacking")
                    ck_oldplate.Checked = rdr_ms("old_plate_IsLacking")
                    ck_validID.Checked = rdr_ms("ValidID_isLacking")
                    ck_cda.Checked = rdr_ms("CDAcert_isLacking")
                    ck_coop.Checked = rdr_ms("Citycoopcert_isLacking")
                    ck_ctc.Checked = rdr_ms("CTC_isLacking")
                    ck_bfad.Checked = rdr_ms("BFADcert_isLacking")
                    ck_brgyresolution.Checked = rdr_ms("brgyreso_isLacking")
                    ck_enro.Checked = rdr_ms("enrocert_isLacking")
                    ck_psa.Checked = rdr_ms("PCA_isLacking")
                    ck_pcab.Checked = rdr_ms("PCAB_isLacking")
                    ck_agriculture.Checked = rdr_ms("CAC_isLacking")
                    ck_licensetooperate.Checked = rdr_ms("PNPlicense_isLacking")
                    ck_citytourism.Checked = rdr_ms("Tourism_isLacking")
                    ck_dot.Checked = rdr_ms("DOT_isLacking")
                    ck_dole.Checked = rdr_ms("DOLE_isLacking")
                    ck_peso.Checked = rdr_ms("PESO_isLacking")
                    ck_cityvet.Checked = rdr_ms("Cityvet_isLacking")
                    ck_slaughter.Checked = rdr_ms("Slaughter_isLacking")
                    ck_bsp.Checked = rdr_ms("BSP_isLacking")
                    ck_francisetooperate.Checked = rdr_ms("Franchise_isLacking")
                    ck_waterpotability.Checked = rdr_ms("waterport_isLacking")
                    ck_firearms.Checked = rdr_ms("firearmslic_isLacking")
                    ck_gross.Checked = rdr_ms("gross_islacking")
                    txt_userid.Text = rdr_ms("system_userid").ToString
                    txt_type_deny.Text = rdr_ms("type_deny").ToString
                    txt_remarks.Text = rdr_ms("remarks").ToString
                    Button5.Enabled = True
                    Button2.Enabled = True


                End If
                Con_ms.Close()

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try


            If MsgBox("Are you sure you want to confirm this deny request?", vbYesNo + vbInformation, "BPLO") = MsgBoxResult.Yes Then

                If ck_itr1.Checked = True Then lack_itr1 = 1 Else lack_itr1 = 0
                If ck_itr2.Checked = True Then lack_itr2 = 1 Else lack_itr2 = 0
                If ck_itr3.Checked = True Then lack_itr3 = 1 Else lack_itr3 = 0
                If ck_itr4.Checked = True Then lack_itr4 = 1 Else lack_itr4 = 0
                If ck_gross.Checked = True Then lack_gross = 1 Else lack_gross = 0
                If ck_unf.Checked = True Then lack_unf = 1 Else lack_unf = 0
                If ck_brgyclearance.Checked = True Then lack_brgyclearance = 1 Else lack_brgyclearance = 0
                If ck_oldpermit.Checked = True Then lack_oldpermit = 1 Else lack_oldpermit = 0
                If ck_oldplate.Checked = True Then lack_oldplate = 1 Else lack_oldplate = 0
                If ck_oldfire.Checked = True Then lack_oldfire = 1 Else lack_oldfire = 0
                If ck_itr.Checked = True Then lack_itr = 1 Else lack_itr = 0
                If ck_marketclearance.Checked = True Then lack_market_clearance = 1 Else lack_market_clearance = 0
                If ck_spa.Checked = True Then lack_spa = 1 Else lack_spa = 0
                If ck_contractlease.Checked = True Then lack_contractlease = 1 Else lack_contractlease = 0
                If ck_validID.Checked = True Then lack_validid = 1 Else lack_validid = 0
                If ck_cda.Checked = True Then lack_cda = 1 Else lack_cda = 0
                If ck_coop.Checked = True Then lack_coop = 1 Else lack_coop = 0
                If ck_ctc.Checked = True Then lack_ctc = 1 Else lack_ctc = 0
                If ck_bfad.Checked = True Then lack_bfad = 1 Else lack_bfad = 0
                If ck_brgyresolution.Checked = True Then lack_brgyresolution = 1 Else lack_brgyresolution = 0
                If ck_enro.Checked = True Then lack_enro = 1 Else lack_enro = 0
                If ck_psa.Checked = True Then lack_psa = 1 Else lack_psa = 0
                If ck_pcab.Checked = True Then lack_pcab = 1 Else lack_pcab = 0
                If ck_agriculture.Checked = True Then lack_agriculture = 1 Else lack_agriculture = 0
                If ck_licensetooperate.Checked = True Then lack_licensetooperate = 1 Else lack_licensetooperate = 0
                If ck_citytourism.Checked = True Then lack_citytourism = 1 Else lack_citytourism = 0
                If ck_dot.Checked = True Then lack_dot = 1 Else lack_dot = 0
                If ck_dole.Checked = True Then lack_dole = 1 Else lack_dole = 0
                If ck_peso.Checked = True Then lack_peso = 1 Else lack_peso = 0
                If ck_cityvet.Checked = True Then lack_cityvet = 1 Else lack_cityvet = 0
                If ck_slaughter.Checked = True Then lack_slaughter = 1 Else lack_slaughter = 0
                If ck_bsp.Checked = True Then lack_bsp = 1 Else lack_bsp = 0
                If ck_francisetooperate.Checked = True Then lack_francisetooperate = 1 Else lack_francisetooperate = 0
                If ck_waterpotability.Checked = True Then lack_waterpotability = 1 Else lack_waterpotability = 0
                If ck_firearms.Checked = True Then lack_firearms = 1 Else lack_firearms = 0












                Dim mytimestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                'update data deny if from assessor or evaluator
                If txt_type_deny.Text = "A" Then


                    'update main

                    Con_ms = New SqlConnection(mcs)
                    Con_ms.Open()
                    conn_ms = "UPDATE ONLINE.business_application_tbl  set  " & _
                           "itr1_IsLacking = '" & lack_itr1 & "', " & _
                              "itr2_IsLacking = '" & lack_itr2 & "', " & _
                               "itr3_IsLacking = '" & lack_itr3 & "', " & _
                                "itr4_IsLacking = '" & lack_itr4 & "', " & _
                            "gross_IsDenied = '" & lack_gross & "', " & _
                            "unified_form_IsLacking = '" & lack_unf & "', " & _
                            "brgy_clearance_IsLacking = '" & lack_brgyclearance & "', " & _
                            "old_permit_IsLacking =  '" & lack_oldpermit & "', " & _
                            "old_plate_IsLacking ='" & lack_oldpermit & "' , " & _
                            "old_fire_IsLacking ='" & lack_oldfire & "', " & _
                            "itr_IsLacking ='" & lack_itr & "', " & _
                            "market_clearance_IsLacking ='" & lack_market_clearance & "', " & _
                            "contract_lease_IsLacking ='" & lack_contractlease & "', " & _
                            "spa_IsLacking ='" & lack_spa & "', " & _
                            "validIDOwner_IsLacking ='" & lack_validid & "', " & _
                            "cdaCertificate_IsLacking ='" & lack_cda & "', " & _
                            "cityCOOPCertificate_IsLacking ='" & lack_coop & "', " & _
                            "CTC_IsLacking ='" & lack_ctc & "', " & _
                            "bfadCertificate_IsLacking ='" & lack_bfad & "', " & _
                            "brgyResolution_IsLacking ='" & lack_brgyresolution & "', " & _
                            "enroCertificate_IsLacking ='" & lack_enro & "', " & _
                            "pca_IsLacking ='" & lack_psa & "', " & _
                            "pcabAccreditation_IsLacking ='" & lack_pcab & "', " & _
                            "cityAgricultureCertification_IsLacking ='" & lack_agriculture & "', " & _
                            "licenseToOperatePNP_IsLacking ='" & lack_licensetooperate & "', " & _
                            "cityTourismCertificate_IsLacking ='" & lack_citytourism & "', " & _
                            "dole_certification_IsLacking ='" & lack_dole & "', " & _
                            "peso_certification_IsLacking ='" & lack_peso & "', " & _
                            "cityvet_certification_IsLacking ='" & lack_cityvet & "', " & _
                            "slaughterReport_IsLacking ='" & lack_slaughter & "', " & _
                            "bsp_accreditation_IsLacking ='" & lack_bsp & "', " & _
                            "franciseToOperateFromSP_IsLacking ='" & lack_francisetooperate & "', " & _
                            "waterpotability_IsLacking ='" & lack_waterpotability & "', " & _
                            "firearmsLicense_IsLacking ='" & lack_firearms & "', " & _
                            "dotCertification_IsLacking ='" & lack_dot & "' " & _
                            "WHERE applicationID='" & txt_applicationno.Text & "'"
                    cmd_ms = New SqlCommand(conn_ms, Con_ms)
                    cmd_ms.ExecuteNonQuery()
                    Con_ms.Close()


                    'update status
                    Con_ms = New SqlConnection(cs)
                    Con_ms.Open()
                    conn_ms = "UPDATE ONLINE.business_applicationstatus_dtl  set assess_status = 'D', Denied_remarks =@Remarks, IsReupload ='0', assess_deny_dttime = '" & mytimestamp & "', user_deny='" & userid & "' WHERE applicationID='" & txt_applicationno.Text & "'"
                    cmd_ms = New SqlCommand(conn_ms, Con_ms)
                    cmd_ms.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = txt_remarks.Text
                    cmd_ms.ExecuteNonQuery()
                    Con_ms.Close()

              




                ElseIf txt_type_deny.Text = "E" Then



                    Con_ms = New SqlConnection(mcs)
                    Con_ms.Open()
                    conn_ms = "UPDATE ONLINE.business_application_tbl  set  " & _
                        "gross_IsDenied = '" & lack_gross & "', " & _
                            "unified_form_IsLacking = '" & lack_unf & "', " & _
                            "brgy_clearance_IsLacking = '" & lack_brgyclearance & "', " & _
                            "old_permit_IsLacking =  '" & lack_oldpermit & "', " & _
                            "old_plate_IsLacking ='" & lack_oldpermit & "' , " & _
                            "old_fire_IsLacking ='" & lack_oldfire & "', " & _
                            "itr_IsLacking ='" & lack_itr & "', " & _
                            "market_clearance_IsLacking ='" & lack_market_clearance & "', " & _
                            "contract_lease_IsLacking ='" & lack_contractlease & "', " & _
                            "spa_IsLacking ='" & lack_spa & "', " & _
                            "validIDOwner_IsLacking ='" & lack_validid & "', " & _
                            "cdaCertificate_IsLacking ='" & lack_cda & "', " & _
                            "cityCOOPCertificate_IsLacking ='" & lack_coop & "', " & _
                            "CTC_IsLacking ='" & lack_ctc & "', " & _
                            "bfadCertificate_IsLacking ='" & lack_bfad & "', " & _
                            "brgyResolution_IsLacking ='" & lack_brgyresolution & "', " & _
                            "enroCertificate_IsLacking ='" & lack_enro & "', " & _
                            "pca_IsLacking ='" & lack_psa & "', " & _
                            "pcabAccreditation_IsLacking ='" & lack_pcab & "', " & _
                            "cityAgricultureCertification_IsLacking ='" & lack_agriculture & "', " & _
                            "licenseToOperatePNP_IsLacking ='" & lack_licensetooperate & "', " & _
                            "cityTourismCertificate_IsLacking ='" & lack_citytourism & "', " & _
                            "dole_certification_IsLacking ='" & lack_dole & "', " & _
                            "peso_certification_IsLacking ='" & lack_peso & "', " & _
                            "cityvet_certification_IsLacking ='" & lack_cityvet & "', " & _
                            "slaughterReport_IsLacking ='" & lack_slaughter & "', " & _
                            "bsp_accreditation_IsLacking ='" & lack_bsp & "', " & _
                            "franciseToOperateFromSP_IsLacking ='" & lack_francisetooperate & "', " & _
                            "waterpotability_IsLacking ='" & lack_waterpotability & "', " & _
                            "firearmsLicense_IsLacking ='" & lack_firearms & "', " & _
                            "dotCertification_IsLacking ='" & lack_dot & "' " & _
                            "WHERE applicationID='" & txt_applicationno.Text & "'"
                    cmd_ms = New SqlCommand(conn_ms, Con_ms)
                    cmd_ms.ExecuteNonQuery()
                    Con_ms.Close()

                    Con_ms = New SqlConnection(mcs)
                    Con_ms.Open()
                    conn_ms = "UPDATE ONLINE.business_applicationstatus_dtl  set eval_status = 'D', Denied_remarks = @Remarks, IsReupload ='0', eval_deny_dttime = '" & mytimestamp & "', user_deny='" & userid & "' WHERE applicationID='" & txt_applicationno.Text & "'"
                    cmd_ms = New SqlCommand(conn_ms, Con_ms)
                    cmd_ms.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = txt_remarks.Text
                    cmd_ms.ExecuteNonQuery()
                    Con_ms.Close()

                End If

                'update to deny_temp_table
                Con_ms = New SqlConnection(mcs)
                Con_ms.Open()
                conn_ms = "UPDATE ONLINE.business_denytemp  set deny_status = 'D' WHERE applicationID='" & txt_applicationno.Text & "'"
                cmd_ms = New SqlCommand(conn_ms, Con_ms)
                cmd_ms.ExecuteNonQuery()
                Con_ms.Close()

                'save to deny_table c/o josie


                Dim remarkstext As String
                remarkstext = txt_remarks.Text & "   Access your account at Tacloban Business Portal. Click the link under Denied status and supply this login credentials:   " & "USERNAME: " & BPLOApplicationRecord.txt_accountno.Text & "       PASSWORD: " & BPLOApplicationRecord.txt_password.Text

                Con = New SqlConnection(cs)
                Con.Open()

                conn = "INSERT INTO email_deny_application (AccountID, ApplicationID, DenyDateTime, Remarks, email, fullname, attachment_type, phonenumber) " _
                   & "VALUES ('" & txt_accountno.Text & "', '" & txt_applicationno.Text & "', '" & mytimestamp & "', @Remarks , '" & txt_email.Text & "', @BusinessName, 'deny_business', '" & TxtContactNo.Text & "')"
                cmd = New SqlCommand(conn, Con)
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = remarkstext
                cmd.Parameters.Add("@BusinessName", SqlDbType.VarChar).Value = BPLOApplicationRecord.txt_businessname.Text
                cmd.ExecuteNonQuery()
                Con.Close()
                MsgBox("Application successully denied. This client will received notification to his email.", vbOKOnly & vbInformation, "Business Renewal")
                Call Clearme()
                Call load_grid()
            Else


            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

  
    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        FormStatus = False
        Me.Close()
    End Sub
End Class