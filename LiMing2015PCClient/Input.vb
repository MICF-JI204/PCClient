Imports Microsoft.Xna.Framework
Partial Public Class Form_ORRM
    'Const FBCRTITICAL_RAD As Single = 88 / 180 * Math.PI
    'Const TURNNING_CRITICAL_RAD As Single = 4 / 180 * Math.PI

    Public Thread_GamePad As New System.Threading.Thread(AddressOf GeneralIO)
    'Public Thread_Loader_Unload As New System.Threading.Thread(AddressOf Loader_Unload)
    Public Local_Robot_Status As New Robot_IOStatus

    Public Sub GeneralIO()
        Dim CurrentGamePadState As Input.GamePadState
        MultiInputITL.DesTbl = New OpITL_Generic
        Dim LoaderStage As Integer = 0
        Dim LoaderTStart As Integer
        While True
            CurrentGamePadState = Input.GamePad.GetState(PlayerIndex.One)
            If CurrentGamePadState.IsConnected Then
                MultiInputITL.InputSource = New PlayerInput_GenericGamePad
                ChangeUIText(Label_XBox_Connection, "GamePad Connected", Drawing.Color.Blue)
            Else
                MultiInputITL.InputSource = New PlayerInput_GenericKeyboard
                ChangeUIText(Label_XBox_Connection, "Using Keyboard", Drawing.Color.Blue)
            End If
            UpdateSource()
            Local_Robot_Status.CraneH = MultiInputITL.GetCraneHDir()
            Local_Robot_Status.CraneV = MultiInputITL.GetCraneVDir()
            Local_Robot_Status.CraneRotation = MultiInputITL.GetCraneRotation()
            Local_Robot_Status.LoaderDir = MultiInputITL.GetLoaderDir()
            Local_Robot_Status.PumpState = MultiInputITL.GetPumpState()
            Local_Robot_Status.MotorSpd = MultiInputITL.GetRobotSpd()
            '========Special Treatment For Loader State====================
            If LoaderStage = 0 Then
                If MultiInputITL.InputSource.LoaderState = PlayerInputHAL.LoaderUnloading Then
                    LoaderStage = 1
                    UIBuffer.LoaderPercent = 0
                    LoaderTStart = My.Computer.Clock.TickCount
                    Log("Unloading Preparing")
                End If
            ElseIf LoaderStage = 1 Then
                If MultiInputITL.InputSource.LoaderState = PlayerInputHAL.LoaderUnloading Then
                    UIBuffer.LoaderPercent = Int((My.Computer.Clock.TickCount - LoaderTStart) / 15)
                    If UIBuffer.LoaderPercent >= 100 Then
                        UIBuffer.LoaderPercent = 100
                        LoaderStage = 2
                        Log("Unloading Confrimed!")
                    End If
                ElseIf MultiInputITL.InputSource.LoaderState = PlayerInputHAL.LoaderNotUnloading Then
                    LoaderStage = 0
                    UIBuffer.LoaderPercent = 0
                    Log("Unloading Canceled")
                End If
            ElseIf LoaderStage = 2 Then
                LoaderStage = 3
                Local_Robot_Status.LoaderState = New Generic_IOStatus(Global_Var.Com_CMD.Loader_StartUnload, 0, 0, 0, 0)
                Log("Unloading CMD Sent")
            ElseIf LoaderStage = 3 Then
                If MultiInputITL.InputSource.LoaderState = PlayerInputHAL.LoaderNotUnloading Then
                    LoaderStage = 4
                    Local_Robot_Status.LoaderState = New Generic_IOStatus(Global_Var.Com_CMD.Loader_StopUnload, 0, 0, 0, 0)
                    Log("Stop Unloading CMD Sent")
                End If
            ElseIf LoaderStage = 4 Then
                LoaderStage = 5
                Log("Unloading Complete")
            Else
            End If
            '==============================================================
            MultiInputITL.UpdateUIBuffer()
            Update_Trejectory()
            Update_Crane()
            Update_Controls()
            Update_Unloader()
            If Global_Var.Com_Connected Then
                If Not Object.Equals(Local_Robot_Status.CraneH, Remote_Robot_Status.CraneH) Then
                    With Local_Robot_Status.CraneH
                        Out_Buffer.Enque(New Out_Msg(11, .CMD, .Arg1H, .Arg1L, .Arg2H, .Arg2L))
                    End With
                End If
                If Not Object.Equals(Local_Robot_Status.CraneV, Remote_Robot_Status.CraneV) Then
                    With Local_Robot_Status.CraneV
                        Out_Buffer.Enque(New Out_Msg(11, .CMD, .Arg1H, .Arg1L, .Arg2H, .Arg2L))
                    End With
                End If
                If Not Object.Equals(Local_Robot_Status.CraneRotation, Remote_Robot_Status.CraneRotation) Then
                    With Local_Robot_Status.CraneRotation
                        Out_Buffer.Enque(New Out_Msg(11, .CMD, .Arg1H, .Arg1L, .Arg2H, .Arg2L))
                    End With
                End If
                If Not Object.Equals(Local_Robot_Status.LoaderDir, Remote_Robot_Status.LoaderDir) Then
                    With Local_Robot_Status.LoaderDir
                        Out_Buffer.Enque(New Out_Msg(11, .CMD, .Arg1H, .Arg1L, .Arg2H, .Arg2L))
                    End With
                End If
                If Not Object.Equals(Local_Robot_Status.LoaderState, Remote_Robot_Status.LoaderState) Then
                    With Local_Robot_Status.LoaderState
                        Out_Buffer.Enque(New Out_Msg(11, .CMD, .Arg1H, .Arg1L, .Arg2H, .Arg2L))
                    End With
                End If
                If Not Object.Equals(Local_Robot_Status.PumpState, Remote_Robot_Status.PumpState) Then
                    With Local_Robot_Status.PumpState
                        Out_Buffer.Enque(New Out_Msg(11, .CMD, .Arg1H, .Arg1L, .Arg2H, .Arg2L))
                    End With
                End If
                If Not Object.Equals(Local_Robot_Status.MotorSpd, Remote_Robot_Status.MotorSpd) Then
                    With Local_Robot_Status.MotorSpd
                        Out_Buffer.Enque(New Out_Msg(11, .CMD, .Arg1H, .Arg1L, .Arg2H, .Arg2L))
                    End With
                End If
            End If
            System.Threading.Thread.Sleep(Global_Var.Game_Suspend_Time)
        End While
    End Sub

   

    Public Sub Update_Crane_Graph(ByRef GamePadState As Input.GamePadState)
        Dim x As Single = GamePadState.ThumbSticks.Right.X
        Dim y As Single = GamePadState.ThumbSticks.Right.Y
        Dim dis As Single = Math.Sqrt(x ^ 2 + y ^ 2)
        If dis > 0.9 Then
            Dim ang As Single = Math.Asin(Math.Abs(y / dis)) / Math.PI * 180
            If x >= 0 Then
                If y >= 0 Then
                    Global_Var.Robot_Crane_Angle = ang
                Else
                    Global_Var.Robot_Crane_Angle = -ang
                End If
            Else
                If y >= 0 Then
                    Global_Var.Robot_Crane_Angle = 180 - ang
                Else
                    Global_Var.Robot_Crane_Angle = ang - 180
                End If
            End If
            If ang < 0 Then ang += 360
        End If
        Update_Crane()
    End Sub

End Class

Public Class UIBuffer

    Public Shared InfoString As String
    Public Shared LogString As String
    Public Shared IsInfoStrChanged As Boolean
    Public Shared IsLogStrChanged As Boolean

    Public Shared Graph_Trejection_Radius As Single
    Public Shared Graph_Trejection_Direction As Graph_Trejection_Dir = Graph_Trejection_Dir.Dir_Null
    Public Shared IsCraneGraphUpdateRequire As Boolean
    Public Shared CraneAngle As Single
    Public Shared CraneRotationLeft As Boolean
    Public Shared CraneRotationRight As Boolean
    Public Shared CraneHForward As Boolean
    Public Shared CraneHBackward As Boolean
    Public Shared CraneVUp As Boolean
    Public Shared CraneVDown As Boolean
    Public Shared LoaderUp As Boolean
    Public Shared LoaderDown As Boolean
    Public Shared PumpState As Boolean

    Public Shared LoaderPercent As Integer = 0
    Public Shared LoaderStage As Integer = 0

    Public Shared Robot_LTurn_Override As Boolean = False
    Public Shared Robot_Rturn_Override As Boolean = False

    Public Enum Graph_Trejection_Dir As Integer
        Dir_Null = 0
        Forward_Left = 1
        Forward_Right = 2
        BackWard_Left = 3
        BackWard_Right = 4
        Forward = 5
        Backward = 6
    End Enum
End Class