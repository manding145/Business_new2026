Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Public Class ConnectionConfiguration

    Private Sub BtnTest_Click(sender As Object, e As EventArgs) Handles BtnTest.Click
        Con = New SqlConnection(cs)
        Try
            Con.Open()
            MsgBox("Successfully connected to database! ")
            Con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If TxtServer.Text = "" Or TxtUsername.Text = "" Or TxtPassword.Text = "" Then
            MsgBox("Please fill up neccessary fields!")
        Else

            My.Settings.Server = TxtServer.Text
            My.Settings.username = TxtUsername.Text
            My.Settings.password = TxtPassword.Text
            My.Settings.Save()
            MsgBox("Connection configuration successfully saved, Please restart this application. Thank you!")
            TxtServer.Text = My.Settings.Server
            TxtUsername.Text = My.Settings.username
            TxtPassword.Text = My.Settings.password
            cs = "Server=" & My.Settings.Server & ";Database=business_renewal;User ID=" & My.Settings.username & ";Password=" & My.Settings.password & ";"
        End If
    End Sub

    Private Sub ConnectionConfiguration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtServer.Text = My.Settings.Server
        TxtUsername.Text = My.Settings.username
        TxtPassword.Text = My.Settings.password
    End Sub
End Class