Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Imports Tulpep.NotificationWindow

Public Class LogIn
    Dim drag, drag1 As Boolean
    Private Sub LogIn_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        txt_username.Text = My.Settings.setusername
        txt_password.Text = My.Settings.setpassword

        If My.Settings.setusername = "" And My.Settings.setpassword = "" Then
            With txt_username
                .SelectionStart = .TextLength
                .SelectionLength = 0
                .SelectionStart = 0
                .ScrollToCaret()
            End With

            With txt_password
                .SelectionStart = .TextLength
                .SelectionLength = 0
                .SelectionStart = 0
                .ScrollToCaret()
            End With
            txt_username.ForeColor = Color.Gray
            txt_password.ForeColor = Color.Gray
        Else
            txt_username.ForeColor = Color.Black
            txt_password.ForeColor = Color.Black
        End If


    End Sub

    Private Sub txt_password_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_password.KeyDown
        With txt_password
            If .Text = "Password" And .ForeColor = Color.Gray Then
                If e.KeyCode = Keys.Right Or e.KeyCode = Keys.Left Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.Home Then
                    e.Handled = True
                End If

            End If
        End With
    End Sub

    Private Sub txt_password_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_password.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            Try


                'get prefix
                Con_ms = New SqlConnection(mcs)
                Con_ms.Open()
                conn_ms = "SELECT * FROM ONLINE.m_prefix_attachments where Status='1'"

                cmd_ms = New SqlCommand(conn_ms, Con_ms)
                rdr_ms = cmd_ms.ExecuteReader(CommandBehavior.CloseConnection)
                If rdr_ms.Read = True Then
                    link_prefix = rdr_ms("PrefixURL")
                End If
                Con_ms.Close()


                Con_ms = New SqlConnection(mcs)
                Con_ms.Open()
                conn_ms = "SELECT  * FROM ONLINE.business_users where user_name='" & txt_username.Text & "' and password='" & txt_password.Text & "'"
                cmd_ms = New SqlCommand(conn_ms, Con_ms)
                rdr_ms = cmd_ms.ExecuteReader(CommandBehavior.CloseConnection)
                If rdr_ms.Read = True Then
                    If chckRemMe.Checked = True Then
                        My.Settings.setusername = txt_username.Text
                        My.Settings.setpassword = txt_password.Text
                        My.Settings.Save()
                    Else
                        My.Settings.setusername = ""
                        My.Settings.setpassword = ""
                        My.Settings.Save()
                    End If
                    'userid = rdr("UserID")
                    ''MainMenu.lbl_UserFirstname.Text = rdr("Fullname")
                    'userfullname = rdr("Fullname")
                    lblfname1 = rdr_ms("FirstName").ToString & " " & rdr_ms("MiddleName").ToString & " " & rdr_ms("LastName").ToString
                    lbluserrole1 = rdr_ms("user_position")
                    'link_prefix = rdr("link_prefix")
                    'myemail = rdr("email")

                    'MainForm.lblfname.Text = rdr("Fullname")
                    'MainForm.lbluserrole.Text = rdr("Userlevel")
                    userid = rdr_ms("system_userid")
                    Con_ms.Close()
                    Me.Hide()
                    Splash.ShowDialog()
                Else
                    MsgBox("Invalid Username or Password", vbOKOnly & vbExclamation, "BPLO Online")
                End If

                Con_ms.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
        End If
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        'ConnectionConfiguration.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles BtnLogin.Click

        Try

            'get prefix
            Con_ms = New SqlConnection(mcs)
            Con_ms.Open()
            conn_ms = "SELECT * FROM ONLINE.m_prefix_attachments where Status='1'"

            cmd_ms = New SqlCommand(conn_ms, Con_ms)
            rdr_ms = cmd_ms.ExecuteReader(CommandBehavior.CloseConnection)
            If rdr_ms.Read = True Then
                link_prefix = rdr_ms("PrefixURL")
            End If
            Con_ms.Close()


            Con_ms = New SqlConnection(mcs)
            Con_ms.Open()
            conn_ms = "SELECT  * FROM ONLINE.business_users where user_name='" & txt_username.Text & "' and password='" & txt_password.Text & "'"
            cmd_ms = New SqlCommand(conn_ms, Con_ms)
            rdr_ms = cmd_ms.ExecuteReader(CommandBehavior.CloseConnection)
            If rdr_ms.Read = True Then
                If chckRemMe.Checked = True Then
                    My.Settings.setusername = txt_username.Text
                    My.Settings.setpassword = txt_password.Text
                    My.Settings.Save()
                Else
                    My.Settings.setusername = ""
                    My.Settings.setpassword = ""
                    My.Settings.Save()
                End If
                'userid = rdr("UserID")
                ''MainMenu.lbl_UserFirstname.Text = rdr("Fullname")
                'userfullname = rdr("Fullname")
                lblfname1 = rdr_ms("FirstName").ToString & " " & rdr_ms("MiddleName").ToString & " " & rdr_ms("LastName").ToString
                lbluserrole1 = rdr_ms("user_position")
                'link_prefix = rdr("link_prefix")
                'myemail = rdr("email")

                'MainForm.lblfname.Text = rdr("Fullname")
                'MainForm.lbluserrole.Text = rdr("Userlevel")
                userid = rdr_ms("system_userid")
                Con_ms.Close()
                Me.Hide()
                Splash.ShowDialog()
            Else
                MsgBox("Invalid Username or Password", vbOKOnly & vbExclamation, "BPLO Online")
            End If

            Con_ms.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub txt_password_MouseDown(sender As Object, e As MouseEventArgs) Handles txt_password.MouseDown
        drag1 = True
        With txt_password
            If .Text = "Password" And .ForeColor = Color.Gray Then
                .SelectionStart = .TextLength
                .SelectionLength = 0
                .SelectionStart = 0
                .ScrollToCaret()

            End If

        End With
    End Sub

    Private Sub txt_password_MouseEnter(sender As Object, e As EventArgs) Handles txt_password.MouseEnter

    End Sub

    Private Sub txt_password_MouseMove(sender As Object, e As MouseEventArgs) Handles txt_password.MouseMove
        If drag1 Then
            With txt_password
                If .Text = "Password" And .ForeColor = Color.Gray Then
                    .Select(0, 0)
                End If
            End With


        End If
    End Sub

    Private Sub txt_password_TextChanged(sender As Object, e As EventArgs) Handles txt_password.TextChanged
        With txt_password
            If .Text = "" Then
                .Text = "Password"
                .ForeColor = Color.Gray
            End If
            If .Text = "Password" And .ForeColor = Color.Gray Then
                .ShortcutsEnabled = False
                .UseSystemPasswordChar = False
            Else
                .ShortcutsEnabled = True
                .UseSystemPasswordChar = True
            End If

            If .TextLength > 8 Then
                If StrReverse(StrReverse(.Text).Remove(8)) = "Password" Then
                    .Text = .Text.Remove(.TextLength - 8)
                    .ForeColor = Color.Black
                    .SelectionStart = .TextLength
                    .ScrollToCaret()
                    .UseSystemPasswordChar = True
                End If
            End If
        End With
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        'ConnectionConfiguration.ShowDialog()
    End Sub

    Private Sub txt_username_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_username.KeyDown
        With txt_username

            If .Text = "Username" And .ForeColor = Color.Gray Then
                If e.KeyCode = Keys.Right Or e.KeyCode = Keys.Left Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.Home Then
                    e.Handled = True
                End If

            End If
        End With
    End Sub

    Private Sub txt_username_MouseDown(sender As Object, e As MouseEventArgs) Handles txt_username.MouseDown
        drag = True
        With txt_username
            If .Text = "Username" And .ForeColor = Color.Gray Then
                .SelectionStart = .TextLength
                .SelectionLength = 0
                .SelectionStart = 0
                .ScrollToCaret()

            End If

        End With
    End Sub

    Private Sub txt_username_MouseMove(sender As Object, e As MouseEventArgs) Handles txt_username.MouseMove
        If drag Then
            With txt_username
                If .Text = "Username" And .ForeColor = Color.Gray Then
                    .Select(0, 0)
                End If
            End With


        End If
    End Sub

    Private Sub txt_username_TextChanged(sender As Object, e As EventArgs) Handles txt_username.TextChanged
        With txt_username
            If .Text = "" Then
                .Text = "Username"
                .ForeColor = Color.Gray
            End If
            If .Text = "Username" And .ForeColor = Color.Gray Then
                .ShortcutsEnabled = False
            Else
                .ShortcutsEnabled = True
            End If

            If .TextLength > 8 Then
                If StrReverse(StrReverse(.Text).Remove(8)) = "Username" Then
                    .Text = .Text.Remove(.TextLength - 8)
                    .ForeColor = Color.Black
                    .SelectionStart = .TextLength
                    .ScrollToCaret()
                End If
            End If
        End With
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        ConnectionConfiguration.ShowDialog()
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)

    End Sub
End Class