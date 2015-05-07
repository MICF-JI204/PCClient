Public Class Robot_IOStatus
    Public MotorSpd As Generic_IOStatus
    Public LoaderDir As Generic_IOStatus
    Public LoaderState As Generic_IOStatus
    Public PumpState As Generic_IOStatus
    Public CraneRotation As Generic_IOStatus
    Public CraneH As Generic_IOStatus
    Public CraneV As Generic_IOStatus
End Class

Public Structure Generic_IOStatus
    Sub New(acmd As Integer, aarg1h As Byte, aarg1l As Byte, aarg2h As Byte, aarg2l As Byte)
        CMD = acmd
        Arg1H = aarg1h
        Arg2H = aarg2h
        Arg1L = aarg1l
        Arg2L = aarg2l
    End Sub

    Public CMD As Integer
    Public Arg1H As Byte
    Public Arg1L As Byte
    Public Arg2H As Byte
    Public Arg2L As Byte
End Structure