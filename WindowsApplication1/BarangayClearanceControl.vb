
Imports System.Data.SqlClient
Imports System.IO
Public Class BarangayClearanceControl
    Public mBarangayID, applicationID_search, mBIN, mowneraddress, mbusinessID, mBusinessname, mAccountNo, mPhone, mBusinessAddress, mBusinessLineDescription, myear, mEmployees, mOwnerName, mBusinessNatureDescription, mBarangayName, mAmount, mORNumber, mDatePaid, mBrgy As String
    Public mpermitno As Integer
    Public permit_stat As String
    Public temp_applicationid As String

    Private Sub Rb_FinalPermit_CheckedChanged(sender As Object, e As EventArgs) Handles Rb_FinalPermit.CheckedChanged

    End Sub

    Private Sub BarangayClearanceControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.Value = Date.Now
        'cmb_signatories.Text = "GEMAFIEL R. GASPAY"
        txt_position.Text = "PUNONG BARANGAY"
        'Call LoadMe()
        Try


            conn = "SELECT * from business_barangay WHERE BarangayId='" & mBarangayID & "'"
            Con = New SqlConnection(cs)
            Con.Open()
            cmd = New SqlCommand(conn, Con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Do While rdr.Read = True
                cmb_signatories.Items.Add(rdr("PunongBarangay")).ToString()
            Loop
            Con.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub BtnPreview_Click(sender As Object, e As EventArgs) Handles BtnPreview.Click

        Try

            Dim mytimestamp = DateTime.Now.ToString("yyyy-MM-dd")
            'SAVE TO BPLS DATABASE FOR BACK UP
            'get this year last permit no
            Dim permit_no As String

            '//check current year
            conn = "Select * from business_brgyclearance_status where Year= '" & Date.Now.Year & "' order by  Year DESC, PermitNo DESC"
            Con = New SqlConnection(cs)
            Con.Open()
            cmd = New SqlCommand(conn, Con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If rdr.Read = True Then


                conn = "Select * from business_brgyclearance_status where Year = '" & Date.Now.Year & "' and BusinessID= '" & mbusinessID & "' "
                Con2 = New SqlConnection(cs)
                Con2.Open()
                cmd2 = New SqlCommand(conn, Con2)
                rdr2 = cmd2.ExecuteReader(CommandBehavior.CloseConnection)
                If rdr2.Read = True Then

                    MsgBox("This Business has an existing barangay clearance for this year!")
                    Con2.Close()
                    Con.Close()
                    Exit Sub
                Else

                    permit_no = rdr("PermitNo") + 1

                    conn = "Select * from business_brgyclearance_status where Year = '" & Date.Now.Year & "' and PermitNo='" & permit_no & "'"
                    Con6 = New SqlConnection(cs)
                    Con6.Open()
                    cmd6 = New SqlCommand(conn, Con6)
                    rdr6 = cmd6.ExecuteReader(CommandBehavior.CloseConnection)
                    If rdr6.Read = True Then

                        MsgBox("This application has already taken in Database!, Contact your system administrator.")

                        Con6.Close()
                        Con.Close()
                        Con2.Close()
                        Exit Sub

                    End If
                    Con6.Close()

                    Dim img As Image = PictureBox1.Image
                    Dim ms As New MemoryStream()
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg) ' Adjust format as needed
                    Dim imgBytes As Byte() = ms.ToArray()


                    'insert to business_permit_status as new
                    Con2 = New SqlConnection(cs)
                    Con2.Open()
                    conn = "INSERT INTO business_brgyclearance_status (OwnerName, BusinessLine, BusinessName, BusinessAddress, Signatory, BarangayCaptainName, Barangay, AccountNo, BusinessID, DatePending, Status, DatePrinted, PermitNo, UserID, Year) " _
                    & "VALUES ('" & mOwnerName & "', '" & mBusinessLineDescription & "','" & mBusinessname & "','" & mBusinessAddress & "',  @Signatory,'" & cmb_signatories.Text & "', '" & mBarangayName & "', '" & txt_AccountNo.Text & "', '" & mbusinessID & "', '" & mytimestamp & "', 'D' , '" & mytimestamp & "', '" & permit_no & "', '" & userid & "', '" & Date.Now.Year & "')"
                    cmd2 = New SqlCommand(conn, Con2)
                    cmd2.Parameters.AddWithValue("@Signatory", imgBytes)
                    cmd2.ExecuteNonQuery()
                    Con2.Close()
                    txt_permitNumber.Text = permit_no

                    'get lasst applicationid
                    Con2 = New SqlConnection(cs)
                    Con2.Open()
                    conn = "SELECT * FROM business_brgyclearance_status ORDER BY permitappid DESC LIMIT 1"
                    cmd2 = New SqlCommand(conn, Con2)
                    rdr2 = cmd2.ExecuteReader(CommandBehavior.CloseConnection)
                    If rdr2.Read = True Then

                        temp_applicationid = rdr2("permitappid")

                    End If
                    Con2.Close()

                    txt_permitNumber.Text = permit_no
                    MsgBox("Barangay Clearance successfully generated!", vbOKOnly & vbInformation, "Business Renewal")

                End If

            Else
                'if not exist then reset to 1

                permit_no = "1"

                conn = "Select * from business_brgyclearance_status where Year = '" & Date.Now.Year & "' and PermitNo='" & permit_no & "'"
                Con6 = New SqlConnection(cs)
                Con6.Open()
                cmd6 = New SqlCommand(conn, Con6)
                rdr6 = cmd6.ExecuteReader(CommandBehavior.CloseConnection)
                If rdr6.Read = True Then

                    MsgBox("This application has already taken in Database!, Contact your system administrator.")

                    Con6.Close()
                    Con.Close()
                    Con2.Close()
                    Exit Sub

                End If
                Con6.Close()

                Dim img As Image = PictureBox1.Image
                Dim ms As New MemoryStream()
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg) ' Adjust format as needed
                Dim imgBytes As Byte() = ms.ToArray()


                'insert to business_permit_status as new
                Con2 = New SqlConnection(cs)
                Con2.Open()
                conn = "INSERT INTO business_brgyclearance_status (Signatory, BarangayCaptainName, Barangay, AccountNo, BusinessID, DatePending, Status, DatePrinted, PermitNo, UserID, Year) " _
                & "VALUES (@Signatory,'" & cmb_signatories.Text & "', '" & mBarangayName & "', '" & txt_AccountNo.Text & "', '" & mbusinessID & "', '" & mytimestamp & "', 'D' , '" & mytimestamp & "', '" & permit_no & "', '" & userid & "', '" & Date.Now.Year & "')"
                cmd2 = New SqlCommand(conn, Con2)
                cmd2.Parameters.AddWithValue("@Signatory", imgBytes)
                cmd2.ExecuteNonQuery()
                Con2.Close()
                txt_permitNumber.Text = permit_no

                'get lasst applicationid
                Con2 = New SqlConnection(cs)
                Con2.Open()
                conn = "SELECT * FROM business_brgyclearance_status ORDER BY permitappid DESC LIMIT 1"
                cmd2 = New SqlCommand(conn, Con2)
                rdr2 = cmd2.ExecuteReader(CommandBehavior.CloseConnection)
                If rdr2.Read = True Then

                    temp_applicationid = rdr2("permitappid")

                End If
                Con2.Close()

                txt_permitNumber.Text = permit_no
                MsgBox("Barangay Clearance successfully generated!", vbOKOnly & vbInformation, "Business Renewal")


            End If


            If permit_stat = "WalkIn" Then

            ElseIf permit_stat = "Online" Then

                Con_ms1 = New SqlConnection(mcs)
                Con_ms1.Open()
                conn = "UPDATE business_applicationstatus_dtl set IsPrinted_BrgyClearance = '1', Printed_dttime_BrgyClearance = '" & mytimestamp & "' WHERE applicationID='" & applicationID_search & "'"
                cmd_ms1 = New SqlCommand(conn, Con_ms1)
                cmd_ms1.ExecuteNonQuery()
                Con_ms1.Close()

            End If



            ''PrintBarangayClearance
            PrintBarangayPermit.ShowDialog()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub BtnPreview1_Click(sender As Object, e As EventArgs) Handles BtnPreview1.Click

        PrintBarangayPermit.ShowDialog()

    End Sub
End Class