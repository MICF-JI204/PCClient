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

    Public Shared SpeedCoeffientL As Single = 0
    Public Shared SpeedcoeffientR As Single = 0

    Public Shared spd As Single = 0
    Public Shared ratio As Single = 0

    Public Shared TimeLastFame_Trej As Integer = 0

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
