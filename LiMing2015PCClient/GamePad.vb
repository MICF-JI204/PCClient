Imports Microsoft.Xna.Framework
Partial Public Class Form_ORRM

    Const FBCRTITICAL_RAD As Single = 88 / 180 * Math.PI
    Const TURNNING_CRITICAL_RAD As Single = 4 / 180 * Math.PI

    Public Thread_GamePad As New System.Threading.Thread(AddressOf GamePadIO)
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
                    Update_Controls(GamePadState)
                    Update_Motion_Motor(GamePadState)
                    Update_Data(GamePadState)
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
            System.Threading.Thread.Sleep(15)
        End While
    End Sub

    Public Sub Update_Controls(ByRef GamePadState As Input.GamePadState)
        If Global_Var.GamePadPreState.Buttons.A <> GamePadState.Buttons.A Then
            Dim Text As String = IIf(GamePadState.Buttons.A = 1, "Button A Down", "Button A Up")
            ChangeUIText(Label_XBox_Connection, Text, Drawing.Color.Blue)
        End If
        If Global_Var.GamePadPreState.Buttons.B <> GamePadState.Buttons.B Then
            Dim Text As String = IIf(GamePadState.Buttons.B = 1, "Button B Down", "Button B Up")
            ChangeUIText(Label_XBox_Connection, Text, Drawing.Color.Blue)
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
                Global_Var.SpeedcoeffientR = spd
                Global_Var.SpeedCoeffientL = spd * ratio
            ElseIf GamePadState.ThumbSticks.Left.Y < 0 And GamePadState.ThumbSticks.Left.X > 0 Then
                Global_Var.SpeedcoeffientR = spd * ratio
                Global_Var.SpeedCoeffientL = spd
            End If
        End If
        '===============================

        '==============================
    End Sub

    Public Sub Update_Data(ByRef GamePadState As Input.GamePadState)

        If Global_Var.GamePadPreState.Buttons.A <> GamePadState.Buttons.A Then
            If GamePadState.Buttons.A = Input.ButtonState.Pressed Then
                Out_Buffer.Enque(New Out_Msg(20, Global_Var.Com_CMD.GamePad_A_Up, 0, 0, 0, 0))
            Else
                Out_Buffer.Enque(New Out_Msg(20, Global_Var.Com_CMD.GamePad_A_Down, 0, 0, 0, 0))
            End If
        End If
        If Global_Var.GamePadPreState.Buttons.B <> GamePadState.Buttons.B Then

        End If
        If Global_Var.GamePadPreState.Buttons.X <> GamePadState.Buttons.X Then

        End If
        If Global_Var.GamePadPreState.Buttons.Y <> GamePadState.Buttons.Y Then

        End If
        If Global_Var.GamePadPreState.Buttons.LeftShoulder <> GamePadState.Buttons.LeftShoulder Then

        End If
        If Global_Var.GamePadPreState.Buttons.RightShoulder <> GamePadState.Buttons.RightShoulder Then

        End If
        If Global_Var.GamePadPreState.DPad.Down <> GamePadState.DPad.Down Then

        End If
        If Global_Var.GamePadPreState.DPad.Up <> GamePadState.DPad.Up Then

        End If
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

    End Sub
End Class

