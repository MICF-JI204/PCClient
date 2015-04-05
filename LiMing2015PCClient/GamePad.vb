Imports Microsoft.Xna.Framework
Partial Public Class Form_ORRM
    Public Thread_GamePad As New System.Threading.Thread(AddressOf GamePadIO)
    Public Sub GamePadIO()
        Dim GamePadState As Input.GamePadState
        ChangeLabel(Label_XBox_Connection, "Waiting For GamePad...", Drawing.Color.Blue)
        Do While Input.GamePad.GetState(PlayerIndex.One).IsConnected = False
        Loop
        GamePadState = Input.GamePad.GetState(PlayerIndex.One)
        ChangeLabel(Label_XBox_Connection, "Connected", Drawing.Color.Green)
        While True
            If GamePadState.IsConnected Then
                ChangeLabel(LX, GamePadState.ThumbSticks.Left.X, Drawing.Color.Black)
                ChangeLabel(LY, GamePadState.ThumbSticks.Left.Y, Drawing.Color.Black)
                ChangeLabel(RX, GamePadState.ThumbSticks.Right.X, Drawing.Color.Black)
                ChangeLabel(RY, GamePadState.ThumbSticks.Right.Y, Drawing.Color.Black)
                If GamePadState.IsButtonDown(Input.Buttons.A) Then ChangeLabel(Label_XBox_Connection, "A Down", Drawing.Color.Blue)
                If GamePadState.IsButtonDown(Input.Buttons.B) Then ChangeLabel(Label_XBox_Connection, "B Down", Drawing.Color.Blue)
                If GamePadState.IsButtonDown(Input.Buttons.X) Then ChangeLabel(Label_XBox_Connection, "X Down", Drawing.Color.Blue)
                If GamePadState.IsButtonDown(Input.Buttons.Y) Then ChangeLabel(Label_XBox_Connection, "Y Down", Drawing.Color.Blue)
                If GamePadState.IsButtonDown(Input.Buttons.DPadLeft) Then ChangeLabel(Label_XBox_Connection, "Dir Left Down", Drawing.Color.Blue)
                If GamePadState.IsButtonDown(Input.Buttons.DPadRight) Then ChangeLabel(Label_XBox_Connection, "Dir Right Down", Drawing.Color.Blue)
                If GamePadState.IsButtonDown(Input.Buttons.DPadUp) Then ChangeLabel(Label_XBox_Connection, "Dir Up Down", Drawing.Color.Blue)
                If GamePadState.IsButtonDown(Input.Buttons.DPadDown) Then ChangeLabel(Label_XBox_Connection, "Dir Down Down", Drawing.Color.Blue)
            Else
                ChangeLabel(Label_XBox_Connection, "Disconnected!Waiting...", Drawing.Color.Red)
                Do While Input.GamePad.GetState(PlayerIndex.One).IsConnected = False
                Loop
                ChangeLabel(Label_XBox_Connection, "Re-Connected", Drawing.Color.Green)
            End If
            GamePadState = Input.GamePad.GetState(PlayerIndex.One)
            System.Threading.Thread.Sleep(10)
        End While
    End Sub
End Class
