Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Public Class Appointment

    Private Sub Appointment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Con_ms = New SqlConnection(mcs)
        Con_ms.Open()

        conn_ms = "SELECT * from ONLINE.appointment_tbl WHERE CAST(datetime AS DATE) = '" + DateTime.Now.ToString("yyyy-MM-dd") + "'"



        cmd_ms = New SqlCommand(conn_ms, Con_ms)
        rdr_ms = cmd_ms.ExecuteReader(CommandBehavior.CloseConnection)
        Do While rdr_ms.Read = True

            DataGrid.Rows.Add(rdr_ms("id"), rdr_ms("datetime"), rdr_ms("email"), rdr_ms("refno"))

        Loop

        Con_ms.Close()
    End Sub
End Class