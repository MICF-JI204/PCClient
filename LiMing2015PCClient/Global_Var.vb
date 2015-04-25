Public Class Global_Var

    Public Const Thread_GamePad_Delay As Integer = 20
    Public Const Thread_Com_Delay As Integer = 10

    Public Const GamePad_Trigger_Critical = 0.8

    Public Shared Graph_Trejection_Radius As Single = 0
    Public Shared Graph_Trejection_Direction As Graph_Trejection_Dir = Graph_Trejection_Dir.Dir_Null
    Public Shared Graph_Trejection_Graph_CentreX As Single = 0.5 * Form_ORRM.PictureBox_Trejection.Width
    Public Shared Graph_Trejection_Graph_CentreY As Single = 0.5 * Form_ORRM.PictureBox_Trejection.Height
    Public Shared Graph_RoboWidth As Single = 30
    Public Shared Graph_RoboHeight As Single = 40
    Public Shared Graph_Wheel_Width As Single = 10
    Public Shared Graph_Wheel_Height As Single = 15

    Public Shared Graph_Crane_Graph_CentreX As Single = 0.36 * Form_ORRM.PictureBox_Crane.Width
    Public Shared Graph_Crane_Graph_CentreY As Single = 0.5 * Form_ORRM.PictureBox_Crane.Height

    Public Shared Robot_Crane_Angle As Single = 0
    Public Shared Robot_WheelL_Speed As Byte = 0
    Public Shared Robot_WheelR_Speed As Byte = 0
    Public Shared Robot_Wheel_MaxSpeed As Integer = 255
    Public Shared Robot_Wheel_MinSpeed As Integer = 0
    Public Shared Robot_LTurn_Override As Boolean = False
    Public Shared Robot_Rturn_Override As Boolean = False
    Public Shared Robot_Crane_VDir As Crane_State = Crane_State.Crane_Still
    Public Shared Robot_Crane_HDir As Integer = 0
    Public Shared Robot_IsHolding As Boolean = False
    Public Shared Robot_Yuntai_Dir As Integer = 0 '0 stop, 1 Left ,2 Right
    Public Shared Robot_Shift As Boolean = False
    Public Shared Robot_Loader_Dir As Integer = 0 '0 stop, 1 down, 2 up
    Public Shared Robot_Loader_State As Integer = 0 '0 Loading, 1 Preparing,2 Unloading, 3 Unloaded

    Public Shared Com_Ready2Connect As Boolean = False
    Public Shared Com_TextMode As Boolean = False
    Public Shared Com_IsClosing As Boolean = False
    Public Shared Com_LastCMDSent As Integer = 0
    Public Shared Com_SetDMotor_Delay As Integer = 20
    Public Shared Com_SetCraneDir_Delay As Integer = 20


    Public Shared SpeedCoeffientL As Single = 0
    Public Shared SpeedCoeffientR As Single = 0

    'Public Shared spd As Single = 0
    'Public Shared ratio As Single = 0

    Public Shared TimeLastFame_Trej As Integer = 0
    Public Shared StartUpTime As Long = My.Computer.Clock.TickCount

    Public Shared GamePadPreState As Microsoft.Xna.Framework.Input.GamePadState

    Public Enum Crane_State As Integer
        Crane_Still = 0
        Crane_Up = 1
        Crane_Down = 2
    End Enum

    Public Enum Graph_Trejection_Dir As Integer
        Dir_Null = 0
        Forward_Left = 1
        Forward_Right = 2
        BackWard_Left = 3
        BackWard_Right = 4
        Forward = 5
        Backward = 6
    End Enum

    Public Enum Err_List As Integer
        NormalExit = 0
        Err_Wrong_In_Header = -1
        Err_Wrong_In_CheckSum = -2
        Err_Exit_With_Msg = -3
    End Enum

    Public Enum Com_CMD As Byte
        Abort = &HFF  'No Argument
        ConfirmCMD = &HF0 'Arg1:int,instruction No. Arg2. Empty
        Set_DMotor = &HA0 ' Arg1:int,spdL;Arg2:int,spdR
        Set_Crane_Dir = &HA1 'Arg1:int dir_in_degrees
        HandShake = &HF1 'No Arg.
        HandConfirm = &HF2 'No Arg.
        'GamePad_X_Down = &HB0 'No Argument
        'GamePad_Y_Down = &HB1
        ''GamePad_A_Down = &HB2
        ''GamePad_B_Down = &HB3
        'GamePad_A_Down = &H1
        'GamePad_B_Down = &H2
        'GamePad_X_Up = &HB4 'No Argument
        'GamePad_Y_Up = &HB5
        'GamePad_A_Up = &HB6
        'GamePad_B_Up = &HB7
        'GamePad_U_Down = &HC2
        'GamePad_D_Down = &HC3
        'GamePad_L_Up = &HC4 'No Argument
        'GamePad_R_Up = &HC5
        'GamePad_U_Up = &HC6
        'GamePad_D_Up = &HC7
        'GamePad_RB_DOWN = &HD0
        'GamePad_RB_Up = &HD1

        Yuntai_Slow = &HE1
        Yuntai_Fast = &HE2
        Yuntai_Stop = &HE3

        Crane_HSetSpeed = &HE4
        Crane_HStop = &HE5
        Crane_VSetSpeed = &HE6
        Crane_VStop = &HE7
        Crane_Hold = &HE8
        Crane_Release = &HE9

        Loader_Up = &HB1
        Loader_Down = &HB2
        Loader_Stop = &HB3
        Loader_StartUnload = &HB4
        Loader_StopUnload = &HB5


    End Enum

    Public Shared Function Get_ComCMD_Code(ByVal name As String) As Com_CMD
        Return CType([Enum].Parse(GetType(Com_CMD), name), Com_CMD)
    End Function

    Public Shared Function Get_ComCMD_Name(ByVal code As Com_CMD) As String
        Dim t As String
        Try
            t = [Enum].GetName(GetType(Com_CMD), code)
        Catch ex As Exception
            Return "UK_Msg" & "(" & Hex(code) & ")"
        End Try

        If t <> Nothing Then Return t
        Return "UK_Msg" & "(" & Hex(code) & ")"
    End Function
End Class