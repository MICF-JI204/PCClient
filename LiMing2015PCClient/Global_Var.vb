Public Class Global_Var
    Public Shared Robot_WheelL_Speed As Single = 0
    Public Shared Robot_WheelR_Speed As Single = 0
    Public Shared Robot_Wheel_MaxSpeed As Integer = 255
    Public Shared Robot_Wheel_MinSpeed As Integer = 0
    Public Shared Graph_Trejection_Radius As Single = 0
    Public Shared Graph_Trejection_Direction As Graph_Trejection_Dir = Graph_Trejection_Dir.Dir_Null
    Public Shared Graph_Trejection_Graph_CentreX As Single = 0.5 * Form_ORRM.PictureBox_Trejection.Width
    Public Shared Graph_Trejection_Graph_CentreY As Single = 0.5 * Form_ORRM.PictureBox_Trejection.Height
    Public Shared Graph_RoboWidth As Single = 30
    Public Shared Graph_RoboHeight As Single = 40
    Public Shared Graph_Wheel_Width As Single = 10
    Public Shared Graph_Wheel_Height As Single = 15

    Public Shared Robot_LTurn_Override As Boolean = False
    Public Shared Robot_Rturn_Override As Boolean = False

    Public Shared Com_Ready2Connect As Boolean = False
    Public Shared Com_TextMode As Boolean = False
    Public Shared Com_IsClosing As Boolean = False

    Public Shared SpeedCoeffientL As Single = 0
    Public Shared SpeedcoeffientR As Single = 0

    'Public Shared spd As Single = 0
    'Public Shared ratio As Single = 0

    Public Shared TimeLastFame_Trej As Integer = 0
    Public Shared StartUpTime As Long = My.Computer.Clock.TickCount

    Public Shared GamePadPreState As Microsoft.Xna.Framework.Input.GamePadState


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
        HandShake = &HF1 'No Arg.
        HandConfirm = &HF2 'No Arg.
        GamePad_X_Down = &HB0 'No Argument
        GamePad_Y_Down = &HB1
        'GamePad_A_Down = &HB2
        'GamePad_B_Down = &HB3
        GamePad_A_Down = &H1
        GamePad_B_Down = &H2
        GamePad_X_Up = &HB4 'No Argument
        GamePad_Y_Up = &HB5
        GamePad_A_Up = &HB6
        GamePad_B_Up = &HB7
        GamePad_L_Down = &HC0 'No Argument
        GamePad_R_Down = &HC1
        GamePad_U_Down = &HC2
        GamePad_D_Down = &HC3
        GamePad_L_Up = &HC4 'No Argument
        GamePad_R_Up = &HC5
        GamePad_U_Up = &HC6
        GamePad_D_Up = &HC7
        GamePad_RB_DOWN = &HD0
        GamePad_RB_Up = &HD1

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
