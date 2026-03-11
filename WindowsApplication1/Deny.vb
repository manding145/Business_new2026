Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Public Class Deny
    Dim lack_itr1, lack_itr2, lack_itr3, lack_itr4, lack_gross, lack_firearms, lack_waterpotability, lack_francisetooperate, lack_bsp, lack_slaughter, lack_cityvet, lack_peso, lack_dole, lack_dot, lack_citytourism, lack_licensetooperate, lack_agriculture, lack_pcab, lack_psa, lack_enro, lack_brgyresolution, lack_spa, lack_contractlease, lack_validid, lack_cda, lack_coop, lack_ctc, lack_bfad, lack_unf, lack_brgyclearance, lack_oldpermit, lack_oldplate, lack_oldfire, lack_itr, lack_market_clearance As Integer
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles ck_brgyclearance.CheckedChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim BPLOApplicationRecord As BPLOApplicationRecord = CType(Application.OpenForms("BPLOApplicationRecord"), BPLOApplicationRecord)


        If ck_itr1.Checked = True Then lack_itr1 = 1 Else lack_itr1 = 0
        If ck_itr2.Checked = True Then lack_itr2 = 1 Else lack_itr2 = 0
        If ck_itr3.Checked = True Then lack_itr3 = 1 Else lack_itr3 = 0
        If ck_itr4.Checked = True Then lack_itr4 = 1 Else lack_itr4 = 0





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
        If ck_gross.Checked = True Then lack_gross = 1 Else lack_gross = 0

        Dim mytimestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        Try
            'Con_ms = New SqlClient.SqlConnection(mcs)
            'Con_ms.Open()
            'conn_ms = "UPDATE ONLINE.business_application_tbl  set  " & _
            '     "itr1_IsLacking = '" & lack_itr1 & "', " & _
            '      "itr2_IsLacking = '" & lack_itr2 & "', " & _
            '       "itr3_IsLacking = '" & lack_itr3 & "', " & _
            '        "itr4_IsLacking = '" & lack_itr4 & "', " & _
            '                  "unified_form_IsLacking = '" & lack_unf & "', " & _
            '                    "gross_IsDenied = '" & lack_gross & "', " & _
            '                  "brgy_clearance_IsLacking = '" & lack_brgyclearance & "', " & _
            '                  "old_permit_IsLacking =  '" & lack_oldpermit & "', " & _
            '                  "old_plate_IsLacking ='" & lack_oldpermit & "' , " & _
            '                  "old_fire_IsLacking ='" & lack_oldfire & "', " & _
            '                  "itr_IsLacking ='" & lack_itr & "', " & _
            '                  "market_clearance_IsLacking ='" & lack_market_clearance & "', " & _
            '                  "contract_lease_IsLacking ='" & lack_contractlease & "', " & _
            '                  "spa_IsLacking ='" & lack_spa & "', " & _
            '                  "validIDOwner_IsLacking ='" & lack_validid & "', " & _
            '                  "cdaCertificate_IsLacking ='" & lack_cda & "', " & _
            '                  "cityCOOPCertificate_IsLacking ='" & lack_coop & "', " & _
            '                  "CTC_IsLacking ='" & lack_ctc & "', " & _
            '                  "bfadCertificate_IsLacking ='" & lack_bfad & "', " & _
            '                  "brgyResolution_IsLacking ='" & lack_brgyresolution & "', " & _
            '                  "enroCertificate_IsLacking ='" & lack_enro & "', " & _
            '                  "pca_IsLacking ='" & lack_psa & "', " & _
            '                  "pcabAccreditation_IsLacking ='" & lack_pcab & "', " & _
            '                  "cityAgricultureCertification_IsLacking ='" & lack_agriculture & "', " & _
            '                  "licenseToOperatePNP_IsLacking ='" & lack_licensetooperate & "', " & _
            '                  "cityTourismCertificate_IsLacking ='" & lack_citytourism & "', " & _
            '                  "dole_certification_IsLacking ='" & lack_dole & "', " & _
            '                  "peso_certification_IsLacking ='" & lack_peso & "', " & _
            '                  "cityvet_certification_IsLacking ='" & lack_cityvet & "', " & _
            '                  "slaughterReport_IsLacking ='" & lack_slaughter & "', " & _
            '                  "bsp_accreditation_IsLacking ='" & lack_bsp & "', " & _
            '                  "franciseToOperateFromSP_IsLacking ='" & lack_francisetooperate & "', " & _
            '                  "waterpotability_IsLacking ='" & lack_waterpotability & "', " & _
            '                  "firearmsLicense_IsLacking ='" & lack_firearms & "', " & _
            '                  "dotCertification_IsLacking ='" & lack_dot & "' " & _
            '                  "WHERE applicationID='" & BPLOApplicationRecord.txt_applicationno.Text & "'"
            'cmd_ms = New SqlCommand(conn_ms, Con_ms)
            'cmd_ms.ExecuteNonQuery()
            'Con_ms.Close()



            Dim remarkstext As String = txt_remarks.Text + vbNewLine + vbNewLine + txt_remarks1.Text

            'remarkstext = txt_remarks.Text & "   Access your account at Tacloban Business Portal. Click the link under Denied status and supply this login credentials:   " & "USERNAME: " & BPLOApplicationRecord.txt_accountno.Text & "       PASSWORD: " & BPLOApplicationRecord.txt_password.Text
            'save to deny_table c/o josie



            Con_ms = New SqlConnection(mcs)
            Con_ms.Open()
            conn = "INSERT INTO ONLINE.email_outbox (userid, accountno, Remarks, email, Subject, fullname, referencecode, datesend) " _
               & "VALUES (@userid, '" & BPLOApplicationRecord.txt_accountno.Text & "',  @Remarks, '" & BPLOApplicationRecord.txt_email.Text & "', 'Business Deny Application' ,@BusinessName, '" & BPLOApplicationRecord.TxtRefenceNo.Text & "', @Date)"
            cmd_ms = New SqlCommand(conn, Con_ms)
            cmd_ms.Parameters.Add("@BusinessName", SqlDbType.VarChar).Value = BPLOApplicationRecord.txt_businessname.Text
            cmd_ms.Parameters.Add("@userid", SqlDbType.VarChar).Value = BPLOApplicationRecord.useraccountid.Text
            cmd_ms.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = remarkstext
            cmd_ms.Parameters.Add("@Date", SqlDbType.VarChar).Value = DateAndTime.Now()
            cmd_ms.ExecuteNonQuery()
            Con_ms.Close()




            Con_ms = New SqlConnection(mcs)
            Con_ms.Open()
            conn_ms = "UPDATE ONLINE.business_applicationstatus_dtl set verify_status = 'D', IsReupload ='0', Denied_remarks = @Remarks,  verify_deny_dttime = '" & mytimestamp & "', user_deny='" & userid & "' WHERE applicationID='" & BPLOApplicationRecord.txt_applicationno.Text & "'"
            cmd_ms = New SqlCommand(conn_ms, Con_ms)
            cmd_ms.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = remarkstext
            cmd_ms.ExecuteNonQuery()
            Con_ms.Close()

            MsgBox("Application successully denied. This client will received notification to his email.", vbOKOnly & vbInformation, "Business Renewal")
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Con.Close()
        End Try







    End Sub

    Private Sub BtnSearchRecord_Click(sender As Object, e As EventArgs) Handles BtnSearchRecord.Click
        Me.Close()
    End Sub

    Private Sub Deny_Load(sender As Object, e As EventArgs) Handles MyBase.Load
       

    End Sub

    Private Sub ck_unf_CheckedChanged(sender As Object, e As EventArgs) Handles ck_unf.CheckedChanged

    End Sub
End Class