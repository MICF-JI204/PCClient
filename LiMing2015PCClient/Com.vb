Partial Public Class Form_ORRM
    Private Const OUT_MSG_LENGTH As Integer = 8
    Private Thread_Connection As New Threading.Thread(AddressOf Com_Connection)

    Private Sub Com_Connection()
        While Not Me.IsHandleCreated
        End While
        ChangeUIText(Label_Connection_Status, "Waiting For Ports...", Drawing.Color.Blue)
        ChangeStatusLabel(ToolStripStatusLabel_Com_status, "Waiting For Ports", Drawing.Color.Blue)
        Dim SerialPortArduino As New System.IO.Ports.SerialPort()
        SerialPortArduino.BaudRate = 9600
        Com_Wait_Connection(SerialPortArduino)
        While True
            If SerialPortArduino.IsOpen = False Then
                Log(SerialPortArduino.PortName & " Connection Lost")
                Com_Wait_Connection(SerialPortArduino)
            Else
                If Global_Var.Com_IsClosing Then
                    Log("User:Closing Serial Port on " & SerialPortArduino.PortName)
                    SerialPortArduino.Close()
                End If
                If Global_Var.Com_TextMode Then
                    If Out_Buffer.QueCount() > 0 Then '非文字模式
                        Dim msg2send As Out_Msg
                        msg2send = Out_Buffer.Deque()
                        msg2send.Generate_CheckSum()
                        SerialPortArduino.Write(msg2send.Buffer, 0, OUT_MSG_LENGTH)
                    End If
                    Do While SerialPortArduino.BytesToRead() > 0
                        In_Buffer.InBuff(SerialPortArduino.ReadByte)
                    Loop
                Else '文字模式
                    If SerialPortArduino.ReadBufferSize() > 0 Then
                        Log("Arduino/Incoming:" & SerialPortArduino.ReadExisting)
                    End If
                    If Out_Buffer.Text_Mode_Buffer_Count > 0 Then
                        Dim str As String = Out_Buffer.De_Text_Mode_Buffer
                        Out_Buffer.Clear_Text_Buffer()
                        Log("User/Send:" & str)
                        str = str.Replace("\n", vbCrLf) '生成回车
                        SerialPortArduino.Write(str)
                    End If
                End If
            End If
        End While


    End Sub

    Private Sub Com_Wait_Connection(ByRef SerialPort As System.IO.Ports.SerialPort)
        Do
            Enable_Control(Button_Connect, True)
            Enable_Control(ComboPort, True)
            Enable_Control(Button_Com_Close, False)
            Enable_Control(Button_ConsoleSend, False)
            Enable_Control(TextBox_ConsoleSend, False)
            Global_Var.Com_Ready2Connect = False
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
                    If Not ComboPort.Items.Contains(SerialPortNameStr) Then
                        AddItemCombo(ComboPort, SerialPortNameStr)
                    End If
                Next
            End While
            Enable_Control(Button_Connect, False)
            Enable_Control(ComboPort, False)
            Enable_Control(Button_Com_Close, True)
            Enable_Control(Button_ConsoleSend, True)
            Enable_Control(TextBox_ConsoleSend, True)
            Try
                SerialPort.PortName = GetSelectedItemCombo(ComboPort)
            Catch
            End Try
            Try
                SerialPort.Open()
            Catch
            End Try
        Loop Until SerialPort.IsOpen = True
        Log(SerialPort.PortName & " Established")
    End Sub
End Class
