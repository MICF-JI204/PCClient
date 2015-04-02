Imports Microsoft.Xna.Framework
Partial Public Class Form_ORRM
    Public Thread_GamePad As New System.Threading.Thread(AddressOf GamePadIO)
    Public Sub GamePadIO()
        ChangeLabel(Label_XBox_Connection, "Waiting For GamePad", Drawing.Color.Orange)
        Do While Input.GamePad.GetState(PlayerIndex.One).IsConnected = False
        Loop
    End Sub
End Class
