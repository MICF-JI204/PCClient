Imports Microsoft.Xna.Framework

Public Class MultiInputITL 'Translation Layer, 
    'Translate HAL to corresponding command with arguments
    Public Shared InputSource As PlayerInputHAL
    Public Shared DesTbl As OpTranslationDesTbl

    Public Shared Sub UpdateSouce()
        InputSource.RefreshSource()
    End Sub

    Public Shared Function GetRobotSpd() As Generic_IOStatus
        Dim t As New Generic_IOStatus
        Dim tspd As PlayerInputHAL.RobotDMotorSpdCo
        If InputSource.RobotRotation = PlayerInputHAL.RobotLeftRotate Then 'Overriding Original Spd
            tspd.LeftSpd = -1
            tspd.RightSpd = 1
        ElseIf InputSource.RobotRotation = PlayerInputHAL.RobotRightRotate Then
            tspd.LeftSpd = -1
            tspd.RightSpd = 1
        Else
            tspd = InputSource.MotorSpd
        End If
        t.CMD = Global_Var.Com_CMD.Set_DMotor
        t.Arg1L = DesTbl.DMotorMidPoint + Math.Sign(tspd.LeftSpd) * _
                    (DesTbl.DMotorRespondingOffset + (128 - DesTbl.DMotorRespondingOffset) * Math.Abs(tspd.LeftSpd))
        t.Arg2L = DesTbl.DMotorMidPoint + Math.Sign(tspd.RightSpd) * _
            (DesTbl.DMotorRespondingOffset + (128 - DesTbl.DMotorRespondingOffset) * Math.Abs(tspd.RightSpd))
        Return t
    End Function

    Public Shared Function GetLoaderDir() As Generic_IOStatus
        Select Case InputSource.LoaderDir
            Case PlayerInputHAL.LoaderUp
                Return New Generic_IOStatus(Global_Var.Com_CMD.Loader_Up, 0, 0, 0, 0)
            Case PlayerInputHAL.LoaderDown
                Return New Generic_IOStatus(Global_Var.Com_CMD.Loader_Down, 0, 0, 0, 0)
            Case PlayerInputHAL.LoaderStop
                Return New Generic_IOStatus(Global_Var.Com_CMD.Loader_Stop, 0, 0, 0, 0)
        End Select
        Return Nothing
    End Function

    Public Shared Function GetCraneRotation() As Generic_IOStatus
        Select Case InputSource.CraneRotation
            Case PlayerInputHAL.CraneRotationClockwise
                Return New Generic_IOStatus(Global_Var.Com_CMD.Yuntai_Fast, 0, 1, 0, 200)
            Case PlayerInputHAL.CraneRotationCtClockwise
                Return New Generic_IOStatus(Global_Var.Com_CMD.Yuntai_Fast, 0, 2, 0, 200)
            Case PlayerInputHAL.CraneRotationStop
                Return New Generic_IOStatus(Global_Var.Com_CMD.Yuntai_Fast, 0, 0, 0, 0)
        End Select
        Return Nothing
    End Function

    Public Shared Function GetCraneHDir() As Generic_IOStatus
        Select Case InputSource.CraneHDir
            Case PlayerInputHAL.CraneHFoward
                Return New Generic_IOStatus(Global_Var.Com_CMD.Crane_HSetSpeed, 0, 255, 0, 1)
            Case PlayerInputHAL.CraneHBack
                Return New Generic_IOStatus(Global_Var.Com_CMD.Crane_HSetSpeed, 0, 255, 0, 2)
            Case PlayerInputHAL.CraneHStop
                Return New Generic_IOStatus(Global_Var.Com_CMD.Crane_HStop, 0, 0, 0, 0)
        End Select
        Return Nothing
    End Function

    Public Shared Function GetCraneVDir() As Generic_IOStatus
        Select Case InputSource.CraneVDir
            Case PlayerInputHAL.CraneVUp
                Return New Generic_IOStatus(Global_Var.Com_CMD.Crane_VSetSpeed, 0, 255, 0, 1)
            Case PlayerInputHAL.CraneVDown
                Return New Generic_IOStatus(Global_Var.Com_CMD.Crane_VSetSpeed, 0, 255, 0, 2)
            Case PlayerInputHAL.CraneVStop
                Return New Generic_IOStatus(Global_Var.Com_CMD.Crane_VStop, 0, 0, 0, 0)
        End Select
        Return Nothing
    End Function

    Public Shared Function GetPumpState() As Generic_IOStatus
        Select Case InputSource.PumpState
            Case PlayerInputHAL.PumpOn
                Return New Generic_IOStatus(Global_Var.Com_CMD.Crane_Hold, 0, 0, 0, 0)
            Case PlayerInputHAL.PumpOff
                Return New Generic_IOStatus(Global_Var.Com_CMD.Crane_Release, 0, 0, 0, 0)
        End Select
        Return Nothing
    End Function

    Public Shared Sub UpdateUIBuffer()
        'Prepare data for Trej. Graph
        If InputSource.MotorSpd.LeftSpd > 0 And InputSource.MotorSpd.RightSpd < 0 Then
            UIBuffer.Graph_Trejection_Direction = UIBuffer.Graph_Trejection_Dir.Forward_Left
        ElseIf InputSource.MotorSpd.LeftSpd > 0 And InputSource.MotorSpd.RightSpd > 0 Then
            UIBuffer.Graph_Trejection_Direction = UIBuffer.Graph_Trejection_Dir.Forward_Right
        ElseIf InputSource.MotorSpd.LeftSpd < 0 And InputSource.MotorSpd.RightSpd < 0 Then
            UIBuffer.Graph_Trejection_Direction = UIBuffer.Graph_Trejection_Dir.BackWard_Left
        ElseIf InputSource.MotorSpd.LeftSpd < 0 And InputSource.MotorSpd.RightSpd > 0 Then
            UIBuffer.Graph_Trejection_Direction = UIBuffer.Graph_Trejection_Dir.BackWard_Right
        End If
        If InputSource.RobotRotation = PlayerInputHAL.RobotLeftRotate Then
            UIBuffer.Robot_LTurn_Override = True
        ElseIf InputSource.RobotRotation = PlayerInputHAL.RobotRightRotate Then
            UIBuffer.Robot_Rturn_Override = True
        Else
            UIBuffer.Robot_LTurn_Override = False
            UIBuffer.Robot_Rturn_Override = True
        End If

    End Sub
End Class

Public MustInherit Class OpTranslationDesTbl
    Public MustOverride Property DMotorMidPoint As Integer
    Public MustOverride Property DMotorRespondingOffset As Integer
    Public MustOverride Property CraneHMaxSpd As Integer
    Public MustOverride Property CraneVMaxSpd As Integer
    Public MustOverride Property CraneRotateMaxSpd As Integer
End Class

Public MustInherit Class PlayerInputHAL 'Generic HAL
    Public Const LoaderUp As Integer = &H10
    Public Const LoaderStop As Integer = &H11
    Public Const LoaderDown As Integer = &H12
    Public Const LoaderHolding As Integer = &H13
    Public Const LoaderUnloading As Integer = &H14
    Public Const LoaderUnloaded As Integer = &H14
    Public Const CraneRotationCtClockwise As Integer = &H20
    Public Const CraneRotationClockwise As Integer = &H21
    Public Const CraneRotationStop As Integer = &H22
    Public Const CraneHFoward As Integer = &H23
    Public Const CraneHBack As Integer = &H24
    Public Const CraneHStop As Integer = &H25
    Public Const CraneVUp As Integer = &H26
    Public Const CraneVDown As Integer = &H27
    Public Const CraneVStop As Integer = &H28
    Public Const PumpOn As Integer = &H30
    Public Const PumpOff As Integer = &H31
    Public Const RobotLeftRotate = &H40
    Public Const RobotRightRotate = &H41
    Public Const RobotRotateStop = &H42
    Public Const FBCRTITICAL_RAD As Single = 88 / 180 * Math.PI
    Public Const TURNNING_CRITICAL_RAD As Single = 4 / 180 * Math.PI

    Public Structure RobotDMotorSpdCo
        Public LeftSpd As Single
        Public RightSpd As Single
    End Structure

    Public MustOverride Sub RefreshSource()
    Public MustOverride Function RobotRotation() As Integer
    Public MustOverride Function LoaderState() As Integer
    Public MustOverride Function LoaderDir() As Integer
    Public MustOverride Function CraneRotation() As Integer
    Public MustOverride Function CraneHDir() As Integer
    Public MustOverride Function CraneVDir() As Integer
    Public MustOverride Function MotorSpd() As RobotDMotorSpdCo
    Public MustOverride Function ShiftButton() As Boolean

    Public MustOverride Function PumpState() As Boolean
End Class

Public Class PlayerInput_GenericGamePad
    Inherits PlayerInputHAL

    Public GamePadState As Input.GamePadState

    Public Overrides Sub RefreshSource()

    End Sub

    Public Overrides Function CraneHDir() As Integer
        Dim tstate As Integer
        If Math.Abs(GamePadState.ThumbSticks.Right.Y) < 0.15 Then
            tstate = 0 'stop
        ElseIf GamePadState.ThumbSticks.Right.Y < 0 Then
            tstate = 2 'Back
        Else
            tstate = 1 'Foward
        End If

        If (tstate <> Global_Var.Robot_Crane_HDir) Or (GamePadState.Buttons.B <> Global_Var.GamePadPreState.Buttons.B) Then
            Global_Var.Robot_Crane_HDir = tstate
            If tstate = 0 Then
                Out_Buffer.Enque(New Out_Msg(20, Global_Var.Com_CMD.Crane_HStop, 0, 0, 0, 0))
            ElseIf tstate = 1 Then
                If Global_Var.Robot_Shift Then
                    Out_Buffer.Enque(New Out_Msg(20, Global_Var.Com_CMD.Crane_HSetSpeed, 0, 255, 0, 2))
                Else
                    Out_Buffer.Enque(New Out_Msg(20, Global_Var.Com_CMD.Crane_HSetSpeed, 0, 255, 0, 2))
                End If
            ElseIf tstate = 2 Then
                If Global_Var.Robot_Shift Then
                    Out_Buffer.Enque(New Out_Msg(20, Global_Var.Com_CMD.Crane_HSetSpeed, 0, 150, 0, 1))
                Else
                    Out_Buffer.Enque(New Out_Msg(20, Global_Var.Com_CMD.Crane_HSetSpeed, 0, 150, 0, 1))
                End If
            End If
        End If
    End Function

    Public Overrides Function CraneRotation() As Integer
        Dim tstate As Integer
        If Math.Abs(GamePadState.ThumbSticks.Right.X) < 0.15 Then
            tstate = 0 'stop
        ElseIf GamePadState.ThumbSticks.Right.X < 0 Then
            tstate = 1 'left
        Else
            tstate = 2 'right
        End If
        If (tstate <> Global_Var.Robot_Yuntai_Dir) Or (GamePadState.Buttons.B <> Global_Var.GamePadPreState.Buttons.B) Then
            Global_Var.Robot_Yuntai_Dir = tstate
            If tstate = 0 Then
                Out_Buffer.Enque(New Out_Msg(20, Global_Var.Com_CMD.Yuntai_Stop, 0, 0, 0, 0))
            ElseIf tstate = 1 Then
                If Global_Var.Robot_Shift Then
                    Out_Buffer.Enque(New Out_Msg(20, Global_Var.Com_CMD.Yuntai_Slow, 0, 1, 0, 200))
                Else
                    Out_Buffer.Enque(New Out_Msg(20, Global_Var.Com_CMD.Yuntai_Fast, 0, 1, 0, 200))
                End If
            ElseIf tstate = 2 Then
                If Global_Var.Robot_Shift Then
                    Out_Buffer.Enque(New Out_Msg(20, Global_Var.Com_CMD.Yuntai_Slow, 0, 2, 0, 200))
                Else
                    Out_Buffer.Enque(New Out_Msg(20, Global_Var.Com_CMD.Yuntai_Fast, 0, 2, 0, 200))
                End If
            End If
        End If
    End Function

    Public Overrides Function CraneVDir() As Integer
        Dim LT_State As Boolean = GamePadState.Triggers.Left > Global_Var.GamePad_Trigger_Critical
        Dim RT_State As Boolean = GamePadState.Triggers.Right > Global_Var.GamePad_Trigger_Critical
        If (LT_State And RT_State) Then
            Return CraneVStop
        ElseIf (LT_State) And (Not RT_State) Then
            Return CraneVDown
        ElseIf (Not LT_State) And (RT_State) Then
            Return CraneVUp
        Else
            Return CraneVStop
        End If
    End Function

    Public Overrides Function LoaderState() As Integer

        If Threading.Thread.VolatileRead(Global_Var.Robot_Loader_State) < 2 Then
            If GamePadState.Buttons.X = Input.ButtonState.Pressed Then
                Threading.Thread.VolatileWrite(Global_Var.Robot_Loader_State, 1)
            Else
                Threading.Thread.VolatileWrite(Global_Var.Robot_Loader_State, 0)
            End If
        End If
        If Threading.Thread.VolatileRead(Global_Var.Robot_Loader_State) = 2 Then
            If GamePadState.Buttons.X = Input.ButtonState.Released Then
                Threading.Thread.VolatileWrite(Global_Var.Robot_Loader_State, 3)
            End If
        End If
    End Function

    Public Overrides Function MotorSpd() As RobotDMotorSpdCo
        Dim spd As Double = Math.Sqrt(Math.Pow(GamePadState.ThumbSticks.Left.X, 2) + Math.Pow(GamePadState.ThumbSticks.Left.Y, 2))
        If spd > 1 Then spd = 1
        If GamePadState.ThumbSticks.Left.X = 0 And GamePadState.ThumbSticks.Left.Y = 0 Then '静止态
            Global_Var.SpeedCoeffientL = 0
            Global_Var.SpeedCoeffientR = 0
        ElseIf Math.Abs(GamePadState.ThumbSticks.Left.Y / GamePadState.ThumbSticks.Left.X) _
            >= Math.Tan(FBCRTITICAL_RAD) Then                                        '几乎直线态
            Global_Var.SpeedCoeffientL = spd * Math.Sign(GamePadState.ThumbSticks.Left.Y)
            Global_Var.SpeedCoeffientR = Global_Var.SpeedCoeffientL
        ElseIf Math.Abs(GamePadState.ThumbSticks.Left.Y / GamePadState.ThumbSticks.Left.X) _
            <= Math.Tan(TURNNING_CRITICAL_RAD) Then                                 '左右转临界
            If GamePadState.ThumbSticks.Left.X > 0 Then
                Global_Var.SpeedCoeffientL = spd
                Global_Var.SpeedCoeffientR = -spd
            Else
                Global_Var.SpeedCoeffientL = -spd
                Global_Var.SpeedCoeffientR = spd
            End If
        Else
            Dim ratio As Double = Math.Abs(GamePadState.ThumbSticks.Left.Y) / (Math.Abs(GamePadState.ThumbSticks.Left.X) + Math.Abs(GamePadState.ThumbSticks.Left.Y))
            If GamePadState.ThumbSticks.Left.Y > 0 And GamePadState.ThumbSticks.Left.X < 0 Then
                Global_Var.SpeedCoeffientR = spd
                Global_Var.SpeedCoeffientL = spd * ratio
            ElseIf GamePadState.ThumbSticks.Left.Y > 0 And GamePadState.ThumbSticks.Left.X > 0 Then
                Global_Var.SpeedCoeffientL = spd
                Global_Var.SpeedCoeffientR = spd * ratio
            ElseIf GamePadState.ThumbSticks.Left.Y < 0 And GamePadState.ThumbSticks.Left.X < 0 Then
                spd = -spd
                Global_Var.SpeedCoeffientR = spd
                Global_Var.SpeedCoeffientL = spd * ratio
            ElseIf GamePadState.ThumbSticks.Left.Y < 0 And GamePadState.ThumbSticks.Left.X > 0 Then
                spd = -spd
                Global_Var.SpeedCoeffientR = spd * ratio
                Global_Var.SpeedCoeffientL = spd
            End If
        End If

        '=========================左右自转=================================
        If Global_Var.GamePadPreState.DPad.Left <> GamePadState.DPad.Left Then
            If GamePadState.IsButtonDown(Input.Buttons.DPadLeft) Then
                Global_Var.Robot_LTurn_Override = True
                Global_Var.Robot_Rturn_Override = False
            End If
            If GamePadState.IsButtonUp(Input.Buttons.DPadLeft) Then
                Global_Var.Robot_LTurn_Override = False
            End If
        End If
        If Global_Var.GamePadPreState.DPad.Right <> GamePadState.DPad.Right Then
            If GamePadState.IsButtonDown(Input.Buttons.DPadRight) Then
                Global_Var.Robot_LTurn_Override = False
                Global_Var.Robot_Rturn_Override = True
            End If
            If GamePadState.IsButtonUp(Input.Buttons.DPadRight) Then
                Global_Var.Robot_Rturn_Override = False
            End If
        End If
        '===================================================================

        Dim c As Single = 1
        If Global_Var.Robot_Shift Then
            c = 0.5
        End If
        Dim leftspd As Byte = 128
        Dim rightspd As Byte = 128
        If Global_Var.Robot_LTurn_Override Then
            leftspd = CByte(128 - (65 + 62 * c))
            rightspd = CByte(128 + (65 + 62 * c))
        ElseIf Global_Var.Robot_Rturn_Override Then
            leftspd = CByte(128 + (65 + 62 * c))
            rightspd = CByte(128 - (65 + 62 * c))
        Else
            leftspd = CByte(128 + Global_Var.SpeedCoeffientL * (65 + 62 * c))
            rightspd = CByte(128 + Global_Var.SpeedCoeffientR * (65 + 62 * c))
        End If
        leftspd = 256 - leftspd
        rightspd = 256 - rightspd
        If My.Computer.Clock.TickCount - Out_Buffer.CMD_Set_DMotor_Last_Time > Global_Var.Com_SetDMotor_Delay Then
            If ((Global_Var.Robot_WheelL_Speed <> leftspd) Or (Global_Var.Robot_WheelR_Speed <> rightspd)) Then
                Out_Buffer.CMD_Set_DMotor_Last_Time = My.Computer.Clock.TickCount
                Global_Var.Robot_WheelL_Speed = leftspd
                Global_Var.Robot_WheelR_Speed = rightspd
                Out_Buffer.Enque(New Out_Msg(11, Global_Var.Com_CMD.Set_DMotor, 0, rightspd, 0, leftspd))
            End If
        End If
    End Function

    Public Overrides Function ShiftButton() As Boolean

        Return GamePadState.Buttons.B = Input.ButtonState.Pressed

    End Function

    Public Overrides Function LoaderDir() As Integer
        If (GamePadState.Buttons.LeftShoulder = Input.ButtonState.Pressed) And _
               (GamePadState.Buttons.RightShoulder = Input.ButtonState.Pressed) Then
            Return LoaderStop
        ElseIf (GamePadState.Buttons.LeftShoulder = Input.ButtonState.Pressed) And _
               (Not GamePadState.Buttons.RightShoulder = Input.ButtonState.Pressed) Then
            Return LoaderDown
        ElseIf (Not GamePadState.Buttons.LeftShoulder = Input.ButtonState.Pressed) And _
               (GamePadState.Buttons.RightShoulder = Input.ButtonState.Pressed) Then
            Return LoaderUp
        Else
            Return LoaderStop
        End If
    End Function

    Public Overrides Function PumpState() As Boolean
        If Global_Var.GamePadPreState.Buttons.Y <> GamePadState.Buttons.Y Then
            If GamePadState.Buttons.Y = Input.ButtonState.Pressed Then
                Global_Var.Robot_IsHolding = Not Global_Var.Robot_IsHolding
            End If
        End If
        Return Global_Var.Robot_IsHolding
    End Function

    Public Overrides Function RobotRotation() As Integer
        If Global_Var.GamePadPreState.DPad.Left <> GamePadState.DPad.Left Then
            If GamePadState.IsButtonDown(Input.Buttons.DPadLeft) Then
                Global_Var.Robot_LTurn_Override = True
                Global_Var.Robot_Rturn_Override = False
            End If
            If GamePadState.IsButtonUp(Input.Buttons.DPadLeft) Then
                Global_Var.Robot_LTurn_Override = False
            End If
        End If
        If Global_Var.GamePadPreState.DPad.Right <> GamePadState.DPad.Right Then
            If GamePadState.IsButtonDown(Input.Buttons.DPadRight) Then
                Global_Var.Robot_LTurn_Override = False
                Global_Var.Robot_Rturn_Override = True
            End If
            If GamePadState.IsButtonUp(Input.Buttons.DPadRight) Then
                Global_Var.Robot_Rturn_Override = False
            End If
        End If
    End Function

End Class

Public Class PlayerInput_GenericKeyboard
    Inherits PlayerInputHAL
    Private BufferedKeyboardState As Input.KeyboardState
    Public Overrides Sub RefreshSource()
        BufferedKeyboardState = Input.Keyboard.GetState
    End Sub

    Public Overrides Function CraneHDir() As Integer
        If BufferedKeyboardState.Item(Input.Keys.I) = Input.KeyState.Down Then
            Return CraneHFoward
        ElseIf BufferedKeyboardState.Item(Input.Keys.K) = Input.KeyState.Down Then
            Return CraneHBack
        Else
            Return CraneHStop
        End If
    End Function

    Public Overrides Function CraneRotation() As Integer
        If BufferedKeyboardState.Item(Input.Keys.J) = Input.KeyState.Down Then
            Return CraneRotationCtClockwise
        ElseIf BufferedKeyboardState.Item(Input.Keys.L) = Input.KeyState.Down Then
            Return CraneRotationClockwise
        Else
            Return CraneRotationStop
        End If
    End Function

    Public Overrides Function CraneVDir() As Integer
        If BufferedKeyboardState.Item(Input.Keys.Y) = Input.KeyState.Down Then
            Return CraneVUp
        ElseIf BufferedKeyboardState.Item(Input.Keys.H) = Input.KeyState.Down Then
            Return CraneVDown
        Else
            Return CraneVStop
        End If
    End Function

    Public Overrides Function LoaderDir() As Integer
        If BufferedKeyboardState.Item(Input.Keys.T) = Input.KeyState.Down Then
            Return LoaderUp
        ElseIf BufferedKeyboardState.Item(Input.Keys.G) = Input.KeyState.Down Then
            Return LoaderDown
        Else
            Return LoaderStop
        End If
    End Function

    Public Overrides Function LoaderState() As Integer
        Static tState As Boolean '[
        tState = Not tState
        If tState Then

        Else

        End If
    End Function

    Public Overrides Function MotorSpd() As PlayerInputHAL.RobotDMotorSpdCo
        Dim t As New RobotDMotorSpdCo
        If BufferedKeyboardState.Item(Input.Keys.W) = Input.KeyState.Down Then
            t.LeftSpd = 1
            t.RightSpd = 1
        ElseIf BufferedKeyboardState.Item(Input.Keys.S) = Input.KeyState.Down Then
            t.LeftSpd = -1
            t.RightSpd = -1
        Else
            t.LeftSpd = 0
            t.RightSpd = 0
        End If
        Return t
    End Function

    Public Overrides Function PumpState() As Boolean
        Static tpumpstate As Boolean
        Static tstate As Boolean
        Dim nstate As Boolean = BufferedKeyboardState.Item(Input.Keys.P) = Input.KeyState.Down
        If tstate <> nstate Then
            If nstate Then tpumpstate = Not tpumpstate
            tstate = nstate
        End If
        If tpumpstate Then
            Return PumpOn
        Else
            Return PumpOff
        End If
    End Function

    Public Overrides Function ShiftButton() As Boolean
        If BufferedKeyboardState.Item(Input.Keys.RightShift) = Input.KeyState.Down Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Overrides Function RobotRotation() As Integer
        If BufferedKeyboardState.Item(Input.Keys.A) = Input.KeyState.Down Then
            Return RobotLeftRotate
        ElseIf BufferedKeyboardState.Item(Input.Keys.D) = Input.KeyState.Down Then
            Return RobotRightRotate
        Else
            Return RobotRotateStop
        End If
    End Function

End Class