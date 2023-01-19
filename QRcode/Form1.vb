Public Class Form1

    Dim siz, url, path As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If RadioButton1.Checked = True Then siz = "120x120"
        If RadioButton2.Checked = True Then siz = "160x160"
        If RadioButton3.Checked = True Then siz = "256x256"
        url = "https://chart.googleapis.com/chart?chs=" & siz & "&cht=qr&chl=%22" & TextBox1.Text & "%22"
        WebBrowser1.Navigate(url)
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SaveFileDialog1.DefaultExt = ".png"
        SaveFileDialog1.ShowDialog()
        Try
            My.Computer.Network.DownloadFile(url, path)
        Catch ex As Exception
            If path = "" Then Exit Sub
            Kill(path)
            My.Computer.Network.DownloadFile(url, path)
        End Try
    End Sub

    Private Sub SaveFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk
        path = SaveFileDialog1.FileName
    End Sub
End Class
