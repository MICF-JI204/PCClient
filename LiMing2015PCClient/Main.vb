
Public Class Form_ORRM
    Private AccLock As Object
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Thread_Connection.Start()
        Thread_GamePad.Start()
        PictureBox_Trejection.Refresh()
    End Sub

    Private Sub Button_Connect_Click(sender As Object, e As EventArgs) Handles Button_Connect.Click
        Global_Var.Com_Ready2Connect = True
    End Sub

    Private Sub Button_Com_Close_Click(sender As Object, e As EventArgs) Handles Button_Com_Close.Click
        Global_Var.Com_IsClosing = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Global_Var.Com_TextMode = Not Global_Var.Com_TextMode
        Log("User:Com Text Mode " & IIf(Global_Var.Com_TextMode, "Enabled", "Disabled"))
        Button1.BackColor = IIf(Global_Var.Com_TextMode, Drawing.Color.LightGreen, Drawing.Color.Red)
    End Sub

    Private Sub Button_ConsoleSend_Click(sender As Object, e As EventArgs) Handles Button_ConsoleSend.Click
        If TextBox_ConsoleSend.Text <> "" Then
            Out_Buffer.Send_Text(TextBox_ConsoleSend.Text)
            TextBox_ConsoleSend.Text = ""
        End If
    End Sub
End Class
