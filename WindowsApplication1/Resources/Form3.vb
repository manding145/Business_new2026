Public Class Form3

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WebBrowser1.Navigate("http://sandbox.pcnetwork.com.ph/health-certificate/includes/mailer/index.php")


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        WebBrowser1.Document.GetElementById("reservationCode").SetAttribute("Value", "luceroronald93@gmail.com")
    End Sub
End Class