Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Public Class b2report

    Private Sub b2report_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmb_year.Text = Date.Now.Year
        cmb_year.Items.Add(Date.Now.Year)


        txt_assessed.Clear()
        txt_paid.Clear()


        conn_ms = "SELECT COUNT (DISTINCT(BusinessID)) AS COUNTASSED FROM [BPLS].[BusinessAssessment]  WHERE [AssessmentDate] LIKE N'%" & cmb_year.Text & "%' "

        Con_ms = New SqlConnection(cs1)
        Con_ms.Open()
        cmd_ms = New SqlCommand(conn_ms, Con_ms)
        rdr_ms = cmd_ms.ExecuteReader(CommandBehavior.CloseConnection)
        If rdr_ms.Read = True Then


            txt_assessed.Text = rdr_ms("COUNTASSED").ToString
        End If

        Con_ms.Close()


        conn_ms = "SELECT COUNT (DISTINCT(BusinessID)) AS COUNTASSED FROM [BPLS].[BusinessCollection_Hdr] WHERE [ORDate] LIKE N'%" & cmb_year.Text & "%' "

        Con_ms = New SqlConnection(cs3)
        Con_ms.Open()
        cmd_ms = New SqlCommand(conn_ms, Con_ms)
        rdr_ms = cmd_ms.ExecuteReader(CommandBehavior.CloseConnection)
        If rdr_ms.Read = True Then


            txt_paid.Text = rdr_ms("COUNTASSED").ToString
        End If

        Con_ms.Close()
    End Sub

    Private Sub cmb_year_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_year.SelectedIndexChanged



        txt_assessed.Clear()
        txt_paid.Clear()


        conn_ms = "SELECT COUNT (DISTINCT(BusinessID)) AS COUNTASSED FROM [BPLS].[BusinessAssessment]  WHERE [AssessmentDate] LIKE N'%" & cmb_year.Text & "%' "

        Con_ms = New SqlConnection(cs1)
        Con_ms.Open()
        cmd_ms = New SqlCommand(conn_ms, Con_ms)
        rdr_ms = cmd_ms.ExecuteReader(CommandBehavior.CloseConnection)
        If rdr_ms.Read = True Then

          
            txt_assessed.Text = rdr_ms("COUNTASSED").ToString
        End If

        Con_ms.Close()


        conn_ms = "SELECT COUNT (DISTINCT(BusinessID)) AS COUNTASSED FROM [BPLS].[BusinessCollection_Hdr] WHERE [ORDate] LIKE N'%" & cmb_year.Text & "%' "

        Con_ms = New SqlConnection(cs3)
        Con_ms.Open()
        cmd_ms = New SqlCommand(conn_ms, Con_ms)
        rdr_ms = cmd_ms.ExecuteReader(CommandBehavior.CloseConnection)
        If rdr_ms.Read = True Then


            txt_paid.Text = rdr_ms("COUNTASSED").ToString
        End If

        Con_ms.Close()


    End Sub
End Class