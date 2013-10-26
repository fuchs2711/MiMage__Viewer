Public Class FileInfo

    Private Sub FileInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label1.Text = "You selected this file: " & Form1.PictureBox1.ImageLocation & vbCrLf & _
        "The filename is: " & System.IO.Path.GetFileName(Form1.PictureBox1.ImageLocation) & vbCrLf & _
        "Located in: " & System.IO.Path.GetDirectoryName(Form1.PictureBox1.ImageLocation) & vbCrLf & _
        "It has the following extension: " & System.IO.Path.GetExtension(Form1.PictureBox1.ImageLocation) & vbCrLf & _
        "The file was created on " & System.IO.File.GetCreationTime(Form1.PictureBox1.ImageLocation) & vbCrLf & _
        "The file was last written to on " & System.IO.File.GetLastWriteTime(Form1.PictureBox1.ImageLocation)
    End Sub
End Class