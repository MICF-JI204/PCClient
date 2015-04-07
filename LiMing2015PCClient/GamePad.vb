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
        ChangeUIText(Label_XBox_Connection, "Connected", Drawing.Color.Green)
        Log("Xbox Connected")
        ChangeStatusLabel(ToolStripStatusLabel_GamePad_Status, "Connection Established", Drawing.Color.Green)
        While True
            If GamePadState.IsConnected Then
                Update_Controls(GamePadState)
                Update_Motion_Motor(GamePadState)
                Update_Buffer(GamePadState)
                Update_Trejectory_Graph(GamePadState)
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
            GamePadState = Input.GamePad.GetState(PlayerIndex.One)
            System.Threading.Thread.Sleep(20)
        End While
    End Sub

    Public Sub Update_Controls(ByRef GamePadState As Input.GamePadState)
        ChangeUIText(LX, GamePadState.ThumbSticks.Left.X, Drawing.Color.Black)
        ChangeUIText(LY, GamePadState.ThumbSticks.Left.Y, Drawing.Color.Black)
        ChangeUIText(RX, GamePadState.ThumbSticks.Right.X, Drawing.Color.Black)
        ChangeUIText(RY, GamePadState.ThumbSticks.Right.Y, Drawing.Color.Black)
        If GamePadState.IsButtonDown(Input.Buttons.A) Then ChangeUIText(Label_XBox_Connection, "A Down", Drawing.Color.Blue)
        If GamePadState.IsButtonDown(Input.Buttons.B) Then ChangeUIText(Label_XBox_Connection, "B Down", Drawing.Color.Blue)
        If GamePadState.IsButtonDown(Input.Buttons.X) Then ChangeUIText(Label_XBox_Connection, "X Down", Drawing.Color.Blue)
        If GamePadState.IsButtonDown(Input.Buttons.Y) Then ChangeUIText(Label_XBox_Connection, "Y Down", Drawing.Color.Blue)
        If GamePadState.IsButtonDown(Input.Buttons.DPadLeft) Then ChangeUIText(Label_XBox_Connection, "Dir Left Down", Drawing.Color.Blue)
        If GamePadState.IsButtonDown(Input.Buttons.DPadRight) Then ChangeUIText(Label_XBox_Connection, "Dir Right Down", Drawing.Color.Blue)
        If GamePadState.IsButtonDown(Input.Buttons.DPadUp) Then ChangeUIText(Label_XBox_Connection, "Dir Up Down", Drawing.Color.Blue)
        If GamePadState.IsButtonDown(Input.Buttons.DPadDown) Then ChangeUIText(Label_XBox_Connection, "Dir Down Down", Drawing.Color.Blue)
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

        If GamePadState.IsButtonDown(Input.Buttons.DPadLeft) Then
            Global_Var.Robot_LTurn_Override = True
            Global_Var.Robot_Rturn_Override = False
        End If

        If GamePadState.IsButtonUp(Input.Buttons.DPadLeft) Then
            Global_Var.Robot_LTurn_Override = False
        End If

        If GamePadState.IsButtonDown(Input.Buttons.DPadRight) Then
            Global_Var.Robot_LTurn_Override = False
            Global_Var.Robot_Rturn_Override = True
        End If

        If GamePadState.IsButtonUp(Input.Buttons.DPadRight) Then
            Global_Var.Robot_Rturn_Override = False
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
    End Sub

    Public Sub Update_Buffer(ByRef GamePadState As Input.GamePadState)
        If GamePadState.IsButtonDown(Input.Buttons.A) Then
            Out_Buffer.Enque(New Out_Msg(Global_Var.Com_CMD.GamePad_A_Down, 30, 0, 0, 0, 0))
        End If
        If GamePadState.IsButtonUp(Input.Buttons.A) Then
            Out_Buffer.Enque(New Out_Msg(Global_Var.Com_CMD.GamePad_A_Up, 30, 0, 0, 0, 0))
        End If
        If GamePadState.IsButtonDown(Input.Buttons.B) Then
            Out_Buffer.Enque(New Out_Msg(Global_Var.Com_CMD.GamePad_B_Down, 30, 0, 0, 0, 0))
        End If
        If GamePadState.IsButtonUp(Input.Buttons.B) Then
            Out_Buffer.Enque(New Out_Msg(Global_Var.Com_CMD.GamePad_B_Up, 30, 0, 0, 0, 0))
        End If
        If GamePadState.IsButtonDown(Input.Buttons.X) Then
            Out_Buffer.Enque(New Out_Msg(Global_Var.Com_CMD.GamePad_X_Down, 30, 0, 0, 0, 0))
        End If
        If GamePadState.IsButtonUp(Input.Buttons.X) Then
            Out_Buffer.Enque(New Out_Msg(Global_Var.Com_CMD.GamePad_X_Up, 30, 0, 0, 0, 0))
        End If
        If GamePadState.IsButtonDown(Input.Buttons.Y) Then
            Out_Buffer.Enque(New Out_Msg(Global_Var.Com_CMD.GamePad_Y_Down, 30, 0, 0, 0, 0))
        End If
        If GamePadState.IsButtonUp(Input.Buttons.Y) Then
            Out_Buffer.Enque(New Out_Msg(Global_Var.Com_CMD.GamePad_Y_Up, 30, 0, 0, 0, 0))
        End If
    End Sub
End Class

