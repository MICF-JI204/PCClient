Imports Microsoft.Xna.Framework

Public Class MultiInputITL 'Translation Layer, 
    'Translate HAL to corresponding command with arguments
    Public Shared InputSource As PlayerInputHAL
    Public Shared DesTbl As OpTranslationDesTbl

    Public Shared Sub UpdateSouce()
        InputSource.RefreshSource()
    End Sub

    Public Shared Function GetRobotSpd() As Generic_IOStatus
        Const FBCRTITICAL_RAD As Single = 88 / 180 * Math.PI
        Const TURNNING_CRITICAL_RAD As Single = 4 / 180 * Math.PI
        Dim tthumb As PlayerInputHAL.MThumbStickInput = InputSource.MotorSpd
        Dim SpdCoL As Single = 0
        Dim SpdCoR As Single = 0
        Dim spd As Double = Math.Sqrt(Math.Pow(tthumb.X, 2) + Math.Pow(tthumb.Y, 2))
        If spd > 1 Then spd = 1
        If tthumb.X = 0 And tthumb.Y = 0 Then '静止态
            SpdCoL = 0
            SpdCoR = 0
        ElseIf Math.Abs(tthumb.Y / tthumb.X) _
            >= Math.Tan(FBCRTITICAL_RAD) Then                                        '几乎直线态
            SpdCoL = spd * Math.Sign(tthumb.Y)
            SpdCoR = SpdCoL
        ElseIf Math.Abs(tthumb.Y / tthumb.X) _
            <= Math.Tan(TURNNING_CRITICAL_RAD) Then                                 '左右转临界
            If tthumb.X > 0 Then
                SpdCoL = spd
                SpdCoR = -spd
            Else
                SpdCoL = -spd
                SpdCoR = spd
            End If
        Else
            Dim ratio As Double = Math.Abs(tthumb.Y) / (Math.Abs(tthumb.X) + Math.Abs(tthumb.Y))
            If tthumb.Y > 0 And tthumb.X < 0 Then
                SpdCoR = spd
                SpdCoL = spd * ratio
            ElseIf tthumb.Y > 0 And tthumb.X > 0 Then
                SpdCoL = spd
                SpdCoR = spd * ratio
            ElseIf tthumb.Y < 0 And tthumb.X < 0 Then
                spd = -spd
                SpdCoR = spd
                SpdCoL = spd * ratio
            ElseIf tthumb.Y < 0 And tthumb.X > 0 Then
                spd = -spd
                SpdCoR = spd * ratio
                SpdCoL = spd
            End If
        End If
        '=========================左右自转=================================
        Dim t As New Generic_IOStatus
        If InputSource.RobotRotation = PlayerInputHAL.RobotLeftRotate Then 'Overriding Original Spd
            SpdCoL = -1
            SpdCoR = 1
        ElseIf InputSource.RobotRotation = PlayerInputHAL.RobotRightRotate Then
            SpdCoL = -1
            SpdCoR = 1
        End If
        t.CMD = Global_Var.Com_CMD.Set_DMotor
        t.Arg1L = DesTbl.DMotorMidPoint + Math.Sign(SpdCoL) * _
                    (DesTbl.DMotorRespondingOffset + (127 - DesTbl.DMotorRespondingOffset) * Math.Abs(SpdCoL))
        t.Arg2L = DesTbl.DMotorMidPoint + Math.Sign(SpdCoR) * _
            (DesTbl.DMotorRespondingOffset + (127 - DesTbl.DMotorRespondingOffset) * Math.Abs(SpdCoR))
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
        '=====================Trej. Graph=======================================
        Const FBCRTITICAL_RAD As Single = 88 / 180 * Math.PI
        Const TURNNING_CRITICAL_RAD As Single = 4 / 180 * Math.PI
        Dim tthumb As PlayerInputHAL.MThumbStickInput = InputSource.MotorSpd
        If tthumb.X = 0 And tthumb.Y = 0 Then '静止态
            UIBuffer.Graph_Trejection_Direction = Global_Var.Graph_Trejection_Dir.Dir_Null
        ElseIf Math.Abs(tthumb.Y / tthumb.X) _
            >= Math.Tan(FBCRTITICAL_RAD) Then                                        '几乎直线态
            If tthumb.Y > 0 Then
                UIBuffer.Graph_Trejection_Direction = Global_Var.Graph_Trejection_Dir.Forward
            Else
                UIBuffer.Graph_Trejection_Direction = Global_Var.Graph_Trejection_Dir.Backward
            End If
        ElseIf Math.Abs(tthumb.Y / tthumb.X) _
            <= Math.Tan(TURNNING_CRITICAL_RAD) Then '左右转临界
            If tthumb.X > 0 Then
                UIBuffer.Graph_Trejection_Direction = Global_Var.Graph_Trejection_Dir.Forward_Right
            Else
                UIBuffer.Graph_Trejection_Direction = Global_Var.Graph_Trejection_Dir.Forward_Left
            End If
            UIBuffer.Graph_Trejection_Radius = 1
        Else
            If tthumb.Y > 0 And tthumb.X < 0 Then
                UIBuffer.Graph_Trejection_Direction = Global_Var.Graph_Trejection_Dir.Forward_Left
            ElseIf tthumb.Y > 0 And tthumb.X > 0 Then
                UIBuffer.Graph_Trejection_Direction = Global_Var.Graph_Trejection_Dir.Forward_Right
            ElseIf tthumb.Y < 0 And tthumb.X < 0 Then
                UIBuffer.Graph_Trejection_Direction = Global_Var.Graph_Trejection_Dir.BackWard_Left
            ElseIf tthumb.Y < 0 And tthumb.X > 0 Then
                UIBuffer.Graph_Trejection_Direction = Global_Var.Graph_Trejection_Dir.BackWard_Right
            End If
            UIBuffer.Graph_Trejection_Radius = Global_Var.Graph_RoboWidth * Math.Abs(tthumb.Y / tthumb.X)
        End If
        If InputSource.RobotRotation = PlayerInputHAL.RobotLeftRotate Then 'Overriding Original Spd
            UIBuffer.Robot_LTurn_Override = True
            UIBuffer.Robot_Rturn_Override = False
        ElseIf InputSource.RobotRotation = PlayerInputHAL.RobotRightRotate Then
            UIBuffer.Robot_LTurn_Override = False
            UIBuffer.Robot_Rturn_Override = True
        Else
            UIBuffer.Robot_LTurn_Override = False
            UIBuffer.Robot_Rturn_Override = False
        End If
        '======================================================================================================
        If TypeOf InputSource Is PlayerInput_GenericGamePad Then
            UIBuffer.IsCraneGraphUpdateRequire = True
        Else
            UIBuffer.IsCraneGraphUpdateRequire = False
        End If
        '======================================================================================================
        Dim t As Integer
        t = InputSource.CraneRotation()
        If t = PlayerInputHAL.CraneRotationClockwise Then
            UIBuffer.CraneRotationLeft = True
            UIBuffer.CraneRotationRight = False
        ElseIf t = PlayerInputHAL.CraneRotationCtClockwise Then
            UIBuffer.CraneRotationLeft = False
            UIBuffer.CraneRotationRight = True
        Else
            UIBuffer.CraneRotationLeft = False
            UIBuffer.CraneRotationRight = False
        End If
        t = InputSource.CraneHDir()
        If t = PlayerInputHAL.CraneHFoward Then
            UIBuffer.CraneHForward = True
            UIBuffer.CraneHBackward = False
        ElseIf t = PlayerInputHAL.CraneHBack Then
            UIBuffer.CraneHForward = False
            UIBuffer.CraneHBackward = True
        Else
            UIBuffer.CraneHForward = False
            UIBuffer.CraneHBackward = False
        End If
        t = InputSource.CraneVDir()
        If t = PlayerInputHAL.CraneVUp Then
            UIBuffer.CraneVUp = True
            UIBuffer.CraneVDown = False
        ElseIf t = PlayerInputHAL.CraneVDown Then
            UIBuffer.CraneVUp = False
            UIBuffer.CraneVDown = True
        Else
            UIBuffer.CraneVUp = False
            UIBuffer.CraneVDown = False
        End If
        '=======================================================================================================
        t = InputSource.LoaderDir
        If t = PlayerInputHAL.LoaderUp Then
            UIBuffer.LoaderUp = True
            UIBuffer.LoaderDown = False
        ElseIf t = PlayerInputHAL.LoaderDown Then
            UIBuffer.LoaderUp = False
            UIBuffer.LoaderDown = True
        Else
            UIBuffer.LoaderUp = False
            UIBuffer.LoaderDown = False
        End If
        '=======================================================================
        t = InputSource.PumpState
        If t = PlayerInputHAL.PumpOn Then
            UIBuffer.PumpState = True
        Else
            UIBuffer.PumpState = False
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

    Public Structure MThumbStickInput
        Public X As Single
        Public Y As Single
    End Structure

    Public MustOverride Sub RefreshSource()
    Public MustOverride Function RobotRotation() As Integer
    Public MustOverride Function LoaderState() As Integer
    Public MustOverride Function LoaderDir() As Integer
    Public MustOverride Function CraneRotation() As Integer
    Public MustOverride Function CraneHDir() As Integer
    Public MustOverride Function CraneVDir() As Integer
    Public MustOverride Function MotorSpd() As MThumbStickInput
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

    Public Overrides Function MotorSpd() As MThumbStickInput

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
        If GamePadState.IsButtonDown(Input.Buttons.DPadLeft) Then
            Return PlayerInputHAL.RobotLeftRotate
        End If
        If GamePadState.IsButtonDown(Input.Buttons.DPadRight) Then
            Return PlayerInputHAL.RobotRightRotate
        End If
        Return RobotRotateStop
    End Function

End Class

Public Class PlayerInput_GenericKeyboard
    Inherits PlayerInputHAL
    Public BufferedKeyboardState As Input.KeyboardState

    Public Overrides Sub RefreshSource()
        BufferedKeyboardState = Input.Keyboard.GetState
        Return
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

    Public Overrides Function MotorSpd() As PlayerInputHAL.MThumbStickInput
        Dim t As New PlayerInputHAL.MThumbStickInput
        If BufferedKeyboardState.Item(Input.Keys.W) = Input.KeyState.Down Then
            t.X = 0
            t.Y = 1
        ElseIf BufferedKeyboardState.Item(Input.Keys.S) = Input.KeyState.Down Then
            t.X = 0
            t.Y = -1
        Else
            t.X = 0
            t.Y = 0
        End If
        Return t
    End Function

    Public Overrides Function PumpState() As Boolean
        Static tpumpstate As Boolean
        Static tstate As Boolean
        Dim nstate As Boolean = BufferedKeyboardState.IsKeyDown(Input.Keys.P)
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
            Debug.Print("AAA")
            Return RobotLeftRotate
        ElseIf BufferedKeyboardState.Item(Input.Keys.D) = Input.KeyState.Down Then
            Debug.Print("DDD")
            Return RobotRightRotate
        Else
            Return RobotRotateStop
        End If
    End Function

End Class
