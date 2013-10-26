Public Class Form1

    Dim picdir As String
    Public picfile As String

    Private Sub DateiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateiToolStripMenuItem.Click
        Dim strFileNameAndPath As String = OpenFile()

        If (strFileNameAndPath = "") Then
            MsgBox("You did not select a file!")
        Else
            'MsgBox("You selected this file: " & strFileNameAndPath & vbCrLf & _
            '"The filename is: " & System.IO.Path.GetFileName(strFileNameAndPath) & vbCrLf & _
            '"Located in: " & System.IO.Path.GetDirectoryName(strFileNameAndPath) & vbCrLf & _
            '"It has the following extension: " & System.IO.Path.GetExtension(strFileNameAndPath) & vbCrLf & _
            '"The file was created on " & System.IO.File.GetCreationTime(strFileNameAndPath) & vbCrLf & _
            '"The file was last written to on " & System.IO.File.GetLastWriteTime(strFileNameAndPath) _
            ')

            PictureBox1.ImageLocation = strFileNameAndPath
            picdir = System.IO.Path.GetDirectoryName(strFileNameAndPath)
            picfile = strFileNameAndPath.Replace(System.IO.Path.GetDirectoryName(strFileNameAndPath) & "\", "")

            Dim di As New IO.DirectoryInfo(picdir)
            Dim diar1 As IO.FileInfo() = di.GetFiles()
            Dim dra As IO.FileInfo

            For Each dra In diar1
                ListBox1.Items.Add(dra)
            Next

            Me.Text = picdir & " | " & picfile

        End If
    End Sub

    Public Function OpenFile() As String

        Dim strFileName = ""

        Dim fileDialogBox As New OpenFileDialog()

        fileDialogBox.Filter = "Image Files (*.png;*.bmp;*.jpg;*.gif)|*.png;*.bmp;*.jpg;*.gif|" _
            & "All Files(*.*)|"

        fileDialogBox.FilterIndex = 1

        'fileDialogBox.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal)
        fileDialogBox.InitialDirectory = "D:\Bilder\b"

        If (fileDialogBox.ShowDialog() = DialogResult.OK) Then
            strFileName = fileDialogBox.FileName
        End If

        Return strFileName
    End Function

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        PictureBox1.ImageLocation = picdir & "\" & ListBox1.SelectedItem.ToString
    End Sub

    Private Sub FileInfoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileInfoToolStripMenuItem.Click
        FileInfo.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            ListBox1.SelectedIndex = ListBox1.SelectedIndex - 1
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            ListBox1.SelectedIndex = ListBox1.SelectedIndex + 1
        Catch ex As Exception

        End Try
    End Sub
End Class
