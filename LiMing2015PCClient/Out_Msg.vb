Public Class Out_Msg
    Public Sub New()
        Buffer(0) = &HCC  '包头
    End Sub

    Public Buffer(8) As Byte

    Public Sub Set_OP(ByVal op As Byte)
        Buffer(1) = op
    End Sub

    Public Sub Set_Priority(ByVal p As Byte)
        Buffer(2) = p
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
            Buffer(7) = (Buffer(7) + Buffer(i)) Mod &HFF
        Next
    End Sub
End Class

Public Class Out_Buffer
    Public Out_Buffer As System.Collections.Generic.Queue(Of Out_Msg)
    Private AccLock As Object
End Class