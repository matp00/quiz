Public Class Form3
    Dim score As Integer = 0
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getResults()
        Label1.Text = Label1.Text + score.ToString + "/" + Form1.results.Count.ToString
    End Sub

    Sub getResults()
        For Each result As KeyValuePair(Of String, Boolean) In Form1.results
            If result.Value = True Then
                score += 1
            End If
        Next
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim file As System.IO.StreamWriter
            file = My.Computer.FileSystem.OpenTextFileWriter(OpenFileDialog1.FileName, True)
            file.WriteLine(Form2.TextBox1.Text + " " + Form2.TextBox2.Text + " " + score.ToString)
            file.Close()
            Me.Close()
            Application.Exit()
        End If
    End Sub
End Class