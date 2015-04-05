Partial Public Class Form_ORRM
    Private Thread_Connection As New Threading.Thread(AddressOf Com_Connection)

    Private Sub Com_Connection()
        While Not Me.IsHandleCreated
        End While
        ChangeLabel(Label_Connection_Status, "Serching For Ports...", Drawing.Color.Blue)
        ChangeStatusLabel(ToolStripStatusLabel_Com_status, "Serching For Ports", Drawing.Color.Blue)
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
        Dim SerialPort As IO.Ports.SerialPort = My.Computer.Ports.OpenSerialPort(ComboPort.SelectedText, 9600)
    End Sub

End Class
