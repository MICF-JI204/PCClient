
Public Class Form_ORRM

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Thread_Connection.Start()
        Thread_GamePad.Start()
        PictureBox_Trejection.Refresh()
    End Sub

  

    Private Sub PictureBox_Trejection_Click(sender As Object, e As EventArgs) Handles PictureBox_Trejection.Click

    End Sub
End Class
