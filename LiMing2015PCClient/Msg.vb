Public Class Out_Msg
    Public Sub New()
        Buffer(0) = &HCC  '包头
    End Sub

    Public Sub New(ByVal pr As Byte, ByVal op As Byte, a1 As Byte, a2 As Byte, a3 As Byte, a4 As Byte)
        Set_OP(op)
        Set_Priority(pr)
        Set_Data(a1, a2, a3, a4)
    End Sub

    Public Buffer(8) As Byte

    Public Sub Set_OP(ByVal op As Byte)
        Buffer(2) = op
    End Sub

    Public Sub Set_Priority(ByVal p As Byte)
        Buffer(1) = p
    End Sub

    Public Sub Set_Data(ByVal arg0 As Byte, ByVal arg1 As Byte, ByVal arg2 As Byte, ByVal arg3 As Byte)
        Buffer(3) = arg0
        Buffer(4) = arg1
        Buffer(5) = arg2
        Buffer(6) = arg3
    End Sub

    Public Sub Generate_CheckSum()
        Dim i As Integer = 0
        For i = 0 To 6
            Buffer(7) = (Int(Buffer(7)) + Int(Buffer(i))) And &HFF
        Next
    End Sub
End Class

Public Class In_Buffer
    Public Shared buffer(4) As Byte
    Private Shared bufferpointer As Byte
    Public Shared Function InBuff(data As Byte) As String
        If bufferpointer = 0 Then
            If data <> &HCC Then
                Return "Arduino/Incoming:Err Invalid Header:" & Hex(data)
            Else
                buffer(bufferpointer) = data
                bufferpointer += 1
            End If
        Else
            buffer(bufferpointer) = data
            bufferpointer += 1
            If bufferpointer = 4 Then
                bufferpointer = 0
                If (Int(buffer(0)) + Int(buffer(1)) + Int(buffer(2))) And &HFF = buffer(3) Then
                    Return DispatchInMsg(buffer(1), buffer(2))
                Else
                    Return "Arduino/Incoming:Err Invalid CheckSum: " & Hex(buffer(0)) & " " _
                                                                     & Hex(buffer(1)) & " " _
                                                                     & Hex(buffer(2)) & " " _
                                                                     & Hex(buffer(3))
                End If
            End If
        End If
        Return Nothing
    End Function

    Public Shared Function DispatchInMsg(ByVal op As Byte, ByVal arg As Byte) As String
        Form_ORRM.ChangeUIText(Form_ORRM.Label_Connection_Status, "Get:" & Global_Var.Get_ComCMD_Name(op), Color.Blue)
        Return "Arduino/Incomming_CMD:" & Global_Var.Get_ComCMD_Name(op) & Hex(arg)
    End Function
End Class

Public Class Out_Buffer
    Private Shared CMD_Buffer As New System.Collections.Generic.Queue(Of Out_Msg)
    Private Shared OutBufferString As String = ""

    Public Shared Sub Send_Text(info As String)
        SyncLock AccLock
            OutBufferString += info
        End SyncLock
    End Sub

    Public Shared Function Text_Mode_Buffer_Count()
        SyncLock AccLock
            Return OutBufferString.Length
        End SyncLock
    End Function

    Public Shared Function De_Text_Mode_Buffer()
        SyncLock AccLock
            Return OutBufferString
        End SyncLock
    End Function

    Public Shared Sub Clear_Text_Buffer()
        SyncLock AccLock
            OutBufferString = ""
        End SyncLock
    End Sub

    Public Shared Sub Enque(msg As Out_Msg)
        SyncLock AccLock
            CMD_Buffer.Enqueue(msg)
        End SyncLock
    End Sub

    Public Shared Function Deque() As Out_Msg
        SyncLock AccLock
            Return CMD_Buffer.Dequeue
        End SyncLock
    End Function

    Public Shared Function QueCount() As Integer
        SyncLock AccLock
            Return CMD_Buffer.Count
        End SyncLock
    End Function

    Public Shared Sub QueEmpty()
        SyncLock AccLock
            OutBufferString = ""
            CMD_Buffer.Clear()
            Return
        End SyncLock
    End Sub

    Private Shared AccLock As String = ""
End Class