Public Class Splash

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub


    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Splash_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Timer1.Start()
        Timer1.Interval = 2600
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        MainMenu.Show()
        'LogIn.Hide()
        Me.Close()
    End Sub

    Private Sub Label1_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs)

    End Sub
End Class