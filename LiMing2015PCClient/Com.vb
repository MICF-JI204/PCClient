Partial Public Class Form_ORRM
    Private Const OUT_MSG_LENGTH As Integer = 8
    Private Thread_Connection As New Threading.Thread(AddressOf Com_Connection)

    Private Sub Com_Connection()
        While Not Me.IsHandleCreated
        End While
        ChangeUIText(Label_Connection_Status, "Waiting For Ports...", Drawing.Color.Blue)
        ChangeStatusLabel(ToolStripStatusLabel_Com_status, "Waiting For Ports", Drawing.Color.Blue)
        Dim SerialPortArduino As New System.IO.Ports.SerialPort()
        SerialPortArduino.BaudRate = 115200
        Com_Wait_Connection(SerialPortArduino)
        Log("User:Closing Serial Port on " & SerialPortArduino.PortName)
        ChangeStatusLabel(ToolStripStatusLabel_Com_status, SerialPortArduino.PortName & " Established", Color.Green)
        ChangeUIText(Label_Connection_Status, SerialPortArduino.PortName & " Established", Color.Green)
        While True
            If SerialPortArduino.IsOpen = False Then
                Log(SerialPortArduino.PortName & " Connection Lost")
                ChangeStatusLabel(ToolStripStatusLabel_Com_status, "Connection Lost", Color.Red)
                ChangeUIText(Label_Connection_Status, "Disconnected", Color.Red)
                Com_Wait_Connection(SerialPortArduino)
                ChangeStatusLabel(ToolStripStatusLabel_Com_status, SerialPortArduino.PortName & " Established", Color.Green)
                ChangeUIText(Label_Connection_Status, SerialPortArduino.PortName & " Established", Color.Green)
            Else
                If Global_Var.Com_IsClosing Then
                    Log("User:Closing Serial Port on " & SerialPortArduino.PortName)
                    Try
                        SerialPortArduino.Close()
                    Catch
                    End Try
                    Global_Var.Com_IsClosing = False
                    Continue While
                    'Wait Until Fully Closed
                End If
            End If

            If Out_Buffer.QueCount() > 0 Then '指令模式写入
                Dim msg2send As Out_Msg = Out_Buffer.Deque()
                msg2send.Generate_CheckSum()
                If msg2send.Buffer(2) = Global_Var.Com_CMD.Set_Crane_Dir Then '特殊处理吊臂方向
                    If My.Computer.Clock.TickCount - Out_Buffer.CMD_Set_CraneDir_Last_Time > Global_Var.Com_SetCraneDir_Delay Then
                        Out_Buffer.CMD_Set_CraneDir_Last_Time = My.Computer.Clock.TickCount
                        myWrite(SerialPortArduino, msg2send.Buffer, 0, OUT_MSG_LENGTH)
                    End If
                Else
                    myWrite(SerialPortArduino, msg2send.Buffer, 0, OUT_MSG_LENGTH)
                End If
                'If msg2send.IsUserCMD Then
                'If msg2send.Buffer(2) <> Global_Var.Com_CMD.Set_DMotor Then
                Log("User/Sending:" & vbCrLf & Hex(msg2send.Buffer(0)) & " " _
                         & Hex(msg2send.Buffer(1)) & " " _
                         & Global_Var.Get_ComCMD_Name(msg2send.Buffer(2)) & " " _
                         & Hex(msg2send.Buffer(3)) & " " _
                         & Hex(msg2send.Buffer(4)) & " " _
                         & Hex(msg2send.Buffer(5)) & " " _
                         & Hex(msg2send.Buffer(6)) & " " _
                         & Hex(msg2send.Buffer(7)))
                'End If
                'End If
            End If


            If Not Global_Var.Com_TextMode Then '指令模式读取
                Do While myBytesToRead(SerialPortArduino) > 0
                    Dim tlog As String = In_Buffer.InBuff(myReadByte(SerialPortArduino))
                    If tlog <> Nothing Then Log(tlog)
                Loop
            Else '文字模式（读取,写入）
                If myBytesToRead(SerialPortArduino) > 0 Then
                    Dim str As String = myReadExsisting(SerialPortArduino)
                    str = str.Replace(vbCrLf, "\n")
                    str = str.Replace(vbCr, "\r")
                    str = str.Replace(vbLf, "\f")
                    Log("Arduino/Incoming:" & str)
                End If
                If Out_Buffer.Text_Mode_Buffer_Count > 0 Then
                    Dim str As String = Out_Buffer.De_Text_Mode_Buffer
                    Out_Buffer.Clear_Text_Buffer()
                    Log("User/Send:" & str)
                    str = str.Replace("\n", vbCrLf) '生成回车
                    myWrite(SerialPortArduino, str)
                End If
            End If
            Threading.Thread.Sleep(Global_Var.Thread_Com_Delay)
        End While


    End Sub

    Private Sub Com_Wait_Connection(ByRef SerialPort As System.IO.Ports.SerialPort)
        Do
            Enable_Control(Button_Connect, True)
            Enable_Control(ComboPort, True)
            Enable_Control(Button_Com_Close, False)
            Global_Var.Com_Ready2Connect = False
            Threading.Thread.Sleep(500)
            While Not Global_Var.Com_Ready2Connect
                Try
                    For Each SerialPortNameStr In ComboPort.Items
                        If Not My.Computer.Ports.SerialPortNames.Contains(SerialPortNameStr.ToString) Then
                            RemoveItemCombo(ComboPort, SerialPortNameStr)
                        End If
                    Next
                Catch
                End Try
                For Each SerialPortNameStr In My.Computer.Ports.SerialPortNames
                    AddItemCombo(ComboPort, SerialPortNameStr)
                Next
            End While
            Enable_Control(Button_Connect, False)
            Enable_Control(ComboPort, False) 'Disable The Buttons
            Try
                SerialPort.PortName = GetSelectedItemCombo(ComboPort)
            Catch
            End Try

            Try
                ChangeUIText(Label_Connection_Status, "Trying to open a port", Color.Blue)
                SerialPort.Open()
            Catch
            End Try
        Loop Until SerialPort.IsOpen = True

        Enable_Control(Button_Com_Close, True)
        Enable_Control(Button_ConsoleSend, True)
        Enable_Control(TextBox_ConsoleSend, True)
        Out_Buffer.QueEmpty()
        Log(SerialPort.PortName & " Established")
    End Sub

    Private Overloads Sub myWrite(ByRef SerialPort As IO.Ports.SerialPort, ByRef Buffer As Byte(), ByVal OffSet As Integer, ByVal Count As Integer)
        Try
            SerialPort.Write(Buffer, OffSet, Count)
            Global_Var.Com_LastCMDSent = My.Computer.Clock.TickCount
        Catch
            Global_Var.Com_IsClosing = True
        End Try
    End Sub

    Private Overloads Sub myWrite(ByRef SerialPort As IO.Ports.SerialPort, ByRef info As String)
        Try
            SerialPort.Write(info)
        Catch ex As UnauthorizedAccessException
            Global_Var.Com_IsClosing = True
        End Try
    End Sub

    Private Function myBytesToRead(ByRef SerialPort As IO.Ports.SerialPort) As Integer
        Try
            Dim t As Integer = SerialPort.BytesToRead
            Return t
        Catch ex As UnauthorizedAccessException
            Global_Var.Com_IsClosing = True
        End Try
        Return 0
    End Function

    Private Function myReadByte(ByRef SerialPort As IO.Ports.SerialPort) As Integer
        Try
            Dim t As Integer = SerialPort.ReadByte
            Return t
        Catch ex As UnauthorizedAccessException
            Global_Var.Com_IsClosing = True
        End Try
        Return 0
    End Function

    Private Function myReadExsisting(ByRef SerialPort As IO.Ports.SerialPort) As String
        Try
            Dim t As String = SerialPort.ReadExisting
            Return t
        Catch ex As UnauthorizedAccessException
            Global_Var.Com_IsClosing = True
        End Try
        Return 0
    End Function
End Class
