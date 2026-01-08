Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Web
Imports System.Data.SqlClient



Public Class PrintBarangayPermit
    Dim rpt As New BarangayClearance
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub GetReport()

        Dim BarangayClearanceControl As BarangayClearanceControl = CType(Application.OpenForms("BarangayClearanceControl"), BarangayClearanceControl)

        rpt.Load(Application.StartupPath & "\BarangayClearance.rpt")
        Dim pfields As New ParameterFields


        Dim pfieldEmployeeRecordID As New ParameterField
        Dim pdiscreteEmployeeRecordID As New ParameterDiscreteValue
        pfieldEmployeeRecordID.Name = "permitAppID"
        pdiscreteEmployeeRecordID.Value = BarangayClearanceControl.temp_applicationid
        pfieldEmployeeRecordID.CurrentValues.Add(pdiscreteEmployeeRecordID)
        pfields.Add(pfieldEmployeeRecordID)



        'Dim TxtBusinessName As CrystalDecisions.CrystalReports.Engine.TextObject = rpt.ReportDefinition.Sections(3).ReportObjects("TxtBusinessName")
        'Dim TxtAccountNo As CrystalDecisions.CrystalReports.Engine.TextObject = rpt.ReportDefinition.Sections(3).ReportObjects("TxtAccountNo")
        'Dim TxtBarangayName As CrystalDecisions.CrystalReports.Engine.TextObject = rpt.ReportDefinition.Sections(3).ReportObjects("TxtBarangayName")
        'Dim TxtBusinessAddress As CrystalDecisions.CrystalReports.Engine.TextObject = rpt.ReportDefinition.Sections(3).ReportObjects("TxtBusinessAddress")
        'Dim TxtContact As CrystalDecisions.CrystalReports.Engine.TextObject = rpt.ReportDefinition.Sections(3).ReportObjects("TxtContact")
        'Dim TxtNumberofEmployees As CrystalDecisions.CrystalReports.Engine.TextObject = rpt.ReportDefinition.Sections(3).ReportObjects("TxtNumberofEmployees")
        'Dim TxtTaxPayer As CrystalDecisions.CrystalReports.Engine.TextObject = rpt.ReportDefinition.Sections(3).ReportObjects("TxtTaxPayer")
        'Dim TxtOwnerAddress As CrystalDecisions.CrystalReports.Engine.TextObject = rpt.ReportDefinition.Sections(3).ReportObjects("TxtOwnerAddress")
        'Dim TxtNatureBusiness As CrystalDecisions.CrystalReports.Engine.TextObject = rpt.ReportDefinition.Sections(3).ReportObjects("TxtNatureBusiness")
        'Dim TxtBusinessLine As CrystalDecisions.CrystalReports.Engine.TextObject = rpt.ReportDefinition.Sections(3).ReportObjects("TxtBusinessLine")
        'Dim TxtOR As CrystalDecisions.CrystalReports.Engine.TextObject = rpt.ReportDefinition.Sections(3).ReportObjects("TxtOR")
        'Dim TxtAmount As CrystalDecisions.CrystalReports.Engine.TextObject = rpt.ReportDefinition.Sections(3).ReportObjects("TxtAmount")
        'Dim TxtDatePaid As CrystalDecisions.CrystalReports.Engine.TextObject = rpt.ReportDefinition.Sections(3).ReportObjects("TxtDatePaid")
        'Dim txt_Date_issued As CrystalDecisions.CrystalReports.Engine.TextObject = rpt.ReportDefinition.Sections(3).ReportObjects("txt_Date_issued")
        'Dim txt_date_expiry As CrystalDecisions.CrystalReports.Engine.TextObject = rpt.ReportDefinition.Sections(3).ReportObjects("txt_date_expiry")
        'Dim txt_permit_no As CrystalDecisions.CrystalReports.Engine.TextObject = rpt.ReportDefinition.Sections(3).ReportObjects("txt_permit_no")
        'Dim txt_permit_year As CrystalDecisions.CrystalReports.Engine.TextObject = rpt.ReportDefinition.Sections(3).ReportObjects("txt_permit_year")
        'Dim txt_signatory_position As CrystalDecisions.CrystalReports.Engine.TextObject = rpt.ReportDefinition.Sections(3).ReportObjects("txt_signatory_position")
        'Dim txt_licenseinspector As CrystalDecisions.CrystalReports.Engine.TextObject = rpt.ReportDefinition.Sections(3).ReportObjects("txt_licenseinspector")
        'Dim txt_signatories As CrystalDecisions.CrystalReports.Engine.TextObject = rpt.ReportDefinition.Sections(3).ReportObjects("txt_signatories")
        'Dim txt_year1 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt.ReportDefinition.Sections(3).ReportObjects("txt_year1")
        'Dim txtBusinessID As CrystalDecisions.CrystalReports.Engine.TextObject = rpt.ReportDefinition.Sections(3).ReportObjects("txtBusinessID")
        'Dim txt_businessname1 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt.ReportDefinition.Sections(3).ReportObjects("txt_businessname1")
        'Dim txt_businessaddress1 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt.ReportDefinition.Sections(3).ReportObjects("txt_businessaddress1")
        'Dim txt_businessnature1 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt.ReportDefinition.Sections(3).ReportObjects("txt_businessnature1")
        'Dim txt_owner1 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt.ReportDefinition.Sections(3).ReportObjects("txt_owner1")
        'Dim txt_owneraddress1 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt.ReportDefinition.Sections(3).ReportObjects("txt_owneraddress1")
        'Dim txt_permitno1 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt.ReportDefinition.Sections(3).ReportObjects("txt_permitno1")
        'Dim txt_remarks1 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt.ReportDefinition.Sections(3).ReportObjects("txt_remarks1")
        'Dim txt_contact1 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt.ReportDefinition.Sections(3).ReportObjects("txt_contact1")
        'Dim txt_barangay1 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt.ReportDefinition.Sections(3).ReportObjects("txt_barangay1")
        '' Dim txt_ownernumber As CrystalDecisions.CrystalReports.Engine.TextObject = rpt.ReportDefinition.Sections(3).ReportObjects("txt_ownernumber")
        'Dim date_issued1 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt.ReportDefinition.Sections(3).ReportObjects("date_issued1")
        'Dim txt_accountno1 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt.ReportDefinition.Sections(3).ReportObjects("txt_accountno1")
        ''Dim txt_dateissued1 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt.ReportDefinition.Sections(3).ReportObjects("txt_dateissued1")
        'Dim txt_paidamount1 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt.ReportDefinition.Sections(3).ReportObjects("txt_paidamount1")
        'Dim txt_ownernumber1 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt.ReportDefinition.Sections(3).ReportObjects("txt_ownernumber1")
        'Dim txt_expirydate1 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt.ReportDefinition.Sections(3).ReportObjects("txt_expirydate1")
        'Dim txt_datepaid1 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt.ReportDefinition.Sections(3).ReportObjects("txt_datepaid1")
        'Dim txt_businessid1 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt.ReportDefinition.Sections(3).ReportObjects("txt_businessid1")
        'Dim txt_ornumber1 As CrystalDecisions.CrystalReports.Engine.TextObject = rpt.ReportDefinition.Sections(3).ReportObjects("txt_ornumber1")
        'Dim txtnature As CrystalDecisions.CrystalReports.Engine.TextObject = rpt.ReportDefinition.Sections(3).ReportObjects("txtnature")


        With MayorsPermitControl
            'Dim NUMBERKO As Integer
            'NUMBERKO = .txt_permitNumber.Text
            'txt_businessid1.Text = .mBIN
            'txtBusinessID.Text = .mBIN
            'txt_permit_no.Text = Format(NUMBERKO, "00000")
            'txt_permit_year.Text = .myear
            'txt_year1.Text = .myear
            'TxtAccountNo.Text = .txt_AccountNo.Text
            'TxtBusinessName.Text = .txt_tradename.Text
            'TxtBarangayName.Text = .mBarangayName
            'TxtBusinessAddress.Text = .mBusinessAddress
            'TxtContact.Text = .mPhone
            'TxtNumberofEmployees.Text = .mEmployees
            'TxtTaxPayer.Text = .mOwnerName
            'TxtOwnerAddress.Text = .mowneraddress
            'TxtNatureBusiness.Text = .mBusinessNatureDescription
            'TxtBusinessLine.Text = .mBusinessLineDescription
            'txtnature.Text = .mBusinessLineDescription
            'TxtOR.Text = .txt_ORNumber.Text
            'TxtAmount.Text = .txt_AmountPaid.Text
            'TxtDatePaid.Text = .txt_datepayment.Text
            'txt_Date_issued.Text = Format(Date.Now, "MM/dd/yyyy")
            'txt_date_expiry.Text = "12/31/" & Now.Year
            'txt_licenseinspector.Text = lblfname1
            'txt_signatories.Text = .cmb_signatories.Text
            'txt_signatory_position.Text = .txt_position.Text
            'txt_businessname1.Text = .mBusinessname
            'txt_businessaddress1.Text = .mBusinessAddress
            'txt_businessnature1.Text = .mBusinessNatureDescription
            'txt_owner1.Text = .mOwnerName
            'txt_owneraddress1.Text = .mowneraddress
            'txt_permitno1.Text = Format(NUMBERKO, "00000")
            'txt_remarks1.Text = .txt_remarks.Text
            'txt_contact1.Text = .mPhone
            'txt_barangay1.Text = .mBarangayName

            'txt_ornumber1.Text = .mORNumber
            'date_issued1.Text = Format(Date.Now, "MM/dd/yyyy")
            'txt_accountno1.Text = .txt_AccountNo.Text

            'txt_paidamount1.Text = .txt_AmountPaid.Text
            'txt_ownernumber1.Text = .mPhone
            'txt_expirydate1.Text = "12/31/" & Now.Year
            'txt_datepaid1.Text = .txt_datepayment.Text


        End With
        rpt.SetDatabaseLogon("sa", "@dm1n1str@t0r")
        CrystalReportViewer1.ReportSource = rpt
        CrystalReportViewer1.ParameterFieldInfo = pfields
        CrystalReportViewer1.Show()





    End Sub

    Private Sub Print_mayorsbusinesspermit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call GetReport()
    End Sub


    Private Sub CrystalReportViewer1_Load(sender As Object, e As EventArgs) Handles CrystalReportViewer1.Load
        'GetReport()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim report As RptMayorsPermit = New RptMayorsPermit
        'report.PrintToPrinter(1, True, 0, 0)


        Try


            'Dim NewMDIChild As New Loading
            'NewMDIChild.MdiParent = MainMenu
            'NewMDIChild.Show()

            'save to deny_table c/o josie
            Dim MayorsPermitControl As MayorsPermitControl = CType(Application.OpenForms("MayorsPermitControl"), MayorsPermitControl)


            If MayorsPermitControl.txt_email.Text = "" Then
                MsgBox("No Email address set to this business account, please update email in BPLS")
                Exit Sub
            Else

            End If
            Loading.Show()
            Dim fullname As String
            With MayorsPermitControl
                fullname = .mAccountNo
                Con = New SqlConnection(cs)
                Con.Open()
                Dim filename As String
                filename = folder_directory & .mAccountNo & "_BarangayClearance.pdf"
                conn = "INSERT INTO email_send (ApplicationID, datesend, email, fullname, attachment_type, FileDirectory, status) " _
                   & "VALUES ('" & .mAccountNo & "', '" & Format((Date.Now), "yyyy-MM-dd") & "', '" & .txt_email.Text & "', '" & fullname & "', 'business_brgyclearance', @filename, '2')"
                cmd = New SqlCommand(conn, Con)

                cmd.Parameters.Add("@filename", SqlDbType.VarChar).Value = filename

                cmd.ExecuteNonQuery()
                Con.Close()




                '  MsgBox("Health Card successfully sent!", vbOKOnly & vbInformation, "Tacloban Health Office Management System")





                'link_string = link_prefix & folderdirectory & DewormingResultLink


                '\\10.0.27.194\FileAttachment\BUSINESS\5-00001


                ' CrDiskFileDestinationOptions.DiskFileName = _
                '                     link_prefix & folder_directory & fullname & "business_mp.pdf"
                Try
                    Dim CrExportOptions As ExportOptions
                    Dim CrDiskFileDestinationOptions As New  _
                    DiskFileDestinationOptions()
                    Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
                    CrDiskFileDestinationOptions.DiskFileName = _
                                                link_prefix & folder_directory & fullname & "_MP.pdf"
                    CrExportOptions = rpt.ExportOptions
                    With CrExportOptions
                        .ExportDestinationType = ExportDestinationType.DiskFile
                        .ExportFormatType = ExportFormatType.PortableDocFormat
                        .DestinationOptions = CrDiskFileDestinationOptions
                        .FormatOptions = CrFormatTypeOptions
                    End With
                    rpt.Export()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try





            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Con.Close()
        End Try



    End Sub

    
End Class