Public Class FrmNotificationControl

    Private Sub FrmNotificationControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If MainMenu.Timer2.Enabled Then
            lblstatus.Text = "Active"
            btncontrol.Text = "Deactivate"
        Else
            lblstatus.Text = "Deactivated"
            btncontrol.Text = "Activate"
        End If
    End Sub

    Private Sub btncontrol_Click(sender As Object, e As EventArgs) Handles btncontrol.Click
        If lblstatus.Text = "Active" Then
            MainMenu.Timer2.Enabled = False
            Me.Close()
            MsgBox("Notification has been deactivated")
        Else
            MainMenu.Timer2.Enabled = True
            Me.Close()
            MsgBox("Notification has been activated")
        End If
    End Sub
End Class