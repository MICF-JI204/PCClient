Partial Public Class Form_ORRM
    Private Thread_Connection As New Threading.Thread(AddressOf Com_Connection)

    Private Sub Com_Connection()
        While Not Me.IsHandleCreated
        End While
        ChangeUIText(Label_Connection_Status, "Serching For Ports...", Drawing.Color.Blue)
        ChangeStatusLabel(ToolStripStatusLabel_Com_status, "Serching For Ports", Drawing.Color.Blue)
        Dim SerialPortArduino As New System.IO.Ports.SerialPort()
        SerialPortArduino.BaudRate = 9600
        Com_Wait_Connection(SerialPortArduino)
    End Sub

    Private Sub Com_Wait_Connection(ByRef SerialPort As System.IO.Ports.SerialPort)
        Do
            Enable_Control(Button_Connect, True)
            Enable_Control(ComboPort, True)
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
            Try
                SerialPort.PortName = GetSelectedItemCombo(ComboPort)
            Catch
            End Try
            Try
                SerialPort.Open()
            Catch
            End Try
        Loop Until SerialPort.IsOpen = True
    End Sub
End Class
