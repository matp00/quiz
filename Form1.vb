Public Class Form1
    Public amountOfPicturesToDisplay = 10
    Dim licznik As Integer = 0
    Dim photos As ListBox.ObjectCollection = Form2.filesListBox.Items
    Public amountOfPicturesInFolder As Integer = photos.Count
    Public results As New Dictionary(Of String, Boolean)
    Dim increment As Integer = 0
    Dim listOfPicturesToDisplay As New List(Of String)
    Dim listOfRepeats As New List(Of Integer)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rand10Pictures()
        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = amountOfPicturesToDisplay
        ProgressBar1.Step = amountOfPicturesToDisplay / amountOfPicturesToDisplay
        ProgressBar1.PerformStep()
        nextPicture()



    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Timer1.Stop()
        Dim filePath = listOfPicturesToDisplay.Item(licznik - 1).ToString
        If filePath.Contains("ng") Then
            results.Add(filePath, True)
        Else
            results.Add(filePath, False)
        End If
        nextPicture()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Timer1.Stop()
        Dim filePath = listOfPicturesToDisplay.Item(licznik - 1).ToString
        If filePath.Contains("valid") Then
            results.Add(filePath, True)
        Else
            results.Add(filePath, False)
        End If
        nextPicture()
    End Sub

    Private Sub nextPicture()
        ProgressBar1.PerformStep()
        If licznik = amountOfPicturesToDisplay Then
            Timer1.Enabled = False
            Me.Hide()
            Form3.Show()
        Else
            PictureBox1.Image = Image.FromFile(listOfPicturesToDisplay.Item(licznik).ToString)
            licznik += 1
            resetTimer()
        End If
    End Sub

    Private Sub rand10Pictures()
        Do While listOfPicturesToDisplay.Count < amountOfPicturesToDisplay
            Dim intResult As Integer
            Randomize()
            intResult = Int((amountOfPicturesInFolder * Rnd()))
            If Not (listOfRepeats.Contains(intResult)) Then
                listOfPicturesToDisplay.Add(photos.Item(intResult))
                listOfRepeats.Add(intResult)
            End If
        Loop
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        clock.Text = Val(clock.Text) - 1
        If clock.Text = "0" Then
            Timer1.Stop()
            clock.Text = "10"
            results.Add(listOfPicturesToDisplay.Item(licznik - 1).ToString, False)
            nextPicture()
        End If
    End Sub

    Private Sub resetTimer()
        Timer1.Start()
        clock.Text = "10"
    End Sub

End Class
