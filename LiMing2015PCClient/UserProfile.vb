
Public Class OpITL_Generic
    Inherits OpTranslationDesTbl

    Public Overrides Property CraneHMaxSpd As Integer = 127

    Public Overrides Property CraneRotateMaxSpd As Integer = 73

    Public Overrides Property CraneVMaxSpd As Integer = 255

    Public Overrides Property DMotorMidPoint As Integer = 128

    Public Overrides Property DMotorRespondingOffset As Integer = 0

    Public Overrides Property GamePad_Trigger_Critical As Single = 0.8

    Public Overrides Property GamePad_CraneHCritical As Single = 0.15

    Public Overrides Property GamePad_CraneRotation_Critical As Single = 0.15
End Class