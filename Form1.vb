Public Class Form1
    Dim licznik As Integer = 0
    Dim photos As ListBox.ObjectCollection = Form2.filesListBox.Items
    Public results As New Dictionary(Of String, Boolean)


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        nextPicture()

    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim filePath = photos.Item(licznik - 1).ToString
        If filePath.Contains("ng") Then
            results.Add(filePath, True)
        Else
            results.Add(filePath, False)
        End If
        nextPicture()


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim filePath = photos.Item(licznik - 1).ToString
        If filePath.Contains("valid") Then
            results.Add(filePath, True)
        Else
            results.Add(filePath, False)
        End If
        nextPicture()

    End Sub

    Private Sub nextPicture()
        If licznik = photos.Count Then
            Me.Hide()
            Form3.Show()
            licznik = 0
        End If

        PictureBox1.Image = Image.FromFile(photos.Item(licznik).ToString)
        licznik += 1
    End Sub



End Class
