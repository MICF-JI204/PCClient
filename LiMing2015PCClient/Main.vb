
Public Class Form_ORRM

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Thread_Connection.Start()
        Thread_GamePad.Start()
        PictureBox_Trejection.Refresh()
    End Sub

    Private Sub Button_Connect_Click(sender As Object, e As EventArgs) Handles Button_Connect.Click
        Global_Var.Com_Ready2Connect = True
    End Sub
End Class
