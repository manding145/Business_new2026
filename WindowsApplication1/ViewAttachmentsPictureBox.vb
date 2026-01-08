
Public Class ViewAttachmentsPictureBox

    Private _originalSize As Size = Nothing
    Private _scale As Single = 1
    Private _scaleDelta As Single = 0.0005
    Private _ratWidth, _ratHeight As Double
    Private Enum execOpt
        OLECMDEXECOPT_DODEFAULT = 0
        OLECMDEXECOPT_PROMPTUSER = 1
        OLECMDEXECOPT_DONTPROMPTUSER = 2
        OLECMDEXECOPT_SHOWHELP = 3
    End Enum
    Private Sub ViewAttachmentsPictureBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage

        'init this from here or a method depending on your needs
        If PictureBox1.Image IsNot Nothing Then
            _ratWidth = PictureBox1.Image.Width / PictureBox1.Image.Height
            _ratHeight = PictureBox1.Image.Height / PictureBox1.Image.Width
            PictureBox1.Size = Panel1.Size
            _originalSize = Panel1.Size
        End If
    End Sub
    Private Sub Form_MouseWheel(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseWheel

        'if very sensitive mouse, change 0.00005 to something even smaller   
        _scaleDelta = Math.Sqrt(PictureBox1.Width * PictureBox1.Height) * 0.00005

        If e.Delta < 0 Then
            _scale -= _scaleDelta
        ElseIf e.Delta > 0 Then
            _scale += _scaleDelta
        End If

        If e.Delta <> 0 Then _
        PictureBox1.Size = New Size(CInt(Math.Round((_originalSize.Width * _ratWidth) * _scale)), _
                                    CInt(Math.Round((_originalSize.Height * _ratHeight) * _scale)))

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim bmp As Bitmap = New Bitmap(PictureBox1.Image)
        bmp.RotateFlip(RotateFlipType.Rotate90FlipNone)
        PictureBox1.Image = bmp
    End Sub
End Class