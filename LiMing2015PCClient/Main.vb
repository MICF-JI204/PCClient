
Public Class Form_ORRM
    Private AccLock As Object


    Private Sub Form_ORRM_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim logfile As New System.IO.StreamWriter("LastLog.log")
        logfile.Write(TextBox_Console_Log.Text)
        logfile.Close()
        Thread_Connection.Abort()
        Thread_GamePad.Abort()
        Thread_Loader_Unload.Abort()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Thread_Connection.Start()
        Thread_GamePad.Start()
        Thread_Loader_Unload.Start()
        PictureBox_Trejection.Refresh()
        Log("Application Running Under" & vbCrLf & Application.StartupPath)
        Log("System Begins to function!")
        Button1.Text = IIf(Global_Var.Com_TextMode, "Text Mode", "CMD Mode")
        Button1.BackColor = IIf(Global_Var.Com_TextMode, Drawing.Color.LightGreen, Drawing.Color.Red)
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
                            datastr(i).Replace("$", "")
                            data(i) = Global_Var.Get_ComCMD_Code(datastr(i))
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

                    Try
                        Dim t As New Out_Msg(data(0), data(1), data(2), data(3), data(4), data(5), True)
                        Out_Buffer.Enque(t)
                    Catch ex As Exception
                        Log("User/CMD_Mode_Send:Not Enough Arguments")
                        GoTo WrongInput
                    End Try
                End If
            End If
        End If
        Return
WrongInput:
        Return

    End Sub

    Private Sub Button_Loader_Release_Click(sender As Object, e As EventArgs) Handles Button_Loader_Unload.Click
        Button_Loader_Unload.Enabled = False
        Global_Var.Robot_Loader_State = 0
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Timer_Game.Start()
        Timer_Suspend.Stop()
        Label_Timer_Suspend.Visible = False
        Label_Timer_Suspend.Text = Global_Var.Game_Suspend_Time

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Timer_Game.Stop()
        Label_Timer_Suspend.Text = Global_Var.Game_Suspend_Time
        Label_Timer_Suspend.Visible = True
        Timer_Suspend.Start()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Timer_Game.Stop()
        Timer_Suspend.Stop()
        Label_Timer_Game.Text = Global_Var.Game_Time
        Label_Timer_Suspend.Visible = False
        Label_Timer_Suspend.Text = Global_Var.Game_Suspend_Time
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer_Game.Tick
        Label_Timer_Game.Text = Label_Timer_Game.Text - 1
        If Label_Timer_Game.Text <= 0 Then
            Timer_Game.Stop()
        End If
    End Sub

    Private Sub Timer_Suspend_Tick(sender As Object, e As EventArgs) Handles Timer_Suspend.Tick
        Label_Timer_Suspend.Text = Label_Timer_Suspend.Text - 1
        If Label_Timer_Game.Text <= 0 Then
            Timer_Game.Start()
            Label_Timer_Suspend.Visible = False
            Timer_Suspend.Stop()
        End If
    End Sub
End Class
