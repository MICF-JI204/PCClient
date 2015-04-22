Imports Microsoft.Xna.Framework
Partial Public Class Form_ORRM

    Const FBCRTITICAL_RAD As Single = 88 / 180 * Math.PI
    Const TURNNING_CRITICAL_RAD As Single = 4 / 180 * Math.PI

    Public Thread_GamePad As New System.Threading.Thread(AddressOf GamePadIO)
    Public Thread_Loader_Unload As New System.Threading.Thread(AddressOf Loader_Unload)

    Public Sub GamePadIO()
        Dim GamePadState As Input.GamePadState
        ChangeUIText(Label_XBox_Connection, "Waiting For GamePad...", Drawing.Color.Blue)
        ChangeStatusLabel(ToolStripStatusLabel_GamePad_Status, "Waiting For GamePad...", Drawing.Color.Blue)
        Do While Input.GamePad.GetState(PlayerIndex.One).IsConnected = False
        Loop
        GamePadState = Input.GamePad.GetState(PlayerIndex.One)
        Global_Var.GamePadPreState = GamePadState
        ChangeUIText(Label_XBox_Connection, "Connected", Drawing.Color.Green)
        Log("Xbox Connected")
        ChangeStatusLabel(ToolStripStatusLabel_GamePad_Status, "Connection Established", Drawing.Color.Green)
        While True
            If GamePadState.IsConnected Then
                If Not Global_Var.GamePadPreState.Equals(GamePadState) Then
                    Update_Data(GamePadState)
                    Update_Motion_Motor(GamePadState)
                    Update_Yuntai(GamePadState)
                    Update_Controls(GamePadState)
                    Update_Crane_Graph(GamePadState)
                    Update_Trejectory_Graph(GamePadState)
                End If
            Else
                ChangeUIText(Label_XBox_Connection, "Disconnected!Waiting...", Drawing.Color.Red)
                Log("Xbox Gamepad Connection Lost")
                ChangeStatusLabel(ToolStripStatusLabel_GamePad_Status, "Disconnected!", Drawing.Color.Red)
                Do While Input.GamePad.GetState(PlayerIndex.One).IsConnected = False
                Loop
                ChangeUIText(Label_XBox_Connection, "Re-Connected", Drawing.Color.Green)
                Log("Xbox Gamepad Connection Re-established")
                ChangeStatusLabel(ToolStripStatusLabel_GamePad_Status, "Connection Established!", Drawing.Color.Green)
            End If
            Global_Var.GamePadPreState = GamePadState
            GamePadState = Input.GamePad.GetState(PlayerIndex.One)
            System.Threading.Thread.Sleep(Global_Var.Thread_GamePad_Delay)
        End While
    End Sub

    Public Sub Update_Controls(ByRef GamePadState As Input.GamePadState)

        If Global_Var.GamePadPreState.Buttons.A <> GamePadState.Buttons.A Then
            Dim str1 As String = IIf(GamePadState.Buttons.A = 1, "Button A Down", "Button A Up")
            ChangeUIText(Label_XBox_Connection, str1, Drawing.Color.Blue)
        End If

        If Global_Var.GamePadPreState.Buttons.B <> GamePadState.Buttons.B Then
            Dim str2 As String = IIf(GamePadState.Buttons.B = 1, "Button B Down", "Button B Up")
            ChangeUIText(Label_XBox_Connection, str2, Drawing.Color.Blue)
        End If

        If Global_Var.GamePadPreState.Buttons.X <> GamePadState.Buttons.X Then
            Dim Text As String = IIf(GamePadState.Buttons.X = 1, "Button X Down", "Button X Up")
            ChangeUIText(Label_XBox_Connection, Text, Drawing.Color.Blue)
        End If

        If Global_Var.GamePadPreState.Buttons.Y <> GamePadState.Buttons.Y Then
            Dim Text As String = IIf(GamePadState.Buttons.Y = 1, "Button Y Down", "Button Y Up")
            ChangeUIText(Label_XBox_Connection, Text, Drawing.Color.Blue)
        End If

        If Global_Var.GamePadPreState.Buttons.LeftShoulder <> GamePadState.Buttons.LeftShoulder Then
            Dim Text As String = IIf(GamePadState.Buttons.LeftShoulder = 1, "Button LS Down", "Button LS Up")
            ChangeUIText(Label_XBox_Connection, Text, Drawing.Color.Blue)
        End If
        If Global_Var.GamePadPreState.Buttons.RightShoulder <> GamePadState.Buttons.RightShoulder Then
            Dim Text As String = IIf(GamePadState.Buttons.RightShoulder = 1, "Button RS Down", "Button RS Up")
            ChangeUIText(Label_XBox_Connection, Text, Drawing.Color.Blue)
        End If
        If Global_Var.GamePadPreState.DPad.Down <> GamePadState.DPad.Down Then
            Dim Text As String = IIf(GamePadState.DPad.Down = 1, "Down Pressed", "Down Released")
            ChangeUIText(Label_XBox_Connection, Text, Drawing.Color.Blue)
        End If
        If Global_Var.GamePadPreState.DPad.Up <> GamePadState.DPad.Up Then
            Dim Text As String = IIf(GamePadState.DPad.Up = 1, "Up Pressed", "Up Released")
            ChangeUIText(Label_XBox_Connection, Text, Drawing.Color.Blue)
        End If
        If Global_Var.GamePadPreState.DPad.Left <> GamePadState.DPad.Left Then
            Dim Text As String = IIf(GamePadState.DPad.Left = 1, "Left Pressed", "Left Released")
            ChangeUIText(Label_XBox_Connection, Text, Drawing.Color.Blue)
        End If
        If Global_Var.GamePadPreState.DPad.Right <> GamePadState.DPad.Right Then
            Dim Text As String = IIf(GamePadState.DPad.Right = 1, "Right Pressed", "Right Released")
            ChangeUIText(Label_XBox_Connection, Text, Drawing.Color.Blue)
        End If
        If Global_Var.GamePadPreState.ThumbSticks.Left.X <> GamePadState.ThumbSticks.Left.X Then
            ChangeUIText(LX, GamePadState.ThumbSticks.Left.X, Drawing.Color.Black)
        End If
        If Global_Var.GamePadPreState.ThumbSticks.Left.Y <> GamePadState.ThumbSticks.Left.Y Then
            ChangeUIText(LY, GamePadState.ThumbSticks.Left.Y, Drawing.Color.Black)
        End If
        If Global_Var.GamePadPreState.ThumbSticks.Right.X <> GamePadState.ThumbSticks.Right.X Then
            ChangeUIText(RX, GamePadState.ThumbSticks.Right.X, Drawing.Color.Black)
        End If
        If Global_Var.GamePadPreState.ThumbSticks.Right.Y <> GamePadState.ThumbSticks.Right.Y Then
            ChangeUIText(RY, GamePadState.ThumbSticks.Right.Y, Drawing.Color.Black)
        End If

        Static tloaderstate As Integer
        If tloaderstate <> Global_Var.Robot_Loader_Dir Then
            If Global_Var.Robot_Loader_Dir = 0 Then
                ChangeUIBackColor(Button_Loader_Down, Drawing.Color.Gainsboro)
                ChangeUIBackColor(Button_Loader_Up, Drawing.Color.Gainsboro)
            ElseIf Global_Var.Robot_Loader_Dir = 1 Then
                ChangeUIBackColor(Button_Loader_Down, Drawing.Color.Red)
                ChangeUIBackColor(Button_Loader_Up, Drawing.Color.Gainsboro)
            ElseIf Global_Var.Robot_Loader_Dir = 2 Then
                ChangeUIBackColor(Button_Loader_Down, Drawing.Color.Gainsboro)
                ChangeUIBackColor(Button_Loader_Up, Drawing.Color.Red)
            End If
            tloaderstate = Global_Var.Robot_Loader_Dir
        End If

        Dim t As Integer = Threading.Thread.VolatileRead(Global_Var.Robot_Loader_State)

        If t = 2 Then
            ChangeUIBackColor(Button_Loader_Unload, Drawing.Color.Red)
        Else
            'ChangeUIBackColor(Button_Loader_Unload, Drawing.Color.Gainsboro)
        End If

        If Global_Var.Robot_IsHolding Then
            ChangeUIBackColor(Button_Crane_Holder, Drawing.Color.Red)
        Else
            ChangeUIBackColor(Button_Crane_Holder, Drawing.Color.PaleGreen)
        End If

        If Global_Var.Robot_Crane_VDir = Global_Var.Crane_State.Crane_Still Then
            ChangeUIBackColor(Button_Crane_Down, Drawing.Color.Gainsboro)
            ChangeUIBackColor(Button_Crane_UP, Drawing.Color.Gainsboro)
        ElseIf Global_Var.Robot_Crane_VDir = Global_Var.Crane_State.Crane_Down Then
            ChangeUIBackColor(Button_Crane_Down, Drawing.Color.Red)
            ChangeUIBackColor(Button_Crane_UP, Drawing.Color.Gainsboro)
        Else
            ChangeUIBackColor(Button_Crane_Down, Drawing.Color.Gainsboro)
            ChangeUIBackColor(Button_Crane_UP, Drawing.Color.Red)
        End If

    End Sub

    Public Sub Update_Trejectory_Graph(ByRef GamePadState As Input.GamePadState)

        If GamePadState.ThumbSticks.Left.X = 0 And GamePadState.ThumbSticks.Left.Y = 0 Then '静止态
            Global_Var.Graph_Trejection_Direction = Global_Var.Graph_Trejection_Dir.Dir_Null
        ElseIf Math.Abs(GamePadState.ThumbSticks.Left.Y / GamePadState.ThumbSticks.Left.X) _
            >= Math.Tan(FBCRTITICAL_RAD) Then                                        '几乎直线态
            If GamePadState.ThumbSticks.Left.Y > 0 Then
                Global_Var.Graph_Trejection_Direction = Global_Var.Graph_Trejection_Dir.Forward
            Else
                Global_Var.Graph_Trejection_Direction = Global_Var.Graph_Trejection_Dir.Backward
            End If
        ElseIf Math.Abs(GamePadState.ThumbSticks.Left.Y / GamePadState.ThumbSticks.Left.X) _
            <= Math.Tan(TURNNING_CRITICAL_RAD) Then '左右转临界
            If GamePadState.ThumbSticks.Left.X > 0 Then
                Global_Var.Graph_Trejection_Direction = Global_Var.Graph_Trejection_Dir.Forward_Right
            Else
                Global_Var.Graph_Trejection_Direction = Global_Var.Graph_Trejection_Dir.Forward_Left
            End If
            Global_Var.Graph_Trejection_Radius = 1
        Else

            If GamePadState.ThumbSticks.Left.Y > 0 And GamePadState.ThumbSticks.Left.X < 0 Then
                Global_Var.Graph_Trejection_Direction = Global_Var.Graph_Trejection_Dir.Forward_Left
            ElseIf GamePadState.ThumbSticks.Left.Y > 0 And GamePadState.ThumbSticks.Left.X > 0 Then
                Global_Var.Graph_Trejection_Direction = Global_Var.Graph_Trejection_Dir.Forward_Right
            ElseIf GamePadState.ThumbSticks.Left.Y < 0 And GamePadState.ThumbSticks.Left.X < 0 Then
                Global_Var.Graph_Trejection_Direction = Global_Var.Graph_Trejection_Dir.BackWard_Left
            ElseIf GamePadState.ThumbSticks.Left.Y < 0 And GamePadState.ThumbSticks.Left.X > 0 Then
                Global_Var.Graph_Trejection_Direction = Global_Var.Graph_Trejection_Dir.BackWard_Right
            End If
            Global_Var.Graph_Trejection_Radius = Global_Var.Graph_RoboWidth _
                * Math.Abs(GamePadState.ThumbSticks.Left.Y / GamePadState.ThumbSticks.Left.X)
        End If


        Update_Trejectory()
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


    '==========================云台====================================
    Public Sub Update_Yuntai(ByRef GamePadState As Input.GamePadState)
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
    End Sub

    Public Sub Update_Motion_Motor(ByRef GamePadState As Input.GamePadState)
        Dim spd As Double = Math.Sqrt(Math.Pow(GamePadState.ThumbSticks.Left.X, 2) + Math.Pow(GamePadState.ThumbSticks.Left.Y, 2))
        If spd > 1 Then spd = 1
        If GamePadState.ThumbSticks.Left.X = 0 And GamePadState.ThumbSticks.Left.Y = 0 Then '静止态
            Global_Var.SpeedCoeffientL = 0
            Global_Var.SpeedcoeffientR = 0
        ElseIf Math.Abs(GamePadState.ThumbSticks.Left.Y / GamePadState.ThumbSticks.Left.X) _
            >= Math.Tan(FBCRTITICAL_RAD) Then                                        '几乎直线态
            Global_Var.SpeedCoeffientL = spd * Math.Sign(GamePadState.ThumbSticks.Left.Y)
            Global_Var.SpeedcoeffientR = Global_Var.SpeedCoeffientL
        ElseIf Math.Abs(GamePadState.ThumbSticks.Left.Y / GamePadState.ThumbSticks.Left.X) _
            <= Math.Tan(TURNNING_CRITICAL_RAD) Then                                 '左右转临界
            If GamePadState.ThumbSticks.Left.X > 0 Then
                Global_Var.SpeedCoeffientL = spd
                Global_Var.SpeedcoeffientR = 0
            Else
                Global_Var.SpeedCoeffientL = 0
                Global_Var.SpeedcoeffientR = spd
            End If
        Else
            Dim ratio As Double = Math.Abs(GamePadState.ThumbSticks.Left.Y) / (Math.Abs(GamePadState.ThumbSticks.Left.X) + Math.Abs(GamePadState.ThumbSticks.Left.Y))
            If GamePadState.ThumbSticks.Left.Y > 0 And GamePadState.ThumbSticks.Left.X < 0 Then
                Global_Var.SpeedcoeffientR = spd
                Global_Var.SpeedCoeffientL = spd * ratio
            ElseIf GamePadState.ThumbSticks.Left.Y > 0 And GamePadState.ThumbSticks.Left.X > 0 Then
                Global_Var.SpeedCoeffientL = spd
                Global_Var.SpeedcoeffientR = spd * ratio
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
            leftspd = CByte(128 - 127 * c)
            rightspd = CByte(128 + 127 * c)
        ElseIf Global_Var.Robot_Rturn_Override Then
            leftspd = CByte(128 + 127 * c)
            rightspd = CByte(128 - 127 * c)
        Else
            leftspd = CByte(128 + c * Global_Var.SpeedCoeffientL * 127)
            rightspd = CByte(128 + c * Global_Var.SpeedCoeffientR * 127)
        End If
        If ((Global_Var.Robot_WheelL_Speed <> leftspd) Or (Global_Var.Robot_WheelR_Speed <> rightspd)) Then
            Out_Buffer.Enque(New Out_Msg(11, Global_Var.Com_CMD.Set_DMotor, 0, leftspd, 0, rightspd))
            Global_Var.Robot_WheelL_Speed = leftspd
            Global_Var.Robot_WheelR_Speed = rightspd
        End If
    End Sub

    Public Sub Update_Data(ByRef GamePadState As Input.GamePadState)

        '=====================换挡==========================
        If Global_Var.GamePadPreState.Buttons.B <> GamePadState.Buttons.B Then
            If GamePadState.Buttons.B = Input.ButtonState.Pressed Then
                Global_Var.Robot_Shift = True
            Else
                Global_Var.Robot_Shift = False
            End If
        End If
        '===================================================

        '=======================丝杆部分=====================================
        Dim loader_tstate As Integer
        If (Global_Var.GamePadPreState.Buttons.LeftShoulder <> GamePadState.Buttons.LeftShoulder) _
            Or (Global_Var.GamePadPreState.Buttons.RightShoulder <> GamePadState.Buttons.RightShoulder) Then
            If (GamePadState.Buttons.LeftShoulder = Input.ButtonState.Pressed) And _
               (GamePadState.Buttons.RightShoulder = Input.ButtonState.Pressed) Then
                loader_tstate = 0
            ElseIf (GamePadState.Buttons.LeftShoulder = Input.ButtonState.Pressed) And _
                   (Not GamePadState.Buttons.RightShoulder = Input.ButtonState.Pressed) Then
                loader_tstate = 1
            ElseIf (Not GamePadState.Buttons.LeftShoulder = Input.ButtonState.Pressed) And _
                   (GamePadState.Buttons.RightShoulder = Input.ButtonState.Pressed) Then
                loader_tstate = 2
            Else
                loader_tstate = 0
            End If
        End If
        If loader_tstate <> Global_Var.Robot_Loader_Dir Then
            Global_Var.Robot_Loader_Dir = loader_tstate
            Select Case Global_Var.Robot_Loader_Dir
                Case 0
                    Out_Buffer.Enque(New Out_Msg(11, Global_Var.Com_CMD.Loader_Stop, 0, 0, 0, 0))
                Case 1
                    Out_Buffer.Enque(New Out_Msg(11, Global_Var.Com_CMD.Loader_Down, 0, 0, 0, 0))
                Case 2
                    Out_Buffer.Enque(New Out_Msg(11, Global_Var.Com_CMD.Loader_Up, 0, 0, 0, 0))
            End Select
        End If
        '===================================================================

        ''============================吊臂前后==============================
        'Dim CraneH_tstate As Integer
        'If (Global_Var.GamePadPreState.Buttons.A <> GamePadState.Buttons.A) _
        '    Or (Global_Var.GamePadPreState.Buttons.Y <> GamePadState.Buttons.Y) Then
        '    If (GamePadState.Buttons.A = Input.ButtonState.Pressed) And _
        '       (GamePadState.Buttons.Y = Input.ButtonState.Pressed) Then
        '        CraneH_tstate = 0 'Stop
        '    ElseIf (GamePadState.Buttons.A = Input.ButtonState.Pressed) And _
        '           (GamePadState.Buttons.Y = Input.ButtonState.Released) Then
        '        CraneH_tstate = 1 'Back
        '    ElseIf (GamePadState.Buttons.A = Input.ButtonState.Released) And _
        '           (GamePadState.Buttons.Y = Input.ButtonState.Pressed) Then
        '        CraneH_tstate = 2 'Forward
        '    Else
        '        CraneH_tstate = 0
        '    End If
        'End If
        'If CraneH_tstate <> Global_Var.Robot_Crane_HDir Then
        '    Global_Var.Robot_Crane_HDir = CraneH_tstate
        '    Select Case Global_Var.Robot_Crane_HDir
        '        Case 0
        '            Out_Buffer.Enque(New Out_Msg(11, Global_Var.Com_CMD.Crane_HStop, 0, 0, 0, 0))
        '        Case 1
        '            Out_Buffer.Enque(New Out_Msg(11, Global_Var.Com_CMD.Crane_HSetSpeed, 0, 180, 0, 1))
        '        Case 2
        '            Out_Buffer.Enque(New Out_Msg(11, Global_Var.Com_CMD.Crane_HSetSpeed, 0, 180, 0, 2))
        '    End Select
        'End If
        '==================================================================

        '============================吊臂上下==============================
        Dim CraneV_tstate As Global_Var.Crane_State
        Dim LT_State As Boolean = GamePadState.Triggers.Left > Global_Var.GamePad_Trigger_Critical
        Dim RT_State As Boolean = GamePadState.Triggers.Right > Global_Var.GamePad_Trigger_Critical
        '  If (Global_Var.GamePadPreState.Buttons.LeftShoulder <> GamePadState.Buttons.LeftShoulder) _
        '     Or (Global_Var.GamePadPreState.Buttons.RightShoulder <> GamePadState.Buttons.RightShoulder) Then
        If (LT_State And RT_State) Then
            CraneV_tstate = Global_Var.Crane_State.Crane_Still 'Stop
        ElseIf (LT_State) And (Not RT_State) Then
            CraneV_tstate = Global_Var.Crane_State.Crane_Down 'Down
        ElseIf (Not LT_State) And (RT_State) Then
            CraneV_tstate = Global_Var.Crane_State.Crane_Up 'Up
        Else
            CraneV_tstate = Global_Var.Crane_State.Crane_Still
        End If
        'End If
        If CraneV_tstate <> Global_Var.Robot_Crane_VDir Then
            Global_Var.Robot_Crane_VDir = CraneV_tstate
            Select Case CraneV_tstate
                Case Global_Var.Crane_State.Crane_Still
                    Out_Buffer.Enque(New Out_Msg(11, Global_Var.Com_CMD.Crane_VStop, 0, 0, 0, 0))
                Case Global_Var.Crane_State.Crane_Down
                    Out_Buffer.Enque(New Out_Msg(11, Global_Var.Com_CMD.Crane_VSetSpeed, 0, 180, 0, 1))
                Case Global_Var.Crane_State.Crane_Up
                    Out_Buffer.Enque(New Out_Msg(11, Global_Var.Com_CMD.Crane_VSetSpeed, 0, 180, 0, 2))
            End Select
        End If
        '==================================================================

        '============================抽板==================================
        If Global_Var.GamePadPreState.Buttons.X <> GamePadState.Buttons.X Then
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
        End If
        '=================================================================

        '=========================吸盘===================================
        If Global_Var.GamePadPreState.Buttons.Y <> GamePadState.Buttons.Y Then
            If GamePadState.Buttons.Y = Input.ButtonState.Pressed Then
                Global_Var.Robot_IsHolding = Not Global_Var.Robot_IsHolding
                If Global_Var.Robot_IsHolding Then
                    Out_Buffer.Enque(New Out_Msg(11, Global_Var.Com_CMD.Crane_Hold, 0, 0, 0, 0))
                Else
                    Out_Buffer.Enque(New Out_Msg(11, Global_Var.Com_CMD.Crane_Release, 0, 0, 0, 0))
                End If
            End If
        End If
        '================================================================
    End Sub

    Public Sub Loader_Unload()
        Dim last_known_state As Integer = 0
        Dim i As Integer = 1
        Dim starttime As Integer = 0
        While True
            Dim t As Integer = Threading.Thread.VolatileRead(Global_Var.Robot_Loader_State)
            If (last_known_state = 0) And (t = 1) Then
                Update_ProgressBar(0)
                starttime = My.Computer.Clock.TickCount
                Input.GamePad.SetVibration(PlayerIndex.One, 1, 1)
            ElseIf (last_known_state = 1) And (t = 1) Then
                i = Int(My.Computer.Clock.TickCount - starttime) / 15
                If i >= 100 Then
                    Global_Var.Robot_Loader_State = 2
                    i = 100
                End If
                Update_ProgressBar(i)
                'Threading.Thread.Sleep(30)
            ElseIf (last_known_state = 1) And (t = 2) Then
                Input.GamePad.SetVibration(PlayerIndex.One, 0, 0)
                Log("Starting to UNLOAD")
                Out_Buffer.Enque(New Out_Msg(11, Global_Var.Com_CMD.Loader_StartUnload, 0, 0, 0, 0))
            ElseIf (last_known_state = 1) And (t = 0) Then
                i = 1
                Update_ProgressBar(0)
                Input.GamePad.SetVibration(PlayerIndex.One, 0, 0)
            ElseIf (last_known_state = 2) And (t = 3) Then
                Out_Buffer.Enque(New Out_Msg(11, Global_Var.Com_CMD.Loader_StopUnload, 0, 0, 0, 0))
                Log("UNLOADING COMPLETE")
            End If
            last_known_state = t
        End While
    End Sub
End Class

