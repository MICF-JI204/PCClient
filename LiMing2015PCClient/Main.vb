
Public Class Form_ORRM
    Private AccLock As Object


    Private Sub Form_ORRM_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim logfile As New System.IO.StreamWriter("LastLog.log")
        Button1.Text = IIf(Global_Var.Com_TextMode, "Text Mode", "CMD Mode")
        Button1.BackColor = IIf(Global_Var.Com_TextMode, Drawing.Color.LightGreen, Drawing.Color.Red)
        logfile.Write(TextBox_Console_Log.Text)
        logfile.Close()
        Thread_Connection.Abort()
        Thread_GamePad.Abort()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Thread_Connection.Start()
        Thread_GamePad.Start()
        PictureBox_Trejection.Refresh()
        Log("Application Running Under" & vbCrLf & Application.StartupPath)

        Log(Global_Var.Get_ComCMD_Code("GamePad_U_Down"))
        Log(Global_Var.Get_ComCMD_Name(Global_Var.Com_CMD.GamePad_B_Down))
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
        Button1.Text = IIf(Global_Var.Com_TextMode, "Text Mode", "CMD Mode")
        Button1.BackColor = IIf(Global_Var.Com_TextMode, Drawing.Color.LightGreen, Drawing.Color.Red)
    End Sub

    Private Sub Button_ConsoleSend_Click(sender As Object, e As EventArgs) Handles Button_ConsoleSend.Click
        If TextBox_ConsoleSend.Text <> "" Then
            If Global_Var.Com_TextMode Then
                Out_Buffer.Send_Text(TextBox_ConsoleSend.Text)
                TextBox_ConsoleSend.Text = ""
            Else
                Dim inputstr As String = TextBox_ConsoleSend.Text
                Dim strs() As String = inputstr.Trim().Split(" ")
                If strs(0).StartsWith(":") Then '特定指令

                Else
                    Dim datastr() As String = strs(0).Split(",")
                    Dim data(datastr.GetUpperBound(0)) As Byte
                    For i As Integer = 0 To datastr.GetUpperBound(0)
                        If datastr(i).StartsWith("$") Then '内部变量（常量）
                        End If
                        datastr(i) = datastr(i).ToUpper
                        datastr(i) = datastr(i).Replace("&H", "")
                        datastr(i) = datastr(i).Replace("0X", "")
                        datastr(i) = "&H" & datastr(i)
                        If Not IsNumeric(datastr(i)) Then
                            Log("User/CMD_Mode_Send:" & (i + 1) & " Is Not a Number")
                            GoTo WrongInput
                        End If
                        Try
                            data(i) = Val(datastr(i))
                        Catch ex As ArgumentException
                            Log("User/CMD_Mode_Send:" & (i + 1) & " Illeagal Argument")
                            GoTo WrongInput
                        Catch ex As OverflowException
                            Log("User/CMD_Mode_Send:" & (i + 1) & " Argument Overflowed")
                            data(i) = Val(datastr(i)) And &HFF
                        End Try
                    Next
                    Dim t As New Out_Msg
                    Try
                        t.Set_OP(data(0))
                        t.Set_Priority(data(1))
                        t.Set_Data(data(2), data(3), data(4), data(5))
                    Catch ex As Exception
                        Log("User/CMD_Mode_Send:Not Enough Arguments")
                        GoTo WrongInput
                    End Try
                    Out_Buffer.Enque(t)
                End If
            End If
        End If
        Return
WrongInput:
        Return

    End Sub
End Class
