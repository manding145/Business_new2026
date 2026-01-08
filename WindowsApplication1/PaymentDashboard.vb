Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient

Public Class PaymentDashboard

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick


        conn_ms = "SELECT " _
        & " COUNT(applicationID) as no_pending " _
        & " FROM ONLINE.business_applicationstatus_dtl where payment_status ='P'"

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
       & " FROM ONLINE.business_applicationstatus_dtl  where payment_status ='D'"

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


    End Sub

    Private Sub PaymentDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load



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
            "business_applicationstatus_dtl.payment_status FROM " & _
            "ONLINE.business_application_tbl  " & _
            "INNER JOIN ONLINE.business_applicationstatus_dtl ON ONLINE.business_application_tbl.applicationID = ONLINE.business_applicationstatus_dtl.applicationID " & _
            "WHERE ONLINE.business_applicationstatus_dtl.payment_status='P' order by application_date ASC, application_time ASC"

            Con_ms = New SqlConnection(mcs)
            Con_ms.Open()
            cmd_ms = New SqlCommand(conn_ms, Con_ms)
            rdr_ms = cmd_ms.ExecuteReader(CommandBehavior.CloseConnection)
            Do While rdr_ms.Read = True

                DataGrid.Rows.Add(rdr_ms("applicationid"), rdr_ms("RefCode"), rdr_ms("RecordID"), rdr_ms("application_date"), Convert.ToDateTime(rdr_ms("application_date")).ToString("hh:mm tt"), rdr_ms("accountno"), rdr_ms("businessname"), rdr_ms("payment_status"), "VIEW")

            Loop

            Con_ms.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Con_ms.Close()
        End Try
    End Sub

    Private Sub DataGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGrid.CellContentClick
        If e.RowIndex = -1 Then

            Exit Sub
        End If

        If e.ColumnIndex = 8 Then

            Try
                'conn_ms = "SELECT business_applicationstatus_dtl.payment_status, business_applicationstatus_dtl.RefCode FROM ONLINE.business_applicationstatus_dtl INNER JOIN business_applicationstatus ON business_application_tbl.applicationID = business_applicationstatus.business_application_tbl inner JOIN business_assessment_dtl ON business_assessment_dtl.applicationID =  business_application_tbl.applicationID where business_applicationstatus_dtl.applicationID= '" & DataGrid.Item(0, DataGrid.CurrentRow.Index).Value & "'"

                conn_ms = "SELECT bat.user_id, bad.PaymentTransactionNo, bad.OfficialReceipt, bad.CTC, bad.FireOR, bsd.payment_status,bat.RefCode, bat.applicationID, bat.accountno, bat.businessname, bad.tax_amt, bad.cedula_amt, bad.fire_local_amount, bad.Total_amt " & _
                          "FROM ONLINE.business_applicationstatus_dtl bsd " & _
                          "INNER JOIN ONLINE.business_application_tbl bat " & _
                          "ON bsd.applicationID = bat.applicationID " & _
                          "INNER JOIN ONLINE.business_assessment_dtl bad " & _
                          "ON bad.applicationID = bsd.applicationID " & _
                          "WHERE bsd.applicationID = '" + DataGrid.Item(0, DataGrid.CurrentRow.Index).Value.ToString() + "'"

                Con_ms = New SqlConnection(mcs)
                Con_ms.Open()
                cmd_ms = New SqlCommand(conn_ms, Con_ms)
                rdr_ms = cmd_ms.ExecuteReader(CommandBehavior.CloseConnection)
                If rdr_ms.Read = True Then

                 


                    Dim NewMDIChild As New Payment()
                    NewMDIChild.Show()


                    Dim payment As Payment = CType(Application.OpenForms("Payment"), Payment)
                    With payment

                      

                            payment.referencono.Text = ""
                            payment.referencono.Text = rdr_ms("RefCode").ToString
                            payment.TxtApplicationNo.Text = rdr_ms("applicationID").ToString
                            payment.TxtAccountNo.Text = rdr_ms("accountno").ToString
                            payment.TxtBusinessName.Text = rdr_ms("businessname").ToString
                            payment.tax_amount.Text = rdr_ms("tax_amt").ToString
                            payment.ctc_amount.Text = rdr_ms("cedula_amt").ToString
                            payment.ctc_fire.Text = rdr_ms("fire_local_amount").ToString
                            payment.TotalAssessmentAmount.Text = rdr_ms("Total_amt").ToString
                        payment.useraccountid.Text = rdr_ms("user_id").ToString


                          

                        If (rdr_ms("payment_status").ToString = "P") Then

                        Else
                            payment.SaveNow.Enabled = False
                            payment.totalpaid.Text = payment.TotalAssessmentAmount.Text
                            payment.assessment_file.Text = rdr_ms("OfficialReceipt").ToString
                            payment.ctc_file.Text = rdr_ms("CTC").ToString
                            payment.TxtTransaction.Text = rdr_ms("PaymentTransactionNo").ToString
                            payment.Button1.Enabled = False
                            payment.Button2.Enabled = False


                        End If


                    End With
                End If

                Con_ms.Close()


            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try



        End If

    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
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
            "business_applicationstatus_dtl.payment_dttime, " & _
            "business_applicationstatus_dtl.payment_status FROM " & _
            "ONLINE.business_application_tbl  " & _
            "INNER JOIN ONLINE.business_applicationstatus_dtl ON ONLINE.business_application_tbl.applicationID = ONLINE.business_applicationstatus_dtl.applicationID " & _
            "WHERE ONLINE.business_applicationstatus_dtl.payment_status='D' order by payment_dttime DESC"

            Con_ms = New SqlConnection(mcs)
            Con_ms.Open()
            cmd_ms = New SqlCommand(conn_ms, Con_ms)
            rdr_ms = cmd_ms.ExecuteReader(CommandBehavior.CloseConnection)
            Do While rdr_ms.Read = True

                DataGrid.Rows.Add(rdr_ms("applicationid"), rdr_ms("RefCode"), rdr_ms("RecordID"), rdr_ms("application_date"), Convert.ToDateTime(rdr_ms("application_date")).ToString("hh:mm tt"), rdr_ms("accountno"), rdr_ms("businessname"), rdr_ms("payment_status"), "VIEW")

            Loop

            Con_ms.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Con_ms.Close()
        End Try
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        FormStatus = False
        Me.Close()
    End Sub
End Class