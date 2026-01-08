Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Public Class UpdateRPT
    Public cancelledTDNID As Integer
    Public currentTDNID As Integer
    Private Sub UpdateRPT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGrid.Rows.Clear()

        Try
          



            conn_ms = "SELECT rpt_applicationid, TDN_no " _
            & " FROM ONLINE.rpt_application WHERE year(Application_timedt)= 2025 and IsPaid is null and (assess_status='V' OR assess_status ='DONE') and payment_status !='V' ORDER BY rpt_applicationid DESC"
            Con_ms = New SqlConnection(mcs)
            Con_ms.Open()
            cmd_ms = New SqlCommand(conn_ms, Con_ms)
            rdr_ms = cmd_ms.ExecuteReader(CommandBehavior.CloseConnection)
            Do While rdr_ms.Read = True



                Dim inputString As String = rdr_ms("TDN_no")
                Dim pattern As String = "^12-0(.+)"

                Dim match As Match = Regex.Match(inputString, pattern)

                If match.Success Then

                    Dim remainingPart As String = match.Groups(1).Value


                    ''conn_ms1 = "Select  DISTINCT(REC.TDN.tdn), TOS.PaymentPosting.PayYear from REC.TDN inner join TOS.PaymentPosting ON tos.PaymentPosting.TDNId = REC.TDN.TDNID  where  REC.TDN.tdn lIKE N'%" & remainingPart & "%' and REC.TDN.RevisionYear = 2012 AND TOS.PaymentPosting.PayYear =2025"
                    conn_ms1 = "SELECT DISTINCT ( REC.TDN.tdn ), REC.TDN.TDNID, IsCancelled " & _
                    "FROM REC.TDN   " & _
                    "WHERE REC.TDN.tdn LIKE N'%" & remainingPart & "%' AND RevisionYear ='2012'"
                    Con_ms1 = New SqlConnection(mcs1)
                    Con_ms1.Open()
                    cmd_ms1 = New SqlCommand(conn_ms1, Con_ms1)
                    rdr_ms1 = cmd_ms1.ExecuteReader(CommandBehavior.CloseConnection)

                    If rdr_ms1.Read = True Then

                        If rdr_ms1("IsCancelled") = 0 Then

                            cancelledTDNID = rdr_ms1("TDNID")
                            currentTDNID = rdr_ms1("TDNID")


                        Else
                           
                            'GO TO TDN NO
                            Dim looptrue As Integer = 0
                            cancelledTDNID = rdr_ms1("TDNID")
                            currentTDNID = rdr_ms1("TDNID")


                            Do While looptrue = 0

                                conn_ms2 = "SELECT * " & _
                                   "FROM REC.TDNHistory   " & _
                                   "WHERE REC.TDNHistory.CancelledTDNID ='" & cancelledTDNID & "'"
                                Con_ms2 = New SqlConnection(mcs1)
                                Con_ms2.Open()
                                cmd_ms2 = New SqlCommand(conn_ms2, Con_ms2)
                                rdr_ms2 = cmd_ms2.ExecuteReader(CommandBehavior.CloseConnection)
                                If rdr_ms2.Read = True Then



                                    cancelledTDNID = rdr_ms2("CurrentTDNID")

                                    conn_ms4 = "SELECT DISTINCT(REC.TDN.tdn), REC.TDN.TDNID as TDNID, IsCancelled " & _
                                      "FROM REC.TDN   " & _
                                      "WHERE REC.TDN.TDNID = '" & cancelledTDNID & "'"
                                    Con_ms4 = New SqlConnection(mcs1)
                                    Con_ms4.Open()
                                    cmd_ms4 = New SqlCommand(conn_ms4, Con_ms4)
                                    rdr_ms4 = cmd_ms4.ExecuteReader(CommandBehavior.CloseConnection)
                                    If rdr_ms4.Read = True Then
                                        If rdr_ms4("IsCancelled") = 0 Then
                                            looptrue = 1
                                            'stop 
                                        Else
                                            cancelledTDNID = rdr_ms4("TDNID")
                                            looptrue = 0

                                        End If

                                    End If
                                    Con_ms4.Close()

                                Else
                                    MsgBox("NOT FOUND")
                                End If
                                Con_ms4.Close()
                            Loop


                        End If

                        ''search from payment posting
                        conn_ms2 = "Select TOS.PaymentPosting.PayYear from  tos.PaymentPosting where tos.PaymentPosting.TDNId ='" & cancelledTDNID & "' AND TOS.PaymentPosting.PayYear =2025"
                        Con_ms2 = New SqlConnection(mcs1)
                        Con_ms2.Open()
                        cmd_ms2 = New SqlCommand(conn_ms2, Con_ms2)
                        rdr_ms2 = cmd_ms2.ExecuteReader(CommandBehavior.CloseConnection)
                        If rdr_ms2.Read = True Then



                            ''Update
                            Con_ms3 = New SqlConnection(mcs)
                            Con_ms3.Open()
                            conn_ms3 = "UPDATE ONLINE.rpt_application set IsPaid='1' , payment_status ='V' WHERE rpt_applicationid='" & rdr_ms("rpt_applicationid") & "'"
                            cmd_ms3 = New SqlCommand(conn_ms3, Con_ms3)
                            cmd_ms3.ExecuteNonQuery()
                            Con_ms3.Close()

                        Else
                            ''Do Nothing
                        End If
                        Con_ms2.Close()





                    End If
                    Con_ms1.Close()






                    Else

                    conn_ms3 = "Select  DISTINCT(REC.TDN.tdn), TOS.PaymentPosting.PayYear from REC.TDN inner join TOS.PaymentPosting ON tos.PaymentPosting.TDNId = REC.TDN.TDNID  where  REC.TDN.tdn ='" & rdr_ms("TDN_no") & "' AND TOS.PaymentPosting.PayYear =2025"
                    Con_ms3 = New SqlConnection(mcs1)
                    Con_ms3.Open()
                    cmd_ms3 = New SqlCommand(conn_ms3, Con_ms3)
                    rdr_ms3 = cmd_ms3.ExecuteReader(CommandBehavior.CloseConnection)
                    If rdr_ms3.Read = True Then



                        ''Update
                        Con_ms2 = New SqlConnection(mcs)
                        Con_ms2.Open()
                        conn_ms2 = "UPDATE ONLINE.rpt_application set IsPaid='1', payment_status ='V' WHERE rpt_applicationid='" & rdr_ms("rpt_applicationid") & "'"
                        cmd_ms2 = New SqlCommand(conn_ms2, Con_ms2)
                        cmd_ms2.ExecuteNonQuery()
                        Con_ms2.Close()

                    Else
                        ''Do Nothing
                    End If
                    Con_ms3.Close()


                    End If



              



            Loop

            Con_ms.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Con_ms.Close()
        End Try


    End Sub
End Class