````vb.net

Public Enum Com_CMD As Integer
        Abort = &HFF  'No Argument
        ConfirmCMD = &HF0 'Arg1:int,instruction No. Arg2. Empty
        Set_DMotor = &HA0 ' Arg1:int,spdL;Arg2:int,spdR
        HandShake = &HF1 'No Arg.
        HandConfirm = &HF2 'No Arg.
        GamePad_X_Down = &HB0 'No Argument
        GamePad_Y_Down = &HB1
        GamePad_A_Down = &HB2
        GamePad_B_Down = &HB3
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

````
